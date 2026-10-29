using System;

namespace LTWIN_N4_QLKH.DTO
{
    /// <summary>
    /// Đối tượng truyền dữ liệu (DTO) biểu diễn một dòng nhật ký biến động trên Sổ Thẻ Kho.
    /// </summary>
    public class TheKhoItemDTO
    {
        public DateTime NgayGhi { get; set; }
        public string NgayGhiStr { get; set; }
        public string ChungTu { get; set; }
        public string DienGiai { get; set; }
        public decimal DonGia { get; set; }
        public object SLNhap { get; set; }
        public object SLXuat { get; set; }
        public decimal SoDuTon { get; set; }
    }
}

