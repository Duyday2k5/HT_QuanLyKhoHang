using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.DAL
{
    public static class KiemKeDAL
    {
        public static List<KiemKeItemDTO> LayDanhSachHangHoaKiemKe()
        {
            const string sql = @"
                SELECT MaSP, TenSP, LoaiHang, DonViTinh, SoLuongTon, GiaNhapGanNhat
                FROM dbo.HangHoa
                ORDER BY MaSP;";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, null);
            List<KiemKeItemDTO> list = new List<KiemKeItemDTO>();

            foreach (DataRow row in dt.Rows)
            {
                int ton = Convert.ToInt32(row["SoLuongTon"]);
                list.Add(new KiemKeItemDTO
                {
                    MaSP = Convert.ToString(row["MaSP"]),
                    TenSP = Convert.ToString(row["TenSP"]),
                    LoaiHang = Convert.ToString(row["LoaiHang"]),
                    DonViTinh = Convert.ToString(row["DonViTinh"]),
                    TonSoSach = ton,
                    ThucDem = ton, // Mặc định thực đếm ban đầu khớp sổ sách
                    GiaNhapGanNhat = Convert.ToDecimal(row["GiaNhapGanNhat"])
                });
            }

            return list;
        }

        /// <summary>
        /// Cân bằng tồn kho tự động:
        /// - Hàng thiếu (DoLech < 0): Tự sinh Phiếu Xuất cân bằng kho & trừ tồn.
        /// - Hàng thừa (DoLech > 0): Tự sinh Phiếu Nhập cân bằng kho & cộng tồn.
        /// Nhờ đó Thẻ Kho (TV4) sẽ ghi nhận đầy đủ lịch sử giao dịch kiểm kê!
        /// </summary>
        public static void CanBangKhoTuDong(
            string maPhieuKiemKe,
            DateTime ngayKiemKe,
            string maNV,
            string khoKiemKe,
            string ghiChu,
            IList<KiemKeItemDTO> danhSachLech)
        {
            if (danhSachLech == null || danhSachLech.Count == 0)
                throw new ArgumentException("Không có mặt hàng nào lệch kho để cân bằng.");

            List<KiemKeItemDTO> hangThieu = new List<KiemKeItemDTO>();
            List<KiemKeItemDTO> hangThua = new List<KiemKeItemDTO>();

            foreach (KiemKeItemDTO item in danhSachLech)
            {
                if (item.DoLech < 0) hangThieu.Add(item);
                else if (item.DoLech > 0) hangThua.Add(item);
            }

            using (SqlConnection conn = DatabaseHelper.CreateConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        // 1. Xử lý các mặt hàng THIẾU -> Tạo Phiếu Xuất cân bằng
                        if (hangThieu.Count > 0)
                        {
                            string maPX = SinhMaPhieuXuatTrongTransaction(conn, tran, ngayKiemKe);
                            decimal tongTienXuat = 0m;
                            foreach (KiemKeItemDTO x in hangThieu)
                            {
                                tongTienXuat += Math.Abs(x.DoLech) * x.GiaNhapGanNhat;
                            }

                            const string sqlPX = @"
                                INSERT INTO dbo.PhieuXuat (MaPX, NgayXuat, MaNV, NguoiNhan, LyDoXuat, TongTienXuat, GhiChu)
                                VALUES (@MaPX, @NgayXuat, @MaNV, @NguoiNhan, @LyDoXuat, @TongTienXuat, @GhiChu);";

                            using (SqlCommand cmdPX = new SqlCommand(sqlPX, conn, tran))
                            {
                                cmdPX.Parameters.Add(new SqlParameter("@MaPX", SqlDbType.VarChar, 20) { Value = maPX });
                                cmdPX.Parameters.Add(new SqlParameter("@NgayXuat", SqlDbType.DateTime) { Value = ngayKiemKe });
                                cmdPX.Parameters.Add(new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = maNV });
                                cmdPX.Parameters.Add(new SqlParameter("@NguoiNhan", SqlDbType.NVarChar, 100) { Value = "Kiểm kê (" + khoKiemKe + ")" });
                                cmdPX.Parameters.Add(new SqlParameter("@LyDoXuat", SqlDbType.NVarChar, 150) { Value = "Xuất cân bằng kiểm kê (" + maPhieuKiemKe + ")" });
                                cmdPX.Parameters.Add(new SqlParameter("@TongTienXuat", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = tongTienXuat });
                                cmdPX.Parameters.Add(new SqlParameter("@GhiChu", SqlDbType.NVarChar, 255) { Value = (object)(ghiChu ?? "Cân bằng hao hụt kiểm kê") });
                                cmdPX.ExecuteNonQuery();
                            }

                            foreach (KiemKeItemDTO item in hangThieu)
                            {
                                int slXuat = Math.Abs(item.DoLech);
                                using (SqlCommand cmdCT = new SqlCommand(
                                    "INSERT INTO dbo.ChiTietPhieuXuat (MaPX, MaSP, SoLuongXuat, DonGiaXuat) VALUES (@MaPX, @MaSP, @SL, @Gia);", conn, tran))
                                {
                                    cmdCT.Parameters.Add(new SqlParameter("@MaPX", SqlDbType.VarChar, 20) { Value = maPX });
                                    cmdCT.Parameters.Add(new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = item.MaSP });
                                    cmdCT.Parameters.Add(new SqlParameter("@SL", SqlDbType.Int) { Value = slXuat });
                                    cmdCT.Parameters.Add(new SqlParameter("@Gia", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = item.GiaNhapGanNhat });
                                    cmdCT.ExecuteNonQuery();
                                }

                                using (SqlCommand cmdUpd = new SqlCommand(
                                    "UPDATE dbo.HangHoa SET SoLuongTon = @ThucDem WHERE MaSP = @MaSP;", conn, tran))
                                {
                                    cmdUpd.Parameters.Add(new SqlParameter("@ThucDem", SqlDbType.Int) { Value = item.ThucDem });
                                    cmdUpd.Parameters.Add(new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = item.MaSP });
                                    cmdUpd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 2. Xử lý các mặt hàng THỪA -> Tạo Phiếu Nhập cân bằng
                        if (hangThua.Count > 0)
                        {
                            string maNCC = DamBaoNhaCungCapKiemKe(conn, tran);
                            string maPN = SinhMaPhieuNhapTrongTransaction(conn, tran, ngayKiemKe);
                            decimal tongTienNhap = 0m;
                            foreach (KiemKeItemDTO n in hangThua)
                            {
                                tongTienNhap += n.DoLech * n.GiaNhapGanNhat;
                            }

                            const string sqlPN = @"
                                INSERT INTO dbo.PhieuNhap (MaPN, NgayNhap, MaNCC, MaNV, TongTienNhap, GhiChu)
                                VALUES (@MaPN, @NgayNhap, @MaNCC, @MaNV, @TongTienNhap, @GhiChu);";

                            using (SqlCommand cmdPN = new SqlCommand(sqlPN, conn, tran))
                            {
                                cmdPN.Parameters.Add(new SqlParameter("@MaPN", SqlDbType.VarChar, 20) { Value = maPN });
                                cmdPN.Parameters.Add(new SqlParameter("@NgayNhap", SqlDbType.DateTime) { Value = ngayKiemKe });
                                cmdPN.Parameters.Add(new SqlParameter("@MaNCC", SqlDbType.VarChar, 15) { Value = maNCC });
                                cmdPN.Parameters.Add(new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = maNV });
                                cmdPN.Parameters.Add(new SqlParameter("@TongTienNhap", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = tongTienNhap });
                                cmdPN.Parameters.Add(new SqlParameter("@GhiChu", SqlDbType.NVarChar, 255)
                                {
                                    Value = "Nhập cân bằng kiểm kê (" + maPhieuKiemKe + ") - " + (ghiChu ?? "")
                                });
                                cmdPN.ExecuteNonQuery();
                            }

                            foreach (KiemKeItemDTO item in hangThua)
                            {
                                int slNhap = item.DoLech;
                                using (SqlCommand cmdCT = new SqlCommand(
                                    "INSERT INTO dbo.ChiTietPhieuNhap (MaPN, MaSP, SoLuongNhap, DonGiaNhap) VALUES (@MaPN, @MaSP, @SL, @Gia);", conn, tran))
                                {
                                    cmdCT.Parameters.Add(new SqlParameter("@MaPN", SqlDbType.VarChar, 20) { Value = maPN });
                                    cmdCT.Parameters.Add(new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = item.MaSP });
                                    cmdCT.Parameters.Add(new SqlParameter("@SL", SqlDbType.Int) { Value = slNhap });
                                    cmdCT.Parameters.Add(new SqlParameter("@Gia", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = item.GiaNhapGanNhat });
                                    cmdCT.ExecuteNonQuery();
                                }

                                using (SqlCommand cmdUpd = new SqlCommand(
                                    "UPDATE dbo.HangHoa SET SoLuongTon = @ThucDem WHERE MaSP = @MaSP;", conn, tran))
                                {
                                    cmdUpd.Parameters.Add(new SqlParameter("@ThucDem", SqlDbType.Int) { Value = item.ThucDem });
                                    cmdUpd.Parameters.Add(new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = item.MaSP });
                                    cmdUpd.ExecuteNonQuery();
                                }
                            }
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        private static string DamBaoNhaCungCapKiemKe(SqlConnection conn, SqlTransaction tran)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 MaNCC FROM dbo.NhaCungCap ORDER BY MaNCC;", conn, tran))
            {
                object existing = cmd.ExecuteScalar();
                if (existing != null && existing != DBNull.Value)
                {
                    return Convert.ToString(existing);
                }
            }

            const string sqlInsertNCC = @"
                INSERT INTO dbo.NhaCungCap (MaNCC, TenNCC, DienThoai, DiaChi, NguoiLienHe)
                VALUES ('NCC_KK', N'Điều chỉnh Kiểm kê Nội bộ', '0000000000', N'Kho nội bộ', N'Hệ thống');";
            using (SqlCommand cmdIns = new SqlCommand(sqlInsertNCC, conn, tran))
            {
                cmdIns.ExecuteNonQuery();
            }
            return "NCC_KK";
        }

        private static string SinhMaPhieuXuatTrongTransaction(SqlConnection conn, SqlTransaction tran, DateTime date)
        {
            string prefix = "PX" + date.ToString("yyyyMMdd");
            using (SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 MaPX FROM dbo.PhieuXuat WHERE MaPX LIKE @P + '%' ORDER BY MaPX DESC;", conn, tran))
            {
                cmd.Parameters.Add(new SqlParameter("@P", SqlDbType.VarChar, 20) { Value = prefix });
                object res = cmd.ExecuteScalar();
                int next = 1;
                if (res != null && res != DBNull.Value)
                {
                    string s = Convert.ToString(res).Trim();
                    int parsed;
                    if (s.Length > prefix.Length && int.TryParse(s.Substring(prefix.Length), out parsed))
                        next = parsed + 1;
                }
                return prefix + next.ToString("D2");
            }
        }

        private static string SinhMaPhieuNhapTrongTransaction(SqlConnection conn, SqlTransaction tran, DateTime date)
        {
            string prefix = "PN" + date.ToString("yyyyMMdd");
            using (SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 MaPN FROM dbo.PhieuNhap WHERE MaPN LIKE @P + '%' ORDER BY MaPN DESC;", conn, tran))
            {
                cmd.Parameters.Add(new SqlParameter("@P", SqlDbType.VarChar, 20) { Value = prefix });
                object res = cmd.ExecuteScalar();
                int next = 1;
                if (res != null && res != DBNull.Value)
                {
                    string s = Convert.ToString(res).Trim();
                    int parsed;
                    if (s.Length > prefix.Length && int.TryParse(s.Substring(prefix.Length), out parsed))
                        next = parsed + 1;
                }
                return prefix + next.ToString("D2");
            }
        }
    }
}