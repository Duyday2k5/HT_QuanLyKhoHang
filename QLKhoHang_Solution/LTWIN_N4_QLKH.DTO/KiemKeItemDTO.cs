using System;

namespace LTWIN_N4_QLKH.DTO
{
    public class KiemKeItemDTO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string LoaiHang { get; set; }
        public string DonViTinh { get; set; }
        public int TonSoSach { get; set; }
        public int ThucDem { get; set; }
        public decimal GiaNhapGanNhat { get; set; }

        public int DoLech
        {
            get { return ThucDem - TonSoSach; }
        }

        public string KetLuan
        {
            get
            {
                int lech = DoLech;
                if (lech == 0) return "Khớp kho";
                if (lech < 0) return "Thiếu " + Math.Abs(lech);
                return "Thừa " + lech;
            }
        }
    }
}