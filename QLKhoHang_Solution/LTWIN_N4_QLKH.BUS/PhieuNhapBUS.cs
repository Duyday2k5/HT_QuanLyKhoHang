using System;
using System.Collections.Generic;
using System.Data;
using LTWIN_N4_QLKH.DAL;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.BUS
{
    public class PhieuNhapBUS
    {
        public DataTable LayDanhSachNhaCungCap()
        {
            return PhieuNhapDAL.LayDanhSachNhaCungCap();
        }

        public DataTable LayDanhSachHangHoa()
        {
            return PhieuNhapDAL.LayDanhSachHangHoa();
        }

        public string SinhMaPhieuNhapMoi(DateTime ngayNhap)
        {
            return PhieuNhapDAL.SinhMaPhieuNhapMoi(ngayNhap);
        }

        public void ThemHoacCapNhatGioHang(
            IList<ChiTietPhieuNhapDTO> gioHang,
            string maSP,
            string tenSP,
            string dvt,
            int soLuong,
            decimal donGia)
        {
            if (string.IsNullOrWhiteSpace(maSP))
                throw new ArgumentException("Vui lòng chọn mặt hàng cần nhập.");
            if (soLuong <= 0)
                throw new ArgumentException("Số lượng nhập phải lớn hơn 0.");
            if (donGia < 0)
                throw new ArgumentException("Đơn giá nhập không được âm.");

            foreach (ChiTietPhieuNhapDTO item in gioHang)
            {
                if (string.Equals(item.MaSP, maSP, StringComparison.OrdinalIgnoreCase))
                {
                    item.SoLuongNhap += soLuong;
                    item.DonGiaNhap = donGia;
                    return;
                }
            }

            gioHang.Add(new ChiTietPhieuNhapDTO
            {
                MaSP = maSP,
                TenSP = tenSP,
                DonViTinh = dvt,
                SoLuongNhap = soLuong,
                DonGiaNhap = donGia
            });
        }

        public decimal TinhTongTien(IList<ChiTietPhieuNhapDTO> gioHang)
        {
            decimal tong = 0m;
            if (gioHang == null) return tong;
            foreach (ChiTietPhieuNhapDTO item in gioHang)
            {
                tong += item.ThanhTien;
            }
            return tong;
        }

        public void LuuPhieuNhap(PhieuNhapDTO phieu, IList<ChiTietPhieuNhapDTO> gioHang)
        {
            if (phieu == null)
                throw new ArgumentNullException(nameof(phieu));
            if (string.IsNullOrWhiteSpace(phieu.MaPN))
                throw new ArgumentException("Số phiếu nhập không được để trống.");
            if (string.IsNullOrWhiteSpace(phieu.MaNCC))
                throw new ArgumentException("Vui lòng chọn Nhà cung cấp.");
            if (string.IsNullOrWhiteSpace(phieu.MaNV))
                throw new ArgumentException("Không xác định được nhân viên lập phiếu.");
            if (gioHang == null || gioHang.Count == 0)
                throw new ArgumentException("Phiếu nhập phải có ít nhất 1 mặt hàng.");

            phieu.TongTienNhap = TinhTongTien(gioHang);
            PhieuNhapDAL.LuuPhieuNhap(phieu, gioHang);
        }
    }
}