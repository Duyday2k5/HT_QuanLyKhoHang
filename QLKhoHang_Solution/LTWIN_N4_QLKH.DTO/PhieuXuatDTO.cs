using System;

namespace LTWIN_N4_QLKH.DTO
{
    public class PhieuXuatDTO
    {
        public string MaPX { get; set; }
        public DateTime NgayXuat { get; set; }
        public string MaNV { get; set; }
        public string NguoiNhan { get; set; }
        public string LyDoXuat { get; set; }
        public decimal TongTienXuat { get; set; }
        public string GhiChu { get; set; }
    }

    public class ChiTietPhieuXuatDTO
    {
        public string MaPX { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuongXuat { get; set; }
        public decimal DonGiaXuat { get; set; }

        public decimal ThanhTien
        {
            get { return SoLuongXuat * DonGiaXuat; }
        }
    }
}