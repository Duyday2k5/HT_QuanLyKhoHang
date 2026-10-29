using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LTWIN_N4_QLKH.BUS;
using LTWIN_N4_QLKH.DTO;
using LTWIN_N4_QLKH.GUI.Helpers;

namespace LTWIN_N4_QLKH.GUI.Forms.MasterData
{
    public partial class frmHangHoa : Form
    {
        private readonly HangHoaBUS _hangHoaBUS = new HangHoaBUS();
        private bool _isAddingNew = false;

        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            SetupUI();
            NapDuLieuCombobox();
            LoadDanhSachHangHoa();
            LamMoiForm();
        }

        #region 1. CĂN CHỈNH BỐ CỤC ĐỘNG & CHUẨN HÓA GIAO DIỆN
        private void SetupUI()
        {
            this.Font = UIThemeHelper.ControlFont;
            this.BackColor = Color.White;

            // 1. Tự động ẩn tiêu đề con bị trùng
            AnTieuDeTrung(this);

            // 2. Tự động đồng bộ chuẩn hóa màu sắc các nút bấm trên form
            ChuanHoaNutBam(this);

            // 3. Chuẩn hóa DataGridView
            if (dgvHangHoa != null)
            {
                UIThemeHelper.ApplyStandardGridStyle(dgvHangHoa);
                dgvHangHoa.ReadOnly = true;
                dgvHangHoa.AllowUserToAddRows = false;
                dgvHangHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            // 4. Bắt phím Enter cho ô tìm kiếm
            TextBox txtSearch = LayOTextBoxTimKiem();
            if (txtSearch != null)
            {
                txtSearch.KeyDown -= TimKiem_KeyDown;
                txtSearch.KeyDown += TimKiem_KeyDown;
            }
        }

        private void AnTieuDeTrung(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label lbl && lbl.Text.ToUpper().Contains("QUẢN LÝ DANH MỤC HÀNG HÓA"))
                {
                    lbl.Visible = false;
                }
                if (c.HasChildren)
                {
                    AnTieuDeTrung(c);
                }
            }
        }

        private void ChuanHoaNutBam(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                {
                    string t = btn.Text.ToLower();
                    if (t.Contains("thêm")) UIThemeHelper.ApplyButtonStyle(btn, UIThemeHelper.ButtonType.Primary);
                    else if (t.Contains("lưu")) UIThemeHelper.ApplyButtonStyle(btn, UIThemeHelper.ButtonType.Secondary);
                    else if (t.Contains("xóa")) UIThemeHelper.ApplyButtonStyle(btn, UIThemeHelper.ButtonType.Danger);
                    else if (t.Contains("làm mới")) UIThemeHelper.ApplyButtonStyle(btn, UIThemeHelper.ButtonType.Neutral);
                    else if (t.Contains("tìm")) UIThemeHelper.ApplyButtonStyle(btn, UIThemeHelper.ButtonType.Search);
                }
                if (c.HasChildren)
                {
                    ChuanHoaNutBam(c);
                }
            }
        }

        private TextBox LayOTextBoxTimKiem()
        {
            foreach (string name in new[] { "txtTimKiem", "txtTim", "txtSearch", "txtTuKhoa" })
            {
                Control[] found = this.Controls.Find(name, true);
                if (found.Length > 0 && found[0] is TextBox tb) return tb;
            }
            return null;
        }

        private void NapDuLieuCombobox()
        {
            try
            {
                List<string> dsLoai = _hangHoaBUS.LayDanhSachLoaiHang();
                if (dsLoai != null && dsLoai.Count > 0)
                {
                    cboLoaiHang.Items.Clear();
                    foreach (var item in dsLoai) cboLoaiHang.Items.Add(item);
                }
                else if (cboLoaiHang.Items.Count == 0)
                {
                    cboLoaiHang.Items.AddRange(new object[] {
                        "Thực phẩm ăn liền",
                        "Đồ uống & Sữa",
                        "Hóa mỹ phẩm"
                    });
                }

                List<string> dsDvt = _hangHoaBUS.LayDanhSachDonViTinh();
                if (dsDvt != null && dsDvt.Count > 0)
                {
                    cboDVT.Items.Clear();
                    foreach (var item in dsDvt) cboDVT.Items.Add(item);
                }
                else if (cboDVT.Items.Count == 0)
                {
                    cboDVT.Items.AddRange(new object[] {
                        "Thùng", "Hộp", "Gói", "Chai", "Lon", "Lốc", "Túi", "Cái"
                    });
                }
            }
            catch
            {
                if (cboLoaiHang.Items.Count == 0)
                {
                    cboLoaiHang.Items.AddRange(new object[] {
                        "Thực phẩm ăn liền",
                        "Đồ uống & Sữa",
                        "Hóa mỹ phẩm"
                    });
                }

                if (cboDVT.Items.Count == 0)
                {
                    cboDVT.Items.AddRange(new object[] {
                        "Thùng", "Hộp", "Gói", "Chai", "Lon", "Lốc", "Túi", "Cái"
                    });
                }
            }
        }
        #endregion

        #region 2. TẢI DỮ LIỆU & ĐỊNH DẠNG CẢNH BÁO TỒN KHO
        private void LoadDanhSachHangHoa(string tuKhoa = "")
        {
            try
            {
                DataTable dt = _hangHoaBUS.LayDanhSachHangHoa(tuKhoa);
                dgvHangHoa.DataSource = dt;
                DinhDangCotGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục hàng hóa: " + ex.Message, "Thông báo lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DinhDangCotGridView()
        {
            if (dgvHangHoa.Columns.Count == 0) return;

            if (dgvHangHoa.Columns["MaSP"] != null)
            {
                dgvHangHoa.Columns["MaSP"].HeaderText = "Mã SP";
                dgvHangHoa.Columns["MaSP"].FillWeight = 50;
            }
            if (dgvHangHoa.Columns["TenSP"] != null)
            {
                dgvHangHoa.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                dgvHangHoa.Columns["TenSP"].FillWeight = 160;
            }
            if (dgvHangHoa.Columns["LoaiHang"] != null)
            {
                dgvHangHoa.Columns["LoaiHang"].HeaderText = "Nhóm loại";
                dgvHangHoa.Columns["LoaiHang"].FillWeight = 85;
            }
            if (dgvHangHoa.Columns["DonViTinh"] != null)
            {
                dgvHangHoa.Columns["DonViTinh"].HeaderText = "ĐVT";
                dgvHangHoa.Columns["DonViTinh"].FillWeight = 45;
                dgvHangHoa.Columns["DonViTinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvHangHoa.Columns["GiaNhapGanNhat"] != null)
            {
                dgvHangHoa.Columns["GiaNhapGanNhat"].HeaderText = "Giá nhập gần nhất";
                dgvHangHoa.Columns["GiaNhapGanNhat"].DefaultCellStyle.Format = "N0";
                dgvHangHoa.Columns["GiaNhapGanNhat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHangHoa.Columns["GiaNhapGanNhat"].FillWeight = 80;
            }
            if (dgvHangHoa.Columns["SoLuongTon"] != null)
            {
                dgvHangHoa.Columns["SoLuongTon"].HeaderText = "Tồn kho";
                dgvHangHoa.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHangHoa.Columns["SoLuongTon"].FillWeight = 55;
            }
            if (dgvHangHoa.Columns["TonToiThieu"] != null)
            {
                dgvHangHoa.Columns["TonToiThieu"].HeaderText = "Tồn Min";
                dgvHangHoa.Columns["TonToiThieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHangHoa.Columns["TonToiThieu"].FillWeight = 50;
            }
            if (dgvHangHoa.Columns["TonToiDa"] != null)
            {
                dgvHangHoa.Columns["TonToiDa"].HeaderText = "Tồn Max";
                dgvHangHoa.Columns["TonToiDa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHangHoa.Columns["TonToiDa"].FillWeight = 50;
            }
            if (dgvHangHoa.Columns["TenHienThi"] != null)
            {
                dgvHangHoa.Columns["TenHienThi"].Visible = false;
            }
        }

        private void dgvHangHoa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            UIThemeHelper.FormatHangHoaRowWarning(e, dgvHangHoa, "SoLuongTon", "TonToiThieu");
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            HienThiChiTietDongHienTai(dgvHangHoa.Rows[e.RowIndex]);
        }

        private void dgvHangHoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHangHoa.CurrentRow != null && dgvHangHoa.CurrentRow.Index >= 0)
            {
                HienThiChiTietDongHienTai(dgvHangHoa.CurrentRow);
            }
        }

        private void HienThiChiTietDongHienTai(DataGridViewRow row)
        {
            try
            {
                txtMaSP.Text = row.Cells["MaSP"].Value?.ToString() ?? "";
                txtTenSP.Text = row.Cells["TenSP"].Value?.ToString() ?? "";
                cboLoaiHang.SelectedItem = row.Cells["LoaiHang"].Value?.ToString();
                cboDVT.SelectedItem = row.Cells["DonViTinh"].Value?.ToString();

                if (decimal.TryParse(row.Cells["GiaNhapGanNhat"].Value?.ToString(), out decimal giaNhap))
                {
                    txtGiaNhap.Text = giaNhap.ToString("N0");
                }
                else
                {
                    txtGiaNhap.Text = "0";
                }

                if (int.TryParse(row.Cells["TonToiThieu"].Value?.ToString(), out int tonMin))
                {
                    numTonMin.Value = Math.Max(numTonMin.Minimum, Math.Min(numTonMin.Maximum, tonMin));
                }
                if (int.TryParse(row.Cells["TonToiDa"].Value?.ToString(), out int tonMax))
                {
                    numTonMax.Value = Math.Max(numTonMax.Minimum, Math.Min(numTonMax.Maximum, tonMax));
                }

                txtMaSP.ReadOnly = true;
                _isAddingNew = false;
            }
            catch
            {
            }
        }
        #endregion

        #region 3. NGHIỆP VỤ CRUD QUA TẦNG BUS
        private void LamMoiForm()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaNhap.Text = "0";

            if (cboLoaiHang.Items.Count > 0) cboLoaiHang.SelectedIndex = 0;
            if (cboDVT.Items.Count > 0) cboDVT.SelectedIndex = 0;

            numTonMin.Value = 10;
            numTonMax.Value = 500;

            txtMaSP.ReadOnly = false;
            _isAddingNew = true;
            txtMaSP.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();
            string loaiHang = cboLoaiHang.SelectedItem?.ToString() ?? "";
            string dvt = cboDVT.SelectedItem?.ToString() ?? "";

            string giaRaw = txtGiaNhap.Text.Replace(".", "").Replace(",", "").Trim();
            if (!decimal.TryParse(giaRaw, out decimal giaNhap) || giaNhap < 0)
            {
                MessageBox.Show("Đơn giá nhập phải là số không âm.", "Sai định dạng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaNhap.Focus();
                return;
            }

            int tonMin = (int)numTonMin.Value;
            int tonMax = (int)numTonMax.Value;

            HangHoaDTO hh = new HangHoaDTO
            {
                MaSP = maSP,
                TenSP = tenSP,
                LoaiHang = loaiHang,
                DonViTinh = dvt,
                GiaNhapGanNhat = giaNhap,
                TonToiThieu = tonMin,
                TonToiDa = tonMax,
                SoLuongTon = 0
            };

            try
            {
                if (_isAddingNew)
                {
                    _hangHoaBUS.ThemHangHoa(hh);
                    MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _hangHoaBUS.CapNhatHangHoa(hh);
                    MessageBox.Show("Cập nhật thông tin sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDanhSachHangHoa();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ràng buộc nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSP) || _isAddingNew)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa từ danh sách.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sản phẩm: [" + maSP + "] - " + txtTenSP.Text + "?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            try
            {
                _hangHoaBUS.XoaHangHoa(maSP);
                MessageBox.Show("Đã xóa sản phẩm thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDanhSachHangHoa();
                LamMoiForm();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Bảo vệ toàn vẹn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TextBox txtSearch = LayOTextBoxTimKiem();
            if (txtSearch != null) txtSearch.Clear();

            LoadDanhSachHangHoa();
            LamMoiForm();
        }

        private void btnTimKiem_Click(object sender, EventArgs e) { ThucHienTimKiem(); }
        private void btnTim_Click(object sender, EventArgs e) { ThucHienTimKiem(); }

        private void ThucHienTimKiem()
        {
            TextBox txtSearch = LayOTextBoxTimKiem();
            string tuKhoa = txtSearch != null ? txtSearch.Text.Trim() : "";
            LoadDanhSachHangHoa(tuKhoa);
        }

        private void TimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucHienTimKiem();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e) { TimKiem_KeyDown(sender, e); }
        private void txtTim_KeyDown(object sender, KeyEventArgs e) { TimKiem_KeyDown(sender, e); }
        #endregion

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
