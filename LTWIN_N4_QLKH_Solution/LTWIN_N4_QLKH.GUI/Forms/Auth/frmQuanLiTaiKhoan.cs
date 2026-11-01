using ClosedXML.Excel;
using LTWIN_N4_QLKH.BUS;
using LTWIN_N4_QLKH.DAL;
using LTWIN_N4_QLKH.DTO;
using LTWIN_N4_QLKH.GUI.Common;
using LTWIN_N4_QLKH.GUI.Helpers;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace LTWIN_N4_QLKH.GUI.Forms.Auth
{
    public partial class frmQuanLiTaiKhoan : Form
    {
        private readonly NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private readonly PhanQuyenBUS _phanQuyenBUS = new PhanQuyenBUS();
        private bool isAddingNew = false;
        private DataTable _dtNhanVien;

        public frmQuanLiTaiKhoan()
        {
            bool designTime = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
            if (!designTime && SessionManager.DaDangNhap)
            {
                _phanQuyenBUS.YeuCauQuyen(SessionManager.NguoiDungHienTai, ChucNang.QuanLyTaiKhoan);
            }

            InitializeComponent();
            UIThemeHelper.ApplyFormHeaderAndIcon(this, "Quản lý Tài khoản & Phân quyền Người dùng", UIThemeHelper.FormIconType.TaiKhoan);
        }

        private void frmQuanLiTaiKhoan_Load(object sender, EventArgs e)
        {
            SetupUI();
            InitComboBoxes();
            LoadDanhSachNhanVien();
            LamMoiForm();
        }

        #region 1. KHỞI TẠO GIAO DIỆN CHUẨN UI/UX
        private void SetupUI()
        {
            UIThemeHelper.ApplyStandardGridStyle(dgvNhanVien);

            // Bật DoubleBuffered để cuộn mượt mà
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvNhanVien, new object[] { true });

            UIThemeHelper.ApplyButtonStyle(btnThem, UIThemeHelper.ButtonType.SaveOrAdd);
            UIThemeHelper.ApplyButtonStyle(btnLuu, UIThemeHelper.ButtonType.Primary);
            UIThemeHelper.ApplyButtonStyle(btnXoa, UIThemeHelper.ButtonType.Danger);
            UIThemeHelper.ApplyButtonStyle(btnDatLaiMK, UIThemeHelper.ButtonType.Neutral);
            UIThemeHelper.ApplyButtonStyle(btnLamMoi, UIThemeHelper.ButtonType.Neutral);
            UIThemeHelper.ApplyButtonStyle(btnXuatExcel, UIThemeHelper.ButtonType.SaveOrAdd);
            UIThemeHelper.ApplyButtonStyle(btnTim, UIThemeHelper.ButtonType.Primary);
            UIThemeHelper.ApplyButtonStyle(btnSinhMa, UIThemeHelper.ButtonType.Neutral);

            // Căn chỉnh tự động khoảng cách giữa các nút thao tác để tránh hiện tượng dính/chồng nút
            btnThem.Width = 96;
            btnLuu.Width = 75;
            btnXoa.Width = 75;
            btnDatLaiMK.Width = 140;
            btnLamMoi.Width = 85;
            btnXuatExcel.Width = 98;
            int curLeft = 6;
            int gap = 8;
            Button[] actionBtns = new Button[] { btnThem, btnLuu, btnXoa, btnDatLaiMK, btnLamMoi, btnXuatExcel };
            foreach (Button b in actionBtns)
            {
                if (b != null)
                {
                    b.Left = curLeft;
                    b.Padding = new Padding(0);
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.TextImageRelation = TextImageRelation.Overlay;
                    curLeft = b.Right + gap;
                }
            }

            // Căn chỉnh 2 cột chuẩn cho các checkbox trong ma trận phân quyền
            foreach (Control c in flpQuyen.Controls)
            {
                if (c is CheckBox cb)
                {
                    cb.AutoSize = false;
                    cb.Size = new Size(185, 24);
                    cb.Margin = new Padding(3, 2, 3, 2);
                }
            }

            this.Font = UIThemeHelper.ControlFont;
            this.BackColor = UIThemeHelper.WorkspaceBgColor;
        }

        private void InitComboBoxes()
        {
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("Quản lý kho");
            cboVaiTro.Items.Add("Thủ kho");
            cboVaiTro.Items.Add("Kế toán kho");
            cboVaiTro.SelectedIndex = 1;

            cboLocVaiTro.Items.Clear();
            cboLocVaiTro.Items.Add("Tất cả");
            cboLocVaiTro.Items.Add("Quản lý kho");
            cboLocVaiTro.Items.Add("Thủ kho");
            cboLocVaiTro.Items.Add("Kế toán kho");
            cboLocVaiTro.SelectedIndex = 0;
        }
        #endregion

        #region 2. TẢI DỮ LIỆU & THỐNG KÊ KPI
        private void LoadDanhSachNhanVien()
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                string vaiTro = cboLocVaiTro.SelectedItem?.ToString() ?? "Tất cả";

                _dtNhanVien = _nhanVienBUS.TimKiemNhanVien(tuKhoa, vaiTro);
                dgvNhanVien.DataSource = _dtNhanVien;

                DinhDangCotGrid();
                CapNhatThongKeKPI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tài khoản: " + ex.Message,
                    "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DinhDangCotGrid()
        {
            dgvNhanVien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (dgvNhanVien.Columns["MaNV"] != null)
            {
                dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
                dgvNhanVien.Columns["MaNV"].FillWeight = 75;
                dgvNhanVien.Columns["MaNV"].MinimumWidth = 70;
                dgvNhanVien.Columns["MaNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvNhanVien.Columns["HoTen"] != null)
            {
                dgvNhanVien.Columns["HoTen"].HeaderText = "Họ và tên nhân viên";
                dgvNhanVien.Columns["HoTen"].FillWeight = 160;
                dgvNhanVien.Columns["HoTen"].MinimumWidth = 150;
                dgvNhanVien.Columns["HoTen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvNhanVien.Columns["TaiKhoan"] != null)
            {
                dgvNhanVien.Columns["TaiKhoan"].HeaderText = "Tên đăng nhập";
                dgvNhanVien.Columns["TaiKhoan"].FillWeight = 100;
                dgvNhanVien.Columns["TaiKhoan"].MinimumWidth = 95;
                dgvNhanVien.Columns["TaiKhoan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvNhanVien.Columns["VaiTro"] != null)
            {
                dgvNhanVien.Columns["VaiTro"].HeaderText = "Vai trò hệ thống";
                dgvNhanVien.Columns["VaiTro"].FillWeight = 105;
                dgvNhanVien.Columns["VaiTro"].MinimumWidth = 100;
                dgvNhanVien.Columns["VaiTro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvNhanVien.Columns["DienThoai"] != null)
            {
                dgvNhanVien.Columns["DienThoai"].HeaderText = "Số điện thoại";
                dgvNhanVien.Columns["DienThoai"].FillWeight = 95;
                dgvNhanVien.Columns["DienThoai"].MinimumWidth = 90;
                dgvNhanVien.Columns["DienThoai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            if (dgvNhanVien.Columns["SoPhieuNhap"] != null)
            {
                dgvNhanVien.Columns["SoPhieuNhap"].HeaderText = "Phiếu nhập";
                dgvNhanVien.Columns["SoPhieuNhap"].FillWeight = 80;
                dgvNhanVien.Columns["SoPhieuNhap"].MinimumWidth = 75;
                dgvNhanVien.Columns["SoPhieuNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvNhanVien.Columns["SoPhieuNhap"].DefaultCellStyle.Format = "N0";
            }
            if (dgvNhanVien.Columns["SoPhieuXuat"] != null)
            {
                dgvNhanVien.Columns["SoPhieuXuat"].HeaderText = "Phiếu xuất";
                dgvNhanVien.Columns["SoPhieuXuat"].FillWeight = 80;
                dgvNhanVien.Columns["SoPhieuXuat"].MinimumWidth = 75;
                dgvNhanVien.Columns["SoPhieuXuat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvNhanVien.Columns["SoPhieuXuat"].DefaultCellStyle.Format = "N0";
            }
        }

        private void CapNhatThongKeKPI()
        {
            try
            {
                DataTable allData = _nhanVienBUS.LayTatCaNhanVien();
                int tong = allData.Rows.Count;
                int quanLy = 0;
                int thuKho = 0;
                int keToan = 0;

                foreach (DataRow row in allData.Rows)
                {
                    string vt = row["VaiTro"]?.ToString() ?? "";
                    if (vt == "Quản lý kho") quanLy++;
                    else if (vt == "Thủ kho") thuKho++;
                    else if (vt == "Kế toán kho") keToan++;
                }

                lblKpiTong.Text = tong.ToString();
                lblKpiQuanLy.Text = quanLy.ToString();
                lblKpiThuKho.Text = thuKho.ToString();
                lblKpiKeToan.Text = keToan.ToString();
            }
            catch
            {
                // Bỏ qua lỗi thống kê nhẹ
            }
        }
        #endregion

        #region 3. MA TRẬN PHÂN QUYỀN TRỰC QUAN
        private void CapNhatQuyenTheoVaiTro(string vaiTro)
        {
            bool isQuanLy = string.Equals(vaiTro, "Quản lý kho", StringComparison.OrdinalIgnoreCase);
            bool isThuKho = string.Equals(vaiTro, "Thủ kho", StringComparison.OrdinalIgnoreCase);
            bool isKeToan = string.Equals(vaiTro, "Kế toán kho", StringComparison.OrdinalIgnoreCase);

            chkQuyenTongQuan.Checked = isQuanLy || isThuKho || isKeToan;
            chkQuyenHangHoa.Checked = isQuanLy;
            chkQuyenNhaCungCap.Checked = isQuanLy;
            chkQuyenNhapKho.Checked = isQuanLy || isThuKho;
            chkQuyenXuatKho.Checked = isQuanLy || isThuKho;
            chkQuyenKiemKe.Checked = isQuanLy || isThuKho;
            chkQuyenTheKho.Checked = isQuanLy || isThuKho || isKeToan;
            chkQuyenBaoCaoTon.Checked = isQuanLy || isKeToan;
            chkQuyenQuanLyTK.Checked = isQuanLy;
            chkQuyenSaoLuu.Checked = isQuanLy;
            chkQuyenKetNoiCSDL.Checked = isQuanLy;
            chkQuyenDoiMK.Checked = isQuanLy || isThuKho || isKeToan;

            // Đổi màu sắc trực quan cho các checkbox quyền
            Color activeColor = Color.FromArgb(15, 118, 110); // Teal
            Color inactiveColor = Color.FromArgb(148, 163, 184); // Gray

            foreach (Control c in flpQuyen.Controls)
            {
                if (c is CheckBox cb)
                {
                    cb.ForeColor = cb.Checked ? activeColor : inactiveColor;
                    cb.Font = new Font("Segoe UI", 9f, cb.Checked ? FontStyle.Bold : FontStyle.Regular);
                }
            }
        }
        #endregion

        #region 4. THAO TÁC CRUD
        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            LamMoiForm();
            txtMaNV.Text = _nhanVienBUS.PhatSinhMaNVMoi();
            txtMaNV.Enabled = true;
            txtTaiKhoan.Enabled = true;
            txtMatKhau.Enabled = true;
            txtMatKhau.Text = "";
            txtHoTen.Focus();
        }

        private void btnSinhMa_Click(object sender, EventArgs e)
        {
            if (isAddingNew)
            {
                txtMaNV.Text = _nhanVienBUS.PhatSinhMaNVMoi();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string dienThoai = txtDienThoai.Text.Trim();
            string vaiTro = cboVaiTro.SelectedItem?.ToString() ?? "";
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng nhập hoặc sinh Mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }

            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrEmpty(taiKhoan))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }

            if (taiKhoan.Contains(" "))
            {
                MessageBox.Show("Tên đăng nhập không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }

            if (string.IsNullOrEmpty(vaiTro))
            {
                MessageBox.Show("Vui lòng chọn Vai trò cho tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboVaiTro.Focus();
                return;
            }

            try
            {
                if (isAddingNew)
                {
                    if (string.IsNullOrEmpty(matKhau) || matKhau.Length < 6)
                    {
                        MessageBox.Show("Mật khẩu khởi tạo phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMatKhau.Focus();
                        return;
                    }

                    _nhanVienBUS.ThemNhanVien(maNV, hoTen, taiKhoan, matKhau, vaiTro, dienThoai);
                    MessageBox.Show($"Thêm mới tài khoản [{taiKhoan}] cho nhân viên '{hoTen}' thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _nhanVienBUS.CapNhatNhanVien(maNV, hoTen, vaiTro, dienThoai);
                    MessageBox.Show($"Cập nhật thông tin nhân viên [{maNV}] thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDanhSachNhanVien();
                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDatLaiMK_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (string.IsNullOrEmpty(maNV) || isAddingNew)
            {
                MessageBox.Show("Vui lòng chọn nhân viên từ danh sách cần đặt lại mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn đặt lại mật khẩu cho tài khoản:\n[{taiKhoan}] - {hoTen} không?\n\n" +
                "Mật khẩu mới sẽ được thiết lập thành mặc định: '12345678'\n" +
                "(Nhân viên nên đăng nhập và đổi lại mật khẩu ngay sau đó).",
                "Xác nhận đặt lại mật khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    _nhanVienBUS.DatLaiMatKhau(maNV, "12345678");
                    MessageBox.Show($"Đặt lại mật khẩu cho tài khoản [{taiKhoan}] thành công!\nMật khẩu mới là: 12345678",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đặt lại mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string taiKhoan = txtTaiKhoan.Text.Trim();

            if (string.IsNullOrEmpty(maNV) || isAddingNew)
            {
                MessageBox.Show("Vui lòng chọn nhân viên từ danh sách cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNVHienTai = SessionManager.NguoiDungHienTai?.MaNV;
            if (!string.IsNullOrEmpty(maNVHienTai) && string.Equals(maNV, maNVHienTai, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không thể xóa tài khoản của chính bạn đang đăng nhập vào hệ thống!",
                    "Chặn thao tác", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                // Kiểm tra xem có phải Quản lý kho duy nhất không
                DataTable dtAll = _nhanVienBUS.LayTatCaNhanVien();
                int soQuanLy = 0;
                foreach (DataRow r in dtAll.Rows)
                {
                    if (r["VaiTro"]?.ToString() == "Quản lý kho") soQuanLy++;
                }

                if (cboVaiTro.SelectedItem?.ToString() == "Quản lý kho" && soQuanLy <= 1)
                {
                    MessageBox.Show("Hệ thống chỉ còn duy nhất 1 Quản lý kho. Không thể xóa tài khoản quản trị cuối cùng!",
                        "Chặn thao tác", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                // Kiểm tra giao dịch phiếu nhập/xuất
                _nhanVienBUS.KiemTraRangBuoc(maNV, out int soPN, out int soPX);
                if (soPN > 0 || soPX > 0)
                {
                    MessageBox.Show(
                        $"Không thể xóa nhân viên [{maNV}] - {hoTen} vì đã phát sinh lịch sử trong kho:\n" +
                        $"• Số phiếu nhập: {soPN}\n" +
                        $"• Số phiếu xuất: {soPX}\n\n" +
                        "Để bảo vệ toàn vẹn chứng từ kế toán, bạn chỉ có thể cập nhật thông tin tài khoản này.",
                        "Chặn xóa vi phạm ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                DialogResult dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa vĩnh viễn tài khoản [{taiKhoan}] của nhân viên:\n[{maNV}] - {hoTen} không?",
                    "Xác nhận xóa tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    _nhanVienBUS.XoaNhanVien(maNV, maNVHienTai);
                    MessageBox.Show("Xóa tài khoản nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNhanVien();
                    LamMoiForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocVaiTro.SelectedIndex = 0;
            LamMoiForm();
            LoadDanhSachNhanVien();
        }

        private void LamMoiForm()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtTaiKhoan.Clear();
            txtDienThoai.Clear();
            txtMatKhau.Clear();
            chkHienMatKhau.Checked = false;
            cboVaiTro.SelectedIndex = 1;

            txtMaNV.Enabled = true;
            txtTaiKhoan.Enabled = true;
            txtMatKhau.Enabled = true;
            isAddingNew = true;

            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDatLaiMK.Enabled = false;

            CapNhatQuyenTheoVaiTro("Thủ kho");
        }
        #endregion

        #region 5. SỰ KIỆN GRID & TƯƠNG TÁC
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                if (row == null || row.Cells["MaNV"].Value == null) return;

                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
                txtTaiKhoan.Text = row.Cells["TaiKhoan"].Value?.ToString() ?? "";
                txtDienThoai.Text = row.Cells["DienThoai"].Value?.ToString() ?? "";

                string vaiTro = row.Cells["VaiTro"].Value?.ToString() ?? "";
                if (cboVaiTro.Items.Contains(vaiTro))
                {
                    cboVaiTro.SelectedItem = vaiTro;
                }

                txtMatKhau.Clear();
                txtMatKhau.Enabled = false; // Khi xem/sửa không sửa trực tiếp mật khẩu
                txtMaNV.Enabled = false;
                txtTaiKhoan.Enabled = false;

                isAddingNew = false;
                btnLuu.Enabled = true;
                btnXoa.Enabled = true;
                btnDatLaiMK.Enabled = true;

                CapNhatQuyenTheoVaiTro(vaiTro);
            }
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvNhanVien.Rows.Count) return;

            // Định dạng cột VaiTro
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "VaiTro" && e.Value != null)
            {
                string vt = e.Value.ToString();
                if (vt == "Quản lý kho")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(15, 118, 110); // Teal đậm
                    e.CellStyle.Font = UIThemeHelper.ControlBoldFont;
                }
                else if (vt == "Thủ kho")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(3, 105, 161); // Blue
                    e.CellStyle.Font = UIThemeHelper.ControlFont;
                }
                else if (vt == "Kế toán kho")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(126, 34, 206); // Purple
                    e.CellStyle.Font = UIThemeHelper.ControlFont;
                }
            }
        }

        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cboVaiTro.SelectedItem?.ToString() ?? "";
            CapNhatQuyenTheoVaiTro(selected);
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void cboLocVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDanhSachNhanVien();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        #region 6. XUẤT BÁO CÁO EXCEL
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nhân viên để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Tệp Excel (*.xlsx)|*.xlsx";
                sfd.FileName = $"DanhSachNhanVien_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            IXLWorksheet ws = wb.Worksheets.Add("NhanVien");

                            // Tiêu đề bảng
                            ws.Range(1, 1, 1, 7).Merge();
                            ws.Cell(1, 1).Value = "DANH SÁCH TÀI KHOẢN VÀ PHÂN QUYỀN NHÂN VIÊN";
                            ws.Cell(1, 1).Style.Font.Bold = true;
                            ws.Cell(1, 1).Style.Font.FontSize = 14;
                            ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.FromHtml("#0F172A");
                            ws.Cell(1, 1).Style.Font.FontColor = XLColor.White;

                            ws.Cell(2, 1).Value = $"Thời gian xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                            ws.Range(2, 1, 2, 7).Merge();
                            ws.Cell(2, 1).Style.Font.Italic = true;
                            ws.Cell(2, 1).Style.Font.FontSize = 9;
                            ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // Header dòng 4
                            string[] headers = { "STT", "Mã NV", "Họ và tên", "Tên đăng nhập", "Vai trò hệ thống", "Số điện thoại", "Số phiếu đã lập" };
                            for (int i = 0; i < headers.Length; i++)
                            {
                                var cell = ws.Cell(4, i + 1);
                                cell.Value = headers[i];
                                cell.Style.Font.Bold = true;
                                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#1E293B");
                                cell.Style.Font.FontColor = XLColor.White;
                                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            }

                            // Dữ liệu
                            int r = 5;
                            int stt = 1;
                            foreach (DataGridViewRow row in dgvNhanVien.Rows)
                            {
                                ws.Cell(r, 1).Value = stt++;
                                ws.Cell(r, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                                ws.Cell(r, 2).Value = row.Cells["MaNV"].Value?.ToString() ?? "";
                                ws.Cell(r, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                                ws.Cell(r, 3).Value = row.Cells["HoTen"].Value?.ToString() ?? "";
                                ws.Cell(r, 4).Value = row.Cells["TaiKhoan"].Value?.ToString() ?? "";
                                ws.Cell(r, 5).Value = row.Cells["VaiTro"].Value?.ToString() ?? "";

                                ws.Cell(r, 6).Value = row.Cells["DienThoai"].Value?.ToString() ?? "";
                                ws.Cell(r, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                                int pn = Convert.ToInt32(row.Cells["SoPhieuNhap"].Value ?? 0);
                                int px = Convert.ToInt32(row.Cells["SoPhieuXuat"].Value ?? 0);
                                ws.Cell(r, 7).Value = $"{pn} nhập, {px} xuất";
                                ws.Cell(r, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                                for (int c = 1; c <= 7; c++)
                                {
                                    ws.Cell(r, c).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                    if (r % 2 == 0)
                                    {
                                        ws.Cell(r, c).Style.Fill.BackgroundColor = XLColor.FromHtml("#F8FAFC");
                                    }
                                }
                                r++;
                            }

                            ws.Columns().AdjustToContents();
                            wb.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Xuất danh sách nhân viên ra Excel thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
