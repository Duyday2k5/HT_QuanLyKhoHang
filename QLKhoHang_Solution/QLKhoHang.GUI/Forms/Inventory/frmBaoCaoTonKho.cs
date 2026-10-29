using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;
using QLKhoHang.BUS;
using QLKhoHang.GUI.Helpers;

namespace QLKhoHang.GUI.Forms.Inventory
{
    public partial class frmBaoCaoTonKho : Form
    {
        private readonly CultureInfo _culture = CultureInfo.GetCultureInfo("vi-VN");
        private readonly TheKhoBUS _theKhoBUS = new TheKhoBUS();
        private DataTable _baoCaoTable;

        public frmBaoCaoTonKho()
        {
            InitializeComponent();
            BackColor = ColorTranslator.FromHtml("#F8FAFC");
        }

        private void frmBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today;

            // Thiết lập chuẩn giao diện
            this.Font = UIThemeHelper.ControlFont;
            if (dgvBaoCaoTonKho != null)
            {
                UIThemeHelper.ApplyStandardGridStyle(dgvBaoCaoTonKho);
                dgvBaoCaoTonKho.ReadOnly = true;
                dgvBaoCaoTonKho.AllowUserToAddRows = false;
                dgvBaoCaoTonKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }

            DinhDangNutThanhCongCu();
            NapDanhSachLoaiHang();
            CapNhatBieuDo(null);
            CanBangSplitter();
        }

        private void DinhDangNutThanhCongCu()
        {
            Button[] toolButtons = new Button[] { btnToanManHinhBang, btnXemCaHaiBang, btnToanManHinhChart, btnXemCaHaiChart };
            foreach (var b in toolButtons)
            {
                if (b == null) continue;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 1;
                b.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
                b.BackColor = Color.White;
                b.ForeColor = Color.FromArgb(51, 65, 85);
                b.Cursor = Cursors.Hand;
                b.MouseEnter += (s, ev) => { ((Button)s).BackColor = Color.FromArgb(226, 232, 240); };
                b.MouseLeave += (s, ev) => { ((Button)s).BackColor = Color.White; };
            }
        }

        private void btnToanManHinhBang_Click(object sender, EventArgs e)
        {
            splitBaoCao.Panel2Collapsed = true;
            splitBaoCao.Panel1Collapsed = false;
        }

        private void btnToanManHinhChart_Click(object sender, EventArgs e)
        {
            splitBaoCao.Panel1Collapsed = true;
            splitBaoCao.Panel2Collapsed = false;
        }

        private void btnXemCaHai_Click(object sender, EventArgs e)
        {
            splitBaoCao.Panel1Collapsed = false;
            splitBaoCao.Panel2Collapsed = false;
            CanBangSplitter();
        }

        private void frmBaoCaoTonKho_Resize(object sender, EventArgs e)
        {
            CanBangSplitter();
        }

        private void CanBangSplitter()
        {
            try
            {
                if (splitBaoCao != null && splitBaoCao.Width > 0 && !splitBaoCao.Panel1Collapsed && !splitBaoCao.Panel2Collapsed)
                {
                    int target = (int)(splitBaoCao.Width * 0.58);
                    if (target >= splitBaoCao.Panel1MinSize && (splitBaoCao.Width - target) >= splitBaoCao.Panel2MinSize)
                    {
                        splitBaoCao.SplitterDistance = target;
                    }
                }
            }
            catch
            {
            }
        }

        private void NapDanhSachLoaiHang()
        {
            try
            {
                DataTable loaiHang = _theKhoBUS.LayDanhSachLoaiHang();
                if (loaiHang == null)
                {
                    loaiHang = new DataTable();
                    loaiHang.Columns.Add("LoaiHang", typeof(string));
                }

                DataRow tatCa = loaiHang.NewRow();
                tatCa["LoaiHang"] = "Tất cả";
                loaiHang.Rows.InsertAt(tatCa, 0);

                cboLoaiHang.DisplayMember = "LoaiHang";
                cboLoaiHang.ValueMember = "LoaiHang";
                cboLoaiHang.DataSource = loaiHang;
                cboLoaiHang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                btnLocBaoCao.Enabled = false;
                HienThiLoi("Không thể tải danh mục nhóm hàng: " + ex.Message);
            }
        }

        private void btnLocBaoCao_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;
            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Khoảng thời gian không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLocBaoCao.Enabled = false;
            btnXuatExcel.Enabled = false;
            dgvBaoCaoTonKho.DataSource = null;
            _baoCaoTable = null;
            DatLaiKPI();
            CapNhatBieuDo(null);
            UseWaitCursor = true;

