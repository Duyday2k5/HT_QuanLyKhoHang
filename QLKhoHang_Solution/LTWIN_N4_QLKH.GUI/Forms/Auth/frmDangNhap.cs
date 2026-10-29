using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LTWIN_N4_QLKH.BUS;
using LTWIN_N4_QLKH.DTO;
using LTWIN_N4_QLKH.GUI.Common;
using LTWIN_N4_QLKH.GUI.Forms.Main;
using LTWIN_N4_QLKH.GUI.Helpers;

namespace LTWIN_N4_QLKH.GUI.Forms.Auth
{
    public partial class frmDangNhap : Form
    {
        private readonly NhanVienBUS _nhanVienBUS = new NhanVienBUS();

        public frmDangNhap()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                NapTaiKhoanDaGhiNho();
                ThemNutCauHinhCSDL();
                CapNhatGiaoDienDangNhap();
            }
        }

        // Cập nhật Logo và chuẩn hóa nút bấm trên màn hình đăng nhập
        private void CapNhatGiaoDienDangNhap()
        {
            if (picLogo != null)
            {
                picLogo.Image = Properties.Resources.logo_khohang;
                picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }

            if (lblBrand != null)
            {
                lblBrand.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                lblBrand.Text = "HỆ THỐNG" + Environment.NewLine + "QUẢN LÝ KHO HÀNG";
            }

            // Chuẩn hóa nút bấm phẳng sang trọng
            UIThemeHelper.ApplyButtonStyle(btnDangNhap, UIThemeHelper.ButtonType.Primary);
            UIThemeHelper.ApplyButtonStyle(btnThoat, UIThemeHelper.ButtonType.Neutral);
        }

        private void ThemNutCauHinhCSDL()
        {
            LinkLabel lnkCauHinh = new LinkLabel();
            lnkCauHinh.Text = "⚙ Cấu hình máy chủ SQL Server";
            lnkCauHinh.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            lnkCauHinh.LinkColor = Color.FromArgb(7, 139, 124);
            lnkCauHinh.AutoSize = true;
            lnkCauHinh.Location = new Point(50, 488);
            lnkCauHinh.Cursor = Cursors.Hand;
            lnkCauHinh.LinkClicked += (s, e) =>
            {
                using (frmKetNoiCSDL form = new frmKetNoiCSDL())
                {
                    form.ShowDialog(this);
                }
            };
            panelContent.Controls.Add(lnkCauHinh);
            lnkCauHinh.BringToFront();
        }

        private void NapTaiKhoanDaGhiNho()
        {
            try
            {
                bool ghiNho = Properties.Settings.Default.GhiNho;
                if (ghiNho)
                {
                    txtTaiKhoan.Text = Properties.Settings.Default.TaiKhoanGhiNho ?? string.Empty;
                    chkGhiNhoTaiKhoan.Checked = true;
                    this.ActiveControl = txtMatKhau;
                    txtMatKhau.Focus();
                }
                else
                {
                    txtTaiKhoan.Text = string.Empty;
                    chkGhiNhoTaiKhoan.Checked = false;
                    this.ActiveControl = txtTaiKhoan;
                    txtTaiKhoan.Focus();
                }
            }
            catch (Exception)
            {
                txtTaiKhoan.Clear();
                chkGhiNhoTaiKhoan.Checked = false;
            }
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVienDTO nhanVien = _nhanVienBUS.DangNhap(txtTaiKhoan.Text, txtMatKhau.Text);
                if (!string.Equals(nhanVien.VaiTro, Convert.ToString(cboVaiTro.SelectedItem), StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Vai trò đã chọn không khớp với tài khoản.", "Không thể đăng nhập",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LuuTaiKhoanDaGhiNho();
                SessionManager.DangNhap(nhanVien);
                Hide();
                using (frmMain mainForm = new frmMain())
                {
                    mainForm.ShowDialog(this);
                }

                txtMatKhau.Clear();
                if (!IsDisposed)
                {
                    Show();
                    Activate();
                    if (chkGhiNhoTaiKhoan.Checked && !string.IsNullOrEmpty(txtTaiKhoan.Text))
                    {
                        txtMatKhau.Focus();
                    }
                    else
                    {
                        txtTaiKhoan.Focus();
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException)
            {
                DialogResult dr = MessageBox.Show(
                    "Không thể kết nối đến SQL Server!\n\nBạn có muốn mở cửa sổ 'Cấu hình kết nối CSDL' để kiểm tra và cập nhật Server name không?",
                    "Lỗi kết nối máy chủ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (dr == DialogResult.Yes)
                {
                    using (frmKetNoiCSDL form = new frmKetNoiCSDL())
                    {
                        form.ShowDialog(this);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Không đọc được cấu hình ứng dụng. Kiểm tra connection string trong App.config.",
                    "Lỗi cấu hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LuuTaiKhoanDaGhiNho()
        {
            try
            {
                if (chkGhiNhoTaiKhoan.Checked)
                {
                    Properties.Settings.Default.GhiNho = true;
                    Properties.Settings.Default.TaiKhoanGhiNho = txtTaiKhoan.Text.Trim();
                    Properties.Settings.Default.TaiKhoanGanNhat = txtTaiKhoan.Text.Trim();
                }
                else
                {
                    Properties.Settings.Default.GhiNho = false;
                    Properties.Settings.Default.TaiKhoanGhiNho = string.Empty;
                    Properties.Settings.Default.TaiKhoanGanNhat = string.Empty;
                }
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void panelHero_Paint(object sender, PaintEventArgs e) { }
        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}