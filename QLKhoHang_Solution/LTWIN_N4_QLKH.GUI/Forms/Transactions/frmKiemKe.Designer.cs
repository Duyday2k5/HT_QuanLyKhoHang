namespace LTWIN_N4_QLKH.GUI.Forms.Transactions
{
    partial class frmKiemKe
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.dgvKiemKe = new System.Windows.Forms.DataGridView();
            this.grpKiemKe = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaKK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenKho = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgayKK = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.btnTaiDuLieu = new System.Windows.Forms.Button();
            this.btnCanBang = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSoLuongLech = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiemKe)).BeginInit();
            this.grpKiemKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlBottom.Controls.Add(this.lblSoLuongLech);
            this.pnlBottom.Controls.Add(this.label6);
            this.pnlBottom.Controls.Add(this.btnHuy);
            this.pnlBottom.Controls.Add(this.btnCanBang);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlBottom.Location = new System.Drawing.Point(0, 560);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(980, 60);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpKiemKe);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(980, 140);
            this.pnlTop.TabIndex = 1;
            // 
            // dgvKiemKe
            // 
            this.dgvKiemKe.AllowUserToAddRows = false;
            this.dgvKiemKe.AllowUserToDeleteRows = false;
            this.dgvKiemKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKiemKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvKiemKe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKiemKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKiemKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKiemKe.Location = new System.Drawing.Point(0, 140);
            this.dgvKiemKe.Name = "dgvKiemKe";
            this.dgvKiemKe.RowHeadersWidth = 51;
            this.dgvKiemKe.RowTemplate.Height = 24;
            this.dgvKiemKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvKiemKe.Size = new System.Drawing.Size(980, 420);
            this.dgvKiemKe.TabIndex = 2;
            // 
            // grpKiemKe
            // 
            this.grpKiemKe.Controls.Add(this.picLogo);
            this.grpKiemKe.Controls.Add(this.btnTaiDuLieu);
            this.grpKiemKe.Controls.Add(this.lblNhanVien);
            this.grpKiemKe.Controls.Add(this.label5);
            this.grpKiemKe.Controls.Add(this.dtpNgayKK);
            this.grpKiemKe.Controls.Add(this.label4);
            this.grpKiemKe.Controls.Add(this.txtGhiChu);
            this.grpKiemKe.Controls.Add(this.label3);
            this.grpKiemKe.Controls.Add(this.txtTenKho);
            this.grpKiemKe.Controls.Add(this.label2);
            this.grpKiemKe.Controls.Add(this.txtMaKK);
            this.grpKiemKe.Controls.Add(this.label1);
            this.grpKiemKe.Location = new System.Drawing.Point(12, 10);
            this.grpKiemKe.Name = "grpKiemKe";
            this.grpKiemKe.Size = new System.Drawing.Size(956, 120);
            this.grpKiemKe.TabIndex = 0;
            this.grpKiemKe.TabStop = false;
            this.grpKiemKe.Text = "Thông tin phiếu kiểm kê kho hàng";
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.Image = global::LTWIN_N4_QLKH.GUI.Properties.Resources.logo_khohang;
            this.picLogo.Location = new System.Drawing.Point(860, 20);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(80, 80);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 11;
            this.picLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số Phiếu ";
            // 
            // txtMaKK
            // 
            this.txtMaKK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMaKK.Location = new System.Drawing.Point(103, 22);
            this.txtMaKK.Name = "txtMaKK";
            this.txtMaKK.ReadOnly = true;
            this.txtMaKK.Size = new System.Drawing.Size(160, 30);
            this.txtMaKK.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kho Hàng ";
            // 
            // txtTenKho
            // 
            this.txtTenKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtTenKho.Location = new System.Drawing.Point(103, 58);
            this.txtTenKho.Name = "txtTenKho";
            this.txtTenKho.ReadOnly = true;
            this.txtTenKho.Size = new System.Drawing.Size(180, 30);
            this.txtTenKho.TabIndex = 3;
            this.txtTenKho.Text = "Kho Chính - Tổng kho";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ghi Chú ";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(103, 87);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(350, 30);
            this.txtGhiChu.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày Kiểm:";
            // 
            // dtpNgayKK
            // 
            this.dtpNgayKK.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayKK.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKK.Location = new System.Drawing.Point(583, 22);
            this.dtpNgayKK.Name = "dtpNgayKK";
            this.dtpNgayKK.Size = new System.Drawing.Size(160, 30);
            this.dtpNgayKK.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(480, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Người Kiểm:";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.lblNhanVien.Location = new System.Drawing.Point(579, 58);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(90, 23);
            this.lblNhanVien.TabIndex = 9;
            this.lblNhanVien.Text = "(Tự động)";
            // 
            // btnTaiDuLieu
            // 
            this.btnTaiDuLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTaiDuLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiDuLieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTaiDuLieu.ForeColor = System.Drawing.Color.White;
            this.btnTaiDuLieu.Location = new System.Drawing.Point(570, 80);
            this.btnTaiDuLieu.Name = "btnTaiDuLieu";
            this.btnTaiDuLieu.Size = new System.Drawing.Size(280, 32);
            this.btnTaiDuLieu.TabIndex = 10;
            this.btnTaiDuLieu.Text = "📥 TẢI DANH SÁCH HÀNG KIỂM KÊ";
            this.btnTaiDuLieu.UseVisualStyleBackColor = false;
            // 
            // btnCanBang
            // 
            this.btnCanBang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.btnCanBang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCanBang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCanBang.ForeColor = System.Drawing.Color.White;
            this.btnCanBang.Location = new System.Drawing.Point(12, 10);
            this.btnCanBang.Name = "btnCanBang";
            this.btnCanBang.Size = new System.Drawing.Size(280, 40);
            this.btnCanBang.TabIndex = 0;
            this.btnCanBang.Text = "⚖️ CÂN BẰNG TỒN KHO TỰ ĐỘNG";
            this.btnCanBang.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(305, 10);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(128, 40);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "🔄 Làm mới";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(43)))), ((int)(((byte)(59)))));
            this.label6.Location = new System.Drawing.Point(680, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Mặt hàng chênh lệch:";
            // 
            // lblSoLuongLech
            // 
            this.lblSoLuongLech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoLuongLech.AutoSize = true;
            this.lblSoLuongLech.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSoLuongLech.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblSoLuongLech.Location = new System.Drawing.Point(882, 15);
            this.lblSoLuongLech.Name = "lblSoLuongLech";
            this.lblSoLuongLech.Size = new System.Drawing.Size(60, 31);
            this.lblSoLuongLech.TabIndex = 3;
            this.lblSoLuongLech.Text = "0 SP";
            // 
            // frmKiemKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(980, 620);
            this.Controls.Add(this.dgvKiemKe);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmKiemKe";
            this.Text = "Kiểm kê và cân bằng kho";
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiemKe)).EndInit();
            this.grpKiemKe.ResumeLayout(false);
            this.grpKiemKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.DataGridView dgvKiemKe;
        private System.Windows.Forms.GroupBox grpKiemKe;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TextBox txtTenKho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaKK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpNgayKK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnCanBang;
        private System.Windows.Forms.Button btnTaiDuLieu;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblSoLuongLech;
        private System.Windows.Forms.Label label6;
    }
}