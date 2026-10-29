using System;
using QLKhoHang.DTO;

namespace QLKhoHang.BUS
{
    /// <summary>
    /// Quyền nghiệp vụ theo vai trò; giao diện và các luồng nghiệp vụ cần kiểm tra qua lớp này.
    /// </summary>
    public class PhanQuyenBUS
    {
        public bool CoQuyen(NhanVienDTO nhanVien, ChucNang chucNang)
        {
            // Cấu hình CSDL là tính năng cứu hộ kỹ thuật, luôn cho phép mở kể cả khi chưa đăng nhập
            if (chucNang == ChucNang.KetNoiCSDL)
            {
                return true;
            }

            if (nhanVien == null)
            {
                return false;
            }

            // Các kiểm tra quyền vai trò bên dưới giữ nguyên...
            if (string.Equals(nhanVien.VaiTro, "Quản lý kho", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (nhanVien == null || string.IsNullOrWhiteSpace(nhanVien.VaiTro))
            {
                return false;
            }

            if (string.Equals(nhanVien.VaiTro, "Quản lý kho", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.Equals(nhanVien.VaiTro, "Thủ kho", StringComparison.OrdinalIgnoreCase))
            {
                return chucNang == ChucNang.TongQuan ||
                       chucNang == ChucNang.NhapKho ||
                       chucNang == ChucNang.XuatKho ||
                       chucNang == ChucNang.KiemKe ||
                       chucNang == ChucNang.TheKho ||
                       chucNang == ChucNang.DoiMatKhau;
            }

            if (string.Equals(nhanVien.VaiTro, "Kế toán kho", StringComparison.OrdinalIgnoreCase))
            {
                return chucNang == ChucNang.TongQuan ||
                       chucNang == ChucNang.TheKho ||
                       chucNang == ChucNang.BaoCaoTonKho ||
                       chucNang == ChucNang.DoiMatKhau;
            }

            return false;
        }

        public void YeuCauQuyen(NhanVienDTO nhanVien, ChucNang chucNang)
        {
            if (!CoQuyen(nhanVien, chucNang))
            {
                throw new UnauthorizedAccessException("Tài khoản không có quyền thực hiện chức năng này.");
            }
        }
    }
}