            try
            {
                string loaiHang = cboLoaiHang.SelectedValue == null
                    ? string.Empty
                    : Convert.ToString(cboLoaiHang.SelectedValue, CultureInfo.CurrentCulture);

                string tuKhoa = txtTimKiem.Text.Trim();

                DataTable baoCao = _theKhoBUS.LayBaoCaoTonKho(tuNgay, denNgay, loaiHang, tuKhoa);

                _baoCaoTable = baoCao;
                dgvBaoCaoTonKho.DataSource = baoCao;
                DinhDangCotBangBaoCao();
                CapNhatKPI(baoCao);
                CapNhatBieuDo(baoCao);
                btnXuatExcel.Enabled = true;
                CanBangSplitter();
            }
            catch (Exception ex)
            {
                HienThiLoi("Không thể tổng hợp báo cáo tồn kho: " + ex.Message);
            }
            finally
            {
                UseWaitCursor = false;
                btnLocBaoCao.Enabled = true;
            }
        }

        private void DinhDangCotBangBaoCao()
        {
            if (dgvBaoCaoTonKho.Columns.Count == 0) return;

            if (dgvBaoCaoTonKho.Columns.Contains("STT"))
            {
                dgvBaoCaoTonKho.Columns["STT"].HeaderText = "STT";
                dgvBaoCaoTonKho.Columns["STT"].Width = 45;
                dgvBaoCaoTonKho.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvBaoCaoTonKho.Columns.Contains("MaSP"))
            {
                dgvBaoCaoTonKho.Columns["MaSP"].HeaderText = "Mã SP";
                dgvBaoCaoTonKho.Columns["MaSP"].Width = 85;
                dgvBaoCaoTonKho.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvBaoCaoTonKho.Columns.Contains("TenSP"))
            {
                dgvBaoCaoTonKho.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                dgvBaoCaoTonKho.Columns["TenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvBaoCaoTonKho.Columns["TenSP"].MinimumWidth = 140;
                dgvBaoCaoTonKho.Columns["TenSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvBaoCaoTonKho.Columns.Contains("LoaiHang"))
            {
                dgvBaoCaoTonKho.Columns["LoaiHang"].HeaderText = "Loại hàng";
                dgvBaoCaoTonKho.Columns["LoaiHang"].Width = 100;
                dgvBaoCaoTonKho.Columns["LoaiHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvBaoCaoTonKho.Columns.Contains("DonViTinh"))
            {
                dgvBaoCaoTonKho.Columns["DonViTinh"].HeaderText = "ĐVT";
                dgvBaoCaoTonKho.Columns["DonViTinh"].Width = 55;
                dgvBaoCaoTonKho.Columns["DonViTinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvBaoCaoTonKho.Columns.Contains("TonDau"))
            {
                dgvBaoCaoTonKho.Columns["TonDau"].HeaderText = "Tồn đầu";
                dgvBaoCaoTonKho.Columns["TonDau"].Width = 75;
                dgvBaoCaoTonKho.Columns["TonDau"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBaoCaoTonKho.Columns["TonDau"].DefaultCellStyle.Format = "N0";
            }
            if (dgvBaoCaoTonKho.Columns.Contains("SLNhap"))
            {
                dgvBaoCaoTonKho.Columns["SLNhap"].HeaderText = "Nhập";
                dgvBaoCaoTonKho.Columns["SLNhap"].Width = 70;
                dgvBaoCaoTonKho.Columns["SLNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBaoCaoTonKho.Columns["SLNhap"].DefaultCellStyle.Format = "N0";
            }
            if (dgvBaoCaoTonKho.Columns.Contains("SLXuat"))
            {
                dgvBaoCaoTonKho.Columns["SLXuat"].HeaderText = "Xuất";
                dgvBaoCaoTonKho.Columns["SLXuat"].Width = 70;
                dgvBaoCaoTonKho.Columns["SLXuat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBaoCaoTonKho.Columns["SLXuat"].DefaultCellStyle.Format = "N0";
            }
            if (dgvBaoCaoTonKho.Columns.Contains("TonCuoi"))
            {
                dgvBaoCaoTonKho.Columns["TonCuoi"].HeaderText = "Tồn cuối";
                dgvBaoCaoTonKho.Columns["TonCuoi"].Width = 75;
                dgvBaoCaoTonKho.Columns["TonCuoi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBaoCaoTonKho.Columns["TonCuoi"].DefaultCellStyle.Format = "N0";
            }
            if (dgvBaoCaoTonKho.Columns.Contains("GiaTriTon"))
            {
                dgvBaoCaoTonKho.Columns["GiaTriTon"].HeaderText = "Giá trị tồn (VNĐ)";
                dgvBaoCaoTonKho.Columns["GiaTriTon"].Width = 110;
                dgvBaoCaoTonKho.Columns["GiaTriTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBaoCaoTonKho.Columns["GiaTriTon"].DefaultCellStyle.Format = "N0";
            }
            if (dgvBaoCaoTonKho.Columns.Contains("TrangThai"))
            {
                dgvBaoCaoTonKho.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvBaoCaoTonKho.Columns["TrangThai"].Width = 120;
                dgvBaoCaoTonKho.Columns["TrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            string[] cotCanAn = new string[] { "TonToiThieu", "TonToiDa", "TongLuanChuyen" };
            foreach (var colName in cotCanAn)
            {
                if (dgvBaoCaoTonKho.Columns.Contains(colName))
                {
                    dgvBaoCaoTonKho.Columns[colName].Visible = false;
                }
            }
        }

        private void CapNhatKPI(DataTable baoCao)
        {
            decimal tongNhap = 0;
            decimal tongXuat = 0;
            decimal tongGiaTriTon = 0;
            foreach (DataRow row in baoCao.Rows)
            {
                tongNhap += Convert.ToDecimal(row["SLNhap"], CultureInfo.InvariantCulture);
                tongXuat += Convert.ToDecimal(row["SLXuat"], CultureInfo.InvariantCulture);
                tongGiaTriTon += Convert.ToDecimal(row["GiaTriTon"], CultureInfo.InvariantCulture);
            }

            lblTongMaHang.Text = baoCao.Rows.Count.ToString("N0", _culture);
            lblTongSLNhap.Text = tongNhap.ToString("N0", _culture);
            lblTongSLXuat.Text = tongXuat.ToString("N0", _culture);
            lblTongGiaTriTon.Text = tongGiaTriTon.ToString("N0", _culture) + " VNĐ";
        }

        private void DatLaiKPI()
        {
            lblTongMaHang.Text = "0";
            lblTongSLNhap.Text = "0";
            lblTongSLXuat.Text = "0";
            lblTongGiaTriTon.Text = "0 VNĐ";
        }

        private void CapNhatBieuDo(DataTable baoCao)
        {
            if (seriesSoLuongNhap == null && chartTopHangHoa != null && chartTopHangHoa.Series.Count > 0)
            {
                seriesSoLuongNhap = chartTopHangHoa.Series[0];
            }
            if (seriesSoLuongXuat == null && chartTopHangHoa != null && chartTopHangHoa.Series.Count > 1)
            {
                seriesSoLuongXuat = chartTopHangHoa.Series[1];
            }

            if (seriesSoLuongNhap != null)
            {
                seriesSoLuongNhap.Points.Clear();
            }
            if (seriesSoLuongXuat != null)
            {
                seriesSoLuongXuat.Points.Clear();
            }

            if (baoCao == null || baoCao.Rows.Count == 0 || seriesSoLuongNhap == null || seriesSoLuongXuat == null)
            {
                return;
            }

            DataView topHangHoa = baoCao.DefaultView;
            topHangHoa.Sort = "TongLuanChuyen DESC, MaSP ASC";
            // Lấy tối đa 8 mặt hàng luân chuyển cao nhất để biểu đồ thoáng đãng, dễ nhìn
            int soMatHang = Math.Min(8, topHangHoa.Count);
            for (int index = 0; index < soMatHang; index++)
            {
                DataRowView row = topHangHoa[index];
                string maSP = Convert.ToString(row["MaSP"], CultureInfo.CurrentCulture);
                string tenSP = Convert.ToString(row["TenSP"], CultureInfo.CurrentCulture);
                string tenNgan = tenSP.Length > 12 ? (tenSP.Substring(0, 10) + "...") : tenSP;
                string labelTrucX = $"{maSP}\n{tenNgan}";

                double slNhap = Convert.ToDouble(row["SLNhap"], CultureInfo.InvariantCulture);
                double slXuat = Convert.ToDouble(row["SLXuat"], CultureInfo.InvariantCulture);

                int idxNhap = seriesSoLuongNhap.Points.AddXY(labelTrucX, slNhap);
                seriesSoLuongNhap.Points[idxNhap].ToolTip = $"{tenSP} ({maSP})\nSố lượng nhập: {slNhap:N0}";

                int idxXuat = seriesSoLuongXuat.Points.AddXY(labelTrucX, slXuat);
                seriesSoLuongXuat.Points[idxXuat].ToolTip = $"{tenSP} ({maSP})\nSố lượng xuất: {slXuat:N0}";
            }
        }

        private void dgvBaoCaoTonKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewColumn col = dgvBaoCaoTonKho.Columns[e.ColumnIndex];
            if (col == null) return;

            DataRowView row = dgvBaoCaoTonKho.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null) return;

            if (col.Name == "TrangThai")
            {
                string trangThai = row["TrangThai"]?.ToString() ?? string.Empty;
                e.CellStyle.Font = new Font(dgvBaoCaoTonKho.Font, FontStyle.Bold);

                if (trangThai.IndexOf("Hết", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                    e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                }
                else if (trangThai.IndexOf("tối thiểu", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                    e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
                }
                else if (trangThai.IndexOf("tối đa", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    e.CellStyle.BackColor = Color.FromArgb(219, 234, 254);
                    e.CellStyle.ForeColor = Color.FromArgb(29, 78, 216);
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                }
            }
            else if (col.Name == "TonCuoi")
            {
                decimal tonCuoi = 0;
                decimal tonToiThieu = 0;
                if (decimal.TryParse(row["TonCuoi"]?.ToString(), out tonCuoi) &&
                    decimal.TryParse(row["TonToiThieu"]?.ToString(), out tonToiThieu))
                {
                    if (tonCuoi <= 0)
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                        e.CellStyle.Font = new Font(dgvBaoCaoTonKho.Font, FontStyle.Bold);
                    }
                    else if (tonCuoi <= tonToiThieu)
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6);
                        e.CellStyle.Font = new Font(dgvBaoCaoTonKho.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (_baoCaoTable == null)
            {
                MessageBox.Show("Vui lòng tổng hợp báo cáo trước khi xuất Excel.", "Chưa có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Xuất báo cáo tổng hợp nhập - xuất - tồn";
                dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dialog.DefaultExt = "xlsx";
                dialog.AddExtension = true;
                dialog.OverwritePrompt = true;
                dialog.FileName = "BaoCaoTonKho_" + DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx";
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                try
                {
                    XuatBaoCaoExcel(dialog.FileName);
                    MessageBox.Show("Đã xuất báo cáo thành công:\n" + dialog.FileName, "Xuất Excel thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xuất file Excel: " + ex.Message, "Xuất Excel thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    System.Windows.Forms.Cursor.Current = Cursors.Default;
                }
            }
        }

        private void XuatBaoCaoExcel(string filePath)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Bao cao ton kho");
                worksheet.Range(1, 1, 1, dgvBaoCaoTonKho.Columns.Count).Merge();
                worksheet.Cell(1, 1).Value = "BÁO CÁO TỔNG HỢP NHẬP - XUẤT - TỒN KHO HÀNG";
                worksheet.Range(2, 1, 2, dgvBaoCaoTonKho.Columns.Count).Merge();
                worksheet.Cell(2, 1).Value = "Kỳ báo cáo: " + dtpTuNgay.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                    + " - " + dtpDenNgay.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                const int headerRow = 4;
                const int firstDataRow = headerRow + 1;

                for (int colIndex = 0; colIndex < dgvBaoCaoTonKho.Columns.Count; colIndex++)
                {
                    worksheet.Cell(headerRow, colIndex + 1).Value = dgvBaoCaoTonKho.Columns[colIndex].HeaderText;
                }

                int excelRow = firstDataRow;
                foreach (DataGridViewRow gridRow in dgvBaoCaoTonKho.Rows)
                {
                    if (gridRow.IsNewRow) continue;
                    for (int colIndex = 0; colIndex < dgvBaoCaoTonKho.Columns.Count; colIndex++)
                    {
                        GanGiaTriOExcel(worksheet.Cell(excelRow, colIndex + 1), gridRow.Cells[colIndex].Value);
                    }
                    excelRow++;
                }

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(filePath);
            }
        }

        private void GanGiaTriOExcel(IXLCell cell, object value)
        {
            if (value == null || value == DBNull.Value)
            {
                cell.Clear(XLClearOptions.Contents);
                return;
            }

            if (value is DateTime)
            {
                cell.Value = (DateTime)value;
                return;
            }

            if (value is byte || value is short || value is int || value is long || value is decimal || value is double || value is float)
            {
                cell.Value = Convert.ToDecimal(value, CultureInfo.InvariantCulture);
                return;
            }

            cell.Value = Convert.ToString(value, CultureInfo.CurrentCulture);
        }

        private void HienThiLoi(string message)
        {
            MessageBox.Show(message, "Báo cáo tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvBaoCaoTonKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
