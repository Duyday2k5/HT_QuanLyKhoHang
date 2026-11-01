using System;

namespace LTWIN_N4_QLKH.DTO
{
    /// <summary>
    /// Đối tượng truyền dữ liệu (DTO) biểu diễn thông tin Hàng hóa trong kho.
    /// </summary>
    public class HangHoaDTO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string LoaiHang { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuongTon { get; set; }
        public int TonToiThieu { get; set; }
        public int TonToiDa { get; set; }
        public decimal GiaNhapGanNhat { get; set; }

        public string TenHienThi
        {
            get
            {
                if (string.IsNullOrWhiteSpace(MaSP)) return TenSP ?? string.Empty;
                return MaSP + " - " + (TenSP ?? string.Empty);
            }
        }
    }
}

