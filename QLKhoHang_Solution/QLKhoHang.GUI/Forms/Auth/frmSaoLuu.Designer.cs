namespace QLKhoHang.GUI.Forms.Auth
{
    partial class frmSaoLuu
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblDatabaseTitle = new System.Windows.Forms.Label();
            this.pnlDatabase = new System.Windows.Forms.Panel();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblDatabaseCaption = new System.Windows.Forms.Label();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.lblWarningIcon = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.pnlBackup = new System.Windows.Forms.Panel();
            this.lblBackupDescription = new System.Windows.Forms.Label();
            this.lblBackupTitle = new System.Windows.Forms.Label();
            this.lblBackupIcon = new System.Windows.Forms.Label();
            this.btnSaoLuu = new System.Windows.Forms.Button();
            this.pnlRestore = new System.Windows.Forms.Panel();
            this.lblRestoreDescription = new System.Windows.Forms.Label();
            this.lblRestoreTitle = new System.Windows.Forms.Label();
            this.lblRestoreIcon = new System.Windows.Forms.Label();
            this.btnKhoiPhuc = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlDatabase.SuspendLayout();
            this.pnlWarning.SuspendLayout();
            this.pnlBackup.SuspendLayout();
            this.pnlRestore.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(16, 44, 59);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 104);
            this.pnlHeader.TabIndex = 0;
            //
            // lblSubtitle
            //
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(185, 211, 216);
            this.lblSubtitle.Location = new System.Drawing.Point(100, 61);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(600, 24);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Bảo vệ dữ liệu kho hàng của bạn";
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(97, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(700, 36);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Sao lưu và khôi phục dữ liệu";
            //
            // picLogo
            //
            this.picLogo.Image = global::QLKhoHang.GUI.Properties.Resources.logo_khohang;
            this.picLogo.Location = new System.Drawing.Point(32, 27);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(48, 48);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            //
            // lblDatabaseTitle
            //
            this.lblDatabaseTitle.AutoSize = true;
            this.lblDatabaseTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDatabaseTitle.ForeColor = System.Drawing.Color.FromArgb(113, 128, 144);
            this.lblDatabaseTitle.Location = new System.Drawing.Point(42, 120);
            this.lblDatabaseTitle.Name = "lblDatabaseTitle";
            this.lblDatabaseTitle.Size = new System.Drawing.Size(185, 15);
            this.lblDatabaseTitle.TabIndex = 1;
            this.lblDatabaseTitle.Text = "DATABASE THEO APP.CONFIG";
            //
            // pnlDatabase
            //
            this.pnlDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatabase.BackColor = System.Drawing.Color.FromArgb(243, 248, 250);
            this.pnlDatabase.Controls.Add(this.lblDatabase);
            this.pnlDatabase.Controls.Add(this.lblDatabaseCaption);
            this.pnlDatabase.Location = new System.Drawing.Point(42, 143);
            this.pnlDatabase.Name = "pnlDatabase";
            this.pnlDatabase.Size = new System.Drawing.Size(1016, 62);
            this.pnlDatabase.TabIndex = 2;
            //
            // lblDatabase
            //
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDatabase.ForeColor = System.Drawing.Color.FromArgb(7, 139, 124);
            this.lblDatabase.Location = new System.Drawing.Point(18, 29);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(77, 20);
            this.lblDatabase.TabIndex = 1;
            this.lblDatabase.Text = "QLKhoHang";
            //
            // lblDatabaseCaption
            //
            this.lblDatabaseCaption.AutoSize = true;
            this.lblDatabaseCaption.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblDatabaseCaption.ForeColor = System.Drawing.Color.FromArgb(113, 128, 144);
            this.lblDatabaseCaption.Location = new System.Drawing.Point(18, 9);
            this.lblDatabaseCaption.Name = "lblDatabaseCaption";
            this.lblDatabaseCaption.Size = new System.Drawing.Size(159, 12);
            this.lblDatabaseCaption.TabIndex = 0;
            this.lblDatabaseCaption.Text = "DATABASE ĐANG KẾT NỐI";
            //
            // pnlWarning
            //
            this.pnlWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWarning.BackColor = System.Drawing.Color.FromArgb(255, 247, 236);
            this.pnlWarning.Controls.Add(this.lblWarningIcon);
            this.pnlWarning.Controls.Add(this.lblWarning);
            this.pnlWarning.Location = new System.Drawing.Point(42, 220);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(1016, 80);
            this.pnlWarning.TabIndex = 3;
            //
            // lblWarningIcon
            //
            this.lblWarningIcon.BackColor = System.Drawing.Color.FromArgb(255, 237, 207);
            this.lblWarningIcon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWarningIcon.ForeColor = System.Drawing.Color.FromArgb(138, 91, 32);
            this.lblWarningIcon.Location = new System.Drawing.Point(18, 24);
            this.lblWarningIcon.Name = "lblWarningIcon";
            this.lblWarningIcon.Size = new System.Drawing.Size(30, 30);
            this.lblWarningIcon.TabIndex = 0;
            this.lblWarningIcon.Text = "!";
            this.lblWarningIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblWarning
            //
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(138, 91, 32);
            this.lblWarning.Location = new System.Drawing.Point(62, 13);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(934, 54);
            this.lblWarning.TabIndex = 1;
            this.lblWarning.Text = "SQL Server service cần quyền truy cập thư mục backup. Khôi phục chỉ tạo database test mới; không ghi đè database nguồn.";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlBackup
            //
            this.pnlBackup.BackColor = System.Drawing.Color.FromArgb(248, 252, 251);
            this.pnlBackup.Controls.Add(this.lblBackupDescription);
            this.pnlBackup.Controls.Add(this.lblBackupTitle);
            this.pnlBackup.Controls.Add(this.lblBackupIcon);
            this.pnlBackup.Controls.Add(this.btnSaoLuu);
            this.pnlBackup.Location = new System.Drawing.Point(42, 322);
            this.pnlBackup.Name = "pnlBackup";
            this.pnlBackup.Size = new System.Drawing.Size(492, 164);
            this.pnlBackup.TabIndex = 4;
            //
            // lblBackupDescription
            //
            this.lblBackupDescription.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBackupDescription.ForeColor = System.Drawing.Color.FromArgb(113, 128, 144);
            this.lblBackupDescription.Location = new System.Drawing.Point(80, 48);
            this.lblBackupDescription.Name = "lblBackupDescription";
            this.lblBackupDescription.Size = new System.Drawing.Size(385, 24);
            this.lblBackupDescription.TabIndex = 2;
            this.lblBackupDescription.Text = "Tạo file .bak mới và kiểm tra tính toàn vẹn.";
            //
            // lblBackupTitle
            //
            this.lblBackupTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBackupTitle.ForeColor = System.Drawing.Color.FromArgb(21, 43, 59);
            this.lblBackupTitle.Location = new System.Drawing.Point(80, 19);
            this.lblBackupTitle.Name = "lblBackupTitle";
            this.lblBackupTitle.Size = new System.Drawing.Size(385, 26);
            this.lblBackupTitle.TabIndex = 1;
            this.lblBackupTitle.Text = "Sao lưu database";
            //
            // lblBackupIcon
            //
            this.lblBackupIcon.BackColor = System.Drawing.Color.FromArgb(224, 244, 239);
            this.lblBackupIcon.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBackupIcon.ForeColor = System.Drawing.Color.FromArgb(7, 139, 124);
            this.lblBackupIcon.Location = new System.Drawing.Point(24, 19);
            this.lblBackupIcon.Name = "lblBackupIcon";
            this.lblBackupIcon.Size = new System.Drawing.Size(42, 42);
            this.lblBackupIcon.TabIndex = 0;
            this.lblBackupIcon.Text = "↓";
            this.lblBackupIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnSaoLuu
            //
            this.btnSaoLuu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaoLuu.BackColor = System.Drawing.Color.FromArgb(19, 148, 132);
            this.btnSaoLuu.FlatAppearance.BorderSize = 0;
            this.btnSaoLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(7, 139, 124);
            this.btnSaoLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaoLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaoLuu.ForeColor = System.Drawing.Color.White;
            this.btnSaoLuu.Location = new System.Drawing.Point(24, 94);
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.Size = new System.Drawing.Size(444, 48);
            this.btnSaoLuu.TabIndex = 3;
            this.btnSaoLuu.Text = "SAO LƯU DATABASE";
            this.btnSaoLuu.UseVisualStyleBackColor = false;
            this.btnSaoLuu.Click += new System.EventHandler(this.BtnSaoLuu_Click);
            //
            // pnlRestore
            //
            this.pnlRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.pnlRestore.BackColor = System.Drawing.Color.FromArgb(255, 250, 249);
            this.pnlRestore.Controls.Add(this.lblRestoreDescription);
            this.pnlRestore.Controls.Add(this.lblRestoreTitle);
            this.pnlRestore.Controls.Add(this.lblRestoreIcon);
            this.pnlRestore.Controls.Add(this.btnKhoiPhuc);
            this.pnlRestore.Location = new System.Drawing.Point(566, 322);
            this.pnlRestore.Name = "pnlRestore";
            this.pnlRestore.Size = new System.Drawing.Size(492, 164);
            this.pnlRestore.TabIndex = 5;
            //
            // lblRestoreDescription
            //
            this.lblRestoreDescription.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRestoreDescription.ForeColor = System.Drawing.Color.FromArgb(113, 128, 144);
            this.lblRestoreDescription.Location = new System.Drawing.Point(80, 48);
            this.lblRestoreDescription.Name = "lblRestoreDescription";
            this.lblRestoreDescription.Size = new System.Drawing.Size(385, 24);
            this.lblRestoreDescription.TabIndex = 2;
            this.lblRestoreDescription.Text = "Tạo database test mới từ file backup đã chọn.";
            //
            // lblRestoreTitle
            //
            this.lblRestoreTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRestoreTitle.ForeColor = System.Drawing.Color.FromArgb(21, 43, 59);
            this.lblRestoreTitle.Location = new System.Drawing.Point(80, 19);
            this.lblRestoreTitle.Name = "lblRestoreTitle";
            this.lblRestoreTitle.Size = new System.Drawing.Size(385, 26);
            this.lblRestoreTitle.TabIndex = 1;
            this.lblRestoreTitle.Text = "Khôi phục sang database test";
            //
            // lblRestoreIcon
            //
            this.lblRestoreIcon.BackColor = System.Drawing.Color.FromArgb(253, 235, 232);
            this.lblRestoreIcon.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblRestoreIcon.ForeColor = System.Drawing.Color.FromArgb(195, 91, 81);
            this.lblRestoreIcon.Location = new System.Drawing.Point(24, 19);
            this.lblRestoreIcon.Name = "lblRestoreIcon";
            this.lblRestoreIcon.Size = new System.Drawing.Size(42, 42);
            this.lblRestoreIcon.TabIndex = 0;
            this.lblRestoreIcon.Text = "↑";
            this.lblRestoreIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnKhoiPhuc
            //
            this.btnKhoiPhuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhoiPhuc.BackColor = System.Drawing.Color.FromArgb(201, 94, 83);
            this.btnKhoiPhuc.FlatAppearance.BorderSize = 0;
            this.btnKhoiPhuc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(174, 73, 64);
            this.btnKhoiPhuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoiPhuc.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnKhoiPhuc.ForeColor = System.Drawing.Color.White;
            this.btnKhoiPhuc.Location = new System.Drawing.Point(24, 94);
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.Size = new System.Drawing.Size(444, 48);
            this.btnKhoiPhuc.TabIndex = 3;
            this.btnKhoiPhuc.Text = "KHÔI PHỤC SANG DB TEST MỚI";
            this.btnKhoiPhuc.UseVisualStyleBackColor = false;
            this.btnKhoiPhuc.Click += new System.EventHandler(this.BtnKhoiPhuc_Click);
            //
            // pnlStatus
            //
            this.pnlStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatus.BackColor = System.Drawing.Color.White;
            this.pnlStatus.Controls.Add(this.lblTrangThai);
            this.pnlStatus.Location = new System.Drawing.Point(42, 503);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1016, 70);
            this.pnlStatus.TabIndex = 6;
            //
            // lblTrangThai
            //
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(113, 128, 144);
            this.lblTrangThai.Location = new System.Drawing.Point(0, 0);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Padding = new System.Windows.Forms.Padding(12, 2, 8, 2);
            this.lblTrangThai.Size = new System.Drawing.Size(1016, 70);
            this.lblTrangThai.TabIndex = 0;
            this.lblTrangThai.Text = "Chưa thực hiện thao tác.";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnDong
            //
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(241, 245, 247);
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(215, 224, 231);
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(67, 87, 103);
            this.btnDong.Location = new System.Drawing.Point(930, 585);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(128, 38);
            this.btnDong.TabIndex = 7;
            this.btnDong.Text = "ĐÓNG";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.BtnDong_Click);
            //
            // frmSaoLuu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(238, 244, 247);
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlRestore);
            this.Controls.Add(this.pnlBackup);
            this.Controls.Add(this.pnlWarning);
            this.Controls.Add(this.pnlDatabase);
            this.Controls.Add(this.lblDatabaseTitle);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSaoLuu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sao lưu và khôi phục dữ liệu";
            this.pnlHeader.ResumeLayout(false);
            this.pnlDatabase.ResumeLayout(false);
            this.pnlDatabase.PerformLayout();
            this.pnlWarning.ResumeLayout(false);
            this.pnlBackup.ResumeLayout(false);
            this.pnlRestore.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblDatabaseTitle;
        private System.Windows.Forms.Panel pnlDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblDatabaseCaption;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Label lblWarningIcon;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Panel pnlBackup;
        private System.Windows.Forms.Label lblBackupDescription;
        private System.Windows.Forms.Label lblBackupTitle;
        private System.Windows.Forms.Label lblBackupIcon;
        private System.Windows.Forms.Button btnSaoLuu;
        private System.Windows.Forms.Panel pnlRestore;
        private System.Windows.Forms.Label lblRestoreDescription;
        private System.Windows.Forms.Label lblRestoreTitle;
        private System.Windows.Forms.Label lblRestoreIcon;
        private System.Windows.Forms.Button btnKhoiPhuc;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Button btnDong;
    }
}
