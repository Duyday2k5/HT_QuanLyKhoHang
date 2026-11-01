using System;
using System.Collections.Generic;
using System.Data;
using LTWIN_N4_QLKH.DAL;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.BUS
{
    /// <summary>
    /// Tầng xử lý nghiệp vụ (BUS) cho danh mục Hàng Hóa.
    /// Kiểm tra toàn bộ ràng buộc nghiệp vụ trước khi gọi xuống tầng DAL.
    /// </summary>
    public class HangHoaBUS
    {
        public DataTable LayDanhSachHangHoa(string tuKhoa = "")
        {
            return HangHoaDAL.GetAllDataTable(tuKhoa);
        }

        public DataTable TimKiemNangCao(string tuKhoa = "", string loaiHang = "", string trangThaiTon = "", string sapXep = "")
        {
            return HangHoaDAL.TimKiemNangCao(tuKhoa, loaiHang, trangThaiTon, sapXep);
        }

        public List<HangHoaDTO> LayDanhSachHangHoaDTO(string tuKhoa = "")
        {
            return HangHoaDAL.GetAll(tuKhoa);
        }

        public HangHoaDTO LayHangHoaTheoMa(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP)) return null;
            return HangHoaDAL.GetById(maSP);
        }

        public void ThemHangHoa(HangHoaDTO hh)
        {
            KiemTraRangBuocNghiepVu(hh);

            if (HangHoaDAL.Exists(hh.MaSP))
            {
                throw new InvalidOperationException($"Mã sản phẩm '{hh.MaSP}' đã tồn tại trong hệ thống.");
            }

            if (!HangHoaDAL.Insert(hh))
            {
                throw new Exception("Thao tác thêm mới sản phẩm vào cơ sở dữ liệu không thành công.");
            }
        }

        public void CapNhatHangHoa(HangHoaDTO hh)
        {
            KiemTraRangBuocNghiepVu(hh);

            if (!HangHoaDAL.Exists(hh.MaSP))
            {
                throw new InvalidOperationException($"Mã sản phẩm '{hh.MaSP}' không tồn tại trong hệ thống.");
            }

            if (!HangHoaDAL.Update(hh))
            {
                throw new Exception("Thao tác cập nhật thông tin sản phẩm không thành công.");
            }
        }

        public void XoaHangHoa(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP))
            {
                throw new ArgumentException("Mã sản phẩm cần xóa không được để trống.");
            }

            if (HangHoaDAL.HasTransactions(maSP))
            {
                throw new InvalidOperationException("Không thể xóa sản phẩm này vì đã phát sinh lịch sử giao dịch trong phiếu nhập/xuất kho!");
            }

            if (!HangHoaDAL.Delete(maSP))
            {
                throw new Exception("Thao tác xóa sản phẩm không thành công.");
            }
        }

        public List<string> LayDanhSachLoaiHang()
        {
            return HangHoaDAL.GetDistinctLoaiHang();
        }

        public List<string> LayDanhSachDonViTinh()
        {
            return HangHoaDAL.GetDistinctDonViTinh();
        }

        private void KiemTraRangBuocNghiepVu(HangHoaDTO hh)
        {
            if (hh == null) throw new ArgumentNullException(nameof(hh));

            if (string.IsNullOrWhiteSpace(hh.MaSP))
                throw new ArgumentException("Vui lòng nhập Mã sản phẩm.");
            if (hh.MaSP.Trim().Length > 20)
                throw new ArgumentException("Mã sản phẩm không được vượt quá 20 ký tự.");

            if (string.IsNullOrWhiteSpace(hh.TenSP))
                throw new ArgumentException("Vui lòng nhập Tên sản phẩm.");
            if (hh.TenSP.Trim().Length > 150)
                throw new ArgumentException("Tên sản phẩm không được vượt quá 150 ký tự.");

            if (string.IsNullOrWhiteSpace(hh.LoaiHang))
                throw new ArgumentException("Vui lòng chọn hoặc nhập Nhóm loại hàng.");

            if (string.IsNullOrWhiteSpace(hh.DonViTinh))
                throw new ArgumentException("Vui lòng chọn hoặc nhập Đơn vị tính.");

            if (hh.GiaNhapGanNhat < 0)
                throw new ArgumentException("Đơn giá nhập phải là số không âm (>= 0).");

            if (hh.TonToiThieu < 0)
                throw new ArgumentException("Ngưỡng 'Tồn tối thiểu' phải là số không âm (>= 0).");

            if (hh.TonToiDa < hh.TonToiThieu)
                throw new ArgumentException("Ngưỡng 'Tồn tối đa' phải lớn hơn hoặc bằng 'Tồn tối thiểu'.");
        }
    }
}
