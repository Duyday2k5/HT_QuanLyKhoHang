using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.DAL
{
    /// <summary>
    /// Tầng truy cập dữ liệu (DAL) cho danh mục Hàng Hóa.
    /// Toàn bộ thao tác truy vấn đều sử dụng tham số (@SqlParameter) để phòng chống SQL Injection.
    /// </summary>
    public static class HangHoaDAL
    {
        public static List<HangHoaDTO> GetAll(string tuKhoa = "")
        {
            DataTable dt = GetAllDataTable(tuKhoa);
            List<HangHoaDTO> list = new List<HangHoaDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapRowToDTO(row));
            }
            return list;
        }

        public static DataTable GetAllDataTable(string tuKhoa = "")
        {
            return TimKiemNangCao(tuKhoa, null, null, null);
        }

        public static DataTable TimKiemNangCao(string tuKhoa = "", string loaiHang = "", string trangThaiTon = "", string sapXep = "")
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> whereClauses = new List<string>();

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                whereClauses.Add("(MaSP LIKE @Pattern OR TenSP LIKE @Pattern OR LoaiHang LIKE @Pattern)");
                parameters.Add(new SqlParameter("@Pattern", SqlDbType.NVarChar, 105) { Value = "%" + tuKhoa.Trim() + "%" });
            }

            if (!string.IsNullOrWhiteSpace(loaiHang) && !loaiHang.Equals("Tất cả", StringComparison.OrdinalIgnoreCase) && !loaiHang.Equals("Tất cả nhóm loại", StringComparison.OrdinalIgnoreCase))
            {
                whereClauses.Add("LoaiHang = @LoaiHang");
                parameters.Add(new SqlParameter("@LoaiHang", SqlDbType.NVarChar, 50) { Value = loaiHang.Trim() });
            }

            if (!string.IsNullOrWhiteSpace(trangThaiTon))
            {
                string tt = trangThaiTon.Trim();
                if (tt.Contains("Cảnh báo") || tt.Contains("Thiếu") || tt.Equals("ThieuHang", StringComparison.OrdinalIgnoreCase))
                {
                    whereClauses.Add("SoLuongTon <= TonToiThieu");
                }
                else if (tt.Contains("Hết hàng") || tt.Equals("HetHang", StringComparison.OrdinalIgnoreCase))
                {
                    whereClauses.Add("SoLuongTon = 0");
                }
                else if (tt.Contains("Tồn an toàn") || tt.Contains("An toàn") || tt.Equals("AnToan", StringComparison.OrdinalIgnoreCase))
                {
                    whereClauses.Add("(SoLuongTon > TonToiThieu AND SoLuongTon <= TonToiDa)");
                }
                else if (tt.Contains("Vượt") || tt.Equals("VuotMax", StringComparison.OrdinalIgnoreCase))
                {
                    whereClauses.Add("SoLuongTon > TonToiDa");
                }
            }

            string whereSql = whereClauses.Count > 0 ? "WHERE " + string.Join(" AND ", whereClauses) : "";

            string orderSql = "ORDER BY MaSP ASC";
            if (!string.IsNullOrWhiteSpace(sapXep))
            {
                string sx = sapXep.Trim();
                if (sx.Contains("Mã SP (Z") || sx.Contains("Mã giảm")) orderSql = "ORDER BY MaSP DESC";
                else if (sx.Contains("Mã SP") || sx.Contains("Mã tăng")) orderSql = "ORDER BY MaSP ASC";
                else if (sx.Contains("Tên") && (sx.Contains("Z - A") || sx.Contains("Giảm"))) orderSql = "ORDER BY TenSP DESC";
                else if (sx.Contains("Tên") && (sx.Contains("A - Z") || sx.Contains("Tăng"))) orderSql = "ORDER BY TenSP ASC";
                else if (sx.Contains("Tồn") && sx.Contains("Giảm")) orderSql = "ORDER BY SoLuongTon DESC, TenSP ASC";
                else if (sx.Contains("Tồn") && sx.Contains("Tăng")) orderSql = "ORDER BY SoLuongTon ASC, TenSP ASC";
                else if (sx.Contains("Giá") && sx.Contains("Giảm")) orderSql = "ORDER BY GiaNhapGanNhat DESC, TenSP ASC";
                else if (sx.Contains("Giá") && sx.Contains("Tăng")) orderSql = "ORDER BY GiaNhapGanNhat ASC, TenSP ASC";
            }

            string sql = $@"
                SELECT MaSP, TenSP, LoaiHang, DonViTinh, 
                       GiaNhapGanNhat, SoLuongTon, TonToiThieu, TonToiDa,
                       (MaSP + N' - ' + TenSP) AS TenHienThi
                FROM dbo.HangHoa
                {whereSql}
                {orderSql};";

            return DatabaseHelper.ExecuteQuery(sql, parameters.Count > 0 ? parameters.ToArray() : null);
        }

        public static HangHoaDTO GetById(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP)) return null;

            const string sql = @"
                SELECT MaSP, TenSP, LoaiHang, DonViTinh, 
                       GiaNhapGanNhat, SoLuongTon, TonToiThieu, TonToiDa
                FROM dbo.HangHoa
                WHERE MaSP = @MaSP;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = maSP.Trim() }
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count == 0) return null;

            return MapRowToDTO(dt.Rows[0]);
        }

        public static bool Insert(HangHoaDTO hh)
        {
            if (hh == null) throw new ArgumentNullException(nameof(hh));

            const string sql = @"
                INSERT INTO dbo.HangHoa 
                    (MaSP, TenSP, LoaiHang, DonViTinh, SoLuongTon, TonToiThieu, TonToiDa, GiaNhapGanNhat)
                VALUES 
                    (@MaSP, @TenSP, @LoaiHang, @DonViTinh, @SoLuongTon, @TonToiThieu, @TonToiDa, @GiaNhapGanNhat);";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = hh.MaSP.Trim() },
                new SqlParameter("@TenSP", SqlDbType.NVarChar, 150) { Value = hh.TenSP.Trim() },
                new SqlParameter("@LoaiHang", SqlDbType.NVarChar, 50) { Value = hh.LoaiHang.Trim() },
                new SqlParameter("@DonViTinh", SqlDbType.NVarChar, 20) { Value = hh.DonViTinh.Trim() },
                new SqlParameter("@SoLuongTon", SqlDbType.Int) { Value = hh.SoLuongTon },
                new SqlParameter("@TonToiThieu", SqlDbType.Int) { Value = hh.TonToiThieu },
                new SqlParameter("@TonToiDa", SqlDbType.Int) { Value = hh.TonToiDa },
                new SqlParameter("@GiaNhapGanNhat", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = hh.GiaNhapGanNhat }
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public static bool Update(HangHoaDTO hh)
        {
            if (hh == null) throw new ArgumentNullException(nameof(hh));

            const string sql = @"
                UPDATE dbo.HangHoa
                SET TenSP = @TenSP,
                    LoaiHang = @LoaiHang,
                    DonViTinh = @DonViTinh,
                    TonToiThieu = @TonToiThieu,
                    TonToiDa = @TonToiDa,
                    GiaNhapGanNhat = @GiaNhapGanNhat
                WHERE MaSP = @MaSP;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = hh.MaSP.Trim() },
                new SqlParameter("@TenSP", SqlDbType.NVarChar, 150) { Value = hh.TenSP.Trim() },
                new SqlParameter("@LoaiHang", SqlDbType.NVarChar, 50) { Value = hh.LoaiHang.Trim() },
                new SqlParameter("@DonViTinh", SqlDbType.NVarChar, 20) { Value = hh.DonViTinh.Trim() },
                new SqlParameter("@TonToiThieu", SqlDbType.Int) { Value = hh.TonToiThieu },
                new SqlParameter("@TonToiDa", SqlDbType.Int) { Value = hh.TonToiDa },
                new SqlParameter("@GiaNhapGanNhat", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = hh.GiaNhapGanNhat }
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public static bool Delete(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP)) return false;

            const string sql = "DELETE FROM dbo.HangHoa WHERE MaSP = @MaSP;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = maSP.Trim() }
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public static bool UpdateSoLuongTon(string maSP, int soLuongThayDoi, bool tang = true)
        {
            if (string.IsNullOrWhiteSpace(maSP)) return false;

            string op = tang ? "+" : "-";
            string sql = $@"
                UPDATE dbo.HangHoa
                SET SoLuongTon = SoLuongTon {op} @SoLuongThayDoi
                WHERE MaSP = @MaSP" + (tang ? ";" : " AND SoLuongTon >= @SoLuongThayDoi;");

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoLuongThayDoi", SqlDbType.Int) { Value = Math.Abs(soLuongThayDoi) },
                new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = maSP.Trim() }
            };

            return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
        }

        public static bool Exists(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP)) return false;

            const string sql = "SELECT COUNT(1) FROM dbo.HangHoa WHERE MaSP = @MaSP;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = maSP.Trim() }
            };

            object result = DatabaseHelper.ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public static bool HasTransactions(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP)) return false;

            const string sql = @"
                SELECT 
                    (SELECT COUNT(1) FROM dbo.ChiTietPhieuNhap WHERE MaSP = @MaSP) +
                    (SELECT COUNT(1) FROM dbo.ChiTietPhieuXuat WHERE MaSP = @MaSP) AS TotalCount;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = maSP.Trim() }
            };

            object result = DatabaseHelper.ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public static List<string> GetDistinctLoaiHang()
        {
            const string sql = @"
                SELECT DISTINCT LoaiHang
                FROM dbo.HangHoa
                WHERE LoaiHang IS NOT NULL AND LoaiHang <> ''
                ORDER BY LoaiHang ASC;";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, null);
            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(Convert.ToString(row["LoaiHang"]));
            }
            return list;
        }

        public static List<string> GetDistinctDonViTinh()
        {
            const string sql = @"
                SELECT DISTINCT DonViTinh
                FROM dbo.HangHoa
                WHERE DonViTinh IS NOT NULL AND DonViTinh <> ''
                ORDER BY DonViTinh ASC;";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, null);
            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(Convert.ToString(row["DonViTinh"]));
            }
            return list;
        }

        private static HangHoaDTO MapRowToDTO(DataRow row)
        {
            return new HangHoaDTO
            {
                MaSP = Convert.ToString(row["MaSP"]),
                TenSP = Convert.ToString(row["TenSP"]),
                LoaiHang = Convert.ToString(row["LoaiHang"]),
                DonViTinh = Convert.ToString(row["DonViTinh"]),
                SoLuongTon = Convert.ToInt32(row["SoLuongTon"]),
                TonToiThieu = Convert.ToInt32(row["TonToiThieu"]),
                TonToiDa = Convert.ToInt32(row["TonToiDa"]),
                GiaNhapGanNhat = Convert.ToDecimal(row["GiaNhapGanNhat"])
            };
        }
    }
}
