using System;
using LTWIN_N4_QLKH.DAL;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.BUS
{
    /// <summary>
    /// Kiểm tra quyền, xác nhận kết nối rồi mới lưu server name cho máy hiện tại.
    /// </summary>
    public class CauHinhCSDL_BUS
    {
        private readonly CauHinhCSDL_DAL _cauHinhDAL = new CauHinhCSDL_DAL();
        private readonly PhanQuyenBUS _phanQuyenBUS = new PhanQuyenBUS();

        public string LayServerNameHienTai()
        {
            return _cauHinhDAL.LayServerNameHienTai();
        }

        public string KiemTraVaLuu(NhanVienDTO nguoiDung, string serverName)
        {
            _phanQuyenBUS.YeuCauQuyen(nguoiDung, ChucNang.KetNoiCSDL);
            if (string.IsNullOrWhiteSpace(serverName))
            {
                throw new ArgumentException("Vui lòng nhập tên SQL Server.", nameof(serverName));
            }

            return _cauHinhDAL.KiemTraVaLuu(serverName);
        }
    }
}
