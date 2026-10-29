using System;

namespace QLKhoHang.DTO
{
    /// <summary>
    /// Đối tượng truyền dữ liệu (DTO) biểu diễn thông tin Nhà cung cấp.
    /// </summary>
    public class NhaCungCapDTO
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string NguoiLienHe { get; set; }

        public string TenHienThi
        {
            get
            {
                if (string.IsNullOrWhiteSpace(MaNCC)) return TenNCC ?? string.Empty;
                return MaNCC + " - " + (TenNCC ?? string.Empty);
            }
        }
    }
}

