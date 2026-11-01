using System;
using System.Collections.Generic;
using LTWIN_N4_QLKH.DAL;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.BUS
{
    public class KiemKeBUS
    {
        public List<KiemKeItemDTO> LayDanhSachHangHoaKiemKe()
        {
            return KiemKeDAL.LayDanhSachHangHoaKiemKe();
        }

        public string SinhMaPhieuKiemKe(DateTime ngayKiemKe)
        {
            return "KK" + ngayKiemKe.ToString("yyyyMMddHHmm");
        }

        public List<KiemKeItemDTO> LocDanhSachCoDoLech(IList<KiemKeItemDTO> danhSach)
        {
            List<KiemKeItemDTO> lech = new List<KiemKeItemDTO>();
            if (danhSach == null) return lech;

            foreach (KiemKeItemDTO item in danhSach)
            {
                if (item.ThucDem < 0)
                {
                    throw new ArgumentException("Số lượng thực đếm của mã hàng '" + item.MaSP + "' không được nhỏ hơn 0.");
                }
                if (item.DoLech != 0)
                {
                    lech.Add(item);
                }
            }
            return lech;
        }

        public void CanBangKhoTuDong(
            string maPhieuKK,
            DateTime ngayKK,
            string maNV,
            string kho,
            string ghiChu,
            IList<KiemKeItemDTO> toanBoDanhSach)
        {
            List<KiemKeItemDTO> danhSachLech = LocDanhSachCoDoLech(toanBoDanhSach);
            if (danhSachLech.Count == 0)
            {
                throw new InvalidOperationException("Tất cả mặt hàng đều đã khớp kho (Độ lệch = 0), không cần cân bằng.");
            }

            KiemKeDAL.CanBangKhoTuDong(maPhieuKK, ngayKK, maNV, kho, ghiChu, danhSachLech);
        }
    }
}