using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.DAL
{
    /// <summary>
    /// Tầng truy cập dữ liệu (DAL) cho Sổ Thẻ Kho và Báo cáo Tổng hợp Tồn kho.
    /// Tích hợp đầy đủ lịch sử biến động từ Nhập kho, Xuất kho và Cân bằng kiểm kê.
    /// </summary>
    public static class TheKhoDAL
    {
        public static DataTable LayDanhSachHangHoaChoTheKho()
        {
            const string sql = @"
                SELECT MaSP, (MaSP + N' - ' + TenSP) AS TenHienThi
                FROM dbo.HangHoa
                ORDER BY TenSP, MaSP;";
            return DatabaseHelper.ExecuteQuery(sql, null);
        }

        public static bool LayThongTinHangHoa(string maSP, out decimal soLuongTon, out decimal giaNhapGanNhat, out string donViTinh)
        {
            soLuongTon = 0;
            giaNhapGanNhat = 0;
            donViTinh = string.Empty;

            const string sql = @"
                SELECT SoLuongTon, DonViTinh, GiaNhapGanNhat
                FROM dbo.HangHoa
                WHERE MaSP = @MaSP;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = maSP.Trim() }
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count == 0) return false;

            DataRow row = dt.Rows[0];
            soLuongTon = Convert.ToDecimal(row["SoLuongTon"], CultureInfo.InvariantCulture);
            giaNhapGanNhat = Convert.ToDecimal(row["GiaNhapGanNhat"], CultureInfo.InvariantCulture);
            donViTinh = Convert.ToString(row["DonViTinh"]);
            return true;
        }

        public static decimal LayTongNhapTuNgayDenNay(string maSP, DateTime tuNgay)
        {
            const string sql = @"
                SELECT COALESCE(SUM(CONVERT(BIGINT, CTPN.SoLuongNhap)), 0)
                FROM dbo.ChiTietPhieuNhap AS CTPN
                INNER JOIN dbo.PhieuNhap AS PN ON PN.MaPN = CTPN.MaPN
                WHERE CTPN.MaSP = @MaSP
                  AND PN.NgayNhap >= @TuNgay
                  AND PN.NgayNhap <= GETDATE();";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = maSP.Trim() },
                new SqlParameter("@TuNgay", SqlDbType.DateTime) { Value = tuNgay }
            };

            object res = DatabaseHelper.ExecuteScalar(sql, parameters);
            if (res == null || res == DBNull.Value) return 0;
            return Convert.ToDecimal(res, CultureInfo.InvariantCulture);
        }

        public static decimal LayTongXuatTuNgayDenNay(string maSP, DateTime tuNgay)
        {
            const string sql = @"
                SELECT COALESCE(SUM(CONVERT(BIGINT, CTPX.SoLuongXuat)), 0)
                FROM dbo.ChiTietPhieuXuat AS CTPX
                INNER JOIN dbo.PhieuXuat AS PX ON PX.MaPX = CTPX.MaPX
                WHERE CTPX.MaSP = @MaSP
                  AND PX.NgayXuat >= @TuNgay
                  AND PX.NgayXuat <= GETDATE();";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = maSP.Trim() },
                new SqlParameter("@TuNgay", SqlDbType.DateTime) { Value = tuNgay }
            };

            object res = DatabaseHelper.ExecuteScalar(sql, parameters);
            if (res == null || res == DBNull.Value) return 0;
            return Convert.ToDecimal(res, CultureInfo.InvariantCulture);
        }

        public static DataTable LayLichSuBienDong(string maSP, DateTime tuNgay, DateTime denNgay)
        {
            const string sql = @"
                SELECT PN.NgayNhap AS NgayGhi,
                       PN.MaPN AS ChungTu,
                       CASE 
                           WHEN PN.GhiChu LIKE N'%cân bằng kiểm kê%' OR PN.GhiChu LIKE N'%Cân bằng%' THEN PN.GhiChu 
                           ELSE N'Nhập hàng ' + ISNULL(NCC.TenNCC, N'') 
                       END AS DienGiai,
                       CTPN.DonGiaNhap AS DonGia,
                       CTPN.SoLuongNhap AS SLNhap,
                       0 AS SLXuat
                FROM dbo.PhieuNhap AS PN
                INNER JOIN dbo.ChiTietPhieuNhap AS CTPN ON CTPN.MaPN = PN.MaPN
                LEFT JOIN dbo.NhaCungCap AS NCC ON NCC.MaNCC = PN.MaNCC
                WHERE CTPN.MaSP = @MaSP
                  AND PN.NgayNhap >= @TuNgay
                  AND PN.NgayNhap < DATEADD(DAY, 1, @DenNgay)
                UNION ALL
                SELECT PX.NgayXuat AS NgayGhi,
                       PX.MaPX AS ChungTu,
                       CASE 
                           WHEN PX.LyDoXuat LIKE N'%cân bằng kiểm kê%' OR PX.LyDoXuat LIKE N'%Cân bằng%' THEN PX.LyDoXuat 
                           ELSE N'Xuất giao ' + ISNULL(PX.NguoiNhan, N'') + N' (' + ISNULL(PX.LyDoXuat, N'') + N')' 
                       END AS DienGiai,
                       CTPX.DonGiaXuat AS DonGia,
                       0 AS SLNhap,
                       CTPX.SoLuongXuat AS SLXuat
                FROM dbo.PhieuXuat AS PX
                INNER JOIN dbo.ChiTietPhieuXuat AS CTPX ON CTPX.MaPX = PX.MaPX
                WHERE CTPX.MaSP = @MaSP
                  AND PX.NgayXuat >= @TuNgay
                  AND PX.NgayXuat < DATEADD(DAY, 1, @DenNgay)
                ORDER BY NgayGhi ASC, ChungTu ASC;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = maSP.Trim() },
                new SqlParameter("@TuNgay", SqlDbType.DateTime) { Value = tuNgay.Date },
                new SqlParameter("@DenNgay", SqlDbType.DateTime) { Value = denNgay.Date }
            };

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public static DataTable LayBaoCaoTonKho(DateTime tuNgay, DateTime denNgay, string loaiHang, string tuKhoa)
        {
            const string sql = @";WITH NhapKy AS
(
    SELECT CTPN.MaSP, SUM(CONVERT(BIGINT, CTPN.SoLuongNhap)) AS SLNhapTrongKy
    FROM dbo.ChiTietPhieuNhap AS CTPN
    INNER JOIN dbo.PhieuNhap AS PN ON PN.MaPN = CTPN.MaPN
    WHERE PN.NgayNhap >= @TuNgay
      AND PN.NgayNhap < DATEADD(DAY, 1, @DenNgay)
    GROUP BY CTPN.MaSP
), XuatKy AS
(
    SELECT CTPX.MaSP, SUM(CONVERT(BIGINT, CTPX.SoLuongXuat)) AS SLXuatTrongKy
    FROM dbo.ChiTietPhieuXuat AS CTPX
    INNER JOIN dbo.PhieuXuat AS PX ON PX.MaPX = CTPX.MaPX
    WHERE PX.NgayXuat >= @TuNgay
      AND PX.NgayXuat < DATEADD(DAY, 1, @DenNgay)
    GROUP BY CTPX.MaSP
), NhapSauKy AS
(
    SELECT CTPN.MaSP, SUM(CONVERT(BIGINT, CTPN.SoLuongNhap)) AS TongNhapSauKy
    FROM dbo.ChiTietPhieuNhap AS CTPN
    INNER JOIN dbo.PhieuNhap AS PN ON PN.MaPN = CTPN.MaPN
    WHERE PN.NgayNhap >= DATEADD(DAY, 1, @DenNgay)
    GROUP BY CTPN.MaSP
), XuatSauKy AS
(
    SELECT CTPX.MaSP, SUM(CONVERT(BIGINT, CTPX.SoLuongXuat)) AS TongXuatSauKy
    FROM dbo.ChiTietPhieuXuat AS CTPX
    INNER JOIN dbo.PhieuXuat AS PX ON PX.MaPX = CTPX.MaPX
    WHERE PX.NgayXuat >= DATEADD(DAY, 1, @DenNgay)
    GROUP BY CTPX.MaSP
), TonTheoKy AS
(
    SELECT HH.MaSP,
           HH.TenSP,
           HH.LoaiHang,
           HH.DonViTinh,
           HH.GiaNhapGanNhat,
           HH.TonToiThieu,
           HH.TonToiDa,
           COALESCE(NK.SLNhapTrongKy, CONVERT(BIGINT, 0)) AS SLNhap,
           COALESCE(XK.SLXuatTrongKy, CONVERT(BIGINT, 0)) AS SLXuat,
           CONVERT(BIGINT, HH.SoLuongTon)
             - COALESCE(NSK.TongNhapSauKy, CONVERT(BIGINT, 0))
             + COALESCE(XSK.TongXuatSauKy, CONVERT(BIGINT, 0)) AS TonCuoi
    FROM dbo.HangHoa AS HH
    LEFT JOIN NhapKy AS NK ON NK.MaSP = HH.MaSP
    LEFT JOIN XuatKy AS XK ON XK.MaSP = HH.MaSP
    LEFT JOIN NhapSauKy AS NSK ON NSK.MaSP = HH.MaSP
    LEFT JOIN XuatSauKy AS XSK ON XSK.MaSP = HH.MaSP
)
SELECT ROW_NUMBER() OVER (ORDER BY MaSP ASC) AS STT,
       MaSP,
       TenSP,
       LoaiHang,
       DonViTinh,
       TonCuoi - SLNhap + SLXuat AS TonDau,
       SLNhap,
       SLXuat,
       TonCuoi,
       CONVERT(DECIMAL(28, 2), TonCuoi * GiaNhapGanNhat) AS GiaTriTon,
       CASE
           WHEN TonCuoi <= 0 THEN N'Hết hàng'
           WHEN TonCuoi <= TonToiThieu THEN N'Chạm ngưỡng tối thiểu'
           WHEN TonCuoi > TonToiDa THEN N'Vượt tồn tối đa'
           ELSE N'Bình thường'
       END AS TrangThai,
       TonToiThieu,
       TonToiDa,
       SLNhap + SLXuat AS TongLuanChuyen
FROM TonTheoKy
WHERE (@LoaiHang = N'' OR LoaiHang = @LoaiHang)
  AND (@TuKhoa = N'' OR MaSP LIKE N'%' + @TuKhoa + N'%' OR TenSP LIKE N'%' + @TuKhoa + N'%')
ORDER BY MaSP ASC;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TuNgay", SqlDbType.DateTime) { Value = tuNgay.Date },
                new SqlParameter("@DenNgay", SqlDbType.DateTime) { Value = denNgay.Date },
                new SqlParameter("@LoaiHang", SqlDbType.NVarChar, 50) { Value = loaiHang ?? string.Empty },
                new SqlParameter("@TuKhoa", SqlDbType.NVarChar, 200) { Value = tuKhoa ?? string.Empty }
            };

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        public static DataTable LayDanhSachLoaiHang()
        {
            const string sql = @"
                SELECT DISTINCT LoaiHang
                FROM dbo.HangHoa
                WHERE LoaiHang IS NOT NULL AND LoaiHang <> ''
                ORDER BY LoaiHang;";
            return DatabaseHelper.ExecuteQuery(sql, null);
        }
    }
}

