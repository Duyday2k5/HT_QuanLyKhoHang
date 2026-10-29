using System;
using System.Collections.Generic;
using System.Data;
using QLKhoHang.DAL;
using QLKhoHang.DTO;

namespace QLKhoHang.BUS
{
    public class PhieuXuatBUS
    {
        public DataTable LayDanhSachHangHoa()
        {
            return PhieuNhapDAL.LayDanhSachHangHoa();
        }

        public string SinhMaPhieuXuatMoi(DateTime ngayXuat)
        {
            return PhieuXuatDAL.SinhMaPhieuXuatMoi(ngayXuat);
        }

        public int LaySoLuongTonHienTai(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP)) return 0;
            return PhieuXuatDAL.LaySoLuongTonHienTai(maSP);
        }

        /// <summary>
        /// Kiểm tra chặt chẽ số lượng tồn kho (bao gồm cả số lượng đã nằm sẵn trong giỏ) để chặn xuất âm.
        /// </summary>
        public void ThemHoacCapNhatGioXuat(
            IList<ChiTietPhieuXuatDTO> gioXuat,
            string maSP,
            string tenSP,
            string dvt,
            int soLuongXuatThem,
            decimal donGiaXuat,
            int tonKhoHienTai)
        {
            if (string.IsNullOrWhiteSpace(maSP))
                throw new ArgumentException("Vui lòng chọn mặt hàng cần xuất.");
            if (soLuongXuatThem <= 0)
                throw new ArgumentException("Số lượng xuất phải lớn hơn 0.");
            if (donGiaXuat < 0)
                throw new ArgumentException("Đơn giá xuất không được âm.");

            ChiTietPhieuXuatDTO dongHienTai = null;
            int daCoTrongGio = 0;

            foreach (ChiTietPhieuXuatDTO item in gioXuat)
            {
                if (string.Equals(item.MaSP, maSP, StringComparison.OrdinalIgnoreCase))
                {
                    dongHienTai = item;
                    daCoTrongGio = item.SoLuongXuat;
                    break;
                }
            }

            int tongMuonXuat = daCoTrongGio + soLuongXuatThem;
            if (tongMuonXuat > tonKhoHienTai)
            {
                throw new InvalidOperationException(
                    string.Format("CẢNH BÁO XUẤT VƯỢT TỒN KHO!\nMặt hàng '{0}' hiện chỉ còn tồn {1} {2}.\nSố lượng bạn muốn xuất ({3} {2}) vượt quá lượng tồn khả dụng!",
                    tenSP, tonKhoHienTai, dvt, tongMuonXuat));
            }

            if (dongHienTai != null)
            {
                dongHienTai.SoLuongXuat = tongMuonXuat;
                dongHienTai.DonGiaXuat = donGiaXuat;
            }
            else
            {
                gioXuat.Add(new ChiTietPhieuXuatDTO
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    DonViTinh = dvt,
                    SoLuongXuat = soLuongXuatThem,
                    DonGiaXuat = donGiaXuat
                });
            }
        }

        public decimal TinhTongTien(IList<ChiTietPhieuXuatDTO> gioXuat)
        {
            decimal tong = 0m;
            if (gioXuat == null) return tong;
            foreach (ChiTietPhieuXuatDTO item in gioXuat)
            {
                tong += item.ThanhTien;
            }
            return tong;
        }

        public void LuuPhieuXuat(PhieuXuatDTO phieu, IList<ChiTietPhieuXuatDTO> gioXuat)
        {
            if (phieu == null)
                throw new ArgumentNullException(nameof(phieu));
            if (string.IsNullOrWhiteSpace(phieu.MaPX))
                throw new ArgumentException("Số phiếu xuất không được để trống.");
            if (string.IsNullOrWhiteSpace(phieu.NguoiNhan))
                throw new ArgumentException("Vui lòng nhập Người / Đơn vị nhận hàng.");
            if (string.IsNullOrWhiteSpace(phieu.LyDoXuat))
                throw new ArgumentException("Vui lòng chọn hoặc nhập Lý do xuất kho.");
            if (gioXuat == null || gioXuat.Count == 0)
                throw new ArgumentException("Phiếu xuất phải có ít nhất 1 mặt hàng.");

            // Kiểm tra bẫy chặn xuất vượt tồn ở tầng BUS trước khi ghi nhận phiếu xuất
            foreach (ChiTietPhieuXuatDTO item in gioXuat)
            {
                if (item.SoLuongXuat <= 0)
                    throw new ArgumentException($"Số lượng xuất của sản phẩm '{item.TenSP}' phải lớn hơn 0.");

                int tonHienTai = LaySoLuongTonHienTai(item.MaSP);
                if (item.SoLuongXuat > tonHienTai)
                {
                    throw new InvalidOperationException(
                        $"Chặn xuất vượt tồn: Mặt hàng '{item.TenSP}' ({item.MaSP}) hiện chỉ còn tồn {tonHienTai} {item.DonViTinh}, không đủ để xuất {item.SoLuongXuat} {item.DonViTinh}!");
                }
            }

            phieu.TongTienXuat = TinhTongTien(gioXuat);
            PhieuXuatDAL.LuuPhieuXuat(phieu, gioXuat);
        }
    }
}