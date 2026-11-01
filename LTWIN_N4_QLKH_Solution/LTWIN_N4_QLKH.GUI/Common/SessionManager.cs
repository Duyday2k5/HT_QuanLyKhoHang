using System;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.GUI.Common
{
    /// <summary>
    /// Giữ thông tin nhân viên đã đăng nhập trong bộ nhớ tiến trình.
    /// Không giữ mật khẩu hoặc chuỗi băm trong session.
    /// </summary>
    public static class SessionManager
    {
        public static NhanVienDTO NguoiDungHienTai { get; private set; }

        public static bool DaDangNhap
        {
            get { return NguoiDungHienTai != null; }
        }

        public static void DangNhap(NhanVienDTO nhanVien)
        {
            if (nhanVien == null || string.IsNullOrWhiteSpace(nhanVien.MaNV))
            {
                throw new ArgumentException("Thông tin nhân viên đăng nhập không hợp lệ.", nameof(nhanVien));
            }

            NguoiDungHienTai = nhanVien;
        }

        public static void DangXuat()
        {
            NguoiDungHienTai = null;
        }
    }
}
