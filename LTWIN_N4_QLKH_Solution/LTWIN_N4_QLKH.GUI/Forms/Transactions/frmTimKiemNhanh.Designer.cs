namespace LTWIN_N4_QLKH.GUI.Forms.Transactions
{
    partial class frmTimKiemNhanh
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
            this.btnDong = new System.Windows.Forms.Button();
            this.btnChon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTimKiem = new System.Windows.Forms.DataGridView();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlBottom.Controls.Add(this.btnDong);
            this.pnlBottom.Controls.Add(this.btnChon);
            this.pnlBottom.Controls.Add(this.label2);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 449);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(728, 55);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(572, 11);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(85, 34);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng ";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // btnChon
            // 
            this.btnChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.btnChon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnChon.ForeColor = System.Drawing.Color.White;
            this.btnChon.Location = new System.Drawing.Point(429, 11);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(95, 34);
            this.btnChon.TabIndex = 1;
            this.btnChon.Text = "✔ Chọn";
            this.btnChon.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label2.Location = new System.Drawing.Point(15, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "💡 Mẹo: Nhấp đúp chuột vào mặt hàng để chọn nhanh";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnTim);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(728, 65);
            this.pnlTop.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(510, 19);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(95, 32);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "🔍 Tìm";
            this.btnTim.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(162, 19);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(310, 27);
            this.txtTimKiem.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ khóa tìm kiếm:";
            // 
            // dgvTimKiem
            // 
            this.dgvTimKiem.AllowUserToAddRows = false;
            this.dgvTimKiem.AllowUserToDeleteRows = false;
            this.dgvTimKiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimKiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTimKiem.Location = new System.Drawing.Point(0, 65);
            this.dgvTimKiem.MultiSelect = false;
            this.dgvTimKiem.Name = "dgvTimKiem";
            this.dgvTimKiem.ReadOnly = true;
            this.dgvTimKiem.RowHeadersVisible = false;
            this.dgvTimKiem.RowHeadersWidth = 51;
            this.dgvTimKiem.RowTemplate.Height = 24;
            this.dgvTimKiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimKiem.Size = new System.Drawing.Size(728, 384);
            this.dgvTimKiem.TabIndex = 2;
            this.dgvTimKiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimKiem_CellContentClick);
            // 
            // frmTimKiemNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 504);
            this.Controls.Add(this.dgvTimKiem);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimKiemNhanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm nhanh mặt hàng";
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.DataGridView dgvTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnChon;
    }
}