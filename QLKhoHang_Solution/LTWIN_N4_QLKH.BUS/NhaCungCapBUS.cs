using System;
using System.Collections.Generic;
using System.Data;
using LTWIN_N4_QLKH.DAL;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.BUS
{
    /// <summary>
    /// Tầng xử lý nghiệp vụ (BUS) cho danh mục Nhà Cung Cấp.
    /// Kiểm tra toàn bộ ràng buộc nghiệp vụ trước khi gọi xuống tầng DAL.
    /// </summary>
    public class NhaCungCapBUS
    {
        public DataTable LayDanhSachNhaCungCap(string tuKhoa = "")
        {
            return NhaCungCapDAL.GetAllDataTable(tuKhoa);
        }

        public List<NhaCungCapDTO> LayDanhSachNhaCungCapDTO(string tuKhoa = "")
        {
            return NhaCungCapDAL.GetAll(tuKhoa);
        }

        public NhaCungCapDTO LayNhaCungCapTheoMa(string maNCC)
        {
            if (string.IsNullOrWhiteSpace(maNCC)) return null;
            return NhaCungCapDAL.GetById(maNCC);
        }

        public void ThemNhaCungCap(NhaCungCapDTO ncc)
        {
            KiemTraRangBuocNghiepVu(ncc);

            if (NhaCungCapDAL.Exists(ncc.MaNCC))
            {
                throw new InvalidOperationException($"Mã nhà cung cấp '{ncc.MaNCC}' đã tồn tại trong hệ thống.");
            }

            if (!NhaCungCapDAL.Insert(ncc))
            {
                throw new Exception("Thao tác thêm mới nhà cung cấp không thành công.");
            }
        }

        public void CapNhatNhaCungCap(NhaCungCapDTO ncc)
        {
            KiemTraRangBuocNghiepVu(ncc);

            if (!NhaCungCapDAL.Exists(ncc.MaNCC))
            {
                throw new InvalidOperationException($"Mã nhà cung cấp '{ncc.MaNCC}' không tồn tại trong hệ thống.");
            }

            if (!NhaCungCapDAL.Update(ncc))
            {
                throw new Exception("Thao tác cập nhật thông tin nhà cung cấp không thành công.");
            }
        }

        public void XoaNhaCungCap(string maNCC)
        {
            if (string.IsNullOrWhiteSpace(maNCC))
            {
                throw new ArgumentException("Mã nhà cung cấp cần xóa không được để trống.");
            }

            if (NhaCungCapDAL.HasTransactions(maNCC))
            {
                throw new InvalidOperationException("Không thể xóa nhà cung cấp này vì đã phát sinh lịch sử phiếu nhập hàng trong kho!");
            }

            if (!NhaCungCapDAL.Delete(maNCC))
            {
                throw new Exception("Thao tác xóa nhà cung cấp không thành công.");
            }
        }

        public DataTable TimKiemNhaCungCap(string tuKhoa)
        {
            return NhaCungCapDAL.GetAllDataTable(tuKhoa);
        }

        private void KiemTraRangBuocNghiepVu(NhaCungCapDTO ncc)
        {
            if (ncc == null) throw new ArgumentNullException(nameof(ncc));

            if (string.IsNullOrWhiteSpace(ncc.MaNCC))
                throw new ArgumentException("Vui lòng nhập Mã nhà cung cấp.");
            if (ncc.MaNCC.Trim().Length > 15)
                throw new ArgumentException("Mã nhà cung cấp không được vượt quá 15 ký tự.");

            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
                throw new ArgumentException("Vui lòng nhập Tên công ty cung ứng.");
            if (ncc.TenNCC.Trim().Length > 150)
                throw new ArgumentException("Tên công ty cung ứng không được vượt quá 150 ký tự.");

            if (string.IsNullOrWhiteSpace(ncc.DienThoai))
                throw new ArgumentException("Vui lòng nhập Số điện thoại liên hệ.");
            if (ncc.DienThoai.Trim().Length > 20)
                throw new ArgumentException("Số điện thoại không được vượt quá 20 ký tự.");

            if (!string.IsNullOrWhiteSpace(ncc.Email) && ncc.Email.Trim().Length > 100)
                throw new ArgumentException("Email không được vượt quá 100 ký tự.");

            if (!string.IsNullOrWhiteSpace(ncc.DiaChi) && ncc.DiaChi.Trim().Length > 250)
                throw new ArgumentException("Địa chỉ không được vượt quá 250 ký tự.");

            if (!string.IsNullOrWhiteSpace(ncc.NguoiLienHe) && ncc.NguoiLienHe.Trim().Length > 100)
                throw new ArgumentException("Tên người liên hệ không được vượt quá 100 ký tự.");
        }
    }
}

