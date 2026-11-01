using LTWIN_N4_QLKH.GUI.Helpers;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTWIN_N4_QLKH.BUS;
using LTWIN_N4_QLKH.GUI.Common;

namespace LTWIN_N4_QLKH.GUI.Forms.Auth
{
    /// <summary>
    /// Backup database hiện cấu hình; restore chỉ tạo database test mới, không thay thế database nguồn.
    /// </summary>
    public partial class frmSaoLuu : Form
    {
        private readonly SaoLuuBUS _saoLuuBUS = new SaoLuuBUS();

        public frmSaoLuu()
        {
            InitializeComponent();
            UIThemeHelper.ApplyFormHeaderAndIcon(this, "Sao lưu & Khôi phục Cơ sở dữ liệu", UIThemeHelper.FormIconType.Database);
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                lblDatabase.Text = _saoLuuBUS.LayDatabaseDangCauHinh();
            }
        }

        private async void BtnSaoLuu_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Chọn file backup mới";
                dialog.Filter = "SQL Server backup (*.bak)|*.bak";
                dialog.DefaultExt = "bak";
                dialog.AddExtension = true;
                dialog.OverwritePrompt = false;
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dialog.FileName = "LTWIN_N4_QLKH_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                DialogResult confirmation = MessageBox.Show(
                    "Tạo bản sao lưu (backup) của cơ sở dữ liệu " + lblDatabase.Text + " tại:\n" + dialog.FileName +
                    "\n\nBạn có muốn tiếp tục thực hiện không?",
                    "Xác nhận sao lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation != DialogResult.Yes)
                {
                    return;
                }

                string path = dialog.FileName;
                await RunOperationAsync("Đang sao lưu...", () =>
                {
                    _saoLuuBUS.SaoLuu(SessionManager.NguoiDungHienTai, path);
                    return "Backup và VERIFYONLY thành công: " + path;
                });
            }
        }

        private async void BtnKhoiPhuc_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn file backup cần khôi phục";
                dialog.Filter = "SQL Server backup (*.bak)|*.bak|Tất cả file (*.*)|*.*";
                dialog.CheckFileExists = true;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                DialogResult confirmation = MessageBox.Show(
                    "File sẽ được kiểm tra và khôi phục thành một database test mới có tên LTWIN_N4_QLKH_TestRestore_... .\n" +
                    "Database LTWIN_N4_QLKH hiện tại không bị thay thế. SQL Server cần quyền tạo database và quyền đọc file backup.\n\nTiếp tục?",
                    "Xác nhận restore an toàn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation != DialogResult.Yes)
                {
                    return;
                }

                string path = dialog.FileName;
                await RunOperationAsync("Đang VERIFYONLY và restore sang database test mới...", () =>
                {
                    string databaseName = _saoLuuBUS.KhoiPhucSangDatabaseTestMoi(
                        SessionManager.NguoiDungHienTai, path);
                    return "Restore thành công sang database test mới: " + databaseName;
                });
            }
        }

        private async Task RunOperationAsync(string progress, Func<string> operation)
        {
            SetBusy(true);
            lblTrangThai.Text = progress;
            try
            {
                string result = await Task.Run(operation);
                lblTrangThai.Text = result;
                MessageBox.Show(result, "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowError("SQL Server không thể thực hiện thao tác. Kiểm tra quyền, trạng thái database và đường dẫn mà SQL Server service truy cập được. " + ex.Message);
            }
            catch (IOException ex)
            {
                ShowError(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                ShowError(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                ShowError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message);
            }
            catch (NotSupportedException ex)
            {
                ShowError(ex.Message);
            }
            catch (ArgumentException ex)
            {
                ShowError(ex.Message);
            }
            catch (ConfigurationErrorsException ex)
            {
                ShowError("Không đọc được cấu hình ứng dụng. " + ex.Message);
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void SetBusy(bool busy)
        {
            btnSaoLuu.Enabled = !busy;
            btnKhoiPhuc.Enabled = !busy;
            UseWaitCursor = busy;
        }

        private void ShowError(string message)
        {
            lblTrangThai.Text = message;
            lblTrangThai.ForeColor = Color.FromArgb(185, 28, 28);
            MessageBox.Show(message, "Thao tác thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
