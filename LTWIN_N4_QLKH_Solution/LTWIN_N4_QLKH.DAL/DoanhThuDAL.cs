using System;
using System.Data;
using System.Data.SqlClient;

namespace LTWIN_N4_QLKH.DAL
{
    /// <summary>
    /// Tầng truy cập dữ liệu (DAL) cho thống kê và báo cáo Doanh Thu xuất kho.
    /// Toàn bộ câu truy vấn đều sử dụng tham số (@SqlParameter) để phòng tránh SQL Injection.
    /// </summary>
    public static class DoanhThuDAL
    {
        /// <summary>
        /// Lấy bảng danh sách phiếu xuất trong một khoảng thời gian.
        /// </summary>
        public static DataTable LayDanhSachPhieuXuat(DateTime tuNgay, DateTime denNgay, string tuKhoa = "")
        {
            const string sql = @"
                SELECT 
                    ROW_NUMBER() OVER(ORDER BY PX.NgayXuat DESC, PX.MaPX DESC) AS STT,
                    PX.MaPX,
                    PX.NgayXuat,
                    PX.NguoiNhan,
                    PX.LyDoXuat,
                    ISNULL(NV.HoTen, PX.MaNV) AS NhanVienXuat,
                    PX.TongTienXuat,
                    ISNULL(PX.GhiChu, N'') AS GhiChu
                FROM dbo.PhieuXuat PX
                LEFT JOIN dbo.NhanVien NV ON PX.MaNV = NV.MaNV
                WHERE PX.NgayXuat >= @TuNgay 
                  AND PX.NgayXuat <= @DenNgay
                  AND (@TuKhoa = '' 
                       OR PX.MaPX LIKE @Pattern 
                       OR PX.NguoiNhan LIKE @Pattern 
                       OR PX.LyDoXuat LIKE @Pattern 
                       OR NV.HoTen LIKE @Pattern)
                ORDER BY PX.NgayXuat DESC, PX.MaPX DESC;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TuNgay", SqlDbType.DateTime) { Value = tuNgay },
                new SqlParameter("@DenNgay", SqlDbType.DateTime) { Value = denNgay },
                new SqlParameter("@TuKhoa", SqlDbType.NVarChar, 100) { Value = tuKhoa ?? string.Empty },
                new SqlParameter("@Pattern", SqlDbType.NVarChar, 105) { Value = "%" + (tuKhoa ?? string.Empty).Trim() + "%" }
            };

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// Lấy chi tiết các mặt hàng xuất của một mã phiếu xuất.
        /// </summary>
        public static DataTable LayChiTietPhieuXuat(string maPX)
        {
            if (string.IsNullOrWhiteSpace(maPX)) return new DataTable();

            const string sql = @"
                SELECT 
                    ROW_NUMBER() OVER(ORDER BY CT.MaSP ASC) AS STT,
                    CT.MaSP,
                    HH.TenSP,
                    HH.LoaiHang,
                    HH.DonViTinh,
                    CT.SoLuongXuat,
                    CT.DonGiaXuat,
                    CT.ThanhTien
                FROM dbo.ChiTietPhieuXuat CT
                INNER JOIN dbo.HangHoa HH ON CT.MaSP = HH.MaSP
                WHERE CT.MaPX = @MaPX
                ORDER BY CT.MaSP ASC;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaPX", SqlDbType.VarChar, 20) { Value = maPX.Trim() }
            };

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// Tổng hợp doanh thu theo từng mặt hàng đã xuất trong khoảng thời gian.
        /// </summary>
        public static DataTable LayDoanhThuTheoMatHang(DateTime tuNgay, DateTime denNgay)
        {
            const string sql = @"
                SELECT 
                    ROW_NUMBER() OVER(ORDER BY SUM(CT.ThanhTien) DESC) AS STT,
                    CT.MaSP,
                    HH.TenSP,
                    HH.LoaiHang,
                    HH.DonViTinh,
                    SUM(CT.SoLuongXuat) AS TongSoLuongXuat,
                    SUM(CT.ThanhTien) AS TongDoanhThu
                FROM dbo.ChiTietPhieuXuat CT
                INNER JOIN dbo.PhieuXuat PX ON CT.MaPX = PX.MaPX
                INNER JOIN dbo.HangHoa HH ON CT.MaSP = HH.MaSP
                WHERE PX.NgayXuat >= @TuNgay AND PX.NgayXuat <= @DenNgay
                GROUP BY CT.MaSP, HH.TenSP, HH.LoaiHang, HH.DonViTinh
                ORDER BY TongDoanhThu DESC;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TuNgay", SqlDbType.DateTime) { Value = tuNgay },
                new SqlParameter("@DenNgay", SqlDbType.DateTime) { Value = denNgay }
            };

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// Tổng hợp doanh thu theo từng ngày để vẽ biểu đồ diễn biến doanh thu.
        /// </summary>
        public static DataTable LayDoanhThuTheoTungNgay(DateTime tuNgay, DateTime denNgay)
        {
            const string sql = @"
                SELECT 
                    CONVERT(VARCHAR(10), PX.NgayXuat, 103) AS Ngay,
                    CAST(PX.NgayXuat AS DATE) AS NgaySort,
                    COUNT(PX.MaPX) AS SoPhieu,
                    SUM(PX.TongTienXuat) AS DoanhThu
                FROM dbo.PhieuXuat PX
                WHERE PX.NgayXuat >= @TuNgay AND PX.NgayXuat <= @DenNgay
                GROUP BY CONVERT(VARCHAR(10), PX.NgayXuat, 103), CAST(PX.NgayXuat AS DATE)
                ORDER BY NgaySort ASC;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TuNgay", SqlDbType.DateTime) { Value = tuNgay },
                new SqlParameter("@DenNgay", SqlDbType.DateTime) { Value = denNgay }
            };

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// Lấy các chỉ số KPI tổng hợp doanh thu: Tổng tiền, Số phiếu xuất, Tổng số lượng xuất.
        /// </summary>
        public static void LayChiSoTongHop(DateTime tuNgay, DateTime denNgay, out decimal tongDoanhThu, out int tongSoPhieu, out int tongSoLuongXuat)
        {
            tongDoanhThu = 0m;
            tongSoPhieu = 0;
            tongSoLuongXuat = 0;

            const string sql = @"
                SELECT 
                    ISNULL(SUM(PX.TongTienXuat), 0) AS TongDoanhThu,
                    COUNT(DISTINCT PX.MaPX) AS TongSoPhieu,
                    ISNULL((
                        SELECT SUM(CT.SoLuongXuat)
                        FROM dbo.ChiTietPhieuXuat CT
                        INNER JOIN dbo.PhieuXuat P ON CT.MaPX = P.MaPX
                        WHERE P.NgayXuat >= @TuNgay AND P.NgayXuat <= @DenNgay
                    ), 0) AS TongSoLuongXuat
                FROM dbo.PhieuXuat PX
                WHERE PX.NgayXuat >= @TuNgay AND PX.NgayXuat <= @DenNgay;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TuNgay", SqlDbType.DateTime) { Value = tuNgay },
                new SqlParameter("@DenNgay", SqlDbType.DateTime) { Value = denNgay }
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                if (r["TongDoanhThu"] != DBNull.Value) tongDoanhThu = Convert.ToDecimal(r["TongDoanhThu"]);
                if (r["TongSoPhieu"] != DBNull.Value) tongSoPhieu = Convert.ToInt32(r["TongSoPhieu"]);
                if (r["TongSoLuongXuat"] != DBNull.Value) tongSoLuongXuat = Convert.ToInt32(r["TongSoLuongXuat"]);
            }
        }
    }
}
