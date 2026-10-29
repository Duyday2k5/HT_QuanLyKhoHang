namespace QLKhoHang.GUI.Forms.Auth
{
    partial class frmKetNoiCSDL
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
            this.btnDong = new System.Windows.Forms.Button();
            this.btnKiemTraVaLuu = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.pnlAuthentication = new System.Windows.Forms.Panel();
            this.lblDatabaseChip = new System.Windows.Forms.Label();
            this.lblAuthenticationValue = new System.Windows.Forms.Label();
            this.lblAuthenticationCaption = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEyebrow = new System.Windows.Forms.Label();
            this.pnlHero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlAuthentication.SuspendLayout();
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
            this.pnlHero.Size = new System.Drawing.Size(280, 650);
            this.pnlHero.TabIndex = 0;
            //
            // lblHeroDescription
            //
            this.lblHeroDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHeroDescription.ForeColor = System.Drawing.Color.FromArgb(191, 212, 217);
            this.lblHeroDescription.Location = new System.Drawing.Point(25, 380);
            this.lblHeroDescription.Name = "lblHeroDescription";
            this.lblHeroDescription.Size = new System.Drawing.Size(230, 58);
            this.lblHeroDescription.TabIndex = 3;
            this.lblHeroDescription.Text = "Ứng dụng dùng Windows Authentication để truy cập SQL Server.";
            this.lblHeroDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblHeroTitle
            //
            this.lblHeroTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblHeroTitle.ForeColor = System.Drawing.Color.FromArgb(238, 248, 246);
            this.lblHeroTitle.Location = new System.Drawing.Point(25, 333);
            this.lblHeroTitle.Name = "lblHeroTitle";
            this.lblHeroTitle.Size = new System.Drawing.Size(230, 38);
            this.lblHeroTitle.TabIndex = 2;
            this.lblHeroTitle.Text = "Kết nối an toàn";
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
            this.picLogo.Image = global::QLKhoHang.GUI.Properties.Resources.logo_khohang;
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
            this.pnlContent.Controls.Add(this.btnDong);
            this.pnlContent.Controls.Add(this.btnKiemTraVaLuu);
            this.pnlContent.Controls.Add(this.pnlStatus);
            this.pnlContent.Controls.Add(this.pnlAuthentication);
            this.pnlContent.Controls.Add(this.txtServerName);
            this.pnlContent.Controls.Add(this.lblServerName);
            this.pnlContent.Controls.Add(this.lblInstructions);
            this.pnlContent.Controls.Add(this.lblTitle);
            this.pnlContent.Controls.Add(this.lblEyebrow);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(280, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(45, 0, 45, 0);
            this.pnlContent.Size = new System.Drawing.Size(700, 650);
            this.pnlContent.TabIndex = 1;
            //
            // btnDong
            //
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(241, 245, 247);
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 224, 231);
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(67, 87, 103);
            this.btnDong.Location = new System.Drawing.Point(410, 524);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(220, 48);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "ĐÓNG";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.BtnDong_Click);
            //
            // btnKiemTraVaLuu
            //
            this.btnKiemTraVaLuu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKiemTraVaLuu.BackColor = System.Drawing.Color.FromArgb(19, 148, 132);
            this.btnKiemTraVaLuu.FlatAppearance.BorderSize = 0;
            this.btnKiemTraVaLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(7, 139, 124);
            this.btnKiemTraVaLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiemTraVaLuu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnKiemTraVaLuu.ForeColor = System.Drawing.Color.White;
            this.btnKiemTraVaLuu.Location = new System.Drawing.Point(45, 524);
            this.btnKiemTraVaLuu.Name = "btnKiemTraVaLuu";
            this.btnKiemTraVaLuu.Size = new System.Drawing.Size(350, 48);
            this.btnKiemTraVaLuu.TabIndex = 2;
            this.btnKiemTraVaLuu.Text = "KIỂM TRA VÀ LƯU";
            this.btnKiemTraVaLuu.UseVisualStyleBackColor = false;
            this.btnKiemTraVaLuu.Click += new System.EventHandler(this.BtnKiemTraVaLuu_Click);
            //
            // pnlStatus
            //
            this.pnlStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(247, 249, 250);
            this.pnlStatus.Controls.Add(this.lblKetQua);
            this.pnlStatus.Location = new System.Drawing.Point(45, 421);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(585, 68);
            this.pnlStatus.TabIndex = 8;
            //
            // lblKetQua
            //
            this.lblKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKetQua.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblKetQua.ForeColor = System.Drawing.Color.FromArgb(113, 128, 144);
            this.lblKetQua.Location = new System.Drawing.Point(0, 0);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Padding = new System.Windows.Forms.Padding(14, 4, 10, 4);
            this.lblKetQua.Size = new System.Drawing.Size(585, 68);
            this.lblKetQua.TabIndex = 0;
            this.lblKetQua.Text = "Server chỉ được lưu sau khi kết nối thử thành công.";
            this.lblKetQua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlAuthentication
            //
            this.pnlAuthentication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAuthentication.BackColor = System.Drawing.Color.FromArgb(243, 248, 250);
            this.pnlAuthentication.Controls.Add(this.lblDatabaseChip);
            this.pnlAuthentication.Controls.Add(this.lblAuthenticationValue);
            this.pnlAuthentication.Controls.Add(this.lblAuthenticationCaption);
            this.pnlAuthentication.Location = new System.Drawing.Point(45, 302);
            this.pnlAuthentication.Name = "pnlAuthentication";
            this.pnlAuthentication.Size = new System.Drawing.Size(585, 92);
            this.pnlAuthentication.TabIndex = 7;
            //
            // lblDatabaseChip
            //
            this.lblDatabaseChip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatabaseChip.BackColor = System.Drawing.Color.FromArgb(232, 245, 242);
            this.lblDatabaseChip.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDatabaseChip.ForeColor = System.Drawing.Color.FromArgb(23, 122, 112);
            this.lblDatabaseChip.Location = new System.Drawing.Point(385, 38);
            this.lblDatabaseChip.Name = "lblDatabaseChip";
            this.lblDatabaseChip.Size = new System.Drawing.Size(180, 31);
            this.lblDatabaseChip.TabIndex = 2;
            this.lblDatabaseChip.Text = "DATABASE  QLKhoHang";
            this.lblDatabaseChip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblAuthenticationValue
            //
            this.lblAuthenticationValue.AutoSize = true;
            this.lblAuthenticationValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAuthenticationValue.ForeColor = System.Drawing.Color.FromArgb(41, 66, 82);
            this.lblAuthenticationValue.Location = new System.Drawing.Point(20, 46);
            this.lblAuthenticationValue.Name = "lblAuthenticationValue";
            this.lblAuthenticationValue.Size = new System.Drawing.Size(184, 19);
            this.lblAuthenticationValue.TabIndex = 1;
            this.lblAuthenticationValue.Text = "Windows Authentication";
            //
            // lblAuthenticationCaption
            //
            this.lblAuthenticationCaption.AutoSize = true;
            this.lblAuthenticationCaption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblAuthenticationCaption.ForeColor = System.Drawing.Color.FromArgb(113, 128, 144);
            this.lblAuthenticationCaption.Location = new System.Drawing.Point(20, 15);
            this.lblAuthenticationCaption.Name = "lblAuthenticationCaption";
            this.lblAuthenticationCaption.Size = new System.Drawing.Size(65, 13);
            this.lblAuthenticationCaption.TabIndex = 0;
            this.lblAuthenticationCaption.Text = "XÁC THỰC";
            //
            // txtServerName
            //
            this.txtServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtServerName.Location = new System.Drawing.Point(45, 232);
            this.txtServerName.MaxLength = 128;
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(585, 25);
            this.txtServerName.TabIndex = 0;
            this.txtServerName.AccessibleName = "Server name";
            //
            // lblServerName
            //
            this.lblServerName.AutoSize = true;
            this.lblServerName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblServerName.ForeColor = System.Drawing.Color.FromArgb(38, 57, 73);
            this.lblServerName.Location = new System.Drawing.Point(45, 204);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(79, 17);
            this.lblServerName.TabIndex = 5;
            this.lblServerName.Text = "Server name";
            //
            // lblInstructions
            //
            this.lblInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(113, 128, 144);
            this.lblInstructions.Location = new System.Drawing.Point(47, 133);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(583, 49);
            this.lblInstructions.TabIndex = 3;
            this.lblInstructions.Text = "Nhập Server name như trong SSMS. Ứng dụng tiếp tục dùng Windows Authentication và database được khai báo trong App.config.";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(21, 43, 59);
            this.lblTitle.Location = new System.Drawing.Point(42, 88);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(329, 41);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Kết nối cơ sở dữ liệu";
            //
            // lblEyebrow
            //
            this.lblEyebrow.AutoSize = true;
            this.lblEyebrow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEyebrow.ForeColor = System.Drawing.Color.FromArgb(7, 139, 124);
            this.lblEyebrow.Location = new System.Drawing.Point(45, 57);
            this.lblEyebrow.Name = "lblEyebrow";
            this.lblEyebrow.Size = new System.Drawing.Size(135, 15);
            this.lblEyebrow.TabIndex = 1;
            this.lblEyebrow.Text = "CẤU HÌNH KẾT NỐI";
            //
            // frmKetNoiCSDL
            //
            this.AcceptButton = this.btnKiemTraVaLuu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(238, 244, 247);
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(980, 650);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHero);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKetNoiCSDL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cấu hình kết nối cơ sở dữ liệu";
            this.pnlHero.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlAuthentication.ResumeLayout(false);
            this.pnlAuthentication.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHero;
        private System.Windows.Forms.Label lblHeroDescription;
        private System.Windows.Forms.Label lblHeroTitle;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnKiemTraVaLuu;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Panel pnlAuthentication;
        private System.Windows.Forms.Label lblDatabaseChip;
        private System.Windows.Forms.Label lblAuthenticationValue;
        private System.Windows.Forms.Label lblAuthenticationCaption;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEyebrow;
    }
}
