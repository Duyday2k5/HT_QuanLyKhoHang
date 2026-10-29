using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.DAL
{
    public static class PhieuXuatDAL
    {
        public static string SinhMaPhieuXuatMoi(DateTime ngayXuat)
        {
            string prefix = "PX" + ngayXuat.ToString("yyyyMMdd");
            const string sql = @"
                SELECT TOP 1 MaPX
                FROM dbo.PhieuXuat
                WHERE MaPX LIKE @Prefix + '%'
                ORDER BY MaPX DESC;";

            object result = DatabaseHelper.ExecuteScalar(sql, new[]
            {
                new SqlParameter("@Prefix", SqlDbType.VarChar, 20) { Value = prefix }
            });

            int nextNumber = 1;
            if (result != null && result != DBNull.Value)
            {
                string lastCode = Convert.ToString(result).Trim();
                if (lastCode.Length > prefix.Length)
                {
                    string suffix = lastCode.Substring(prefix.Length);
                    int parsed;
                    if (int.TryParse(suffix, out parsed))
                    {
                        nextNumber = parsed + 1;
                    }
                }
            }

            return prefix + nextNumber.ToString("D2");
        }

        public static int LaySoLuongTonHienTai(string maSP)
        {
            const string sql = "SELECT SoLuongTon FROM dbo.HangHoa WHERE MaSP = @MaSP;";
            object result = DatabaseHelper.ExecuteScalar(sql, new[]
            {
                new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = maSP }
            });

            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Lưu Phiếu Xuất + Chi Tiết Phiếu Xuất + Trừ Tồn Kho trong 1 SqlTransaction (Chặn xuất âm tuyệt đối).
        /// </summary>
        public static void LuuPhieuXuat(PhieuXuatDTO phieu, IList<ChiTietPhieuXuatDTO> chiTietList)
        {
            if (phieu == null) throw new ArgumentNullException(nameof(phieu));
            if (chiTietList == null || chiTietList.Count == 0)
                throw new ArgumentException("Danh sách mặt hàng xuất không được rỗng.", nameof(chiTietList));

            using (SqlConnection conn = DatabaseHelper.CreateConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        const string sqlMaster = @"
                            INSERT INTO dbo.PhieuXuat (MaPX, NgayXuat, MaNV, NguoiNhan, LyDoXuat, TongTienXuat, GhiChu)
                            VALUES (@MaPX, @NgayXuat, @MaNV, @NguoiNhan, @LyDoXuat, @TongTienXuat, @GhiChu);";

                        using (SqlCommand cmdMaster = new SqlCommand(sqlMaster, conn, tran))
                        {
                            cmdMaster.Parameters.Add(new SqlParameter("@MaPX", SqlDbType.VarChar, 20) { Value = phieu.MaPX });
                            cmdMaster.Parameters.Add(new SqlParameter("@NgayXuat", SqlDbType.DateTime) { Value = phieu.NgayXuat });
                            cmdMaster.Parameters.Add(new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = phieu.MaNV });
                            cmdMaster.Parameters.Add(new SqlParameter("@NguoiNhan", SqlDbType.NVarChar, 100) { Value = phieu.NguoiNhan.Trim() });
                            cmdMaster.Parameters.Add(new SqlParameter("@LyDoXuat", SqlDbType.NVarChar, 150) { Value = phieu.LyDoXuat.Trim() });
                            cmdMaster.Parameters.Add(new SqlParameter("@TongTienXuat", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = phieu.TongTienXuat });
                            cmdMaster.Parameters.Add(new SqlParameter("@GhiChu", SqlDbType.NVarChar, 255)
                            {
                                Value = string.IsNullOrWhiteSpace(phieu.GhiChu) ? (object)DBNull.Value : phieu.GhiChu.Trim()
                            });
                            cmdMaster.ExecuteNonQuery();
                        }

                        const string sqlDetail = @"
                            INSERT INTO dbo.ChiTietPhieuXuat (MaPX, MaSP, SoLuongXuat, DonGiaXuat)
                            VALUES (@MaPX, @MaSP, @SoLuongXuat, @DonGiaXuat);";

                        // Điều kiện AND SoLuongTon >= @SoLuongXuat chặn xuất âm ngay tại tầng Database
                        const string sqlDeductStock = @"
                            UPDATE dbo.HangHoa
                            SET SoLuongTon = SoLuongTon - @SoLuongXuat
                            WHERE MaSP = @MaSP AND SoLuongTon >= @SoLuongXuat;";

                        foreach (ChiTietPhieuXuatDTO item in chiTietList)
                        {
                            using (SqlCommand cmdStock = new SqlCommand(sqlDeductStock, conn, tran))
                            {
                                cmdStock.Parameters.Add(new SqlParameter("@SoLuongXuat", SqlDbType.Int) { Value = item.SoLuongXuat });
                                cmdStock.Parameters.Add(new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = item.MaSP });

                                int affected = cmdStock.ExecuteNonQuery();
                                if (affected == 0)
                                {
                                    throw new InvalidOperationException(
                                        "Sản phẩm '" + item.TenSP + "' (" + item.MaSP + ") không đủ số lượng tồn kho để xuất (Chặn xuất âm)!");
                                }
                            }

                            using (SqlCommand cmdDetail = new SqlCommand(sqlDetail, conn, tran))
                            {
                                cmdDetail.Parameters.Add(new SqlParameter("@MaPX", SqlDbType.VarChar, 20) { Value = phieu.MaPX });
                                cmdDetail.Parameters.Add(new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = item.MaSP });
                                cmdDetail.Parameters.Add(new SqlParameter("@SoLuongXuat", SqlDbType.Int) { Value = item.SoLuongXuat });
                                cmdDetail.Parameters.Add(new SqlParameter("@DonGiaXuat", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = item.DonGiaXuat });
                                cmdDetail.ExecuteNonQuery();
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
    }
}