using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;
using LTWIN_N4_QLKH.BUS;
using LTWIN_N4_QLKH.GUI.Helpers;

namespace LTWIN_N4_QLKH.GUI.Forms.Inventory
{
    public partial class frmBaoCaoTonKho : Form
    {
        private readonly CultureInfo _culture = CultureInfo.GetCultureInfo("vi-VN");
        private readonly TheKhoBUS _theKhoBUS = new TheKhoBUS();
        private readonly DoanhThuBUS _doanhThuBUS = new DoanhThuBUS();

        private DataTable _baoCaoTable;
        private DataTable _doanhThuTable;
        private DateTime _dtCurrentTuNgay;
        private DateTime _dtCurrentDenNgay;

        public frmBaoCaoTonKho()
        {
            InitializeComponent();
            UIThemeHelper.ApplyFormHeaderAndIcon(this, "Báo cáo Tồn kho & Doanh thu xuất kho", UIThemeHelper.FormIconType.BaoCao);
            BackColor = ColorTranslator.FromHtml("#F8FAFC");
        }

        private void frmBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            // Thiết lập ngày mặc định cho tab Tồn kho
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

            if (dgvDoanhThu != null)
            {
                UIThemeHelper.ApplyStandardGridStyle(dgvDoanhThu);
                dgvDoanhThu.ReadOnly = true;
                dgvDoanhThu.AllowUserToAddRows = false;
                dgvDoanhThu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }

            DinhDangNutThanhCongCu();
            NapDanhSachLoaiHang();
            CapNhatBieuDo(null);

            // Khởi tạo tab Doanh thu
            KhoiTaoTabDoanhThu();

            CanBangSplitter();

            // Cấu hình cố định vùng vẽ biểu đồ để nhãn trục X không bị cắt ở đáy khi mở rộng
            if (chartTopHangHoa != null && chartTopHangHoa.ChartAreas.Count > 0)
            {
                var ca = chartTopHangHoa.ChartAreas[0];
                ca.AxisX.IsLabelAutoFit = true;
                ca.InnerPlotPosition.Auto = false;
                ca.InnerPlotPosition.X = 8f;
                ca.InnerPlotPosition.Y = 4f;
                ca.InnerPlotPosition.Width = 90f;
                ca.InnerPlotPosition.Height = 68f;
            }

            if (chartDoanhThu != null && chartDoanhThu.ChartAreas.Count > 0)
            {
                var ca2 = chartDoanhThu.ChartAreas[0];
                ca2.AxisX.IsLabelAutoFit = true;
                ca2.InnerPlotPosition.Auto = false;
                ca2.InnerPlotPosition.X = 8f;
                ca2.InnerPlotPosition.Y = 4f;
                ca2.InnerPlotPosition.Width = 90f;
                ca2.InnerPlotPosition.Height = 68f;
            }
        }

        #region CÔNG CỤ CHUNG VA GIAO DIỆN 
        private void DinhDangNutThanhCongCu()
        {
            Button[] toolButtons = new Button[] { btnToanManHinhBang, btnXemCaHaiBang, btnToanManHinhChart, btnXemCaHaiChart, btnXemChiTietPhieu };
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
            chartTopHangHoa.Invalidate(); chartTopHangHoa.Update();
        }

        private void btnXemCaHai_Click(object sender, EventArgs e)
        {
            splitBaoCao.Panel1Collapsed = false;
            splitBaoCao.Panel2Collapsed = false;
            CanBangSplitter();
            chartTopHangHoa.Invalidate(); chartTopHangHoa.Update();
        }

