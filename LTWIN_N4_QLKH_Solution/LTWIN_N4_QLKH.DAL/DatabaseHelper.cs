using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LTWIN_N4_QLKH.DAL
{
    /// <summary>
    /// Điểm dùng chung cho các thao tác truy vấn SQL Server.
    /// Mọi giá trị đầu vào phải được truyền qua SqlParameter.
    /// </summary>
    public static class DatabaseHelper
    {
        private const string ConnectionStringName = "LTWIN_N4_QLKHConnection";

        public static DataTable ExecuteQuery(string sql, SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentException("Câu truy vấn không được để trống.", nameof(sql));
            }

            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                AddParameters(command, parameters);
                DataTable result = new DataTable();
                adapter.Fill(result);
                return result;
            }
        }

        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentException("Câu lệnh SQL không được để trống.", nameof(sql));
            }

            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                AddParameters(command, parameters);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentException("Câu truy vấn không được để trống.", nameof(sql));
            }

            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                AddParameters(command, parameters);
                connection.Open();
                return command.ExecuteScalar();
            }
        }

        internal static SqlConnection CreateConnection(bool useMaster = false, string serverNameOverride = null)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
            {
                throw new ConfigurationErrorsException(
                    "Không tìm thấy connection string '" + ConnectionStringName + "' trong App.config.");
            }

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(settings.ConnectionString);
            string selectedServer = string.IsNullOrWhiteSpace(serverNameOverride)
                ? SqlServerNameSettings.LoadOverride()
                : serverNameOverride.Trim();
            if (!string.IsNullOrWhiteSpace(selectedServer))
            {
                builder.DataSource = selectedServer;
            }

            if (useMaster)
            {
                builder.InitialCatalog = "master";
            }

            return new SqlConnection(builder.ConnectionString);
        }

        internal static string GetConfiguredDatabaseName()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
            {
                throw new ConfigurationErrorsException(
                    "Không tìm thấy connection string '" + ConnectionStringName + "' trong App.config.");
            }

            return new SqlConnectionStringBuilder(settings.ConnectionString).InitialCatalog;
        }

        internal static string TestConnection(string serverNameOverride)
        {
            using (SqlConnection connection = CreateConnection(false, serverNameOverride))
            using (SqlCommand command = new SqlCommand("SELECT DB_NAME();", connection))
            {
                connection.Open();
                return Convert.ToString(command.ExecuteScalar());
            }
        }

        private static void AddParameters(SqlCommand command, SqlParameter[] parameters)
        {
            if (parameters == null)
            {
                return;
            }

            foreach (SqlParameter parameter in parameters)
            {
                if (parameter == null)
                {
                    throw new ArgumentException("Danh sách tham số chứa giá trị null.", nameof(parameters));
                }

                command.Parameters.Add(parameter);
            }
        }
    }
}
