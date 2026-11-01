namespace LTWIN_N4_QLKH.GUI.Forms.MasterData
{
    partial class frmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblSubHeader = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.grpPhanCong = new System.Windows.Forms.GroupBox();
            this.lblTV4 = new System.Windows.Forms.Label();
            this.lblTV3 = new System.Windows.Forms.Label();
            this.lblTV2 = new System.Windows.Forms.Label();
            this.lblTV1 = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblPhienBan = new System.Windows.Forms.Label();
            this.lblNenTang = new System.Windows.Forms.Label();
            this.lblNganhHang = new System.Windows.Forms.Label();
            this.lblTenDeTai = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.grpPhanCong.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblSubHeader);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.pnlHeader.Size = new System.Drawing.Size(780, 85);
            this.pnlHeader.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::LTWIN_N4_QLKH.GUI.Properties.Resources.logo_khohang;
            this.picLogo.Location = new System.Drawing.Point(695, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(60, 60);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.AutoSize = true;
            this.lblSubHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblSubHeader.Location = new System.Drawing.Point(20, 48);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(430, 21);
            this.lblSubHeader.TabIndex = 1;
            this.lblSubHeader.Text = "Hệ thống Quản lý Kho hàng Tiêu dùng nhanh & Bách hóa";
            this.lblSubHeader.UseMnemonic = false;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(18, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(410, 35);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "GIỚI THIỆU PHẦN MỀM & DỰ ÁN";
            this.lblHeaderTitle.UseMnemonic = false;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlContent.Controls.Add(this.grpPhanCong);
            this.pnlContent.Controls.Add(this.grpThongTin);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 85);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(780, 465);
            this.pnlContent.TabIndex = 1;
            // 
            // grpPhanCong
            // 
            this.grpPhanCong.BackColor = System.Drawing.Color.White;
            this.grpPhanCong.Controls.Add(this.lblTV4);
            this.grpPhanCong.Controls.Add(this.lblTV3);
            this.grpPhanCong.Controls.Add(this.lblTV2);
            this.grpPhanCong.Controls.Add(this.lblTV1);
            this.grpPhanCong.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPhanCong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPhanCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpPhanCong.Location = new System.Drawing.Point(20, 185);
            this.grpPhanCong.Name = "grpPhanCong";
            this.grpPhanCong.Padding = new System.Windows.Forms.Padding(16);
            this.grpPhanCong.Size = new System.Drawing.Size(740, 260);
            this.grpPhanCong.TabIndex = 1;
            this.grpPhanCong.TabStop = false;
            this.grpPhanCong.Text = "MA TRẬN PHÂN CHIA NHIỆM VỤ NHÓM (25% / THÀNH VIÊN)";
            // 
            // lblTV4
            // 
            this.lblTV4.AutoSize = true;
            this.lblTV4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTV4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblTV4.Location = new System.Drawing.Point(16, 192);
            this.lblTV4.Name = "lblTV4";
            this.lblTV4.Size = new System.Drawing.Size(705, 42);
            this.lblTV4.TabIndex = 3;
            this.lblTV4.Text = "• Thành viên 4: Nguyễn Nhật Duy (NT) - MSSV: 231A010060 (Báo cáo & QA):\r\n  Thẻ kho, Báo cáo Nhập-Xuất-Tồn, Xuất Excel ClosedXML, Biểu đồ luân chuyển, Test Cases kiểm thử.";
            this.lblTV4.UseMnemonic = false;
            // 
            // lblTV3
            // 
            this.lblTV3.AutoSize = true;
            this.lblTV3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTV3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblTV3.Location = new System.Drawing.Point(16, 138);
            this.lblTV3.Name = "lblTV3";
            this.lblTV3.Size = new System.Drawing.Size(685, 42);
            this.lblTV3.TabIndex = 2;
            this.lblTV3.Text = "• Thành viên 3: Bùi Quang Duy - MSSV: 231A290127 (Transactions):\r\n  Lập phiếu Nhập kho, Xuất kho, Kiểm kê & Cân bằng kho, SqlTransaction ACID, Chặn xuất vượt tồn.";
            this.lblTV3.UseMnemonic = false;
            // 
            // lblTV2
            // 
            this.lblTV2.AutoSize = true;
            this.lblTV2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTV2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblTV2.Location = new System.Drawing.Point(16, 84);
            this.lblTV2.Name = "lblTV2";
            this.lblTV2.Size = new System.Drawing.Size(715, 42);
            this.lblTV2.TabIndex = 1;
            this.lblTV2.Text = "• Thành viên 2: Đỗ Lê Tuấn Đạt - MSSV: 231A290089 (Master Data):\r\n  Quản lý Hàng hóa, Nhà cung cấp, frmAbout, UIThemeHelper, Cảnh báo tồn kho, Seed Data SQL FMCG.";
            this.lblTV2.UseMnemonic = false;
            // 
            // lblTV1
            // 
            this.lblTV1.AutoSize = true;
            this.lblTV1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTV1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblTV1.Location = new System.Drawing.Point(16, 32);
            this.lblTV1.Name = "lblTV1";
            this.lblTV1.Size = new System.Drawing.Size(715, 42);
            this.lblTV1.TabIndex = 0;
            this.lblTV1.Text = "• Thành viên 1: Nguyễn Quốc Bảo - MSSV: 231A290098 (Kiến trúc & CSDL):\r\n  Quản trị Git repo, Script CSDL LTWIN_N4_QLKH_DB chuẩn, DatabaseHelper.cs, Phân quyền RBAC, Sao lưu CSDL.";
            this.lblTV1.UseMnemonic = false;
            // 
            // grpThongTin
            // 
            this.grpThongTin.BackColor = System.Drawing.Color.White;
            this.grpThongTin.Controls.Add(this.lblPhienBan);
            this.grpThongTin.Controls.Add(this.lblNenTang);
            this.grpThongTin.Controls.Add(this.lblNganhHang);
            this.grpThongTin.Controls.Add(this.lblTenDeTai);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpThongTin.Location = new System.Drawing.Point(20, 20);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Padding = new System.Windows.Forms.Padding(16);
            this.grpThongTin.Size = new System.Drawing.Size(740, 165);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "THÔNG TIN ĐỀ TÀI TIỂU LUẬN";
            // 
            // lblPhienBan
            // 
            this.lblPhienBan.AutoSize = true;
            this.lblPhienBan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhienBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPhienBan.Location = new System.Drawing.Point(16, 126);
            this.lblPhienBan.Name = "lblPhienBan";
            this.lblPhienBan.Size = new System.Drawing.Size(320, 21);
            this.lblPhienBan.TabIndex = 3;
            this.lblPhienBan.Text = "• Phiên bản: Release v1.0.0 (Niên khóa 2026)";
            // 
            // lblNenTang
            // 
            this.lblNenTang.AutoSize = true;
            this.lblNenTang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNenTang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblNenTang.Location = new System.Drawing.Point(16, 94);
            this.lblNenTang.Name = "lblNenTang";
            this.lblNenTang.Size = new System.Drawing.Size(479, 21);
            this.lblNenTang.TabIndex = 2;
            this.lblNenTang.Text = "• Công nghệ: C# Windows Forms (.NET Framework 4.8) & SQL Server";
            this.lblNenTang.UseMnemonic = false;
            // 
            // lblNganhHang
            // 
            this.lblNganhHang.AutoSize = true;
            this.lblNganhHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNganhHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblNganhHang.Location = new System.Drawing.Point(16, 62);
            this.lblNganhHang.Name = "lblNganhHang";
            this.lblNganhHang.Size = new System.Drawing.Size(545, 21);
            this.lblNganhHang.TabIndex = 1;
            this.lblNganhHang.Text = "• Mô hình nghiệp vụ: Kho hàng tiêu dùng nhanh (FMCG) / Bách hóa tổng hợp";
            // 
            // lblTenDeTai
            // 
            this.lblTenDeTai.AutoSize = true;
            this.lblTenDeTai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTenDeTai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblTenDeTai.Location = new System.Drawing.Point(16, 30);
            this.lblTenDeTai.Name = "lblTenDeTai";
            this.lblTenDeTai.Size = new System.Drawing.Size(303, 21);
            this.lblTenDeTai.TabIndex = 0;
            this.lblTenDeTai.Text = "• Đề tài: PHẦN MỀM QUẢN LÝ KHO HÀNG (LTWIN_N4_QLKH)";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.lblCopyright);
            this.pnlBottom.Controls.Add(this.btnDong);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 550);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(780, 60);
            this.pnlBottom.TabIndex = 2;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCopyright.Location = new System.Drawing.Point(20, 20);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(395, 20);
            this.lblCopyright.TabIndex = 1;
            this.lblCopyright.Text = "© 2026 Nhóm Đồ Án Quản Lý Kho Hàng. All rights reserved.";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(645, 12);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(115, 36);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 610);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Giới thiệu Phần mềm & Thông tin Đề tài";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.grpPhanCong.ResumeLayout(false);
            this.grpPhanCong.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblSubHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblTenDeTai;
        private System.Windows.Forms.Label lblNganhHang;
        private System.Windows.Forms.Label lblNenTang;
        private System.Windows.Forms.Label lblPhienBan;
        private System.Windows.Forms.GroupBox grpPhanCong;
        private System.Windows.Forms.Label lblTV1;
        private System.Windows.Forms.Label lblTV2;
        private System.Windows.Forms.Label lblTV3;
        private System.Windows.Forms.Label lblTV4;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lblCopyright;
    }
}
