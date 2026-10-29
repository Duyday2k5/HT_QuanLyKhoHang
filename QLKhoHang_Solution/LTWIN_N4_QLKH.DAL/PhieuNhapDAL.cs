using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LTWIN_N4_QLKH.DTO;

namespace LTWIN_N4_QLKH.DAL
{
    public static class PhieuNhapDAL
    {
        public static DataTable LayDanhSachNhaCungCap()
        {
            const string sql = @"
                SELECT MaNCC, TenNCC, DienThoai, DiaChi
                FROM dbo.NhaCungCap
                ORDER BY TenNCC;";
            return DatabaseHelper.ExecuteQuery(sql, null);
        }

        public static DataTable LayDanhSachHangHoa()
        {
            const string sql = @"
                SELECT MaSP, TenSP, LoaiHang, DonViTinh, SoLuongTon, TonToiThieu, TonToiDa, GiaNhapGanNhat,
                       (MaSP + N' - ' + TenSP) AS HienThi
                FROM dbo.HangHoa
                ORDER BY MaSP;";
            return DatabaseHelper.ExecuteQuery(sql, null);
        }

        public static string SinhMaPhieuNhapMoi(DateTime ngayNhap)
        {
            string prefix = "PN" + ngayNhap.ToString("yyyyMMdd");
            const string sql = @"
                SELECT TOP 1 MaPN
                FROM dbo.PhieuNhap
                WHERE MaPN LIKE @Prefix + '%'
                ORDER BY MaPN DESC;";

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

        /// <summary>
        /// Lưu Phiếu Nhập + Chi Tiết Phiếu Nhập + Cộng dồn Tồn Kho trong cùng 1 SqlTransaction (ACID).
        /// </summary>
        public static void LuuPhieuNhap(PhieuNhapDTO phieu, IList<ChiTietPhieuNhapDTO> chiTietList)
        {
            if (phieu == null) throw new ArgumentNullException(nameof(phieu));
            if (chiTietList == null || chiTietList.Count == 0)
                throw new ArgumentException("Danh sách mặt hàng nhập không được rỗng.", nameof(chiTietList));

            using (SqlConnection conn = DatabaseHelper.CreateConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        const string sqlMaster = @"
                            INSERT INTO dbo.PhieuNhap (MaPN, NgayNhap, MaNCC, MaNV, TongTienNhap, GhiChu)
                            VALUES (@MaPN, @NgayNhap, @MaNCC, @MaNV, @TongTienNhap, @GhiChu);";

                        using (SqlCommand cmdMaster = new SqlCommand(sqlMaster, conn, tran))
                        {
                            cmdMaster.Parameters.Add(new SqlParameter("@MaPN", SqlDbType.VarChar, 20) { Value = phieu.MaPN });
                            cmdMaster.Parameters.Add(new SqlParameter("@NgayNhap", SqlDbType.DateTime) { Value = phieu.NgayNhap });
                            cmdMaster.Parameters.Add(new SqlParameter("@MaNCC", SqlDbType.VarChar, 15) { Value = phieu.MaNCC });
                            cmdMaster.Parameters.Add(new SqlParameter("@MaNV", SqlDbType.VarChar, 10) { Value = phieu.MaNV });
                            cmdMaster.Parameters.Add(new SqlParameter("@TongTienNhap", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = phieu.TongTienNhap });
                            cmdMaster.Parameters.Add(new SqlParameter("@GhiChu", SqlDbType.NVarChar, 255)
                            {
                                Value = string.IsNullOrWhiteSpace(phieu.GhiChu) ? (object)DBNull.Value : phieu.GhiChu.Trim()
                            });
                            cmdMaster.ExecuteNonQuery();
                        }

                        // Lưu ý: Cột ThanhTien là PERSISTED Computed Column trong SQL nên không đưa vào INSERT
                        const string sqlDetail = @"
                            INSERT INTO dbo.ChiTietPhieuNhap (MaPN, MaSP, SoLuongNhap, DonGiaNhap)
                            VALUES (@MaPN, @MaSP, @SoLuongNhap, @DonGiaNhap);";

                        const string sqlUpdateStock = @"
                            UPDATE dbo.HangHoa
                            SET SoLuongTon = SoLuongTon + @SoLuongNhap,
                                GiaNhapGanNhat = @DonGiaNhap
                            WHERE MaSP = @MaSP;";

                        foreach (ChiTietPhieuNhapDTO item in chiTietList)
                        {
                            using (SqlCommand cmdDetail = new SqlCommand(sqlDetail, conn, tran))
                            {
                                cmdDetail.Parameters.Add(new SqlParameter("@MaPN", SqlDbType.VarChar, 20) { Value = phieu.MaPN });
                                cmdDetail.Parameters.Add(new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = item.MaSP });
                                cmdDetail.Parameters.Add(new SqlParameter("@SoLuongNhap", SqlDbType.Int) { Value = item.SoLuongNhap });
                                cmdDetail.Parameters.Add(new SqlParameter("@DonGiaNhap", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = item.DonGiaNhap });
                                cmdDetail.ExecuteNonQuery();
                            }

                            using (SqlCommand cmdStock = new SqlCommand(sqlUpdateStock, conn, tran))
                            {
                                cmdStock.Parameters.Add(new SqlParameter("@SoLuongNhap", SqlDbType.Int) { Value = item.SoLuongNhap });
                                cmdStock.Parameters.Add(new SqlParameter("@DonGiaNhap", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = item.DonGiaNhap });
                                cmdStock.Parameters.Add(new SqlParameter("@MaSP", SqlDbType.VarChar, 20) { Value = item.MaSP });

                                int updated = cmdStock.ExecuteNonQuery();
                                if (updated == 0)
                                {
                                    throw new InvalidOperationException("Không tìm thấy mã sản phẩm '" + item.MaSP + "' để cập nhật tồn kho.");
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
    }
}