using System;
using System.Data;
using LTWIN_N4_QLKH.DAL;

namespace LTWIN_N4_QLKH.BUS
{
    /// <summary>
    /// Tầng xử lý nghiệp vụ (BUS) cho chức năng thống kê và phân tích Doanh Thu.
    /// Tính toán theo ngày, tháng, năm hoặc khoảng thời gian tùy chọn.
    /// </summary>
    public class DoanhThuBUS
    {
        public DataTable LayDanhSachPhieuXuat(DateTime tuNgay, DateTime denNgay, string tuKhoa = "")
        {
            DateTime start = tuNgay.Date;
            DateTime end = denNgay.Date.AddDays(1).AddSeconds(-1);
            return DoanhThuDAL.LayDanhSachPhieuXuat(start, end, tuKhoa);
        }

        public DataTable LayChiTietPhieuXuat(string maPX)
        {
            return DoanhThuDAL.LayChiTietPhieuXuat(maPX);
        }

        public DataTable LayDoanhThuTheoMatHang(DateTime tuNgay, DateTime denNgay)
        {
            DateTime start = tuNgay.Date;
            DateTime end = denNgay.Date.AddDays(1).AddSeconds(-1);
            return DoanhThuDAL.LayDoanhThuTheoMatHang(start, end);
        }

        public DataTable LayDoanhThuTheoTungNgay(DateTime tuNgay, DateTime denNgay)
        {
            DateTime start = tuNgay.Date;
            DateTime end = denNgay.Date.AddDays(1).AddSeconds(-1);
            return DoanhThuDAL.LayDoanhThuTheoTungNgay(start, end);
        }

        public void LayChiSoTongHop(DateTime tuNgay, DateTime denNgay, out decimal tongDoanhThu, out int tongSoPhieu, out int tongSoLuongXuat)
        {
            DateTime start = tuNgay.Date;
            DateTime end = denNgay.Date.AddDays(1).AddSeconds(-1);
            DoanhThuDAL.LayChiSoTongHop(start, end, out tongDoanhThu, out tongSoPhieu, out tongSoLuongXuat);
        }

        /// <summary>
        /// Xác định khoảng thời gian chuẩn xác theo các chế độ lọc: Theo Ngày, Theo Tháng, hoặc Khoảng thời gian.
        /// </summary>
        public void XacDinhKhoangThoiGian(string cheDo, DateTime ngayChon, int thang, int nam, DateTime tuNgayChon, DateTime denNgayChon, out DateTime tuNgay, out DateTime denNgay)
        {
            if (cheDo == "Theo ngày")
            {
                tuNgay = ngayChon.Date;
                denNgay = ngayChon.Date;
            }
            else if (cheDo == "Theo tháng")
            {
                tuNgay = new DateTime(nam, thang, 1);
                denNgay = tuNgay.AddMonths(1).AddDays(-1);
            }
            else
            {
                tuNgay = tuNgayChon.Date;
                denNgay = denNgayChon.Date;
            }
        }
    }
}
