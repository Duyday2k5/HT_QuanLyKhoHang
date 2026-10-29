using LTWIN_N4_QLKH.BUS;
using LTWIN_N4_QLKH.DTO;
using LTWIN_N4_QLKH.GUI;
using LTWIN_N4_QLKH.GUI.Common;
using LTWIN_N4_QLKH.GUI.Forms.Auth;
using LTWIN_N4_QLKH.GUI.Forms.Inventory;
using LTWIN_N4_QLKH.GUI.Forms.MasterData;
using LTWIN_N4_QLKH.GUI.Forms.Transactions;
using LTWIN_N4_QLKH.GUI.Helpers;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LTWIN_N4_QLKH.GUI.Forms.Main
{
    public partial class frmMain : Form
    {
        private readonly PhanQuyenBUS _phanQuyenBUS = new PhanQuyenBUS();
        private Form _activeChildForm = null;
        private bool _isLoggingOut = false;

        public frmMain()
        {
            bool designTime = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
            if (!designTime && !SessionManager.DaDangNhap)
            {
                throw new UnauthorizedAccessException("Cần đăng nhập trước khi mở màn hình chính.");
            }

            InitializeComponent();
            NhanVienDTO user = designTime ? GetDesignUser() : SessionManager.NguoiDungHienTai;
            HienThiNguoiDung(user);
            CauHinhMenu(user);
            HienThiTongQuan(user);

            ThemNutGioiThieu();
            VeLogoHienDai();

            if (!designTime)
            {
                FormClosed += delegate
                {
                    DongFormConHienTai();
                    if (!_isLoggingOut)
                    {
                        SessionManager.DangXuat();
                        Application.Exit();
                    }
                };
            }
        }

        // VẼ VÀ HIỂN THỊ LOGO HỆ THỐNG
        private void VeLogoHienDai()
        {
            try
            {
                if (picLogoMain != null)
                {
                    picLogoMain.Image = Properties.Resources.logo_khohang;
                    picLogoMain.SizeMode = PictureBoxSizeMode.Zoom;
                }

                if (picLogoSidebar != null)
                {
                    picLogoSidebar.Image = Properties.Resources.logo_khohang;
                    picLogoSidebar.SizeMode = PictureBoxSizeMode.Zoom;
                }

                if (lblBrand != null)
                {
                    lblBrand.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    lblBrand.Text = "HỆ THỐNG" + Environment.NewLine + "QUẢN LÝ KHO HÀNG";
                }
            }
            catch
            {
            }
        }

        private void LogoControl_Paint(object sender, PaintEventArgs e)
        {
            Control pnl = sender as Control;
            if (pnl == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            if (Properties.Resources.logo_khohang != null)
            {
                g.DrawImage(Properties.Resources.logo_khohang, new Rectangle(0, 0, pnl.Width, pnl.Height));
            }
        }
        

        //ĐIỀU HƯỚNG & QUẢN LÝ FORM CON
        private void ThemNutGioiThieu()
        {
            Button btnAbout = new Button();
            btnAbout.Text = "Giới thiệu đề tài";
            btnAbout.Size = new Size(236, 36);
            btnAbout.Margin = new Padding(0, 1, 0, 1);
            btnAbout.FlatStyle = FlatStyle.Flat;
            btnAbout.FlatAppearance.BorderSize = 0;
            btnAbout.BackColor = Color.FromArgb(16, 44, 59);
            btnAbout.ForeColor = Color.FromArgb(226, 232, 240);
            btnAbout.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            btnAbout.TextAlign = ContentAlignment.MiddleLeft;
            btnAbout.Padding = new Padding(12, 0, 4, 0);
            btnAbout.Cursor = Cursors.Hand;

            btnAbout.MouseEnter += (s, e) => { btnAbout.BackColor = Color.FromArgb(19, 126, 119); };
            btnAbout.MouseLeave += (s, e) => { btnAbout.BackColor = Color.FromArgb(16, 44, 59); };

            btnAbout.Click += (s, e) =>
            {
                using (frmAbout f = new frmAbout())
                {
                    f.ShowDialog(this);
                }
            };

            flpMenu.Controls.Add(btnAbout);
        }

        private static NhanVienDTO GetDesignUser()
        {
            return new NhanVienDTO { HoTen = "Nguyễn Văn An", VaiTro = "Quản lý kho" };
        }

        private void DongFormConHienTai()
        {
            if (_activeChildForm != null)
            {
                pnlModulePlaceholder.Controls.Remove(_activeChildForm);
                _activeChildForm.Close();
                _activeChildForm.Dispose();
                _activeChildForm = null;
            }

            pnlModulePlaceholder.Controls.Clear();
            lblModulePlaceholder.Visible = true;
        }

        private void HienThiFormCon(Form childForm, string tieuDe)
        {
            DongFormConHienTai();

            _activeChildForm = childForm;
            lblTieuDe.Text = tieuDe.ToUpperInvariant();
            pnlDashboard.Visible = false;
            pnlModulePlaceholder.Visible = true;
            lblModulePlaceholder.Visible = false;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlModulePlaceholder.Controls.Clear();
            pnlModulePlaceholder.Controls.Add(childForm);
            pnlModulePlaceholder.Tag = childForm;
            UIThemeHelper.DongBoToanDienFormCon(childForm, tieuDe);
            childForm.BringToFront();
            childForm.Show();
        }

        private void HienThiNguoiDung(NhanVienDTO user)
        {
            if (user == null) return;
            lblNguoiDung.Text = user.HoTen + Environment.NewLine + user.VaiTro;
            lblAvatar.Text = Initials(user.HoTen);
            btnHeaderDangXuat.Text = "Đăng xuất  ·  " + user.HoTen;
        }

        private void CauHinhMenu(NhanVienDTO user)
        {
            ConfigureMenuItem(btnTongQuan, ChucNang.TongQuan, user);
            ConfigureMenuItem(btnHangHoa, ChucNang.HangHoa, user);
            ConfigureMenuItem(btnNhaCungCap, ChucNang.NhaCungCap, user);
            ConfigureMenuItem(btnNhapKho, ChucNang.NhapKho, user);
            ConfigureMenuItem(btnXuatKho, ChucNang.XuatKho, user);
            ConfigureMenuItem(btnKiemKeKho, ChucNang.KiemKe, user);
            ConfigureMenuItem(btnTheKho, ChucNang.TheKho, user);
            ConfigureMenuItem(btnBaoCaoTonKho, ChucNang.BaoCaoTonKho, user);
            ConfigureMenuItem(btnQuanLyTaiKhoan, ChucNang.QuanLyTaiKhoan, user);
            ConfigureMenuItem(btnSaoLuu, ChucNang.SaoLuu, user);
            ConfigureMenuItem(btnKetNoiCSDL, ChucNang.KetNoiCSDL, user);
        }

        private void ConfigureMenuItem(Button button, ChucNang chucNang, NhanVienDTO user)
        {
            button.Tag = chucNang;
            button.Visible = _phanQuyenBUS.CoQuyen(user, chucNang);
        }

        private static string Initials(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "NV";
            string[] parts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1)
                return parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpperInvariant();
            return (parts[0][0].ToString() + parts[parts.Length - 1][0]).ToUpperInvariant();
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null || !(button.Tag is ChucNang)) return;

            foreach (Control control in flpMenu.Controls)
            {
                Button item = control as Button;
                if (item == null) continue;
                bool selected = ReferenceEquals(item, button);
                item.BackColor = selected ? Color.FromArgb(19, 126, 119) : Color.FromArgb(16, 44, 59);
                item.ForeColor = selected ? Color.White : Color.FromArgb(226, 232, 240);
            }

            ChucNang chucNang = (ChucNang)button.Tag;

            if (chucNang == ChucNang.TongQuan)
            {
                DongFormConHienTai();
                pnlDashboard.Visible = true;
                pnlDashboard.BringToFront();
                pnlModulePlaceholder.Visible = false;
                lblTieuDe.Text = "TỔNG QUAN HỆ THỐNG";
                TaiDuLieuHoatDongGanDay();
                return;
            }

            OpenModule(chucNang, button.Text);
        }

        private void OpenModule(ChucNang chucNang, string tenModule)
        {
            try
            {
                if (chucNang == ChucNang.KetNoiCSDL)
                {
                    using (frmKetNoiCSDL form = new frmKetNoiCSDL())
                    {
                        form.ShowDialog(this);
                    }
                    return;
                }

                if (SessionManager.NguoiDungHienTai != null)
                {
                    _phanQuyenBUS.YeuCauQuyen(SessionManager.NguoiDungHienTai, chucNang);
                }

                if (chucNang == ChucNang.SaoLuu)
                {
                    using (frmSaoLuu form = new frmSaoLuu())
                    {
                        form.ShowDialog(this);
                    }
                    return;
                }

                switch (chucNang)
                {
                    case ChucNang.HangHoa:
                        HienThiFormCon(new frmHangHoa(), "QUẢN LÝ DANH MỤC HÀNG HÓA");
                        return;

                    case ChucNang.NhaCungCap:
                        HienThiFormCon(new frmNhaCungCap(), "QUẢN LÝ NHÀ CUNG CẤP");
                        return;

                    case ChucNang.NhapKho:
                        HienThiFormCon(new frmNhapKho(), "QUẢN LÝ NHẬP KHO");
                        return;

                    case ChucNang.XuatKho:
                        HienThiFormCon(new frmXuatKho(), "QUẢN LÝ XUẤT KHO");
                        return;

                    case ChucNang.KiemKe:
                        HienThiFormCon(new frmKiemKe(), "KIỂM KÊ VÀ CÂN BẰNG KHO");
                        return;

                    case ChucNang.TheKho:
                        HienThiFormCon(new frmTheKho(), "SỔ THẺ KHO HÀNG HÓA");
                        return;

                    case ChucNang.BaoCaoTonKho:
                        HienThiFormCon(new frmBaoCaoTonKho(), "BÁO CÁO NHẬP - XUẤT - TỒN");
                        return;

                    case ChucNang.QuanLyTaiKhoan:
                        HienThiFormCon(new frmQuanLiTaiKhoan(), "QUẢN LÝ TÀI KHOẢN NGƯỜI DÙNG");
                        return;
                }

                DongFormConHienTai();
                lblTieuDe.Text = tenModule.ToUpperInvariant();
                lblModulePlaceholder.Text = tenModule + Environment.NewLine + Environment.NewLine +
                    "Màn hình này sẽ được tích hợp khi hoàn tất module được phân công.";
                lblModulePlaceholder.Visible = true;
                pnlDashboard.Visible = false;
                pnlModulePlaceholder.Visible = true;
                pnlModulePlaceholder.BringToFront();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HienThiTongQuan(NhanVienDTO user)
        {
            lblChaoMung.Text = "Xin chào, " + user.HoTen + ". Bạn đang đăng nhập với vai trò " + user.VaiTro + ".";
            lblTrangThai.Text = "●  Kết nối cơ sở dữ liệu sẽ được kiểm tra khi truy vấn.";
            lblDatabaseStatus.Text = "Database theo cấu hình ứng dụng: LTWIN_N4_QLKH_DB";

            TaiDuLieuHoatDongGanDay();
        }

        private void TaiDuLieuHoatDongGanDay()
        {
            try
            {
                lblActivityDescription.Text = "Theo dõi nhật ký giao dịch xuất - nhập kho và các hoạt động hệ thống mới nhất theo thời gian thực.";
                DataTable dt = null;

                try
                {
                    const string sql = @"
                        SELECT TOP 20
                            HoatDong.NgayGhi,
                            HoatDong.LoaiGiaoDich,
                            HoatDong.MaChungTu,
                            HoatDong.DienGiai,
                            HoatDong.NguoiThucHien,
                            HoatDong.GiaTri
                        FROM (
                            SELECT 
                                PN.NgayNhap AS NgayGhi,
                                N'Nhập kho' AS LoaiGiaoDich,
                                PN.MaPN AS MaChungTu,
                                CASE 
                                    WHEN PN.GhiChu LIKE N'%cân bằng%' OR PN.GhiChu LIKE N'%Cân bằng%' THEN PN.GhiChu
                                    ELSE N'Nhập hàng từ ' + ISNULL(NCC.TenNCC, PN.MaNCC)
                                END AS DienGiai,
                                ISNULL(NV.HoTen, PN.MaNV) AS NguoiThucHien,
                                PN.TongTienNhap AS GiaTri
                            FROM dbo.PhieuNhap PN
                            LEFT JOIN dbo.NhaCungCap NCC ON PN.MaNCC = NCC.MaNCC
                            LEFT JOIN dbo.NhanVien NV ON PN.MaNV = NV.MaNV

                            UNION ALL

                            SELECT 
                                PX.NgayXuat AS NgayGhi,
                                N'Xuất kho' AS LoaiGiaoDich,
                                PX.MaPX AS MaChungTu,
                                CASE 
                                    WHEN PX.LyDoXuat LIKE N'%cân bằng%' OR PX.LyDoXuat LIKE N'%Cân bằng%' THEN PX.LyDoXuat
                                    ELSE N'Xuất giao ' + ISNULL(PX.NguoiNhan, N'') + N' (' + ISNULL(PX.LyDoXuat, N'') + N')'
                                END AS DienGiai,
                                ISNULL(NV.HoTen, PX.MaNV) AS NguoiThucHien,
                                PX.TongTienXuat AS GiaTri
                            FROM dbo.PhieuXuat PX
                            LEFT JOIN dbo.NhanVien NV ON PX.MaNV = NV.MaNV
                        ) AS HoatDong
                        ORDER BY NgayGhi DESC;";

                    dt = LTWIN_N4_QLKH.DAL.DatabaseHelper.ExecuteQuery(sql, null);
                }
                catch
                {
                    dt = null;
                }

                if (dt == null || dt.Rows.Count == 0)
                {
                    dt = TaoDuLieuHoatDongMau();
                }

                dgvHoatDongGanDay.DataSource = dt;
                UIThemeHelper.ApplyStandardGridStyle(dgvHoatDongGanDay);

                if (dgvHoatDongGanDay.Columns.Contains("NgayGhi"))
                {
                    dgvHoatDongGanDay.Columns["NgayGhi"].HeaderText = "Thời gian";
                    dgvHoatDongGanDay.Columns["NgayGhi"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvHoatDongGanDay.Columns["NgayGhi"].Width = 140;
                }

                if (dgvHoatDongGanDay.Columns.Contains("LoaiGiaoDich"))
                {
                    dgvHoatDongGanDay.Columns["LoaiGiaoDich"].HeaderText = "Loại hoạt động";
                    dgvHoatDongGanDay.Columns["LoaiGiaoDich"].Width = 120;
                    dgvHoatDongGanDay.Columns["LoaiGiaoDich"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvHoatDongGanDay.Columns.Contains("MaChungTu"))
                {
                    dgvHoatDongGanDay.Columns["MaChungTu"].HeaderText = "Mã chứng từ";
                    dgvHoatDongGanDay.Columns["MaChungTu"].Width = 130;
                    dgvHoatDongGanDay.Columns["MaChungTu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvHoatDongGanDay.Columns.Contains("DienGiai"))
                {
                    dgvHoatDongGanDay.Columns["DienGiai"].HeaderText = "Nội dung chi tiết";
                    dgvHoatDongGanDay.Columns["DienGiai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvHoatDongGanDay.Columns["DienGiai"].MinimumWidth = 220;
                }

                if (dgvHoatDongGanDay.Columns.Contains("NguoiThucHien"))
                {
                    dgvHoatDongGanDay.Columns["NguoiThucHien"].HeaderText = "Người thực hiện";
                    dgvHoatDongGanDay.Columns["NguoiThucHien"].Width = 160;
                }

                if (dgvHoatDongGanDay.Columns.Contains("GiaTri"))
                {
                    dgvHoatDongGanDay.Columns["GiaTri"].HeaderText = "Giá trị (VNĐ)";
                    dgvHoatDongGanDay.Columns["GiaTri"].Width = 130;
                    dgvHoatDongGanDay.Columns["GiaTri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvHoatDongGanDay.Columns["GiaTri"].DefaultCellStyle.Format = "N0";
                }

                dgvHoatDongGanDay.CellFormatting -= DgvHoatDongGanDay_CellFormatting;
                dgvHoatDongGanDay.CellFormatting += DgvHoatDongGanDay_CellFormatting;

                dgvHoatDongGanDay.Visible = true;
                lblActivityEmpty.Visible = false;
            }
            catch
            {
                dgvHoatDongGanDay.Visible = false;
                lblActivityEmpty.Visible = true;
            }
        }

        private static DataTable TaoDuLieuHoatDongMau()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NgayGhi", typeof(DateTime));
            dt.Columns.Add("LoaiGiaoDich", typeof(string));
            dt.Columns.Add("MaChungTu", typeof(string));
            dt.Columns.Add("DienGiai", typeof(string));
            dt.Columns.Add("NguoiThucHien", typeof(string));
            dt.Columns.Add("GiaTri", typeof(decimal));

            DateTime now = DateTime.Now;
            dt.Rows.Add(now.AddMinutes(-25), "Nhập kho", "PN20261030001", "Nhập hàng từ Unilever Việt Nam (Dầu gội, Xà bông)", "Nguyễn Quốc Bảo", 25600000m);
            dt.Rows.Add(now.AddHours(-2), "Xuất kho", "PX20261030001", "Xuất hàng giao Siêu thị Bách Hóa Xanh (Bán buôn)", "Bùi Quang Duy", 18450000m);
            dt.Rows.Add(now.AddHours(-4), "Nhập kho", "PN20261030002", "Nhập hàng từ Masan Consumer (Nước mắm Nam Ngư, Mì Omachi)", "Đỗ Lê Tuấn Đạt", 32100000m);
            dt.Rows.Add(now.AddDays(-1).AddHours(3), "Kiểm kê", "KK20261029001", "Cân bằng kiểm kê định kỳ Khu vực Bách hóa tổng hợp", "Nguyễn Nhật Duy", 0m);
            dt.Rows.Add(now.AddDays(-1).AddHours(1), "Xuất kho", "PX20261029001", "Xuất giao Chuỗi Cửa hàng Tiện lợi Circle K", "Bùi Quang Duy", 14200000m);
            dt.Rows.Add(now.AddDays(-2).AddHours(2), "Nhập kho", "PN20261028001", "Nhập hàng từ Nestlé Việt Nam (Sữa Milo, Nescafé)", "Nguyễn Quốc Bảo", 28500000m);
            dt.Rows.Add(now.AddDays(-2).AddHours(-1), "Xuất kho", "PX20261028001", "Xuất giao Hệ thống Siêu thị Co.opmart (Xuất bán lẻ)", "Nguyễn Nhật Duy", 21750000m);
            dt.Rows.Add(now.AddDays(-3).AddHours(4), "Hệ thống", "SYS20261027", "Đồng bộ danh mục 20 sản phẩm FMCG tiêu chuẩn", "Quản trị viên", 0m);

            return dt;
        }

        private void DgvHoatDongGanDay_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvHoatDongGanDay.Columns[e.ColumnIndex].Name;
            if (colName == "LoaiGiaoDich" && e.Value != null)
            {
                string val = e.Value.ToString();
                e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                if (val.Contains("Nhập"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(13, 148, 136); // Teal
                }
                else if (val.Contains("Xuất"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235); // Blue
                }
                else if (val.Contains("Kiểm kê"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6); // Amber
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(100, 116, 139); // Gray
                }
            }
        }

        private void BtnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                _phanQuyenBUS.YeuCauQuyen(SessionManager.NguoiDungHienTai, ChucNang.DoiMatKhau);
                using (frmDoiMatKhau form = new frmDoiMatKhau())
                {
                    form.ShowDialog(this);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDangXuat_Click(object sender, EventArgs e)
        {
            _isLoggingOut = true;
            DongFormConHienTai();
            SessionManager.DangXuat();
            Close();
        }

        private void lblNguoiDung_Click(object sender, EventArgs e) { }
        private void lblModulePlaceholder_Click(object sender, EventArgs e) { }
        private void pnlWorkspace_Paint(object sender, PaintEventArgs e) { }
    }
}