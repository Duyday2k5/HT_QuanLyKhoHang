using System;

namespace LTWIN_N4_QLKH.DTO
{
    public class PhieuNhapDTO
    {
        public string MaPN { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaNCC { get; set; }
        public string MaNV { get; set; }
        public decimal TongTienNhap { get; set; }
        public string GhiChu { get; set; }
    }

    public class ChiTietPhieuNhapDTO
    {
        public string MaPN { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuongNhap { get; set; }
        public decimal DonGiaNhap { get; set; }

        public decimal ThanhTien
        {
            get { return SoLuongNhap * DonGiaNhap; }
        }
    }
}