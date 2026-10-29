using System;
using System.Data.SqlClient;

namespace LTWIN_N4_QLKH.DAL
{
    /// <summary>
    /// Kiểm tra SQL Server rồi lưu tên instance cho Windows user hiện tại.
    /// </summary>
    public class CauHinhCSDL_DAL
    {
        public string LayServerNameHienTai()
        {
            string saved = SqlServerNameSettings.LoadOverride();
            if (!string.IsNullOrWhiteSpace(saved))
            {
                return saved;
            }

            return new SqlConnectionStringBuilder(
                System.Configuration.ConfigurationManager.ConnectionStrings["LTWIN_N4_QLKHConnection"].ConnectionString)
                .DataSource;
        }

        public string KiemTraVaLuu(string serverName)
        {
            if (string.IsNullOrWhiteSpace(serverName))
            {
                throw new ArgumentException("Vui lòng nhập tên SQL Server.", nameof(serverName));
            }

            if (serverName.Length > 128)
            {
                throw new ArgumentException("Tên SQL Server không được dài quá 128 ký tự.", nameof(serverName));
            }

            // Xác thực cú pháp connection string trước khi thử kết nối.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = serverName.Trim()
            };

            string databaseName = DatabaseHelper.TestConnection(builder.DataSource);
            SqlServerNameSettings.SaveOverride(builder.DataSource);
            return databaseName;
        }
    }
}
