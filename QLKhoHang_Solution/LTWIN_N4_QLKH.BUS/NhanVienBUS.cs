using System;
using System.Data;
using LTWIN_N4_QLKH.DAL;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.BUS
{
    /// <summary>
    /// Kiểm tra dữ liệu đầu vào và điều phối nghiệp vụ nhân viên và tài khoản.
    /// </summary>
    public class NhanVienBUS
    {
        private readonly NhanVienDAL _nhanVienDAL;

        public NhanVienBUS() : this(new NhanVienDAL())
        {
        }

        internal NhanVienBUS(NhanVienDAL nhanVienDAL)
        {
            _nhanVienDAL = nhanVienDAL ?? throw new ArgumentNullException(nameof(nhanVienDAL));
        }

        public NhanVienDTO DangNhap(string taiKhoan, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(taiKhoan))
            {
                throw new ArgumentException("Vui lòng nhập tài khoản.", nameof(taiKhoan));
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                throw new ArgumentException("Vui lòng nhập mật khẩu.", nameof(matKhau));
            }

            NhanVienDTO nhanVien = _nhanVienDAL.DangNhap(taiKhoan.Trim(), matKhau);
            if (nhanVien == null)
            {
                throw new UnauthorizedAccessException("Tài khoản hoặc mật khẩu không đúng.");
            }

            return nhanVien;
        }

        public void DoiMatKhau(NhanVienDTO nhanVien, string matKhauCu, string matKhauMoi, string xacNhanMatKhau)
        {
            if (nhanVien == null || string.IsNullOrWhiteSpace(nhanVien.MaNV))
            {
                throw new UnauthorizedAccessException("Phiên đăng nhập không hợp lệ. Vui lòng đăng nhập lại.");
            }

            if (string.IsNullOrEmpty(matKhauCu))
            {
                throw new ArgumentException("Vui lòng nhập mật khẩu hiện tại.", nameof(matKhauCu));
            }

            if (string.IsNullOrEmpty(matKhauMoi) || matKhauMoi.Length < 6)
            {
                throw new ArgumentException("Mật khẩu mới phải có ít nhất 6 ký tự.", nameof(matKhauMoi));
            }

            if (!string.Equals(matKhauMoi, xacNhanMatKhau, StringComparison.Ordinal))
            {
                throw new ArgumentException("Mật khẩu xác nhận không khớp.", nameof(xacNhanMatKhau));
            }

            if (string.Equals(matKhauCu, matKhauMoi, StringComparison.Ordinal))
            {
                throw new ArgumentException("Mật khẩu mới phải khác mật khẩu hiện tại.", nameof(matKhauMoi));
            }

            if (!_nhanVienDAL.DoiMatKhau(nhanVien.MaNV, matKhauCu, matKhauMoi))
            {
                throw new UnauthorizedAccessException(
                    "Không đổi được mật khẩu. Hãy kiểm tra mật khẩu hiện tại hoặc đăng nhập lại.");
            }
        }

        public DataTable LayTatCaNhanVien()
        {
            return _nhanVienDAL.LayTatCaNhanVien();
        }

        public DataTable TimKiemNhanVien(string tuKhoa, string vaiTro)
        {
            return _nhanVienDAL.TimKiemNhanVien(tuKhoa, vaiTro);
        }

        public string PhatSinhMaNVMoi()
        {
            return _nhanVienDAL.PhatSinhMaNVMoi();
        }

        public void ThemNhanVien(string maNV, string hoTen, string taiKhoan, string matKhau, string vaiTro, string dienThoai)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                throw new ArgumentException("Mã nhân viên không được để trống.", nameof(maNV));

            if (string.IsNullOrWhiteSpace(hoTen))
                throw new ArgumentException("Họ tên nhân viên không được để trống.", nameof(hoTen));

            if (string.IsNullOrWhiteSpace(taiKhoan))
                throw new ArgumentException("Tên đăng nhập không được để trống.", nameof(taiKhoan));

            if (taiKhoan.Trim().Contains(" "))
                throw new ArgumentException("Tên đăng nhập không được chứa khoảng trắng.", nameof(taiKhoan));

            if (string.IsNullOrEmpty(matKhau) || matKhau.Length < 6)
                throw new ArgumentException("Mật khẩu khởi tạo phải có ít nhất 6 ký tự.", nameof(matKhau));

            if (string.IsNullOrWhiteSpace(vaiTro) ||
                (vaiTro != "Quản lý kho" && vaiTro != "Thủ kho" && vaiTro != "Kế toán kho"))
            {
                throw new ArgumentException("Vai trò không hợp lệ. Vui lòng chọn một trong các vai trò: Quản lý kho, Thủ kho, Kế toán kho.");
            }

            maNV = maNV.Trim().ToUpperInvariant();
            taiKhoan = taiKhoan.Trim();
            hoTen = hoTen.Trim();

            if (_nhanVienDAL.KiemTraTrungMaNV(maNV))
                throw new InvalidOperationException($"Mã nhân viên '{maNV}' đã tồn tại trong hệ thống.");

            if (_nhanVienDAL.KiemTraTrungTaiKhoan(taiKhoan))
                throw new InvalidOperationException($"Tài khoản đăng nhập '{taiKhoan}' đã tồn tại.");

            bool ok = _nhanVienDAL.ThemNhanVien(maNV, hoTen, taiKhoan, matKhau, vaiTro, dienThoai);
            if (!ok)
                throw new Exception("Thêm nhân viên thất bại. Vui lòng thử lại.");
        }

        public void CapNhatNhanVien(string maNV, string hoTen, string vaiTro, string dienThoai)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                throw new ArgumentException("Mã nhân viên không được để trống.", nameof(maNV));

            if (string.IsNullOrWhiteSpace(hoTen))
                throw new ArgumentException("Họ tên nhân viên không được để trống.", nameof(hoTen));

            if (string.IsNullOrWhiteSpace(vaiTro) ||
                (vaiTro != "Quản lý kho" && vaiTro != "Thủ kho" && vaiTro != "Kế toán kho"))
            {
                throw new ArgumentException("Vai trò không hợp lệ. Vui lòng chọn một trong các vai trò: Quản lý kho, Thủ kho, Kế toán kho.");
            }

            bool ok = _nhanVienDAL.CapNhatNhanVien(maNV.Trim(), hoTen.Trim(), vaiTro, dienThoai);
            if (!ok)
                throw new Exception("Cập nhật thông tin nhân viên thất bại.");
        }

        public void DatLaiMatKhau(string maNV, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                throw new ArgumentException("Mã nhân viên không hợp lệ.", nameof(maNV));

            if (string.IsNullOrEmpty(matKhauMoi) || matKhauMoi.Length < 6)
                throw new ArgumentException("Mật khẩu mới phải có ít nhất 6 ký tự.", nameof(matKhauMoi));

            bool ok = _nhanVienDAL.DatLaiMatKhau(maNV.Trim(), matKhauMoi);
            if (!ok)
                throw new Exception("Đặt lại mật khẩu thất bại.");
        }

        public void XoaNhanVien(string maNV, string maNVHienTaiDangNhap)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                throw new ArgumentException("Vui lòng chọn nhân viên cần xóa.", nameof(maNV));

            maNV = maNV.Trim();
            if (!string.IsNullOrWhiteSpace(maNVHienTaiDangNhap) &&
                string.Equals(maNV, maNVHienTaiDangNhap.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Không thể xóa tài khoản của chính bạn đang đăng nhập vào hệ thống.");
            }

            _nhanVienDAL.KiemTraRangBuocGiaoDich(maNV, out int soPN, out int soPX);
            if (soPN > 0 || soPX > 0)
            {
                throw new InvalidOperationException(
                    $"Không thể xóa nhân viên [{maNV}] vì đã phát sinh giao dịch lịch sử trong kho ({soPN} phiếu nhập, {soPX} phiếu xuất)!\nĐể đảm bảo tính toàn vẹn dữ liệu kế toán, tài khoản này không được phép xóa.");
            }

            bool ok = _nhanVienDAL.XoaNhanVien(maNV);
            if (!ok)
                throw new Exception("Xóa tài khoản nhân viên thất bại.");
        }

        public void KiemTraRangBuoc(string maNV, out int soPN, out int soPX)
        {
            _nhanVienDAL.KiemTraRangBuocGiaoDich(maNV, out soPN, out soPX);
        }
    }
}
