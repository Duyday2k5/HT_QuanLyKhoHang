using LTWIN_N4_QLKH.GUI.Helpers;
using System;
using System.Configuration;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using LTWIN_N4_QLKH.BUS;
using LTWIN_N4_QLKH.GUI.Common;

namespace LTWIN_N4_QLKH.GUI.Forms.Auth
{
    /// <summary>Đổi mật khẩu của tài khoản đang đăng nhập.</summary>
    public partial class frmDoiMatKhau : Form
    {
        private readonly NhanVienBUS _nhanVienBUS = new NhanVienBUS();

        public frmDoiMatKhau()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && !SessionManager.DaDangNhap)
                throw new UnauthorizedAccessException("Cần đăng nhập trước khi đổi mật khẩu.");
            InitializeComponent();
            UIThemeHelper.ApplyFormHeaderAndIcon(this, "Đổi mật khẩu người dùng", UIThemeHelper.FormIconType.DoiMatKhau);
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _nhanVienBUS.DoiMatKhau(
                    SessionManager.NguoiDungHienTai,
                    txtMatKhauCu.Text,
                    txtMatKhauMoi.Text,
                    txtXacNhanMatKhau.Text);

                MessageBox.Show("Đổi mật khẩu thành công.", "Hoàn tất",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Kiểm tra thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Không thể đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không kết nối được SQL Server để cập nhật mật khẩu.",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Không đọc được connection string trong App.config.",
                    "Lỗi cấu hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool show = chkHienMatKhau.Checked;
            txtMatKhauCu.UseSystemPasswordChar = !show;
            txtMatKhauMoi.UseSystemPasswordChar = !show;
            txtXacNhanMatKhau.UseSystemPasswordChar = !show;
        }
    }
}
