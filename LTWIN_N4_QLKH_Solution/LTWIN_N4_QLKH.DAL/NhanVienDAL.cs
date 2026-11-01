using System;
using System.Data;
using System.Data.SqlClient;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.DAL
{
    /// <summary>
    /// Đọc, ghi và quản lý tài khoản nhân viên trong cơ sở dữ liệu.
    /// Mật khẩu luôn được băm bằng PBKDF2-SHA256 trước khi lưu.
    /// </summary>
    public class NhanVienDAL
    {
        public NhanVienDTO DangNhap(string taiKhoan, string matKhau)
        {
            const string sql = @"
SELECT MaNV, HoTen, TaiKhoan, MatKhau, VaiTro, DienThoai
FROM dbo.NhanVien
WHERE TaiKhoan = @TaiKhoan;";

            DataTable rows = DatabaseHelper.ExecuteQuery(
                sql,
                new[] { new SqlParameter("@TaiKhoan", SqlDbType.VarChar, 50) { Value = taiKhoan } });

            if (rows.Rows.Count != 1)
            {
                return null;
            }

            DataRow row = rows.Rows[0];
            string storedHash = Convert.ToString(row["MatKhau"]);
            if (!PasswordHasher.Verify(matKhau, storedHash))
            {
                return null;
            }

            return new NhanVienDTO
            {
                MaNV = Convert.ToString(row["MaNV"]),
                HoTen = Convert.ToString(row["HoTen"]),
                TaiKhoan = Convert.ToString(row["TaiKhoan"]),
                VaiTro = Convert.ToString(row["VaiTro"]),
                DienThoai = row.IsNull("DienThoai") ? null : Convert.ToString(row["DienThoai"])
            };
        }

        public bool DoiMatKhau(string maNV, string matKhauCu, string matKhauMoi)
        {
            const string selectSql = @"
SELECT MatKhau
FROM dbo.NhanVien
WHERE MaNV = @MaNV;";

            DataTable rows = DatabaseHelper.ExecuteQuery(
                selectSql,
                new[] { new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = maNV } });

            if (rows.Rows.Count != 1)
            {
                return false;
            }

            string storedHash = Convert.ToString(rows.Rows[0]["MatKhau"]);
            if (!PasswordHasher.Verify(matKhauCu, storedHash))
            {
                return false;
            }

            const string updateSql = @"
UPDATE dbo.NhanVien
SET MatKhau = @MatKhauMoi
WHERE MaNV = @MaNV AND MatKhau = @MatKhauCu;";

            int affected = DatabaseHelper.ExecuteNonQuery(
                updateSql,
                new[]
                {
                    new SqlParameter("@MatKhauMoi", SqlDbType.VarChar, 255)
                    {
                        Value = PasswordHasher.Hash(matKhauMoi)
                    },
                    new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = maNV },
                    new SqlParameter("@MatKhauCu", SqlDbType.VarChar, 255) { Value = storedHash }
                });

            return affected == 1;
        }

        public DataTable LayTatCaNhanVien()
        {
            const string sql = @"
SELECT nv.MaNV, nv.HoTen, nv.TaiKhoan, nv.VaiTro, nv.DienThoai,
       (SELECT COUNT(*) FROM dbo.PhieuNhap pn WHERE pn.MaNV = nv.MaNV) AS SoPhieuNhap,
       (SELECT COUNT(*) FROM dbo.PhieuXuat px WHERE px.MaNV = nv.MaNV) AS SoPhieuXuat
FROM dbo.NhanVien nv
ORDER BY nv.MaNV ASC;";

            return DatabaseHelper.ExecuteQuery(sql, null);
        }

        public DataTable TimKiemNhanVien(string tuKhoa, string vaiTro)
        {
            const string sql = @"
SELECT nv.MaNV, nv.HoTen, nv.TaiKhoan, nv.VaiTro, nv.DienThoai,
       (SELECT COUNT(*) FROM dbo.PhieuNhap pn WHERE pn.MaNV = nv.MaNV) AS SoPhieuNhap,
       (SELECT COUNT(*) FROM dbo.PhieuXuat px WHERE px.MaNV = nv.MaNV) AS SoPhieuXuat
FROM dbo.NhanVien nv
WHERE (nv.MaNV LIKE @kw OR nv.HoTen LIKE @kw OR nv.TaiKhoan LIKE @kw OR ISNULL(nv.DienThoai, '') LIKE @kw)
  AND (@vaiTro = N'' OR @vaiTro = N'Tất cả' OR nv.VaiTro = @vaiTro)
ORDER BY nv.MaNV ASC;";

            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@kw", SqlDbType.NVarChar, 100) { Value = "%" + (tuKhoa ?? "").Trim() + "%" },
                new SqlParameter("@vaiTro", SqlDbType.NVarChar, 30) { Value = vaiTro ?? "" }
            };

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public bool KiemTraTrungMaNV(string maNV)
        {
            const string sql = "SELECT COUNT(1) FROM dbo.NhanVien WHERE MaNV = @MaNV;";
            object res = DatabaseHelper.ExecuteScalar(sql, new[]
            {
                new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = maNV }
            });
            return Convert.ToInt32(res) > 0;
        }

        public bool KiemTraTrungTaiKhoan(string taiKhoan, string maNVBoQua = null)
        {
            string sql = "SELECT COUNT(1) FROM dbo.NhanVien WHERE TaiKhoan = @TaiKhoan";
            SqlParameter[] pars;
            if (!string.IsNullOrEmpty(maNVBoQua))
            {
                sql += " AND MaNV <> @MaNVBoQua;";
                pars = new[]
                {
                    new SqlParameter("@TaiKhoan", SqlDbType.VarChar, 50) { Value = taiKhoan },
                    new SqlParameter("@MaNVBoQua", SqlDbType.VarChar, 10) { Value = maNVBoQua }
                };
            }
            else
            {
                sql += ";";
                pars = new[]
                {
                    new SqlParameter("@TaiKhoan", SqlDbType.VarChar, 50) { Value = taiKhoan }
                };
            }

            object res = DatabaseHelper.ExecuteScalar(sql, pars);
            return Convert.ToInt32(res) > 0;
        }

        public bool ThemNhanVien(string maNV, string hoTen, string taiKhoan, string matKhauPlain, string vaiTro, string dienThoai)
        {
            const string sql = @"
INSERT INTO dbo.NhanVien (MaNV, HoTen, TaiKhoan, MatKhau, VaiTro, DienThoai)
VALUES (@MaNV, @HoTen, @TaiKhoan, @MatKhau, @VaiTro, @DienThoai);";

            string hashed = PasswordHasher.Hash(matKhauPlain);

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = maNV },
                new SqlParameter("@HoTen", SqlDbType.NVarChar, 100) { Value = hoTen },
                new SqlParameter("@TaiKhoan", SqlDbType.VarChar, 50) { Value = taiKhoan },
                new SqlParameter("@MatKhau", SqlDbType.VarChar, 255) { Value = hashed },
                new SqlParameter("@VaiTro", SqlDbType.NVarChar, 30) { Value = vaiTro },
                new SqlParameter("@DienThoai", SqlDbType.VarChar, 15) { Value = string.IsNullOrWhiteSpace(dienThoai) ? (object)DBNull.Value : dienThoai.Trim() }
            };

            return DatabaseHelper.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool CapNhatNhanVien(string maNV, string hoTen, string vaiTro, string dienThoai)
        {
            const string sql = @"
UPDATE dbo.NhanVien
SET HoTen = @HoTen,
    VaiTro = @VaiTro,
    DienThoai = @DienThoai
WHERE MaNV = @MaNV;";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = maNV },
                new SqlParameter("@HoTen", SqlDbType.NVarChar, 100) { Value = hoTen },
                new SqlParameter("@VaiTro", SqlDbType.NVarChar, 30) { Value = vaiTro },
                new SqlParameter("@DienThoai", SqlDbType.VarChar, 15) { Value = string.IsNullOrWhiteSpace(dienThoai) ? (object)DBNull.Value : dienThoai.Trim() }
            };

            return DatabaseHelper.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool DatLaiMatKhau(string maNV, string matKhauMoiPlain)
        {
            const string sql = @"
UPDATE dbo.NhanVien
SET MatKhau = @MatKhauMoi
WHERE MaNV = @MaNV;";

            string hashed = PasswordHasher.Hash(matKhauMoiPlain);

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = maNV },
                new SqlParameter("@MatKhauMoi", SqlDbType.VarChar, 255) { Value = hashed }
            };

            return DatabaseHelper.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool XoaNhanVien(string maNV)
        {
            const string sql = "DELETE FROM dbo.NhanVien WHERE MaNV = @MaNV;";
            SqlParameter[] pars = new[]
            {
                new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = maNV }
            };
            return DatabaseHelper.ExecuteNonQuery(sql, pars) > 0;
        }

        public void KiemTraRangBuocGiaoDich(string maNV, out int soPhieuNhap, out int soPhieuXuat)
        {
            const string sqlPN = "SELECT COUNT(1) FROM dbo.PhieuNhap WHERE MaNV = @MaNV;";
            object resPN = DatabaseHelper.ExecuteScalar(sqlPN, new[] { new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = maNV } });
            soPhieuNhap = Convert.ToInt32(resPN);

            const string sqlPX = "SELECT COUNT(1) FROM dbo.PhieuXuat WHERE MaNV = @MaNV;";
            object resPX = DatabaseHelper.ExecuteScalar(sqlPX, new[] { new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = maNV } });
            soPhieuXuat = Convert.ToInt32(resPX);
        }

        public string PhatSinhMaNVMoi()
        {
            const string sql = "SELECT TOP 1 MaNV FROM dbo.NhanVien WHERE MaNV LIKE 'NV%' ORDER BY MaNV DESC;";
            object res = DatabaseHelper.ExecuteScalar(sql, null);
            if (res == null || res == DBNull.Value)
            {
                return "NV0001";
            }

            string currentMax = res.ToString();
            if (currentMax.Length > 2 && int.TryParse(currentMax.Substring(2), out int num))
            {
                return string.Format("NV{0:D4}", num + 1);
            }

            return "NV0001";
        }
    }
}
