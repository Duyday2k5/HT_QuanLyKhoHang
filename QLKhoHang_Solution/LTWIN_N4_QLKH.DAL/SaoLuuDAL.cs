using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;

namespace LTWIN_N4_QLKH.DAL
{
    /// <summary>
    /// Backup database đã cấu hình và chỉ restore thành database test mới.
    /// </summary>
    public class SaoLuuDAL
    {
        public string LayDatabaseDangCauHinh()
        {
            return DatabaseHelper.GetConfiguredDatabaseName();
        }

        public void SaoLuuDatabase(string backupPath)
        {
            if (string.IsNullOrWhiteSpace(backupPath))
            {
                throw new ArgumentException("Chưa chọn đường dẫn file backup.", nameof(backupPath));
            }

            string fullPath = Path.GetFullPath(backupPath);
            if (File.Exists(fullPath))
            {
                throw new IOException("File đã tồn tại. Chọn tên file backup mới để không ghi đè.");
            }

            string databaseName = DatabaseHelper.GetConfiguredDatabaseName();
            if (string.IsNullOrWhiteSpace(databaseName) || string.Equals(databaseName, "master", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("App.config chưa trỏ tới database dự án hợp lệ.");
            }

            const string sql = @"
BACKUP DATABASE @DatabaseName
TO DISK = @BackupPath
WITH COPY_ONLY, CHECKSUM, STATS = 5;";

            using (SqlConnection connection = DatabaseHelper.CreateConnection(true))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add("@DatabaseName", SqlDbType.NVarChar, 128).Value = databaseName;
                command.Parameters.Add("@BackupPath", SqlDbType.NVarChar, 4000).Value = fullPath;
                connection.Open();
                command.ExecuteNonQuery();
            }

            VerifyBackup(fullPath);
        }

        public string RestoreToNewTestDatabase(string backupPath)
        {
            if (string.IsNullOrWhiteSpace(backupPath))
            {
                throw new ArgumentException("Chưa chọn file backup.", nameof(backupPath));
            }

            string fullPath = Path.GetFullPath(backupPath);
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("Không tìm thấy file backup trên máy này.", fullPath);
            }

            VerifyBackup(fullPath);
            List<BackupFile> files = ReadBackupFileList(fullPath);
            if (files.Count == 0)
            {
                throw new InvalidDataException("Backup không chứa file dữ liệu hoặc file log có thể khôi phục.");
            }

            string testDatabaseName = "LTWIN_N4_QLKH_TestRestore_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fff", CultureInfo.InvariantCulture);
            string dataDirectory;
            string logDirectory;
            GetDefaultDirectories(out dataDirectory, out logDirectory);

            StringBuilder sql = new StringBuilder();
            sql.Append("RESTORE DATABASE ").Append(QuoteIdentifier(testDatabaseName));
            sql.Append(" FROM DISK = @BackupPath WITH ");

            int dataIndex = 0;
            int logIndex = 0;
            for (int i = 0; i < files.Count; i++)
            {
                BackupFile file = files[i];
                string destination;
                if (file.Type == "L")
                {
                    logIndex++;
                    destination = Path.Combine(logDirectory, testDatabaseName + "_Log" + logIndex + ".ldf");
                }
                else
                {
                    dataIndex++;
                    string extension = dataIndex == 1 ? ".mdf" : ".ndf";
                    destination = Path.Combine(dataDirectory, testDatabaseName + "_Data" + dataIndex + extension);
                }

                if (i > 0)
                {
                    sql.Append(", ");
                }

                // SQL Server RESTORE MOVE requires file-name literals; escape every metadata/path literal.
                sql.Append("MOVE ").Append(QuoteString(file.LogicalName))
                   .Append(" TO ").Append(QuoteString(destination));
            }

            sql.Append(", RECOVERY, CHECKSUM;");

            using (SqlConnection connection = DatabaseHelper.CreateConnection(true))
            using (SqlCommand command = new SqlCommand(sql.ToString(), connection))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add("@BackupPath", SqlDbType.NVarChar, 4000).Value = fullPath;
                connection.Open();

