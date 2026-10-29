using System;

namespace QLKhoHang.DTO
{
    /// <summary>
    /// Đối tượng truyền dữ liệu (DTO) biểu diễn một dòng trong Báo cáo Tổng hợp Nhập - Xuất - Tồn.
    /// </summary>
    public class BaoCaoTonKhoDTO
    {
        public int STT { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string LoaiHang { get; set; }
        public string DonViTinh { get; set; }
        public long TonDau { get; set; }
        public long SLNhap { get; set; }
        public long SLXuat { get; set; }
        public long TonCuoi { get; set; }
        public decimal GiaTriTon { get; set; }
        public string TrangThai { get; set; }
        public int TonToiThieu { get; set; }
        public int TonToiDa { get; set; }
        public long TongLuanChuyen { get; set; }
    }
}

