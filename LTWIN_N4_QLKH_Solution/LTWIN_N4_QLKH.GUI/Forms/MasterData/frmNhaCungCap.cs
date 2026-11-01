using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LTWIN_N4_QLKH.BUS;
using LTWIN_N4_QLKH.DTO;
using LTWIN_N4_QLKH.GUI.Helpers;

namespace LTWIN_N4_QLKH.GUI.Forms.MasterData
{
    public partial class frmNhaCungCap : Form
    {
        private readonly NhaCungCapBUS _nccBUS = new NhaCungCapBUS();
        private bool _isAddingNew = false;

        public frmNhaCungCap()
        {
            InitializeComponent();
            UIThemeHelper.ApplyFormHeaderAndIcon(this, "Quản lý Đối tác & Nhà cung cấp", UIThemeHelper.FormIconType.NhaCungCap);
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadDanhSachNhaCungCap();
            LamMoiForm();
        }

        #region 1. CĂN CHỈNH BỐ CỤC ĐỘNG VÀ CHUẨN HÓA GIAO DIỆN
        private void SetupUI()
        {
            this.Font = UIThemeHelper.ControlFont;
            this.BackColor = Color.White;

            // 1. Tự động ẩn tiêu đề con bị trùng
            AnTieuDeTrung(this);

            // 2. Tự động đồng bộ chuẩn hóa màu sắc các nút bấm
            ChuanHoaNutBam(this);

            // 3. Áp dụng định dạng bảng DataGridView chuẩn công sở
            if (dgvNhaCungCap != null)
            {
                UIThemeHelper.ApplyStandardGridStyle(dgvNhaCungCap);
                dgvNhaCungCap.ReadOnly = true;
                dgvNhaCungCap.AllowUserToAddRows = false;
                dgvNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                if (c is Label lbl && lbl.Text.ToUpper().Contains("QUẢN LÝ DANH MỤC NHÀ CUNG CẤP"))
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
            foreach (string name in new[] { "txtTimKiem", "txtTim", "txtSearch", "txtTuKhoa", "txtTimNCC" })
            {
                Control[] found = this.Controls.Find(name, true);
                if (found.Length > 0 && found[0] is TextBox tb) return tb;
            }
            return null;
        }
        #endregion

        #region 2. TẢI DỮ LIỆU VÀ BINDING DÒNG ĐƯỢC CHỌN
        private void LoadDanhSachNhaCungCap(string tuKhoa = "")
        {
            try
            {
                DataTable dt = _nccBUS.LayDanhSachNhaCungCap(tuKhoa);
                dgvNhaCungCap.DataSource = dt;
                DinhDangCotGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục nhà cung cấp: " + ex.Message, "Thông báo lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DinhDangCotGridView()
        {
            if (dgvNhaCungCap.Columns.Count == 0) return;

            foreach (DataGridViewColumn col in dgvNhaCungCap.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvNhaCungCap.Columns["MaNCC"] != null)
            {
                dgvNhaCungCap.Columns["MaNCC"].HeaderText = "Mã NCC";
                dgvNhaCungCap.Columns["MaNCC"].FillWeight = 55;
            }
            if (dgvNhaCungCap.Columns["TenNCC"] != null)
            {
                dgvNhaCungCap.Columns["TenNCC"].HeaderText = "Tên công ty cung ứng";
                dgvNhaCungCap.Columns["TenNCC"].FillWeight = 160;
            }
            if (dgvNhaCungCap.Columns["DienThoai"] != null)
            {
                dgvNhaCungCap.Columns["DienThoai"].HeaderText = "Điện thoại";
                dgvNhaCungCap.Columns["DienThoai"].FillWeight = 80;
            }
            if (dgvNhaCungCap.Columns["NguoiLienHe"] != null)
            {
                dgvNhaCungCap.Columns["NguoiLienHe"].HeaderText = "Người liên hệ";
                dgvNhaCungCap.Columns["NguoiLienHe"].FillWeight = 90;
            }
            if (dgvNhaCungCap.Columns["DiaChi"] != null)
            {
                dgvNhaCungCap.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dgvNhaCungCap.Columns["DiaChi"].FillWeight = 150;
            }
            if (dgvNhaCungCap.Columns["Email"] != null)
            {
                dgvNhaCungCap.Columns["Email"].HeaderText = "Email";
                dgvNhaCungCap.Columns["Email"].FillWeight = 130;
            }
            if (dgvNhaCungCap.Columns["TenHienThi"] != null)
            {
                dgvNhaCungCap.Columns["TenHienThi"].Visible = false;
            }
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            HienThiChiTietDongHienTai(dgvNhaCungCap.Rows[e.RowIndex]);
        }

        private void dgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow != null && dgvNhaCungCap.CurrentRow.Index >= 0)
            {
                HienThiChiTietDongHienTai(dgvNhaCungCap.CurrentRow);
            }
        }

        private void HienThiChiTietDongHienTai(DataGridViewRow row)
        {
            try
            {
                txtMaNCC.Text = row.Cells["MaNCC"].Value?.ToString() ?? "";
                txtTenNCC.Text = row.Cells["TenNCC"].Value?.ToString() ?? "";
                txtDienThoai.Text = row.Cells["DienThoai"].Value?.ToString() ?? "";
                txtNguoiLienHe.Text = row.Cells["NguoiLienHe"].Value?.ToString() ?? "";
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";

                txtMaNCC.ReadOnly = true;
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
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDienThoai.Clear();
            txtNguoiLienHe.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();

            txtMaNCC.ReadOnly = false;
            _isAddingNew = true;
            txtMaNCC.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maNCC = txtMaNCC.Text.Trim();
            string tenNCC = txtTenNCC.Text.Trim();
            string dienThoai = txtDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string nguoiLienHe = txtNguoiLienHe.Text.Trim();

            NhaCungCapDTO ncc = new NhaCungCapDTO
            {
                MaNCC = maNCC,
                TenNCC = tenNCC,
                DienThoai = dienThoai,
                Email = email,
                DiaChi = diaChi,
                NguoiLienHe = nguoiLienHe
            };

            try
            {
                if (_isAddingNew)
                {
                    _nccBUS.ThemNhaCungCap(ncc);
                    MessageBox.Show("Thêm mới nhà cung cấp thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _nccBUS.CapNhatNhaCungCap(ncc);
                    MessageBox.Show("Cập nhật thông tin nhà cung cấp thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDanhSachNhaCungCap();
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
            string maNCC = txtMaNCC.Text.Trim();
            if (string.IsNullOrWhiteSpace(maNCC) || _isAddingNew)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa từ danh sách.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa nhà cung cấp: [" + maNCC + "] - " + txtTenNCC.Text + "?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            try
            {
                _nccBUS.XoaNhaCungCap(maNCC);
                MessageBox.Show("Đã xóa nhà cung cấp thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDanhSachNhaCungCap();
                LamMoiForm();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Bảo vệ toàn vẹn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhà cung cấp: " + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TextBox txtSearch = LayOTextBoxTimKiem();
            if (txtSearch != null) txtSearch.Clear();

            LoadDanhSachNhaCungCap();
            LamMoiForm();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            ThucHienTimKiem();
        }

        private void ThucHienTimKiem()
        {
            TextBox txtSearch = LayOTextBoxTimKiem();
            string tuKhoa = txtSearch != null ? txtSearch.Text.Trim() : "";
            LoadDanhSachNhaCungCap(tuKhoa);
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

        private void txtTimNCC_KeyDown(object sender, KeyEventArgs e)
        {
            TimKiem_KeyDown(sender, e);
        }
        #endregion

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
