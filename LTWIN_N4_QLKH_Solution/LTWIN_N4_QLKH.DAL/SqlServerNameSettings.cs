using System;
using System.IO;
using System.Text;

namespace LTWIN_N4_QLKH.DAL
{
    /// <summary>
    /// Lưu đè tên SQL Server riêng cho Windows user, không sửa App.config trong thư mục cài đặt.
    /// Chỉ lưu tên instance; không lưu thông tin xác thực.
    /// </summary>
    internal static class SqlServerNameSettings
    {
        private static string SettingsFilePath
        {
            get
            {
                string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(localAppData, "LTWIN_N4_QLKH", "sql-server.txt");
            }
        }

        internal static string LoadOverride()
        {
            string path = SettingsFilePath;
            if (!File.Exists(path))
            {
                return null;
            }

            string value = File.ReadAllText(path, Encoding.UTF8).Trim();
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        internal static void SaveOverride(string serverName)
        {
            if (string.IsNullOrWhiteSpace(serverName))
            {
                throw new ArgumentException("Tên SQL Server không được để trống.", nameof(serverName));
            }

            string path = SettingsFilePath;
            string directory = Path.GetDirectoryName(path);
            Directory.CreateDirectory(directory);

            string temporaryPath = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                File.WriteAllText(temporaryPath, serverName.Trim(), new UTF8Encoding(false));
                if (File.Exists(path))
                {
                    File.Replace(temporaryPath, path, null);
                }
                else
                {
                    File.Move(temporaryPath, path);
                }
            }
            finally
            {
                if (File.Exists(temporaryPath))
                {
                    File.Delete(temporaryPath);
                }
            }
        }
    }
}
