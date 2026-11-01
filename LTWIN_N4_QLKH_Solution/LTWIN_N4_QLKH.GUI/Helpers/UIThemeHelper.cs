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

        
        #region 2.1. ĐỊNH NGHĨA ICON CHUẨN THEO CHỨC NĂNG FORM
        public enum FormIconType
        {
            WarehouseApp,      // Màn hình chính, Đăng nhập
            HangHoa,           // Quản lý Hàng hóa
            NhaCungCap,        // Quản lý Nhà cung cấp
            NhapKho,           // Quản lý Nhập kho
            XuatKho,           // Quản lý Xuất kho
            KiemKe,            // Kiểm kê & Cân bằng kho
            TheKho,            // Sổ Thẻ kho
            BaoCao,            // Báo cáo tồn kho & Doanh thu
            TaiKhoan,          // Quản lý tài khoản
            DoiMatKhau,        // Đổi mật khẩu
            Database,          // Sao lưu & Kết nối CSDL
            About,             // Giới thiệu đề tài
            Search,            // Tìm kiếm nhanh
            Logout             // Đăng xuất
        }

        private static readonly System.Collections.Generic.Dictionary<FormIconType, Icon> _iconCache =
            new System.Collections.Generic.Dictionary<FormIconType, Icon>();

        private static readonly System.Collections.Generic.Dictionary<FormIconType, Bitmap> _masterBitmapCache =
            new System.Collections.Generic.Dictionary<FormIconType, Bitmap>();

        private static readonly System.Collections.Generic.Dictionary<string, Bitmap> _scaledBitmapCache =
            new System.Collections.Generic.Dictionary<string, Bitmap>();

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

        public static Bitmap GetMasterIconBitmap(FormIconType type)
        {
            if (_masterBitmapCache.TryGetValue(type, out Bitmap cachedBmp) && cachedBmp != null)
            {
                return cachedBmp;
            }

            Bitmap bmp = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.Clear(Color.Transparent);

                Color bgColor;
                Action<Graphics> drawGlyph;

                switch (type)
                {
                    case FormIconType.HangHoa:
                        bgColor = Color.FromArgb(15, 118, 110);
                        drawGlyph = (gr) =>
                        {
                            gr.FillRectangle(Brushes.White, 7, 10, 18, 14);
                            gr.DrawRectangle(new Pen(Color.FromArgb(15, 118, 110), 1.5f), 7, 10, 18, 14);
                            gr.DrawLine(new Pen(Color.FromArgb(245, 158, 11), 2.5f), 16, 10, 16, 24);
                            gr.DrawLine(new Pen(Color.FromArgb(245, 158, 11), 2.5f), 7, 16, 25, 16);
                        };
                        break;

                    case FormIconType.NhaCungCap:
                        bgColor = Color.FromArgb(29, 78, 216);
                        drawGlyph = (gr) =>
                        {
                            gr.FillRectangle(Brushes.White, 6, 9, 13, 11);
                            gr.FillRectangle(Brushes.White, 19, 13, 7, 7);
                            gr.FillEllipse(Brushes.White, 8, 19, 5, 5);
                            gr.FillEllipse(Brushes.White, 19, 19, 5, 5);
                            gr.FillEllipse(new SolidBrush(Color.FromArgb(29, 78, 216)), 9.5f, 20.5f, 2, 2);
                            gr.FillEllipse(new SolidBrush(Color.FromArgb(29, 78, 216)), 20.5f, 20.5f, 2, 2);
                        };
                        break;

                    case FormIconType.NhapKho:
                        bgColor = Color.FromArgb(4, 120, 87);
                        drawGlyph = (gr) =>
                        {
                            gr.DrawRectangle(new Pen(Brushes.White, 2f), 6, 15, 20, 10);
                            using (Pen pArrow = new Pen(Color.FromArgb(254, 240, 138), 2.5f))
                            {
                                gr.DrawLine(pArrow, 16, 5, 16, 17);
                                gr.DrawLine(pArrow, 11, 12, 16, 17);
                                gr.DrawLine(pArrow, 21, 12, 16, 17);
                            }
                        };
                        break;

                    case FormIconType.XuatKho:
                        bgColor = Color.FromArgb(194, 65, 12);
                        drawGlyph = (gr) =>
                        {
                            gr.DrawRectangle(new Pen(Brushes.White, 2f), 6, 15, 20, 10);
                            using (Pen pArrow = new Pen(Color.FromArgb(254, 240, 138), 2.5f))
                            {
                                gr.DrawLine(pArrow, 16, 17, 16, 5);
                                gr.DrawLine(pArrow, 11, 10, 16, 5);
                                gr.DrawLine(pArrow, 21, 10, 16, 5);
                            }
                        };
                        break;

                    case FormIconType.KiemKe:
                        bgColor = Color.FromArgb(109, 40, 217);
                        drawGlyph = (gr) =>
                        {
                            gr.FillRectangle(Brushes.White, 7, 7, 18, 19);
                            gr.FillRectangle(new SolidBrush(Color.FromArgb(76, 29, 149)), 12, 5, 8, 4);
                            gr.DrawLine(new Pen(Color.FromArgb(109, 40, 217), 1.5f), 10, 13, 22, 13);
                            gr.DrawLine(new Pen(Color.FromArgb(109, 40, 217), 1.5f), 10, 17, 17, 17);
                            using (Pen pTick = new Pen(Color.FromArgb(16, 185, 129), 2.5f))
                            {
                                gr.DrawLine(pTick, 17, 20, 19, 23);
                                gr.DrawLine(pTick, 19, 23, 24, 16);
                            }
                        };
                        break;

                    case FormIconType.TheKho:
                        bgColor = Color.FromArgb(3, 105, 161);
                        drawGlyph = (gr) =>
                        {
                            gr.FillRectangle(Brushes.White, 7, 6, 18, 20);
                            gr.FillRectangle(new SolidBrush(Color.FromArgb(2, 132, 199)), 7, 6, 4, 20);
                            gr.DrawLine(new Pen(Color.FromArgb(100, 116, 139), 1.5f), 13, 11, 22, 11);
                            gr.DrawLine(new Pen(Color.FromArgb(100, 116, 139), 1.5f), 13, 15, 22, 15);
                            gr.DrawLine(new Pen(Color.FromArgb(100, 116, 139), 1.5f), 13, 19, 19, 19);
                        };
                        break;

                    case FormIconType.BaoCao:
                        bgColor = Color.FromArgb(180, 83, 9);
                        drawGlyph = (gr) =>
                        {
                            gr.FillRectangle(Brushes.White, 7, 18, 4, 7);
                            gr.FillRectangle(Brushes.White, 14, 12, 4, 13);
                            gr.FillRectangle(Brushes.White, 21, 7, 4, 18);
                            using (Pen pTrend = new Pen(Color.FromArgb(254, 240, 138), 2f))
                            {
                                gr.DrawLine(pTrend, 8, 16, 15, 10);
                                gr.DrawLine(pTrend, 15, 10, 23, 5);
                            }
                        };
                        break;

                    case FormIconType.TaiKhoan:
                        bgColor = Color.FromArgb(51, 65, 85);
                        drawGlyph = (gr) =>
                        {
                            gr.FillEllipse(Brushes.White, 12, 7, 8, 8);
                            gr.FillPie(Brushes.White, 6, 16, 20, 16, 180, 180);
                        };
                        break;

                    case FormIconType.DoiMatKhau:
                        bgColor = Color.FromArgb(67, 56, 202);
                        drawGlyph = (gr) =>
                        {
                            gr.DrawArc(new Pen(Brushes.White, 2f), 11, 7, 10, 10, 180, 180);
                            gr.FillRectangle(Brushes.White, 9, 13, 14, 12);
                            gr.FillEllipse(new SolidBrush(Color.FromArgb(67, 56, 202)), 14, 16, 4, 4);
                            gr.DrawLine(new Pen(Color.FromArgb(67, 56, 202), 2f), 16, 18, 16, 22);
                        };
                        break;

                    case FormIconType.Database:
                        bgColor = Color.FromArgb(13, 148, 136);
                        drawGlyph = (gr) =>
                        {
                            gr.DrawEllipse(new Pen(Brushes.White, 1.8f), 7, 6, 18, 6);
                            gr.DrawArc(new Pen(Brushes.White, 1.8f), 7, 12, 18, 6, 0, 180);
                            gr.DrawArc(new Pen(Brushes.White, 1.8f), 7, 18, 18, 6, 0, 180);
                            gr.DrawLine(new Pen(Brushes.White, 1.8f), 7, 9, 7, 21);
                            gr.DrawLine(new Pen(Brushes.White, 1.8f), 25, 9, 25, 21);
                        };
                        break;

                    case FormIconType.About:
                        bgColor = Color.FromArgb(37, 99, 235);
                        drawGlyph = (gr) =>
                        {
                            gr.DrawEllipse(new Pen(Brushes.White, 2f), 6, 6, 20, 20);
                            gr.FillEllipse(Brushes.White, 14.5f, 10, 3, 3);
                            gr.FillRectangle(Brushes.White, 14.5f, 15, 3, 7);
                        };
                        break;

                    case FormIconType.Search:
                        bgColor = Color.FromArgb(15, 118, 110);
                        drawGlyph = (gr) =>
                        {
                            gr.DrawEllipse(new Pen(Brushes.White, 2.5f), 7, 7, 12, 12);
                            gr.DrawLine(new Pen(Brushes.White, 3f), 17, 17, 24, 24);
                        };
                        break;

                    case FormIconType.Logout:
                        bgColor = Color.FromArgb(225, 29, 72);
                        drawGlyph = (gr) =>
                        {
                            gr.DrawRectangle(new Pen(Brushes.White, 2f), 7, 7, 10, 18);
                            using (Pen pArrow = new Pen(Color.FromArgb(254, 240, 138), 2.2f))
                            {
                                gr.DrawLine(pArrow, 13, 16, 25, 16);
                                gr.DrawLine(pArrow, 20, 11, 25, 16);
                                gr.DrawLine(pArrow, 20, 21, 25, 16);
                            }
                        };
                        break;

                    case FormIconType.WarehouseApp:
                    default:
                        bgColor = Color.FromArgb(16, 44, 59);
                        drawGlyph = (gr) =>
                        {
                            Point[] roof = new Point[] { new Point(6, 14), new Point(16, 6), new Point(26, 14) };
                            gr.FillPolygon(new SolidBrush(Color.FromArgb(19, 126, 119)), roof);
                            gr.FillRectangle(Brushes.White, 8, 14, 16, 11);
                            gr.FillRectangle(new SolidBrush(Color.FromArgb(16, 44, 59)), 13, 17, 6, 8);
                        };
                        break;
                }

                using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int r = 6;
                    Rectangle rect = new Rectangle(1, 1, 30, 30);
                    path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
                    path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
                    path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
                    path.CloseFigure();

                    using (SolidBrush bBg = new SolidBrush(bgColor))
                    {
                        g.FillPath(bBg, path);
                    }
                }

                drawGlyph(g);
            }

            _masterBitmapCache[type] = bmp;
            return bmp;
        }

        public static Icon GetFormIcon(FormIconType type)
        {
            if (_iconCache.TryGetValue(type, out Icon cachedIcon) && cachedIcon != null)
            {
                return cachedIcon;
            }

            try
            {
                Bitmap bmp = GetMasterIconBitmap(type);
                IntPtr hIcon = bmp.GetHicon();
                Icon newIcon = (Icon)Icon.FromHandle(hIcon).Clone();
                DestroyIcon(hIcon);

                _iconCache[type] = newIcon;
                return newIcon;
            }
            catch
            {
                return SystemIcons.Application;
            }
        }

        /// <summary>
        /// Lấy hình ảnh Icon kích thước chuẩn dùng cho nút menu sidebar hoặc thanh công cụ
        /// </summary>
        public static Image GetMenuIconImage(FormIconType type, int size = 20)
        {
            string cacheKey = type.ToString() + "_" + size;
            if (_scaledBitmapCache.TryGetValue(cacheKey, out Bitmap cached) && cached != null)
            {
                return cached;
            }

            try
            {
                Bitmap master = GetMasterIconBitmap(type);
                Bitmap target = new Bitmap(size, size, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(target))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.Clear(Color.Transparent);
                    g.DrawImage(master, new Rectangle(0, 0, size, size));
                }

                _scaledBitmapCache[cacheKey] = target;
                return target;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gán icon và căn chỉnh chuẩn cho các nút điều hướng sidebar (trực quan, hiện đại, cân đối)
        /// </summary>
        public static void SetupSidebarMenuButton(Button button, FormIconType iconType, int iconSize = 20)
        {
            if (button == null) return;
            try
            {
                button.Image = GetMenuIconImage(iconType, iconSize);
                button.ImageAlign = ContentAlignment.MiddleLeft;
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.TextImageRelation = TextImageRelation.ImageBeforeText;
                button.Padding = new Padding(12, 0, 8, 0);
            }
            catch
            {
            }
        }

        public static void ApplyFormHeaderAndIcon(Form form, string title, FormIconType iconType)
        {
            if (form == null) return;
            if (!string.IsNullOrWhiteSpace(title))
            {
                form.Text = title;
            }
            try
            {
                form.Icon = GetFormIcon(iconType);
                form.ShowIcon = true;
            }
            catch
            {
            }
        }
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
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(186, 230, 253);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgv.AlternatingRowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
            btn.TextImageRelation = (btn.Image != null) ? TextImageRelation.ImageBeforeText : TextImageRelation.Overlay;

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
            FormIconType iconType = FormIconType.WarehouseApp;
            string t = (tieuDe ?? "").ToUpperInvariant();
            if (t.Contains("HÀNG HÓA")) iconType = FormIconType.HangHoa;
            else if (t.Contains("NHÀ CUNG CẤP")) iconType = FormIconType.NhaCungCap;
            else if (t.Contains("NHẬP KHO")) iconType = FormIconType.NhapKho;
            else if (t.Contains("XUẤT KHO")) iconType = FormIconType.XuatKho;
            else if (t.Contains("KIỂM KÊ")) iconType = FormIconType.KiemKe;
            else if (t.Contains("THẺ KHO")) iconType = FormIconType.TheKho;
            else if (t.Contains("BÁO CÁO")) iconType = FormIconType.BaoCao;
            else if (t.Contains("TÀI KHOẢN")) iconType = FormIconType.TaiKhoan;
            else if (t.Contains("SAO LƯU")) iconType = FormIconType.Database;
            else if (t.Contains("GIỚI THIỆU")) iconType = FormIconType.About;

            ApplyFormHeaderAndIcon(childForm, tieuDe, iconType);

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