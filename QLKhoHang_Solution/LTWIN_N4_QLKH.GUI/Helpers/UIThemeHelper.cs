using System;
using System.Drawing;
using System.Windows.Forms;

namespace LTWIN_N4_QLKH.GUI.Helpers
{
    public static class UIThemeHelper
    {
        #region 1. BẢNG MÀU CHUẨN
        public static readonly Color PrimaryDark = Color.FromArgb(30, 41, 59);      // #1E293B
        public static readonly Color WorkspaceBg = Color.FromArgb(248, 250, 252);   // #F8FAFC
        public static readonly Color WorkspaceBgColor = Color.FromArgb(248, 250, 252);
        public static readonly Color AccentTeal = Color.FromArgb(13, 148, 136);     // #0D9488
        public static readonly Color AccentTealHover = Color.FromArgb(15, 118, 110);
        public static readonly Color AccentBlue = Color.FromArgb(37, 99, 235);      // #2563EB
        public static readonly Color AccentBlueHover = Color.FromArgb(29, 78, 216);
        public static readonly Color DangerRed = Color.FromArgb(239, 68, 68);       // #EF4444
        public static readonly Color DangerRedHover = Color.FromArgb(220, 38, 38);
        public static readonly Color WarningRowBg = Color.FromArgb(254, 226, 226);   // #FEE2E2
        public static readonly Color WarningText = Color.FromArgb(185, 28, 28);      // #B91C1C
        public static readonly Color NeutralGray = Color.FromArgb(100, 116, 139);   // #64748B
        public static readonly Color NeutralGrayHover = Color.FromArgb(71, 85, 105);
        public static readonly Color BorderColor = Color.FromArgb(226, 232, 240);
        #endregion

        #region 2. FONT CHỮ CHUẨN
        public static readonly Font HeaderFont = new Font("Segoe UI", 13f, FontStyle.Bold);
        public static readonly Font SubHeaderFont = new Font("Segoe UI", 10.5f, FontStyle.Bold);
        public static readonly Font ControlFont = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        public static readonly Font ControlBoldFont = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font GridFont = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        public static readonly Font SmallFont = new Font("Segoe UI", 8.5f, FontStyle.Regular);
        public static readonly Font WarningFont = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        #endregion

        #region 3. VẼ LOGO DÙNG CHUNG TOÀN HỆ THỐNG
        public static void VeLogoHienDai(Panel pnlLogo, Label lblGlyph, Label lblBrandText)
        {
            if (pnlLogo == null) return;

            if (lblGlyph != null) lblGlyph.Text = string.Empty;
            pnlLogo.BackColor = Color.Transparent;

            pnlLogo.Paint -= Logo_Paint;
            pnlLogo.Paint += Logo_Paint;
            pnlLogo.Invalidate();

            if (lblBrandText != null)
            {
                lblBrandText.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                lblBrandText.Text = "HỆ THỐNG" + Environment.NewLine + "QUẢN LÝ KHO HÀNG";
            }
        }

        private static void Logo_Paint(object sender, PaintEventArgs e)
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
        #endregion

        #region 4. CHUẨN HÓA DATAGRIDVIEW
        public static void SetDoubleBuffered(this DataGridView dgv, bool enable = true)
        {
            if (dgv == null) return;
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { enable });
        }

        public static void ApplyStandardGridStyle(DataGridView dgv)
        {
            if (dgv == null) return;

            SetDoubleBuffered(dgv, true);

            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(241, 245, 249);
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDark;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = ControlBoldFont;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgv.ColumnHeadersHeight = 38;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.RowTemplate.Height = 34;
            dgv.DefaultCellStyle.Font = GridFont;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(186, 230, 253);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgv.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(186, 230, 253);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        public static void FormatHangHoaRowWarning(DataGridViewCellFormattingEventArgs e, DataGridView dgv, string colTonKho = "SoLuongTon", string colTonToiThieu = "TonToiThieu")
        {
            if (e == null || dgv == null || e.RowIndex < 0 || e.RowIndex >= dgv.Rows.Count) return;

            DataGridViewRow row = dgv.Rows[e.RowIndex];
            if (row.Cells[colTonKho]?.Value != null && row.Cells[colTonToiThieu]?.Value != null)
            {
                if (int.TryParse(row.Cells[colTonKho].Value.ToString(), out int tonKho) &&
                    int.TryParse(row.Cells[colTonToiThieu].Value.ToString(), out int tonMin))
                {
                    if (tonKho <= tonMin)
                    {
                        row.DefaultCellStyle.BackColor = WarningRowBg;
                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 202, 202);
                        row.DefaultCellStyle.SelectionForeColor = WarningText;

                        if (row.Cells[colTonKho] != null)
                        {
                            row.Cells[colTonKho].Style.ForeColor = WarningText;
                            row.Cells[colTonKho].Style.Font = WarningFont;
                        }
                    }
                }
            }
        }
        #endregion

        #region 5. CHUẨN HÓA NÚT BẤM (BUTTON)
        public enum ButtonType
        {
            Primary,
            Secondary,
            Danger,
            Neutral,
            Search,
            SaveOrAdd
        }

