using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ClosedXML.Excel;
using LTWIN_N4_QLKH.BUS;
using LTWIN_N4_QLKH.GUI.Helpers;

namespace LTWIN_N4_QLKH.GUI.Forms.Inventory
{
    public partial class frmTheKho : Form
    {
        private readonly CultureInfo _culture = CultureInfo.GetCultureInfo("vi-VN");
        private readonly TheKhoBUS _theKhoBUS = new TheKhoBUS();
        private string _donViTinh = string.Empty;

        public frmTheKho()
        {
            InitializeComponent();
            UIThemeHelper.ApplyFormHeaderAndIcon(this, "Sổ Thẻ kho Hàng hóa", UIThemeHelper.FormIconType.TheKho);
            BackColor = ColorTranslator.FromHtml("#F8FAFC");
        }

        private void frmTheKho_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today;

            // Thiết lập chuẩn giao diện
            this.Font = UIThemeHelper.ControlFont;
            if (dgvTheKho != null)
            {
                UIThemeHelper.ApplyStandardGridStyle(dgvTheKho);
                dgvTheKho.ReadOnly = true;
                dgvTheKho.AllowUserToAddRows = false;
                dgvTheKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTheKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            try
            {
                DataTable hangHoa = _theKhoBUS.LayDanhSachHangHoaChoTheKho();
                cboHangHoa.DisplayMember = "TenHienThi";
                cboHangHoa.ValueMember = "MaSP";
                cboHangHoa.DataSource = hangHoa;

                bool coHangHoa = hangHoa != null && hangHoa.Rows.Count > 0;
                cboHangHoa.Enabled = coHangHoa;
                btnXemTheKho.Enabled = coHangHoa;
                btnXuatExcel.Enabled = false;

                if (!coHangHoa)
                {
                    lblGhiChu.Text = "Chưa có mặt hàng trong danh mục.";
                }
            }
            catch (Exception ex)
            {
                btnXemTheKho.Enabled = false;
                btnXuatExcel.Enabled = false;
                HienThiLoi("Không thể tải danh sách mặt hàng: " + ex.Message);
            }
        }

        private void btnXemTheKho_Click(object sender, EventArgs e)
        {
            if (cboHangHoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần xem.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;
            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Khoảng thời gian không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnXemTheKho.Enabled = false;
            btnXuatExcel.Enabled = false;
            dgvTheKho.DataSource = null;
            lblTonDau.Text = "—";
            lblTongNhap.Text = "—";
            lblTongXuat.Text = "—";
            lblTonCuoi.Text = "—";
            UseWaitCursor = true;

            try
            {
                string maSP = Convert.ToString(cboHangHoa.SelectedValue, CultureInfo.InvariantCulture);

                decimal tonDauKy;
                decimal tongNhapTrongKy;
                decimal tongXuatTrongKy;
                decimal tonCuoiKy;
                string donViTinh;

                DataTable theKho = _theKhoBUS.LayTheKho(
                    maSP,
                    tuNgay,
                    denNgay,
                    out tonDauKy,
                    out tongNhapTrongKy,
                    out tongXuatTrongKy,
                    out tonCuoiKy,
                    out donViTinh);

                _donViTinh = donViTinh;
                dgvTheKho.DataSource = theKho;

                foreach (DataGridViewColumn col in dgvTheKho.Columns)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                CapNhatKPI(tonDauKy, tongNhapTrongKy, tongXuatTrongKy, tonCuoiKy);
                int soGiaoDich = Math.Max(0, theKho.Rows.Count - 1);
                lblGhiChu.ForeColor = Color.FromArgb(71, 85, 105);
                lblGhiChu.Text = "Đơn vị tính: " + _donViTinh + "  |  " + soGiaoDich.ToString("N0", _culture) + " giao dịch trong kỳ.";
                btnXuatExcel.Enabled = true;
            }
            catch (Exception ex)
            {
                btnXuatExcel.Enabled = false;
                HienThiLoi("Không thể tải thẻ kho: " + ex.Message);
            }
            finally
            {
                UseWaitCursor = false;
                btnXemTheKho.Enabled = cboHangHoa.Enabled && cboHangHoa.Items.Count > 0;
            }
        }

        private void CapNhatKPI(decimal tonDau, decimal tongNhap, decimal tongXuat, decimal tonCuoi)
        {
            lblTonDau.Text = DinhDangSoLuong(tonDau) + " " + _donViTinh;
            lblTongNhap.Text = "+" + DinhDangSoLuong(tongNhap) + " " + _donViTinh;
            lblTongXuat.Text = "-" + DinhDangSoLuong(tongXuat) + " " + _donViTinh;
            lblTonCuoi.Text = DinhDangSoLuong(tonCuoi) + " " + _donViTinh;
        }

        private string DinhDangSoLuong(decimal value)
        {
            return value.ToString("N0", _culture);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvTheKho.Rows.Count == 0 || cboHangHoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng xem dữ liệu thẻ kho trước khi xuất Excel.", "Chưa có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Xuất báo cáo thẻ kho";
                dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dialog.DefaultExt = "xlsx";
                dialog.AddExtension = true;
                dialog.OverwritePrompt = true;
                dialog.FileName = "TheKho_" + DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx";
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                try
                {
                    XuatBaoCaoExcel(dialog.FileName);
                    MessageBox.Show("Đã xuất báo cáo thẻ kho thành công:\n" + dialog.FileName, "Xuất Excel thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                IXLWorksheet worksheet = workbook.Worksheets.Add("The kho");
                worksheet.Range(1, 1, 1, 7).Merge();
                worksheet.Cell(1, 1).Value = "BÁO CÁO THẺ KHO";
                worksheet.Cell(2, 1).Value = "Mặt hàng: " + cboHangHoa.Text;
                worksheet.Range(2, 1, 2, 7).Merge();
                worksheet.Cell(3, 1).Value = "Kỳ báo cáo: " + dtpTuNgay.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + " - " + dtpDenNgay.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                worksheet.Range(3, 1, 3, 7).Merge();

                worksheet.Cell(5, 1).Value = lblTieuDeTonDau.Text;
                worksheet.Cell(5, 3).Value = lblTieuDeTongNhap.Text;
                worksheet.Cell(5, 5).Value = lblTieuDeTongXuat.Text;
                worksheet.Cell(5, 7).Value = lblTieuDeTonCuoi.Text;
                worksheet.Cell(6, 1).Value = lblTonDau.Text;
                worksheet.Cell(6, 3).Value = lblTongNhap.Text;
                worksheet.Cell(6, 5).Value = lblTongXuat.Text;
                worksheet.Cell(6, 7).Value = lblTonCuoi.Text;

                int headerRow = 8;
                for (int colIndex = 0; colIndex < dgvTheKho.Columns.Count; colIndex++)
                {
                    worksheet.Cell(headerRow, colIndex + 1).Value = dgvTheKho.Columns[colIndex].HeaderText;
                }

                int excelRow = headerRow + 1;
                foreach (DataGridViewRow gridRow in dgvTheKho.Rows)
                {
                    if (gridRow.IsNewRow) continue;
                    for (int colIndex = 0; colIndex < dgvTheKho.Columns.Count; colIndex++)
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
            lblGhiChu.ForeColor = Color.FromArgb(185, 28, 28);
            lblGhiChu.Text = message;
            MessageBox.Show(message, "Thẻ kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
