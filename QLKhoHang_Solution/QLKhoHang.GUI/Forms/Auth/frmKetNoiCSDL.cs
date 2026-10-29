using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKhoHang.BUS;
using QLKhoHang.GUI.Common;

namespace QLKhoHang.GUI.Forms.Auth
{
    /// <summary>Thay server name cho Windows user hiện tại sau khi kết nối thử thành công.</summary>
    public partial class frmKetNoiCSDL : Form
    {
        private readonly CauHinhCSDL_BUS _cauHinhBUS = new CauHinhCSDL_BUS();

        public frmKetNoiCSDL()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                txtServerName.Text = _cauHinhBUS.LayServerNameHienTai();
            }
        }

        private async void BtnKiemTraVaLuu_Click(object sender, EventArgs e)
        {
            btnKiemTraVaLuu.Enabled = false;
            UseWaitCursor = true;
            lblKetQua.Text = "Đang kiểm tra kết nối...";
            try
            {
                string serverName = txtServerName.Text.Trim();
                string databaseName = await Task.Run(() => _cauHinhBUS.KiemTraVaLuu(
                    SessionManager.NguoiDungHienTai, serverName));
                lblKetQua.Text = "Đã kết nối database " + databaseName + " và lưu server cho user Windows hiện tại.";
                lblKetQua.ForeColor = Color.FromArgb(13, 116, 88);
                MessageBox.Show("Kết nối thành công tới " + serverName + " / " + databaseName + ".",
                    "Đã kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                HienThiLoi(ex.Message);
            }
            catch (ArgumentException ex)
            {
                HienThiLoi(ex.Message);
            }
            catch (SqlException ex)
            {
                HienThiLoi("SQL Server từ chối kết nối. Kiểm tra tên instance, database và quyền Windows. " + ex.Message);
            }
            catch (ConfigurationErrorsException ex)
            {
                HienThiLoi("Không đọc được cấu hình ứng dụng. " + ex.Message);
            }
            catch (IOException ex)
            {
                HienThiLoi("Không lưu được cấu hình riêng cho user Windows. " + ex.Message);
            }
            finally
            {
                UseWaitCursor = false;
                btnKiemTraVaLuu.Enabled = true;
            }
        }

        private void HienThiLoi(string message)
        {
            lblKetQua.Text = message;
            lblKetQua.ForeColor = Color.FromArgb(185, 28, 28);
            MessageBox.Show(message, "Không thể kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
