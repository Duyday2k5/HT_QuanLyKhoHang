using System;
using System.Data;
using System.Globalization;
using QLKhoHang.DAL;

namespace QLKhoHang.BUS
{
    /// <summary>
    /// Tầng xử lý nghiệp vụ (BUS) cho Sổ Thẻ Kho và Báo cáo Nhập - Xuất - Tồn.
    /// Tính toán biến động kho chính xác, bao gồm cả lịch sử Cân bằng kho kiểm kê.
    /// </summary>
    public class TheKhoBUS
    {
        public DataTable LayDanhSachHangHoaChoTheKho()
        {
            return TheKhoDAL.LayDanhSachHangHoaChoTheKho();
        }

        public DataTable LayTheKho(
            string maSP,
            DateTime tuNgay,
            DateTime denNgay,
            out decimal tonDauKy,
            out decimal tongNhapTrongKy,
            out decimal tongXuatTrongKy,
            out decimal tonCuoiKy,
            out string donViTinh)
        {
            if (string.IsNullOrWhiteSpace(maSP))
            {
                throw new ArgumentException("Vui lòng chọn mặt hàng cần tra cứu thẻ kho.");
            }

            if (tuNgay.Date > denNgay.Date)
            {
                throw new ArgumentException("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
            }

            decimal soLuongTonHienTai;
            decimal giaNhapGanNhat;
            if (!TheKhoDAL.LayThongTinHangHoa(maSP, out soLuongTonHienTai, out giaNhapGanNhat, out donViTinh))
            {
                throw new InvalidOperationException("Mặt hàng đã bị xóa hoặc không còn tồn tại trong danh mục.");
            }

            decimal tongNhapTuNgayDenNay = TheKhoDAL.LayTongNhapTuNgayDenNay(maSP, tuNgay.Date);
            decimal tongXuatTuNgayDenNay = TheKhoDAL.LayTongXuatTuNgayDenNay(maSP, tuNgay.Date);

            tonDauKy = soLuongTonHienTai - tongNhapTuNgayDenNay + tongXuatTuNgayDenNay;

            DataTable giaoDich = TheKhoDAL.LayLichSuBienDong(maSP, tuNgay.Date, denNgay.Date);

            DataTable theKho = TaoBangTheKho();
            decimal soDuHienTai = tonDauKy;

            theKho.Rows.Add(
                tuNgay.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                "DUKY",
                "Tồn đầu kỳ",
                giaNhapGanNhat,
                "-",
                "-",
                soDuHienTai);

            tongNhapTrongKy = 0;
            tongXuatTrongKy = 0;

            foreach (DataRow row in giaoDich.Rows)
            {
                DateTime ngayGhi = Convert.ToDateTime(row["NgayGhi"], CultureInfo.InvariantCulture);
                decimal donGia = Convert.ToDecimal(row["DonGia"], CultureInfo.InvariantCulture);
                decimal slNhap = Convert.ToDecimal(row["SLNhap"], CultureInfo.InvariantCulture);
                decimal slXuat = Convert.ToDecimal(row["SLXuat"], CultureInfo.InvariantCulture);

                soDuHienTai = soDuHienTai + slNhap - slXuat;
                tongNhapTrongKy += slNhap;
                tongXuatTrongKy += slXuat;

                theKho.Rows.Add(
                    ngayGhi.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Convert.ToString(row["ChungTu"], CultureInfo.CurrentCulture),
                    Convert.ToString(row["DienGiai"], CultureInfo.CurrentCulture),
                    donGia,
                    slNhap > 0 ? (object)slNhap : "-",
                    slXuat > 0 ? (object)slXuat : "-",
                    soDuHienTai);
            }

            tonCuoiKy = soDuHienTai;
            return theKho;
        }

        public DataTable LayBaoCaoTonKho(DateTime tuNgay, DateTime denNgay, string loaiHang, string tuKhoa)
        {
            if (tuNgay.Date > denNgay.Date)
            {
                throw new ArgumentException("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
            }

            string filterLoaiHang = string.Equals(loaiHang, "Tất cả", StringComparison.CurrentCultureIgnoreCase)
                ? string.Empty
                : (loaiHang ?? string.Empty).Trim();

            return TheKhoDAL.LayBaoCaoTonKho(tuNgay.Date, denNgay.Date, filterLoaiHang, (tuKhoa ?? string.Empty).Trim());
        }

        public DataTable LayDanhSachLoaiHang()
        {
            return TheKhoDAL.LayDanhSachLoaiHang();
        }

        private static DataTable TaoBangTheKho()
        {
            DataTable table = new DataTable("TheKho");
            table.Columns.Add("NgayGhi", typeof(string));
            table.Columns.Add("ChungTu", typeof(string));
            table.Columns.Add("DienGiai", typeof(string));
            table.Columns.Add("DonGia", typeof(decimal));
            table.Columns.Add("SLNhap", typeof(object));
            table.Columns.Add("SLXuat", typeof(object));
            table.Columns.Add("SoDuTon", typeof(decimal));
            return table;
        }
    }
}