                using (SqlCommand existsCommand = new SqlCommand("SELECT CASE WHEN DB_ID(@DatabaseName) IS NULL THEN 0 ELSE 1 END;", connection))
                {
                    existsCommand.Parameters.Add("@DatabaseName", SqlDbType.NVarChar, 128).Value = testDatabaseName;
                    if (Convert.ToInt32(existsCommand.ExecuteScalar(), CultureInfo.InvariantCulture) != 0)
                    {
                        throw new InvalidOperationException("Database test đích đã tồn tại; không thực hiện restore.");
                    }
                }

                command.ExecuteNonQuery();
            }

            return testDatabaseName;
        }

        private static void VerifyBackup(string backupPath)
        {
            const string sql = "RESTORE VERIFYONLY FROM DISK = @BackupPath WITH CHECKSUM;";
            using (SqlConnection connection = DatabaseHelper.CreateConnection(true))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add("@BackupPath", SqlDbType.NVarChar, 4000).Value = backupPath;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static List<BackupFile> ReadBackupFileList(string backupPath)
        {
            const string sql = "RESTORE FILELISTONLY FROM DISK = @BackupPath;";
            List<BackupFile> files = new List<BackupFile>();

            using (SqlConnection connection = DatabaseHelper.CreateConnection(true))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add("@BackupPath", SqlDbType.NVarChar, 4000).Value = backupPath;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int logicalNameIndex = reader.GetOrdinal("LogicalName");
                    int typeIndex = reader.GetOrdinal("Type");
                    while (reader.Read())
                    {
                        string type = Convert.ToString(reader.GetValue(typeIndex), CultureInfo.InvariantCulture);
                        if (type == "D" || type == "L")
                        {
                            files.Add(new BackupFile
                            {
                                LogicalName = Convert.ToString(reader.GetValue(logicalNameIndex), CultureInfo.InvariantCulture),
                                Type = type
                            });
                        }
                        else
                        {
                            throw new NotSupportedException(
                                "Backup chứa loại file không hỗ trợ khôi phục an toàn: " + type + ".");
                        }
                    }
                }
            }

            return files;
        }

        private static void GetDefaultDirectories(out string dataDirectory, out string logDirectory)
        {
            const string sql = @"
SELECT CONVERT(NVARCHAR(4000), SERVERPROPERTY('InstanceDefaultDataPath')) AS DataPath,
       CONVERT(NVARCHAR(4000), SERVERPROPERTY('InstanceDefaultLogPath')) AS LogPath;";

            using (SqlConnection connection = DatabaseHelper.CreateConnection(true))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dataDirectory = reader.IsDBNull(0) ? null : reader.GetString(0);
                        logDirectory = reader.IsDBNull(1) ? null : reader.GetString(1);
                    }
                    else
                    {
                        dataDirectory = null;
                        logDirectory = null;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(dataDirectory))
            {
                dataDirectory = GetMasterFileDirectory(0);
            }

            if (string.IsNullOrWhiteSpace(logDirectory))
            {
                logDirectory = GetMasterFileDirectory(1);
            }

            if (string.IsNullOrWhiteSpace(dataDirectory) || string.IsNullOrWhiteSpace(logDirectory))
            {
                throw new InvalidOperationException("Không xác định được thư mục dữ liệu mặc định trên SQL Server.");
            }
        }

        private static string GetMasterFileDirectory(int fileType)
        {
            const string sql = "SELECT TOP (1) physical_name FROM sys.master_files WHERE database_id = DB_ID(N'master') AND type = @FileType;";
            using (SqlConnection connection = DatabaseHelper.CreateConnection(true))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@FileType", SqlDbType.Int).Value = fileType;
                connection.Open();
                string physicalPath = Convert.ToString(command.ExecuteScalar(), CultureInfo.InvariantCulture);
                return string.IsNullOrWhiteSpace(physicalPath) ? null : Path.GetDirectoryName(physicalPath);
            }
        }

        private static string QuoteIdentifier(string value)
        {
            return "[" + value.Replace("]", "]]" ) + "]";
        }

        private static string QuoteString(string value)
        {
            return "N'" + value.Replace("'", "''") + "'";
        }

        private sealed class BackupFile
        {
            internal string LogicalName { get; set; }
            internal string Type { get; set; }
        }
    }
}
