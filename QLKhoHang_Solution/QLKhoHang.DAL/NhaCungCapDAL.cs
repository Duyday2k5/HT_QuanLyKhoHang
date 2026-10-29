using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLKhoHang.DTO;

namespace QLKhoHang.DAL
{
    /// <summary>
    /// Tầng truy cập dữ liệu (DAL) cho danh mục Nhà Cung Cấp.
    /// Toàn bộ thao tác truy vấn đều sử dụng tham số (@SqlParameter) để phòng chống SQL Injection.
    /// </summary>
    public static class NhaCungCapDAL
    {
        public static List<NhaCungCapDTO> GetAll(string tuKhoa = "")
        {
            DataTable dt = GetAllDataTable(tuKhoa);
            List<NhaCungCapDTO> list = new List<NhaCungCapDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapRowToDTO(row));
            }
            return list;
        }

        public static DataTable GetAllDataTable(string tuKhoa = "")
        {
            const string sql = @"
                SELECT MaNCC, TenNCC, DienThoai, NguoiLienHe, DiaChi, Email,
                       (MaNCC + N' - ' + TenNCC) AS TenHienThi
                FROM dbo.NhaCungCap
                WHERE (@TuKhoa = '' 
                       OR MaNCC LIKE @Pattern 
                       OR TenNCC LIKE @Pattern 
                       OR DienThoai LIKE @Pattern 
                       OR NguoiLienHe LIKE @Pattern)
                ORDER BY MaNCC ASC;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TuKhoa", SqlDbType.NVarChar, 100) { Value = tuKhoa ?? string.Empty },
                new SqlParameter("@Pattern", SqlDbType.NVarChar, 105) { Value = "%" + (tuKhoa ?? string.Empty).Trim() + "%" }
            };

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public static NhaCungCapDTO GetById(string maNCC)
        {
            if (string.IsNullOrWhiteSpace(maNCC)) return null;

            const string sql = @"
                SELECT MaNCC, TenNCC, DienThoai, NguoiLienHe, DiaChi, Email
                FROM dbo.NhaCungCap
                WHERE MaNCC = @MaNCC;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNCC", SqlDbType.VarChar, 15) { Value = maNCC.Trim() }
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count == 0) return null;

            return MapRowToDTO(dt.Rows[0]);
        }

        public static bool Insert(NhaCungCapDTO ncc)
        {
            if (ncc == null) throw new ArgumentNullException(nameof(ncc));

            const string sql = @"
                INSERT INTO dbo.NhaCungCap 
                    (MaNCC, TenNCC, DienThoai, Email, DiaChi, NguoiLienHe)
                VALUES 
                    (@MaNCC, @TenNCC, @DienThoai, @Email, @DiaChi, @NguoiLienHe);";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNCC", SqlDbType.VarChar, 15) { Value = ncc.MaNCC.Trim() },
                new SqlParameter("@TenNCC", SqlDbType.NVarChar, 150) { Value = ncc.TenNCC.Trim() },
                new SqlParameter("@DienThoai", SqlDbType.VarChar, 20) { Value = ncc.DienThoai.Trim() },
                new SqlParameter("@Email", SqlDbType.VarChar, 100)
                {
                    Value = string.IsNullOrWhiteSpace(ncc.Email) ? (object)DBNull.Value : ncc.Email.Trim()
                },
                new SqlParameter("@DiaChi", SqlDbType.NVarChar, 250)
                {
                    Value = string.IsNullOrWhiteSpace(ncc.DiaChi) ? (object)DBNull.Value : ncc.DiaChi.Trim()
                },
                new SqlParameter("@NguoiLienHe", SqlDbType.NVarChar, 100)
                {
                    Value = string.IsNullOrWhiteSpace(ncc.NguoiLienHe) ? (object)DBNull.Value : ncc.NguoiLienHe.Trim()
                }
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public static bool Update(NhaCungCapDTO ncc)
        {
            if (ncc == null) throw new ArgumentNullException(nameof(ncc));

            const string sql = @"
                UPDATE dbo.NhaCungCap
                SET TenNCC = @TenNCC,
                    DienThoai = @DienThoai,
                    Email = @Email,
                    DiaChi = @DiaChi,
                    NguoiLienHe = @NguoiLienHe
                WHERE MaNCC = @MaNCC;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNCC", SqlDbType.VarChar, 15) { Value = ncc.MaNCC.Trim() },
                new SqlParameter("@TenNCC", SqlDbType.NVarChar, 150) { Value = ncc.TenNCC.Trim() },
                new SqlParameter("@DienThoai", SqlDbType.VarChar, 20) { Value = ncc.DienThoai.Trim() },
                new SqlParameter("@Email", SqlDbType.VarChar, 100)
                {
                    Value = string.IsNullOrWhiteSpace(ncc.Email) ? (object)DBNull.Value : ncc.Email.Trim()
                },
                new SqlParameter("@DiaChi", SqlDbType.NVarChar, 250)
                {
                    Value = string.IsNullOrWhiteSpace(ncc.DiaChi) ? (object)DBNull.Value : ncc.DiaChi.Trim()
                },
                new SqlParameter("@NguoiLienHe", SqlDbType.NVarChar, 100)
                {
                    Value = string.IsNullOrWhiteSpace(ncc.NguoiLienHe) ? (object)DBNull.Value : ncc.NguoiLienHe.Trim()
                }
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public static bool Delete(string maNCC)
        {
            if (string.IsNullOrWhiteSpace(maNCC)) return false;

            const string sql = "DELETE FROM dbo.NhaCungCap WHERE MaNCC = @MaNCC;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNCC", SqlDbType.VarChar, 15) { Value = maNCC.Trim() }
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public static bool Exists(string maNCC)
        {
            if (string.IsNullOrWhiteSpace(maNCC)) return false;

            const string sql = "SELECT COUNT(1) FROM dbo.NhaCungCap WHERE MaNCC = @MaNCC;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNCC", SqlDbType.VarChar, 15) { Value = maNCC.Trim() }
            };

            object result = DatabaseHelper.ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public static bool HasTransactions(string maNCC)
        {
            if (string.IsNullOrWhiteSpace(maNCC)) return false;

            const string sql = "SELECT COUNT(1) FROM dbo.PhieuNhap WHERE MaNCC = @MaNCC;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNCC", SqlDbType.VarChar, 15) { Value = maNCC.Trim() }
            };

            object result = DatabaseHelper.ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public static List<NhaCungCapDTO> Search(string tuKhoa)
        {
            return GetAll(tuKhoa);
        }

        private static NhaCungCapDTO MapRowToDTO(DataRow row)
        {
            return new NhaCungCapDTO
            {
                MaNCC = Convert.ToString(row["MaNCC"]),
                TenNCC = Convert.ToString(row["TenNCC"]),
                DienThoai = Convert.ToString(row["DienThoai"]),
                Email = row["Email"] == DBNull.Value ? string.Empty : Convert.ToString(row["Email"]),
                DiaChi = row["DiaChi"] == DBNull.Value ? string.Empty : Convert.ToString(row["DiaChi"]),
                NguoiLienHe = row["NguoiLienHe"] == DBNull.Value ? string.Empty : Convert.ToString(row["NguoiLienHe"])
            };
        }
    }
}

