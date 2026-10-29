using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LTWIN_N4_QLKH.GUI.Common
{
    /// <summary>
    /// Thành phần trình bày dùng chung cho các form TV1.
    /// </summary>
    internal static class UiTheme
    {
        internal static readonly Color Canvas = Color.FromArgb(238, 244, 247);
        internal static readonly Color Workspace = Color.FromArgb(242, 246, 248);
        internal static readonly Color Navy = Color.FromArgb(16, 44, 59);
        internal static readonly Color NavyLight = Color.FromArgb(23, 74, 88);
        internal static readonly Color Teal = Color.FromArgb(19, 168, 143);
        internal static readonly Color TealDark = Color.FromArgb(7, 139, 124);
        internal static readonly Color Text = Color.FromArgb(21, 43, 59);
        internal static readonly Color Muted = Color.FromArgb(113, 128, 144);
        internal static readonly Color Border = Color.FromArgb(215, 224, 231);
        internal static readonly Color Pale = Color.FromArgb(243, 248, 250);
        internal static readonly Color White = Color.White;

        internal static Label Label(string name, string text, float size, Color color, bool bold = false)
        {
            return new Label
            {
                Name = name,
                Text = text,
                AutoSize = true,
                ForeColor = color,
                Font = new Font("Segoe UI", size, bold ? FontStyle.Bold : FontStyle.Regular),
                UseMnemonic = false
            };
        }

        internal static Button Button(string name, string text, bool primary)
        {
            Button button = new Button
            {
                Name = name,
                Text = text,
                FlatStyle = FlatStyle.Flat,
                BackColor = primary ? Teal : Color.FromArgb(241, 245, 247),
                ForeColor = primary ? White : Color.FromArgb(67, 87, 103),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false,
                TabStop = true
            };
            button.FlatAppearance.BorderSize = primary ? 0 : 1;
            button.FlatAppearance.BorderColor = Border;
            button.FlatAppearance.MouseOverBackColor = primary ? TealDark : Color.FromArgb(230, 238, 241);
            button.FlatAppearance.MouseDownBackColor = primary ? Color.FromArgb(6, 119, 107) : Color.FromArgb(220, 230, 234);
            return button;
        }

        internal static Panel Card(string name, int radius = 16)
        {
            Panel panel = new Panel
            {
                Name = name,
                BackColor = White,
                BorderStyle = BorderStyle.None
            };
            ApplyRounded(panel, radius);
            return panel;
        }

        internal static Panel InputFrame(string name, Control input, int height = 48)
        {
            Panel frame = new Panel
            {
                Name = name,
                Height = height,
                BackColor = White,
                Padding = new Padding(12, 7, 12, 6)
            };
            frame.Paint += delegate(object sender, PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Border, 1.2F))
                using (GraphicsPath path = RoundedRectangle(new Rectangle(0, 0, frame.Width - 1, frame.Height - 1), 10))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            };
            frame.Resize += delegate { frame.Invalidate(); };
            TextBox textBox = input as TextBox;
            if (textBox != null)
            {
                textBox.BorderStyle = BorderStyle.None;
            }
            ComboBox comboBox = input as ComboBox;
            if (comboBox != null)
            {
                comboBox.FlatStyle = FlatStyle.Flat;
            }
            input.Dock = DockStyle.Fill;
            input.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            input.ForeColor = Text;
            frame.Controls.Add(input);
            return frame;
        }

        internal static void ApplyRounded(Control control, int radius)
        {
            if (control == null)
            {
                return;
            }

            Action apply = delegate
            {
                if (control.Width <= 0 || control.Height <= 0)
                {
                    return;
                }

                using (GraphicsPath path = RoundedRectangle(new Rectangle(0, 0, control.Width, control.Height), radius))
                {
                    Region oldRegion = control.Region;
                    control.Region = new Region(path);
                    if (oldRegion != null)
                    {
                        oldRegion.Dispose();
                    }
                }
            };

            control.Resize += delegate { apply(); };
            control.HandleCreated += delegate { apply(); };
            if (control.IsHandleCreated)
            {
                apply();
            }
        }

        internal static void ApplyRoundedLeft(Control control, int radius)
        {
            if (control == null) return;
            Action apply = delegate
            {
                if (control.Width <= 0 || control.Height <= 0) return;
                int diameter = Math.Min(radius * 2, Math.Min(control.Width, control.Height));
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(0, 0, diameter, diameter, 180, 90);
                    path.AddLine(radius, 0, control.Width, 0);
                    path.AddLine(control.Width, 0, control.Width, control.Height);
                    path.AddLine(control.Width, control.Height, radius, control.Height);
                    path.AddArc(0, control.Height - diameter, diameter, diameter, 90, 90);
                    path.CloseFigure();
                    Region oldRegion = control.Region;
                    control.Region = new Region(path);
                    if (oldRegion != null) oldRegion.Dispose();
                }
            };
            control.Resize += delegate { apply(); };
            control.HandleCreated += delegate { apply(); };
            if (control.IsHandleCreated) apply();
        }

        internal static GraphicsPath RoundedPath(Rectangle bounds, int radius)
        {
            return RoundedRectangle(bounds, radius);
        }

        private static GraphicsPath RoundedRectangle(Rectangle bounds, int radius)
        {
            int diameter = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
