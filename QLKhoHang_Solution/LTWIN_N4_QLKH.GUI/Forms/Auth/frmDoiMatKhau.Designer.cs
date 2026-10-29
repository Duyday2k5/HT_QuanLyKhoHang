namespace LTWIN_N4_QLKH.GUI.Forms.Auth
{
    partial class frmDoiMatKhau
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHero = new System.Windows.Forms.Panel();
            this.lblHeroDescription = new System.Windows.Forms.Label();
            this.lblHeroTitle = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.chkHienMatKhau = new System.Windows.Forms.CheckBox();
            this.lblSecurityNote = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLuuMatKhau = new System.Windows.Forms.Button();
            this.txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.lblXacNhanMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.lblMatKhauMoi = new System.Windows.Forms.Label();
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.lblMatKhauCu = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblEyebrow = new System.Windows.Forms.Label();
            this.pnlHero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHero
            //
            this.pnlHero.BackColor = System.Drawing.Color.FromArgb(16, 44, 59);
            this.pnlHero.Controls.Add(this.lblHeroDescription);
            this.pnlHero.Controls.Add(this.lblHeroTitle);
            this.pnlHero.Controls.Add(this.lblBrand);
            this.pnlHero.Controls.Add(this.picLogo);
            this.pnlHero.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHero.Location = new System.Drawing.Point(0, 0);
            this.pnlHero.Name = "pnlHero";
            this.pnlHero.Size = new System.Drawing.Size(280, 660);
            this.pnlHero.TabIndex = 0;
            //
            // lblHeroDescription
            //
            this.lblHeroDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHeroDescription.ForeColor = System.Drawing.Color.FromArgb(191, 212, 217);
            this.lblHeroDescription.Location = new System.Drawing.Point(27, 379);
            this.lblHeroDescription.Name = "lblHeroDescription";
            this.lblHeroDescription.Size = new System.Drawing.Size(226, 56);
            this.lblHeroDescription.TabIndex = 3;
            this.lblHeroDescription.Text = "Tạo mật khẩu mới để bảo vệ quyền truy cập hệ thống kho.";
            this.lblHeroDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitle
            //
            this.lblHeroTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitle.ForeColor = System.Drawing.Color.FromArgb(238, 248, 246);
            this.lblHeroTitle.Location = new System.Drawing.Point(27, 328);
            this.lblHeroTitle.Name = "lblHeroTitle";
            this.lblHeroTitle.Size = new System.Drawing.Size(226, 38);
            this.lblHeroTitle.TabIndex = 2;
            this.lblHeroTitle.Text = "Bảo mật tài khoản";
            this.lblHeroTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblBrand
            //
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(78, 23);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(180, 43);
            this.lblBrand.TabIndex = 1;
            this.lblBrand.Text = "HỆ THỐNG\r\nQUẢN LÝ KHO HÀNG";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // picLogo
            //
            this.picLogo.Image = global::LTWIN_N4_QLKH.GUI.Properties.Resources.logo_khohang;
            this.picLogo.Location = new System.Drawing.Point(20, 20);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(48, 48);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            //
            // pnlContent
            //
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.chkHienMatKhau);
            this.pnlContent.Controls.Add(this.lblSecurityNote);
            this.pnlContent.Controls.Add(this.btnDong);
            this.pnlContent.Controls.Add(this.btnLuuMatKhau);
            this.pnlContent.Controls.Add(this.txtXacNhanMatKhau);
            this.pnlContent.Controls.Add(this.lblXacNhanMatKhau);
            this.pnlContent.Controls.Add(this.txtMatKhauMoi);
            this.pnlContent.Controls.Add(this.lblMatKhauMoi);
            this.pnlContent.Controls.Add(this.txtMatKhauCu);
            this.pnlContent.Controls.Add(this.lblMatKhauCu);
            this.pnlContent.Controls.Add(this.lblMoTa);
            this.pnlContent.Controls.Add(this.lblTieuDe);
            this.pnlContent.Controls.Add(this.lblEyebrow);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(280, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(45, 0, 45, 0);
            this.pnlContent.Size = new System.Drawing.Size(700, 660);
            this.pnlContent.TabIndex = 1;
            //
            // lblSecurityNote
            //
            this.lblSecurityNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSecurityNote.AutoSize = true;
            this.lblSecurityNote.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSecurityNote.ForeColor = System.Drawing.Color.FromArgb(148, 163, 178);
            this.lblSecurityNote.Location = new System.Drawing.Point(129, 574);
            this.lblSecurityNote.Name = "lblSecurityNote";
            this.lblSecurityNote.Size = new System.Drawing.Size(294, 15);
            this.lblSecurityNote.TabIndex = 11;
            this.lblSecurityNote.Text = "Mật khẩu được bảo vệ bằng cơ chế băm an toàn.";
            //
            // btnDong
            //
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(241, 245, 247);
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 224, 231);
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(67, 87, 103);
            this.btnDong.Location = new System.Drawing.Point(422, 503);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(205, 48);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "ĐÓNG";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.BtnDong_Click);
            //
            // btnLuuMatKhau
            //
            this.btnLuuMatKhau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuMatKhau.BackColor = System.Drawing.Color.FromArgb(19, 148, 132);
            this.btnLuuMatKhau.FlatAppearance.BorderSize = 0;
            this.btnLuuMatKhau.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(7, 139, 124);
            this.btnLuuMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLuuMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnLuuMatKhau.Location = new System.Drawing.Point(45, 503);
            this.btnLuuMatKhau.Name = "btnLuuMatKhau";
            this.btnLuuMatKhau.Size = new System.Drawing.Size(361, 48);
            this.btnLuuMatKhau.TabIndex = 3;
            this.btnLuuMatKhau.Text = "CẬP NHẬT";
            this.btnLuuMatKhau.UseVisualStyleBackColor = false;
            this.btnLuuMatKhau.Click += new System.EventHandler(this.BtnLuu_Click);
            //
            // chkHienMatKhau
            //
            this.chkHienMatKhau.AutoSize = true;
            this.chkHienMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkHienMatKhau.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.chkHienMatKhau.Location = new System.Drawing.Point(45, 450);
            this.chkHienMatKhau.Name = "chkHienMatKhau";
            this.chkHienMatKhau.Size = new System.Drawing.Size(130, 21);
            this.chkHienMatKhau.TabIndex = 9;
            this.chkHienMatKhau.Text = "Hiển thị mật khẩu";
            this.chkHienMatKhau.UseVisualStyleBackColor = true;
            this.chkHienMatKhau.CheckedChanged += new System.EventHandler(this.chkHienMatKhau_CheckedChanged);
            //
            // txtXacNhanMatKhau
            //
            this.txtXacNhanMatKhau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXacNhanMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(45, 409);
            this.txtXacNhanMatKhau.MaxLength = 255;
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(582, 25);
            this.txtXacNhanMatKhau.TabIndex = 2;
            this.txtXacNhanMatKhau.UseSystemPasswordChar = true;
            //
            // lblXacNhanMatKhau
            //
            this.lblXacNhanMatKhau.AutoSize = true;
            this.lblXacNhanMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblXacNhanMatKhau.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblXacNhanMatKhau.Location = new System.Drawing.Point(45, 383);
            this.lblXacNhanMatKhau.Name = "lblXacNhanMatKhau";
            this.lblXacNhanMatKhau.Size = new System.Drawing.Size(142, 17);
            this.lblXacNhanMatKhau.TabIndex = 8;
            this.lblXacNhanMatKhau.Text = "Xác nhận mật khẩu mới";
            //
            // txtMatKhauMoi
            //
            this.txtMatKhauMoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatKhauMoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMatKhauMoi.Location = new System.Drawing.Point(45, 316);
            this.txtMatKhauMoi.MaxLength = 255;
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(582, 25);
            this.txtMatKhauMoi.TabIndex = 1;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;
            //
            // lblMatKhauMoi
            //
            this.lblMatKhauMoi.AutoSize = true;
            this.lblMatKhauMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMatKhauMoi.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblMatKhauMoi.Location = new System.Drawing.Point(45, 290);
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Size = new System.Drawing.Size(194, 17);
            this.lblMatKhauMoi.TabIndex = 6;
            this.lblMatKhauMoi.Text = "Mật khẩu mới (ít nhất 8 ký tự)";
            //
            // txtMatKhauCu
            //
            this.txtMatKhauCu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatKhauCu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMatKhauCu.Location = new System.Drawing.Point(45, 223);
            this.txtMatKhauCu.MaxLength = 255;
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Size = new System.Drawing.Size(582, 25);
            this.txtMatKhauCu.TabIndex = 0;
            this.txtMatKhauCu.UseSystemPasswordChar = true;
            //
            // lblMatKhauCu
            //
            this.lblMatKhauCu.AutoSize = true;
            this.lblMatKhauCu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMatKhauCu.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblMatKhauCu.Location = new System.Drawing.Point(45, 197);
            this.lblMatKhauCu.Name = "lblMatKhauCu";
            this.lblMatKhauCu.Size = new System.Drawing.Size(117, 17);
            this.lblMatKhauCu.TabIndex = 4;
            this.lblMatKhauCu.Text = "Mật khẩu hiện tại";
            //
            // lblMoTa
            //
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(113, 128, 144);
            this.lblMoTa.Location = new System.Drawing.Point(47, 139);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(305, 19);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "Nhập mật khẩu hiện tại và chọn mật khẩu mới.";
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(21, 43, 59);
            this.lblTieuDe.Location = new System.Drawing.Point(42, 88);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(219, 41);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "Đổi mật khẩu";
            //
            // lblEyebrow
            //
            this.lblEyebrow.AutoSize = true;
            this.lblEyebrow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEyebrow.ForeColor = System.Drawing.Color.FromArgb(7, 139, 124);
            this.lblEyebrow.Location = new System.Drawing.Point(45, 57);
            this.lblEyebrow.Name = "lblEyebrow";
            this.lblEyebrow.Size = new System.Drawing.Size(149, 15);
            this.lblEyebrow.TabIndex = 0;
            this.lblEyebrow.Text = "THIẾT LẬP TÀI KHOẢN";
            //
            // frmDoiMatKhau
            //
            this.AcceptButton = this.btnLuuMatKhau;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(238, 244, 247);
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(980, 660);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHero);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            this.pnlHero.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHero;
        private System.Windows.Forms.Label lblHeroDescription;
        private System.Windows.Forms.Label lblHeroTitle;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.CheckBox chkHienMatKhau;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblSecurityNote;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuuMatKhau;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.Label lblXacNhanMatKhau;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Label lblMatKhauMoi;
        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.Label lblMatKhauCu;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblEyebrow;
    }
}