        public static void ApplyButtonStyle(Button btn, ButtonType type)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Cursor = Cursors.Hand;
            btn.Height = Math.Max(btn.Height, 36);
            btn.Padding = new Padding(0);
            btn.Margin = new Padding(3);
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;

            Color baseColor;
            Color hoverColor;

            switch (type)
            {
                case ButtonType.SaveOrAdd:
                case ButtonType.Primary:
                    baseColor = AccentTeal;
                    hoverColor = AccentTealHover;
                    break;
                case ButtonType.Secondary:
                    baseColor = PrimaryDark;
                    hoverColor = Color.FromArgb(51, 65, 85);
                    break;
                case ButtonType.Danger:
                    baseColor = DangerRed;
                    hoverColor = DangerRedHover;
                    break;
                case ButtonType.Search:
                    baseColor = Color.FromArgb(15, 118, 110);
                    hoverColor = AccentTeal;
                    break;
                case ButtonType.Neutral:
                default:
                    baseColor = NeutralGray;
                    hoverColor = NeutralGrayHover;
                    break;
            }

            btn.BackColor = baseColor;
            btn.FlatAppearance.MouseOverBackColor = hoverColor;
        }
        #endregion

        #region 6. ĐỒNG BỘ TOÀN DIỆN MỌI FORM CON KHI MỞ
        /// <summary>
        /// Tự động duyệt sạch sẽ các form con (ẩn tiêu đề lặp, chuẩn hóa nút, làm đẹp lưới)
        /// </summary>
        public static void DongBoToanDienFormCon(Form childForm, string tieuDe)
        {
            if (childForm == null) return;

            childForm.BackColor = Color.White;
            childForm.Font = ControlFont;

            QuetVaChuanHoaControls(childForm, tieuDe);
        }

        private static void QuetVaChuanHoaControls(Control parent, string tieuDe)
        {
            foreach (Control c in parent.Controls)
            {
                // 1. Ẩn tiêu đề con bị trùng lặp với thanh tiêu đề trên frmMain
                if (c is Label lbl)
                {
                    string txt = lbl.Text.Trim().ToUpper();
                    if (txt.StartsWith("QUẢN LÝ") || txt.StartsWith("KIỂM KÊ") ||
                        txt.StartsWith("SỔ THẺ") || txt.StartsWith("BÁO CÁO") ||
                        (!string.IsNullOrEmpty(tieuDe) && txt.Contains(tieuDe.ToUpper())))
                    {
                        if (lbl.Font.Size >= 12f)
                        {
                            lbl.Visible = false;
                        }
                    }
                }

                // 2. Tự động đồng bộ chuẩn hóa các nút bấm
                if (c is Button btn)
                {
                    string t = btn.Text.ToLower().Trim();

                    // Sửa lỗi nút bị cụt chữ và dính nút trên frmQuanLiTaiKhoan
                    if (t.Contains("đặt lại mật"))
                    {
                        btn.Text = "Đặt lại mật khẩu";
                        btn.Width = Math.Max(btn.Width, 136);

                        // Nếu nút nằm cùng panel với các nút khác, tự động căn chỉnh khoảng cách để không bị dính nút
                        if (btn.Parent != null)
                        {
                            foreach (Control sibling in btn.Parent.Controls)
                            {
                                if (sibling is Button sibBtn && sibBtn != btn && sibBtn.Left >= btn.Left && sibBtn.Left < btn.Right + 6)
                                {
                                    sibBtn.Left = btn.Right + 8;
                                }
                            }
                        }
                    }

                    if (t.Contains("thêm") || t.Contains("cân bằng") || t.Contains("xuất") || t.Contains("tải"))
                    {
                        ApplyButtonStyle(btn, ButtonType.Primary);
                    }
                    else if (t.Contains("lưu"))
                    {
                        ApplyButtonStyle(btn, ButtonType.Secondary);
                    }
                    else if (t.Contains("xóa"))
                    {
                        ApplyButtonStyle(btn, ButtonType.Danger);
                    }
                    else if (t.Contains("làm mới") || t.Contains("đóng"))
                    {
                        ApplyButtonStyle(btn, ButtonType.Neutral);
                    }
                    else if (t.Contains("tìm") || t.Contains("xem") || t.Contains("tổng hợp"))
                    {
                        ApplyButtonStyle(btn, ButtonType.Search);
                    }
                    else
                    {
                        ApplyButtonStyle(btn, ButtonType.Neutral);
                    }
                }

                // 3. Tự động chuẩn hóa mọi DataGridView tìm thấy
                if (c is DataGridView dgv)
                {
                    ApplyStandardGridStyle(dgv);
                }

                // 4. Chuẩn hóa GroupBox tiêu đề sắc nét
                if (c is GroupBox gb)
                {
                    gb.Font = ControlBoldFont;
                    gb.ForeColor = PrimaryDark;
                }

                // Đệ quy duyệt các control bên trong
                if (c.HasChildren)
                {
                    QuetVaChuanHoaControls(c, tieuDe);
                }
            }
        }
        #endregion
    }
}