        private void frmBaoCaoTonKho_Resize(object sender, EventArgs e)
        {
            CanBangSplitter();

            // Cấu hình cố định vùng vẽ biểu đồ để nhãn trục X không bị cắt ở đáy khi mở rộng
            if (chartTopHangHoa != null && chartTopHangHoa.ChartAreas.Count > 0)
            {
                var ca = chartTopHangHoa.ChartAreas[0];
                ca.AxisX.IsLabelAutoFit = true;
                ca.InnerPlotPosition.Auto = false;
                ca.InnerPlotPosition.X = 8f;
                ca.InnerPlotPosition.Y = 4f;
                ca.InnerPlotPosition.Width = 90f;
                ca.InnerPlotPosition.Height = 68f;
            }

            if (chartDoanhThu != null && chartDoanhThu.ChartAreas.Count > 0)
            {
                var ca2 = chartDoanhThu.ChartAreas[0];
                ca2.AxisX.IsLabelAutoFit = true;
                ca2.InnerPlotPosition.Auto = false;
                ca2.InnerPlotPosition.X = 8f;
                ca2.InnerPlotPosition.Y = 4f;
                ca2.InnerPlotPosition.Width = 90f;
                ca2.InnerPlotPosition.Height = 68f;
            }
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

                if (splitDoanhThu != null && splitDoanhThu.Width > 0 && !splitDoanhThu.Panel1Collapsed && !splitDoanhThu.Panel2Collapsed)
                {
                    int targetDT = (int)(splitDoanhThu.Width * 0.58);
                    if (targetDT >= splitDoanhThu.Panel1MinSize && (splitDoanhThu.Width - targetDT) >= splitDoanhThu.Panel2MinSize)
                    {
                        splitDoanhThu.SplitterDistance = targetDT;
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #region TAB 1: BÁO CÁO TỒN KHO 
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

            // Toàn bộ text và số căn sang bên trái theo yêu cầu chuẩn hóa
            foreach (DataGridViewColumn col in dgvBaoCaoTonKho.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvBaoCaoTonKho.Columns.Contains("STT"))
            {
                dgvBaoCaoTonKho.Columns["STT"].HeaderText = "STT";
                dgvBaoCaoTonKho.Columns["STT"].Width = 45;
                dgvBaoCaoTonKho.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvBaoCaoTonKho.Columns.Contains("MaSP"))
            {
                dgvBaoCaoTonKho.Columns["MaSP"].HeaderText = "Mã SP";
                dgvBaoCaoTonKho.Columns["MaSP"].Width = 85;
                dgvBaoCaoTonKho.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
                dgvBaoCaoTonKho.Columns["DonViTinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvBaoCaoTonKho.Columns.Contains("TonDau"))
            {
                dgvBaoCaoTonKho.Columns["TonDau"].HeaderText = "Tồn đầu";
                dgvBaoCaoTonKho.Columns["TonDau"].Width = 75;
                dgvBaoCaoTonKho.Columns["TonDau"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvBaoCaoTonKho.Columns["TonDau"].DefaultCellStyle.Format = "N0";
            }
            if (dgvBaoCaoTonKho.Columns.Contains("SLNhap"))
            {
                dgvBaoCaoTonKho.Columns["SLNhap"].HeaderText = "Nhập";
                dgvBaoCaoTonKho.Columns["SLNhap"].Width = 70;
                dgvBaoCaoTonKho.Columns["SLNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvBaoCaoTonKho.Columns["SLNhap"].DefaultCellStyle.Format = "N0";
            }
            if (dgvBaoCaoTonKho.Columns.Contains("SLXuat"))
            {
                dgvBaoCaoTonKho.Columns["SLXuat"].HeaderText = "Xuất";
                dgvBaoCaoTonKho.Columns["SLXuat"].Width = 70;
                dgvBaoCaoTonKho.Columns["SLXuat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvBaoCaoTonKho.Columns["SLXuat"].DefaultCellStyle.Format = "N0";
            }
            if (dgvBaoCaoTonKho.Columns.Contains("TonCuoi"))
            {
                dgvBaoCaoTonKho.Columns["TonCuoi"].HeaderText = "Tồn cuối";
                dgvBaoCaoTonKho.Columns["TonCuoi"].Width = 75;
                dgvBaoCaoTonKho.Columns["TonCuoi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvBaoCaoTonKho.Columns["TonCuoi"].DefaultCellStyle.Format = "N0";
            }
            if (dgvBaoCaoTonKho.Columns.Contains("GiaTriTon"))
            {
                dgvBaoCaoTonKho.Columns["GiaTriTon"].HeaderText = "Giá trị tồn (VNĐ)";
                dgvBaoCaoTonKho.Columns["GiaTriTon"].Width = 110;
                dgvBaoCaoTonKho.Columns["GiaTriTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvBaoCaoTonKho.Columns["GiaTriTon"].DefaultCellStyle.Format = "N0";
            }
            if (dgvBaoCaoTonKho.Columns.Contains("TrangThai"))
            {
                dgvBaoCaoTonKho.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvBaoCaoTonKho.Columns["TrangThai"].Width = 120;
                dgvBaoCaoTonKho.Columns["TrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
            if (chartTopHangHoa == null || chartTopHangHoa.Series.Count < 2) return;

            Series seriesNhap = chartTopHangHoa.Series[0];
            Series seriesXuat = chartTopHangHoa.Series[1];

            seriesNhap.Points.Clear();
            seriesNhap.IsXValueIndexed = true;
            seriesXuat.Points.Clear();
            seriesXuat.IsXValueIndexed = true;

            if (chartTopHangHoa.ChartAreas.Count > 0)
            {
                ChartArea ca = chartTopHangHoa.ChartAreas[0];
                ca.AxisX.Interval = 1;
                ca.AxisX.IsMarginVisible = true;
                ca.AxisX.LabelStyle.Angle = 0;
                ca.AxisX.LabelStyle.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
                ca.AxisX.MajorTickMark.Enabled = true;
                ca.AxisX.MajorTickMark.LineColor = Color.FromArgb(148, 163, 184);
                ca.AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;
                ca.AxisX.MajorTickMark.Size = 4;
                ca.AxisX.MajorGrid.Enabled = false;
                ca.InnerPlotPosition.Auto = false; ca.InnerPlotPosition.X = 8f; ca.InnerPlotPosition.Y = 4f; ca.InnerPlotPosition.Width = 90f; ca.InnerPlotPosition.Height = 68f;
            }

            if (baoCao == null || baoCao.Rows.Count == 0) return;

            DataView topHangHoa = baoCao.DefaultView;
            topHangHoa.Sort = "TongLuanChuyen DESC, MaSP ASC";
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

                int idxNhap = seriesNhap.Points.AddXY(labelTrucX, slNhap);
                seriesNhap.Points[idxNhap].ToolTip = $"{tenSP} ({maSP})\nSố lượng nhập: {slNhap:N0}";

                int idxXuat = seriesXuat.Points.AddXY(labelTrucX, slXuat);
                seriesXuat.Points[idxXuat].ToolTip = $"{tenSP} ({maSP})\nSố lượng xuất: {slXuat:N0}";
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
        #endregion

        #region TAB 2: BÁO CÁO DOANH THU 
        private void KhoiTaoTabDoanhThu()
        {
            try
            {
                cboCheDoDT.SelectedIndex = 0; // Khoảng thời gian
                dtpTuNgayDT.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                dtpDenNgayDT.Value = DateTime.Today;

                cboThangDT.Items.Clear();
                for (int i = 1; i <= 12; i++)
                {
                    cboThangDT.Items.Add($"Tháng {i}");
                }
                cboThangDT.SelectedIndex = DateTime.Today.Month - 1;
                numNamDT.Value = DateTime.Today.Year;

                cboKieuXemDT.SelectedIndex = 0; // Danh sách phiếu xuất

                TaiDuLieuDoanhThu();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi khởi tạo Tab Doanh thu: " + ex.Message);
            }
        }

        private void cboCheDoDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cheDo = cboCheDoDT.SelectedItem?.ToString() ?? "Khoảng thời gian";

            if (cheDo == "Theo ngày")
            {
                lblTuNgayDT.Visible = true;
                lblTuNgayDT.Text = "Chọn ngày:";
                dtpTuNgayDT.Visible = true;

                lblDenNgayDT.Visible = false;
                dtpDenNgayDT.Visible = false;

                lblThangDT.Visible = false;
                cboThangDT.Visible = false;
                lblNamDT.Visible = false;
                numNamDT.Visible = false;
            }
            else if (cheDo == "Theo tháng")
            {
                lblTuNgayDT.Visible = false;
                dtpTuNgayDT.Visible = false;

                lblDenNgayDT.Visible = false;
                dtpDenNgayDT.Visible = false;

                lblThangDT.Visible = true;
                cboThangDT.Visible = true;
                lblNamDT.Visible = true;
                numNamDT.Visible = true;
            }
            else // Khoảng thời gian
            {
                lblTuNgayDT.Visible = true;
                lblTuNgayDT.Text = "Từ ngày:";
                dtpTuNgayDT.Visible = true;

                lblDenNgayDT.Visible = true;
                dtpDenNgayDT.Visible = true;

                lblThangDT.Visible = false;
                cboThangDT.Visible = false;
                lblNamDT.Visible = false;
                numNamDT.Visible = false;
            }
        }

        private void btnLocDT_Click(object sender, EventArgs e)
        {
            TaiDuLieuDoanhThu();
        }

        private void cboKieuXemDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDuLieuDoanhThu();
        }

        private void TaiDuLieuDoanhThu()
        {
            string cheDo = cboCheDoDT.SelectedItem?.ToString() ?? "Khoảng thời gian";
            DateTime tuNgay;
            DateTime denNgay;

            if (cheDo == "Theo ngày")
            {
                tuNgay = dtpTuNgayDT.Value.Date;
                denNgay = dtpTuNgayDT.Value.Date;
            }
            else if (cheDo == "Theo tháng")
            {
                int thang = cboThangDT.SelectedIndex + 1;
                int nam = (int)numNamDT.Value;
                tuNgay = new DateTime(nam, thang, 1);
                denNgay = tuNgay.AddMonths(1).AddDays(-1);
            }
            else
            {
                tuNgay = dtpTuNgayDT.Value.Date;
                denNgay = dtpDenNgayDT.Value.Date;
                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Từ ngày không thể lớn hơn đến ngày.", "Khoảng thời gian không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            _dtCurrentTuNgay = tuNgay;
            _dtCurrentDenNgay = denNgay;

            try
            {
                UseWaitCursor = true;

                // 1. Cập nhật các thẻ KPI doanh thu
                _doanhThuBUS.LayChiSoTongHop(tuNgay, denNgay, out decimal tongDoanhThu, out int tongSoPhieu, out int tongSLXuat);
                decimal doanhThuTB = tongSoPhieu > 0 ? (tongDoanhThu / tongSoPhieu) : 0;

                lblTongDoanhThu.Text = tongDoanhThu.ToString("N0", _culture) + " VNĐ";
                lblTongSoPhieu.Text = tongSoPhieu.ToString("N0", _culture) + " phiếu";
                lblTongSLXuatDT.Text = tongSLXuat.ToString("N0", _culture) + " SP";
                lblDoanhThuTB.Text = doanhThuTB.ToString("N0", _culture) + " VNĐ";

                // 2. Tải bảng dữ liệu theo chế độ xem
                int kieuXem = cboKieuXemDT.SelectedIndex;
                string tuKhoa = txtTimKiemDT != null ? txtTimKiemDT.Text.Trim() : "";

                if (kieuXem == 0) // Danh sách phiếu xuất
                {
                    _doanhThuTable = _doanhThuBUS.LayDanhSachPhieuXuat(tuNgay, denNgay, tuKhoa);
                    dgvDoanhThu.DataSource = _doanhThuTable;
                    DinhDangCotDanhSachPhieu();
                    btnXemChiTietPhieu.Visible = true;
                }
                else if (kieuXem == 1) // Tổng hợp theo mặt hàng
                {
                    _doanhThuTable = _doanhThuBUS.LayDoanhThuTheoMatHang(tuNgay, denNgay);
                    dgvDoanhThu.DataSource = _doanhThuTable;
                    DinhDangCotTheoMatHang();
                    btnXemChiTietPhieu.Visible = false;
                }
                else // Tổng hợp theo từng ngày
                {
                    _doanhThuTable = _doanhThuBUS.LayDoanhThuTheoTungNgay(tuNgay, denNgay);
                    dgvDoanhThu.DataSource = _doanhThuTable;
                    DinhDangCotTheoNgay();
                    btnXemChiTietPhieu.Visible = false;
                }

                // 3. Cập nhật biểu đồ doanh thu
                CapNhatBieuDoDoanhThu(kieuXem, tuNgay, denNgay);
                CanBangSplitter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        private void DinhDangCotDanhSachPhieu()
        {
            if (dgvDoanhThu.Columns.Count == 0) return;

            // Toàn bộ text và số căn sang bên trái theo yêu cầu chuẩn hóa
            foreach (DataGridViewColumn col in dgvDoanhThu.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvDoanhThu.Columns.Contains("STT"))
            {
                dgvDoanhThu.Columns["STT"].HeaderText = "STT";
                dgvDoanhThu.Columns["STT"].Width = 45;
            }
            if (dgvDoanhThu.Columns.Contains("MaPX"))
            {
                dgvDoanhThu.Columns["MaPX"].HeaderText = "Mã phiếu xuất";
                dgvDoanhThu.Columns["MaPX"].Width = 110;
            }
            if (dgvDoanhThu.Columns.Contains("NgayXuat"))
            {
                dgvDoanhThu.Columns["NgayXuat"].HeaderText = "Ngày xuất";
                dgvDoanhThu.Columns["NgayXuat"].Width = 135;
                dgvDoanhThu.Columns["NgayXuat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvDoanhThu.Columns.Contains("NguoiNhan"))
            {
                dgvDoanhThu.Columns["NguoiNhan"].HeaderText = "Người nhận";
                dgvDoanhThu.Columns["NguoiNhan"].FillWeight = 140;
            }
            if (dgvDoanhThu.Columns.Contains("LyDoXuat"))
            {
                dgvDoanhThu.Columns["LyDoXuat"].HeaderText = "Lý do xuất";
                dgvDoanhThu.Columns["LyDoXuat"].FillWeight = 130;
            }
            if (dgvDoanhThu.Columns.Contains("NhanVienXuat"))
            {
                dgvDoanhThu.Columns["NhanVienXuat"].HeaderText = "Nhân viên xuất";
                dgvDoanhThu.Columns["NhanVienXuat"].FillWeight = 120;
            }
            if (dgvDoanhThu.Columns.Contains("TongTienXuat"))
            {
                dgvDoanhThu.Columns["TongTienXuat"].HeaderText = "Tổng tiền (VNĐ)";
                dgvDoanhThu.Columns["TongTienXuat"].FillWeight = 120;
                dgvDoanhThu.Columns["TongTienXuat"].DefaultCellStyle.Format = "N0";
            }
            if (dgvDoanhThu.Columns.Contains("GhiChu"))
            {
                dgvDoanhThu.Columns["GhiChu"].HeaderText = "Ghi chú";
                dgvDoanhThu.Columns["GhiChu"].FillWeight = 100;
            }
        }

        private void DinhDangCotTheoMatHang()
        {
            if (dgvDoanhThu.Columns.Count == 0) return;

            foreach (DataGridViewColumn col in dgvDoanhThu.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvDoanhThu.Columns.Contains("STT"))
            {
                dgvDoanhThu.Columns["STT"].HeaderText = "STT";
                dgvDoanhThu.Columns["STT"].Width = 45;
            }
            if (dgvDoanhThu.Columns.Contains("MaSP"))
            {
                dgvDoanhThu.Columns["MaSP"].HeaderText = "Mã SP";
                dgvDoanhThu.Columns["MaSP"].Width = 85;
            }
            if (dgvDoanhThu.Columns.Contains("TenSP"))
            {
                dgvDoanhThu.Columns["TenSP"].HeaderText = "Tên mặt hàng";
                dgvDoanhThu.Columns["TenSP"].FillWeight = 170;
            }
            if (dgvDoanhThu.Columns.Contains("LoaiHang"))
            {
                dgvDoanhThu.Columns["LoaiHang"].HeaderText = "Loại hàng";
                dgvDoanhThu.Columns["LoaiHang"].FillWeight = 100;
            }
            if (dgvDoanhThu.Columns.Contains("DonViTinh"))
            {
                dgvDoanhThu.Columns["DonViTinh"].HeaderText = "ĐVT";
                dgvDoanhThu.Columns["DonViTinh"].Width = 60;
            }
            if (dgvDoanhThu.Columns.Contains("TongSoLuongXuat"))
            {
                dgvDoanhThu.Columns["TongSoLuongXuat"].HeaderText = "Tổng SL xuất";
                dgvDoanhThu.Columns["TongSoLuongXuat"].FillWeight = 90;
                dgvDoanhThu.Columns["TongSoLuongXuat"].DefaultCellStyle.Format = "N0";
            }
            if (dgvDoanhThu.Columns.Contains("TongDoanhThu"))
            {
                dgvDoanhThu.Columns["TongDoanhThu"].HeaderText = "Doanh thu (VNĐ)";
                dgvDoanhThu.Columns["TongDoanhThu"].FillWeight = 130;
                dgvDoanhThu.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0";
            }
        }

        private void DinhDangCotTheoNgay()
        {
            if (dgvDoanhThu.Columns.Count == 0) return;

            foreach (DataGridViewColumn col in dgvDoanhThu.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvDoanhThu.Columns.Contains("Ngay"))
            {
                dgvDoanhThu.Columns["Ngay"].HeaderText = "Ngày giao dịch";
                dgvDoanhThu.Columns["Ngay"].FillWeight = 100;
            }
            if (dgvDoanhThu.Columns.Contains("SoPhieu"))
            {
                dgvDoanhThu.Columns["SoPhieu"].HeaderText = "Số phiếu xuất";
                dgvDoanhThu.Columns["SoPhieu"].FillWeight = 80;
                dgvDoanhThu.Columns["SoPhieu"].DefaultCellStyle.Format = "N0";
            }
            if (dgvDoanhThu.Columns.Contains("DoanhThu"))
            {
                dgvDoanhThu.Columns["DoanhThu"].HeaderText = "Doanh thu trong ngày (VNĐ)";
                dgvDoanhThu.Columns["DoanhThu"].FillWeight = 150;
                dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
            }
            if (dgvDoanhThu.Columns.Contains("NgaySort"))
            {
                dgvDoanhThu.Columns["NgaySort"].Visible = false;
            }
        }

        private void CapNhatBieuDoDoanhThu(int kieuXem, DateTime tuNgay, DateTime denNgay)
        {
            if (chartDoanhThu == null || chartDoanhThu.Series.Count == 0) return;

            Series s = chartDoanhThu.Series[0];
            s.Points.Clear();
            s.IsXValueIndexed = true;

            if (chartDoanhThu.ChartAreas.Count > 0)
            {
                ChartArea ca = chartDoanhThu.ChartAreas[0];
                ca.AxisX.Interval = 1;
                ca.AxisX.IsMarginVisible = true;
                ca.AxisX.LabelStyle.Angle = 0;
                ca.AxisX.LabelStyle.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
                ca.AxisX.MajorTickMark.Enabled = true;
                ca.AxisX.MajorTickMark.LineColor = Color.FromArgb(148, 163, 184);
                ca.AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;
                ca.AxisX.MajorTickMark.Size = 4;
                ca.AxisX.MajorGrid.Enabled = false;
                ca.InnerPlotPosition.Auto = false; ca.InnerPlotPosition.X = 8f; ca.InnerPlotPosition.Y = 4f; ca.InnerPlotPosition.Width = 90f; ca.InnerPlotPosition.Height = 68f;
            }

            if (kieuXem == 1) // Biểu đồ mặt hàng doanh thu cao nhất
            {
                chartDoanhThu.Titles[0].Text = "TOP MẶT HÀNG ĐẠT DOANH THU CAO NHẤT";
                s.Name = "Doanh thu mặt hàng";

                DataTable dtHang = _doanhThuBUS.LayDoanhThuTheoMatHang(tuNgay, denNgay);
                if (dtHang != null && dtHang.Rows.Count > 0)
                {
                    int topCount = Math.Min(8, dtHang.Rows.Count);
                    for (int i = 0; i < topCount; i++)
                    {
                        DataRow r = dtHang.Rows[i];
                        string maSP = Convert.ToString(r["MaSP"]);
                        string tenSP = Convert.ToString(r["TenSP"]);
                        string tenNgan = tenSP.Length > 10 ? (tenSP.Substring(0, 8) + "..") : tenSP;
                        string label = $"{maSP}\n{tenNgan}";
                        double dtVal = Convert.ToDouble(r["TongDoanhThu"]);

                        int pIdx = s.Points.AddXY(label, dtVal);
                        s.Points[pIdx].ToolTip = $"{tenSP} ({maSP})\nDoanh thu: {dtVal:N0} VNĐ";
                    }
                }
            }
            else // Biểu đồ diễn biến doanh thu theo ngày
            {
                chartDoanhThu.Titles[0].Text = "DIỄN BIẾN DOANH THU THEO THỜI GIAN";
                s.Name = "Doanh thu theo ngày";

                DataTable dtNgay = _doanhThuBUS.LayDoanhThuTheoTungNgay(tuNgay, denNgay);
                if (dtNgay != null && dtNgay.Rows.Count > 0)
                {
                    foreach (DataRow r in dtNgay.Rows)
                    {
                        string ngay = Convert.ToString(r["Ngay"]);
                        double dtVal = Convert.ToDouble(r["DoanhThu"]);
                        int soPhieu = Convert.ToInt32(r["SoPhieu"]);

                        int pIdx = s.Points.AddXY(ngay, dtVal);
                        s.Points[pIdx].ToolTip = $"Ngày: {ngay}\nSố phiếu xuất: {soPhieu}\nDoanh thu: {dtVal:N0} VNĐ";
                    }
                }
            }
        }

        private void btnXemChiTietPhieu_Click(object sender, EventArgs e)
        {
            XemChiTietPhieuHienTai();
        }

        private void dgvDoanhThu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && cboKieuXemDT.SelectedIndex == 0)
            {
                XemChiTietPhieuHienTai();
            }
        }

        private void XemChiTietPhieuHienTai()
        {
            if (dgvDoanhThu.CurrentRow == null || !dgvDoanhThu.Columns.Contains("MaPX"))
            {
                MessageBox.Show("Vui lòng chọn một phiếu xuất từ bảng danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maPX = dgvDoanhThu.CurrentRow.Cells["MaPX"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(maPX)) return;

            string nguoiNhan = dgvDoanhThu.CurrentRow.Cells["NguoiNhan"].Value?.ToString() ?? "";
            string ngayXuat = dgvDoanhThu.CurrentRow.Cells["NgayXuat"].Value?.ToString() ?? "";
            string tongTien = dgvDoanhThu.CurrentRow.Cells["TongTienXuat"].Value?.ToString() ?? "0";

            DataTable dtChiTiet = _doanhThuBUS.LayChiTietPhieuXuat(maPX);

            // Hiển thị Form Modal chi tiết sản phẩm của phiếu xuất
            HienThiDialogChiTietPhieu(maPX, nguoiNhan, ngayXuat, tongTien, dtChiTiet);
        }

        private void HienThiDialogChiTietPhieu(string maPX, string nguoiNhan, string ngayXuat, string tongTien, DataTable dtChiTiet)
        {
            using (Form fChiTiet = new Form())
            {
                fChiTiet.Text = "Chi tiết mặt hàng xuất kho - " + maPX;
                fChiTiet.Size = new Size(820, 480);
                fChiTiet.StartPosition = FormStartPosition.CenterParent;
                fChiTiet.Font = UIThemeHelper.ControlFont;
                fChiTiet.BackColor = Color.White;

                Panel pnlTop = new Panel { Dock = DockStyle.Top, Height = 65, Padding = new Padding(12), BackColor = Color.FromArgb(248, 250, 252) };
                Label lblHeader = new Label
                {
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    Text = $"Mã phiếu: {maPX}   |   Người nhận: {nguoiNhan}   |   Thời gian: {ngayXuat}\nTổng giá trị phiếu xuất: {Convert.ToDecimal(tongTien):N0} VNĐ"
                };
                pnlTop.Controls.Add(lblHeader);

                DataGridView dgv = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    DataSource = dtChiTiet,
                    ReadOnly = true,
                    AllowUserToAddRows = false,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };
                UIThemeHelper.ApplyStandardGridStyle(dgv);

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                if (dgv.Columns.Contains("STT")) dgv.Columns["STT"].Width = 45;
                if (dgv.Columns.Contains("MaSP")) dgv.Columns["MaSP"].Width = 85;
                if (dgv.Columns.Contains("TenSP")) dgv.Columns["TenSP"].FillWeight = 160;
                if (dgv.Columns.Contains("LoaiHang")) dgv.Columns["LoaiHang"].FillWeight = 100;
                if (dgv.Columns.Contains("DonViTinh")) dgv.Columns["DonViTinh"].Width = 60;
                if (dgv.Columns.Contains("SoLuongXuat"))
                {
                    dgv.Columns["SoLuongXuat"].HeaderText = "Số lượng";
                    dgv.Columns["SoLuongXuat"].FillWeight = 80;
                    dgv.Columns["SoLuongXuat"].DefaultCellStyle.Format = "N0";
                }
                if (dgv.Columns.Contains("DonGiaXuat"))
                {
                    dgv.Columns["DonGiaXuat"].HeaderText = "Đơn giá (VNĐ)";
                    dgv.Columns["DonGiaXuat"].FillWeight = 110;
                    dgv.Columns["DonGiaXuat"].DefaultCellStyle.Format = "N0";
                }
                if (dgv.Columns.Contains("ThanhTien"))
                {
                    dgv.Columns["ThanhTien"].HeaderText = "Thành tiền (VNĐ)";
                    dgv.Columns["ThanhTien"].FillWeight = 120;
                    dgv.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }

                Panel pnlBottom = new Panel { Dock = DockStyle.Bottom, Height = 45, Padding = new Padding(8), BackColor = Color.FromArgb(248, 250, 252) };
                Button btnDong = new Button { Text = "Đóng", Dock = DockStyle.Right, Width = 100, DialogResult = DialogResult.OK };
                UIThemeHelper.ApplyButtonStyle(btnDong, UIThemeHelper.ButtonType.Neutral);
                btnDong.Click += (s, ev) => fChiTiet.Close();
                pnlBottom.Controls.Add(btnDong);

                fChiTiet.Controls.Add(dgv);
                fChiTiet.Controls.Add(pnlTop);
                fChiTiet.Controls.Add(pnlBottom);

                fChiTiet.ShowDialog(this);
            }
        }

        private void btnXuatExcelDT_Click(object sender, EventArgs e)
        {
            if (_doanhThuTable == null || _doanhThuTable.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu doanh thu để xuất file Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Xuất báo cáo doanh thu xuất kho";
                dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dialog.DefaultExt = "xlsx";
                dialog.AddExtension = true;
                dialog.OverwritePrompt = true;
                dialog.FileName = "BaoCaoDoanhThu_" + DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx";

                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        IXLWorksheet ws = workbook.Worksheets.Add("Doanh thu xuat kho");
                        ws.Range(1, 1, 1, dgvDoanhThu.Columns.Count).Merge();
                        ws.Cell(1, 1).Value = "BÁO CÁO THỐNG KÊ DOANH THU XUẤT KHO";
                        ws.Range(2, 1, 2, dgvDoanhThu.Columns.Count).Merge();
                        ws.Cell(2, 1).Value = $"Kỳ báo cáo: Từ {_dtCurrentTuNgay:dd/MM/yyyy} đến {_dtCurrentDenNgay:dd/MM/yyyy}  |  Tổng doanh thu: {lblTongDoanhThu.Text}";

                        const int headerRow = 4;
                        const int firstDataRow = 5;

                        for (int colIndex = 0; colIndex < dgvDoanhThu.Columns.Count; colIndex++)
                        {
                            ws.Cell(headerRow, colIndex + 1).Value = dgvDoanhThu.Columns[colIndex].HeaderText;
                        }

                        int excelRow = firstDataRow;
                        foreach (DataGridViewRow gridRow in dgvDoanhThu.Rows)
                        {
                            if (gridRow.IsNewRow) continue;
                            for (int colIndex = 0; colIndex < dgvDoanhThu.Columns.Count; colIndex++)
                            {
                                GanGiaTriOExcel(ws.Cell(excelRow, colIndex + 1), gridRow.Cells[colIndex].Value);
                            }
                            excelRow++;
                        }

                        ws.Columns().AdjustToContents();
                        workbook.SaveAs(dialog.FileName);
                    }

                    MessageBox.Show("Đã xuất báo cáo doanh thu thành công:\n" + dialog.FileName, "Xuất Excel thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        #endregion

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

        private void dgvBaoCaoTonKho_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
