namespace QLKhoHang.GUI.Forms.Inventory
{
    partial class frmTheKho
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.TableLayoutPanel tlpBoLoc;
        private System.Windows.Forms.Label lblHangHoaTitle;
        private System.Windows.Forms.Label lblTuNgayTitle;
        private System.Windows.Forms.Label lblDenNgayTitle;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.ComboBox cboHangHoa;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXemTheKho;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Panel pnlKPI;
        private System.Windows.Forms.TableLayoutPanel tlpKPI;
        private System.Windows.Forms.Panel pnlKpiTonDau;
        private System.Windows.Forms.Panel pnlKpiTongNhap;
        private System.Windows.Forms.Panel pnlKpiTongXuat;
        private System.Windows.Forms.Panel pnlKpiTonCuoi;
        private System.Windows.Forms.Label lblTieuDeTonDau;
        private System.Windows.Forms.Label lblTieuDeTongNhap;
        private System.Windows.Forms.Label lblTieuDeTongXuat;
        private System.Windows.Forms.Label lblTieuDeTonCuoi;
        private System.Windows.Forms.Label lblTonDau;
        private System.Windows.Forms.Label lblTongNhap;
        private System.Windows.Forms.Label lblTongXuat;
        private System.Windows.Forms.Label lblTonCuoi;
        private System.Windows.Forms.DataGridView dgvTheKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChungTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienGiai;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDuTon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpBoLoc = new System.Windows.Forms.GroupBox();
            this.tlpBoLoc = new System.Windows.Forms.TableLayoutPanel();
            this.lblHangHoaTitle = new System.Windows.Forms.Label();
            this.lblTuNgayTitle = new System.Windows.Forms.Label();
            this.lblDenNgayTitle = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.cboHangHoa = new System.Windows.Forms.ComboBox();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXemTheKho = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.pnlKPI = new System.Windows.Forms.Panel();
            this.tlpKPI = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpiTonDau = new System.Windows.Forms.Panel();
            this.lblTieuDeTonDau = new System.Windows.Forms.Label();
            this.lblTonDau = new System.Windows.Forms.Label();
            this.pnlKpiTongNhap = new System.Windows.Forms.Panel();
            this.lblTieuDeTongNhap = new System.Windows.Forms.Label();
            this.lblTongNhap = new System.Windows.Forms.Label();
            this.pnlKpiTongXuat = new System.Windows.Forms.Panel();
            this.lblTieuDeTongXuat = new System.Windows.Forms.Label();
            this.lblTongXuat = new System.Windows.Forms.Label();
            this.pnlKpiTonCuoi = new System.Windows.Forms.Panel();
            this.lblTieuDeTonCuoi = new System.Windows.Forms.Label();
            this.lblTonCuoi = new System.Windows.Forms.Label();
            this.dgvTheKho = new System.Windows.Forms.DataGridView();
            this.NgayGhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChungTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienGiai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDuTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpBoLoc.SuspendLayout();
            this.tlpBoLoc.SuspendLayout();
            this.pnlKPI.SuspendLayout();
            this.tlpKPI.SuspendLayout();
            this.pnlKpiTonDau.SuspendLayout();
            this.pnlKpiTongNhap.SuspendLayout();
            this.pnlKpiTongXuat.SuspendLayout();
            this.pnlKpiTonCuoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheKho)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Controls.Add(this.tlpBoLoc);
            this.grpBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoLoc.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoLoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpBoLoc.Location = new System.Drawing.Point(12, 12);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Padding = new System.Windows.Forms.Padding(12, 24, 12, 8);
            this.grpBoLoc.Size = new System.Drawing.Size(1443, 132);
            this.grpBoLoc.TabIndex = 0;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Bộ lọc thẻ kho";
            // 
            // tlpBoLoc
            // 
            this.tlpBoLoc.ColumnCount = 5;
            this.tlpBoLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpBoLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpBoLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpBoLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpBoLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpBoLoc.Controls.Add(this.lblHangHoaTitle, 0, 0);
            this.tlpBoLoc.Controls.Add(this.lblTuNgayTitle, 1, 0);
            this.tlpBoLoc.Controls.Add(this.lblDenNgayTitle, 2, 0);
            this.tlpBoLoc.Controls.Add(this.lblGhiChu, 0, 2);
            this.tlpBoLoc.Controls.Add(this.cboHangHoa, 0, 1);
            this.tlpBoLoc.Controls.Add(this.dtpTuNgay, 1, 1);
            this.tlpBoLoc.Controls.Add(this.dtpDenNgay, 2, 1);
            this.tlpBoLoc.Controls.Add(this.btnXemTheKho, 3, 1);
            this.tlpBoLoc.Controls.Add(this.btnXuatExcel, 4, 1);
            this.tlpBoLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBoLoc.Location = new System.Drawing.Point(12, 47);
            this.tlpBoLoc.Name = "tlpBoLoc";
            this.tlpBoLoc.RowCount = 3;
            this.tlpBoLoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpBoLoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpBoLoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBoLoc.Size = new System.Drawing.Size(1419, 77);
            this.tlpBoLoc.TabIndex = 0;
            // 
            // lblHangHoaTitle
            // 
            this.lblHangHoaTitle.AutoSize = true;
            this.lblHangHoaTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHangHoaTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHangHoaTitle.Location = new System.Drawing.Point(3, 0);
            this.lblHangHoaTitle.Name = "lblHangHoaTitle";
            this.lblHangHoaTitle.Size = new System.Drawing.Size(476, 23);
            this.lblHangHoaTitle.TabIndex = 0;
            this.lblHangHoaTitle.Text = "Mặt hàng";
            this.lblHangHoaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTuNgayTitle
            // 
            this.lblTuNgayTitle.AutoSize = true;
            this.lblTuNgayTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTuNgayTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgayTitle.Location = new System.Drawing.Point(485, 0);
            this.lblTuNgayTitle.Name = "lblTuNgayTitle";
            this.lblTuNgayTitle.Size = new System.Drawing.Size(249, 23);
            this.lblTuNgayTitle.TabIndex = 1;
            this.lblTuNgayTitle.Text = "Từ ngày";
            this.lblTuNgayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDenNgayTitle
            // 
            this.lblDenNgayTitle.AutoSize = true;
            this.lblDenNgayTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDenNgayTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgayTitle.Location = new System.Drawing.Point(740, 0);
            this.lblDenNgayTitle.Name = "lblDenNgayTitle";
            this.lblDenNgayTitle.Size = new System.Drawing.Size(249, 23);
            this.lblDenNgayTitle.TabIndex = 2;
            this.lblDenNgayTitle.Text = "Đến ngày";
            this.lblDenNgayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblGhiChu.Location = new System.Drawing.Point(3, 61);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(476, 16);
            this.lblGhiChu.TabIndex = 3;
            this.lblGhiChu.Text = "Số dư tồn tính lũy kế theo ngày chứng từ.";
            this.lblGhiChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboHangHoa
            // 
            this.cboHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboHangHoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHangHoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHangHoa.FormattingEnabled = true;
            this.cboHangHoa.Location = new System.Drawing.Point(3, 26);
            this.cboHangHoa.Name = "cboHangHoa";
            this.cboHangHoa.Size = new System.Drawing.Size(476, 31);
            this.cboHangHoa.TabIndex = 4;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(485, 26);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(249, 30);
            this.dtpTuNgay.TabIndex = 5;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(740, 26);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(249, 30);
            this.dtpDenNgay.TabIndex = 6;
            // 
            // btnXemTheKho
            // 
            this.btnXemTheKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnXemTheKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXemTheKho.Enabled = false;
            this.btnXemTheKho.FlatAppearance.BorderSize = 0;
            this.btnXemTheKho.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnXemTheKho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnXemTheKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTheKho.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemTheKho.ForeColor = System.Drawing.Color.White;
            this.btnXemTheKho.Location = new System.Drawing.Point(995, 26);
            this.btnXemTheKho.Name = "btnXemTheKho";
            this.btnXemTheKho.Size = new System.Drawing.Size(206, 32);
            this.btnXemTheKho.TabIndex = 7;
            this.btnXemTheKho.Text = "XEM DỮ LIỆU";
            this.btnXemTheKho.UseVisualStyleBackColor = false;
            this.btnXemTheKho.Click += new System.EventHandler(this.btnXemTheKho_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.btnXuatExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXuatExcel.Enabled = false;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.btnXuatExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(184)))), ((int)(((byte)(166)))));
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(1207, 26);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(209, 32);
            this.btnXuatExcel.TabIndex = 8;
            this.btnXuatExcel.Text = "XUẤT EXCEL (.XLSX)";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // pnlKPI
            // 
            this.pnlKPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlKPI.Controls.Add(this.tlpKPI);
            this.pnlKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKPI.Location = new System.Drawing.Point(12, 144);
            this.pnlKPI.Name = "pnlKPI";
            this.pnlKPI.Padding = new System.Windows.Forms.Padding(8);
            this.pnlKPI.Size = new System.Drawing.Size(1443, 88);
            this.pnlKPI.TabIndex = 1;
            // 
            // tlpKPI
            // 
            this.tlpKPI.ColumnCount = 4;
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.Controls.Add(this.pnlKpiTonDau, 0, 0);
            this.tlpKPI.Controls.Add(this.pnlKpiTongNhap, 1, 0);
            this.tlpKPI.Controls.Add(this.pnlKpiTongXuat, 2, 0);
            this.tlpKPI.Controls.Add(this.pnlKpiTonCuoi, 3, 0);
            this.tlpKPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKPI.Location = new System.Drawing.Point(8, 8);
            this.tlpKPI.Name = "tlpKPI";
            this.tlpKPI.RowCount = 1;
            this.tlpKPI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKPI.Size = new System.Drawing.Size(1427, 72);
            this.tlpKPI.TabIndex = 0;
            // 
            // pnlKpiTonDau
            // 
            this.pnlKpiTonDau.BackColor = System.Drawing.Color.White;
            this.pnlKpiTonDau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiTonDau.Controls.Add(this.lblTieuDeTonDau);
            this.pnlKpiTonDau.Controls.Add(this.lblTonDau);
            this.pnlKpiTonDau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiTonDau.Location = new System.Drawing.Point(3, 0);
            this.pnlKpiTonDau.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.pnlKpiTonDau.Name = "pnlKpiTonDau";
            this.pnlKpiTonDau.Size = new System.Drawing.Size(347, 72);
            this.pnlKpiTonDau.TabIndex = 0;
            // 
            // lblTieuDeTonDau
            // 
            this.lblTieuDeTonDau.AutoSize = true;
            this.lblTieuDeTonDau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTonDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTonDau.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTonDau.Name = "lblTieuDeTonDau";
            this.lblTieuDeTonDau.Size = new System.Drawing.Size(85, 23);
            this.lblTieuDeTonDau.TabIndex = 0;
            this.lblTieuDeTonDau.Text = "TỒN ĐẦU";
            // 
            // lblTonDau
            // 
            this.lblTonDau.AutoSize = true;
            this.lblTonDau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTonDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTonDau.Location = new System.Drawing.Point(12, 29);
            this.lblTonDau.Name = "lblTonDau";
            this.lblTonDau.Size = new System.Drawing.Size(27, 23);
            this.lblTonDau.TabIndex = 1;
            this.lblTonDau.Text = "—";
            // 
            // pnlKpiTongNhap
            // 
            this.pnlKpiTongNhap.BackColor = System.Drawing.Color.White;
            this.pnlKpiTongNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiTongNhap.Controls.Add(this.lblTieuDeTongNhap);
            this.pnlKpiTongNhap.Controls.Add(this.lblTongNhap);
            this.pnlKpiTongNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiTongNhap.Location = new System.Drawing.Point(359, 0);
            this.pnlKpiTongNhap.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.pnlKpiTongNhap.Name = "pnlKpiTongNhap";
            this.pnlKpiTongNhap.Size = new System.Drawing.Size(347, 72);
            this.pnlKpiTongNhap.TabIndex = 1;
            // 
            // lblTieuDeTongNhap
            // 
            this.lblTieuDeTongNhap.AutoSize = true;
            this.lblTieuDeTongNhap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTongNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongNhap.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongNhap.Name = "lblTieuDeTongNhap";
            this.lblTieuDeTongNhap.Size = new System.Drawing.Size(108, 23);
            this.lblTieuDeTongNhap.TabIndex = 0;
            this.lblTieuDeTongNhap.Text = "TỔNG NHẬP";
            // 
            // lblTongNhap
            // 
            this.lblTongNhap.AutoSize = true;
            this.lblTongNhap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.lblTongNhap.Location = new System.Drawing.Point(12, 29);
            this.lblTongNhap.Name = "lblTongNhap";
            this.lblTongNhap.Size = new System.Drawing.Size(27, 23);
            this.lblTongNhap.TabIndex = 1;
            this.lblTongNhap.Text = "—";
            // 
            // pnlKpiTongXuat
            // 
            this.pnlKpiTongXuat.BackColor = System.Drawing.Color.White;
            this.pnlKpiTongXuat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiTongXuat.Controls.Add(this.lblTieuDeTongXuat);
            this.pnlKpiTongXuat.Controls.Add(this.lblTongXuat);
            this.pnlKpiTongXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiTongXuat.Location = new System.Drawing.Point(715, 0);
            this.pnlKpiTongXuat.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.pnlKpiTongXuat.Name = "pnlKpiTongXuat";
            this.pnlKpiTongXuat.Size = new System.Drawing.Size(347, 72);
            this.pnlKpiTongXuat.TabIndex = 2;
            // 
            // lblTieuDeTongXuat
            // 
            this.lblTieuDeTongXuat.AutoSize = true;
            this.lblTieuDeTongXuat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTongXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongXuat.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongXuat.Name = "lblTieuDeTongXuat";
            this.lblTieuDeTongXuat.Size = new System.Drawing.Size(104, 23);
            this.lblTieuDeTongXuat.TabIndex = 0;
            this.lblTieuDeTongXuat.Text = "TỔNG XUẤT";
            // 
            // lblTongXuat
            // 
            this.lblTongXuat.AutoSize = true;
            this.lblTongXuat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblTongXuat.Location = new System.Drawing.Point(12, 29);
            this.lblTongXuat.Name = "lblTongXuat";
            this.lblTongXuat.Size = new System.Drawing.Size(27, 23);
            this.lblTongXuat.TabIndex = 1;
            this.lblTongXuat.Text = "—";
            // 
            // pnlKpiTonCuoi
            // 
            this.pnlKpiTonCuoi.BackColor = System.Drawing.Color.White;
            this.pnlKpiTonCuoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiTonCuoi.Controls.Add(this.lblTieuDeTonCuoi);
            this.pnlKpiTonCuoi.Controls.Add(this.lblTonCuoi);
            this.pnlKpiTonCuoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiTonCuoi.Location = new System.Drawing.Point(1071, 0);
            this.pnlKpiTonCuoi.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlKpiTonCuoi.Name = "pnlKpiTonCuoi";
            this.pnlKpiTonCuoi.Size = new System.Drawing.Size(356, 72);
            this.pnlKpiTonCuoi.TabIndex = 3;
            // 
            // lblTieuDeTonCuoi
            // 
            this.lblTieuDeTonCuoi.AutoSize = true;
            this.lblTieuDeTonCuoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTonCuoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTonCuoi.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTonCuoi.Name = "lblTieuDeTonCuoi";
            this.lblTieuDeTonCuoi.Size = new System.Drawing.Size(91, 23);
            this.lblTieuDeTonCuoi.TabIndex = 0;
            this.lblTieuDeTonCuoi.Text = "TỒN CUỐI";
            // 
            // lblTonCuoi
            // 
            this.lblTonCuoi.AutoSize = true;
            this.lblTonCuoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTonCuoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTonCuoi.Location = new System.Drawing.Point(12, 29);
            this.lblTonCuoi.Name = "lblTonCuoi";
            this.lblTonCuoi.Size = new System.Drawing.Size(27, 23);
            this.lblTonCuoi.TabIndex = 1;
            this.lblTonCuoi.Text = "—";
            // 
            // dgvTheKho
            // 
            this.dgvTheKho.AllowUserToAddRows = false;
            this.dgvTheKho.AllowUserToDeleteRows = false;
            this.dgvTheKho.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvTheKho.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTheKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTheKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvTheKho.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTheKho.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTheKho.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTheKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTheKho.ColumnHeadersHeight = 40;
            this.dgvTheKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTheKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayGhi,
            this.ChungTu,
            this.DienGiai,
            this.DonGia,
            this.SLNhap,
            this.SLXuat,
            this.SoDuTon});
            this.dgvTheKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTheKho.EnableHeadersVisualStyles = false;
            this.dgvTheKho.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvTheKho.Location = new System.Drawing.Point(12, 232);
            this.dgvTheKho.MultiSelect = false;
            this.dgvTheKho.Name = "dgvTheKho";
            this.dgvTheKho.ReadOnly = true;
            this.dgvTheKho.RowHeadersVisible = false;
            this.dgvTheKho.RowHeadersWidth = 51;
            this.dgvTheKho.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTheKho.RowTemplate.Height = 34;
            this.dgvTheKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTheKho.Size = new System.Drawing.Size(1443, 539);
            this.dgvTheKho.TabIndex = 2;
            // 
            // NgayGhi
            // 
            this.NgayGhi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayGhi.DataPropertyName = "NgayGhi";
            this.NgayGhi.FillWeight = 13F;
            this.NgayGhi.HeaderText = "Ngày ghi";
            this.NgayGhi.MinimumWidth = 6;
            this.NgayGhi.Name = "NgayGhi";
            this.NgayGhi.ReadOnly = true;
            // 
            // ChungTu
            // 
            this.ChungTu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChungTu.DataPropertyName = "ChungTu";
            this.ChungTu.FillWeight = 14F;
            this.ChungTu.HeaderText = "Chứng từ";
            this.ChungTu.MinimumWidth = 6;
            this.ChungTu.Name = "ChungTu";
            this.ChungTu.ReadOnly = true;
            // 
            // DienGiai
            // 
            this.DienGiai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DienGiai.DataPropertyName = "DienGiai";
            this.DienGiai.FillWeight = 34F;
            this.DienGiai.HeaderText = "Diễn giải nội dung";
            this.DienGiai.MinimumWidth = 6;
            this.DienGiai.Name = "DienGiai";
            this.DienGiai.ReadOnly = true;
            // 
            // DonGia
            // 
            this.DonGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.DonGia.DefaultCellStyle = dataGridViewCellStyle3;
            this.DonGia.FillWeight = 13F;
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.MinimumWidth = 6;
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            // 
            // SLNhap
            // 
            this.SLNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SLNhap.DataPropertyName = "SLNhap";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.SLNhap.DefaultCellStyle = dataGridViewCellStyle4;
            this.SLNhap.FillWeight = 8F;
            this.SLNhap.HeaderText = "SL Nhập";
            this.SLNhap.MinimumWidth = 6;
            this.SLNhap.Name = "SLNhap";
            this.SLNhap.ReadOnly = true;
            // 
            // SLXuat
            // 
            this.SLXuat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SLXuat.DataPropertyName = "SLXuat";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.SLXuat.DefaultCellStyle = dataGridViewCellStyle5;
            this.SLXuat.FillWeight = 8F;
            this.SLXuat.HeaderText = "SL Xuất";
            this.SLXuat.MinimumWidth = 6;
            this.SLXuat.Name = "SLXuat";
            this.SLXuat.ReadOnly = true;
            // 
            // SoDuTon
            // 
            this.SoDuTon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoDuTon.DataPropertyName = "SoDuTon";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.SoDuTon.DefaultCellStyle = dataGridViewCellStyle6;
            this.SoDuTon.FillWeight = 10F;
            this.SoDuTon.HeaderText = "Số dư tồn";
            this.SoDuTon.MinimumWidth = 6;
            this.SoDuTon.Name = "SoDuTon";
            this.SoDuTon.ReadOnly = true;
            // 
            // frmTheKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1467, 783);
            this.Controls.Add(this.dgvTheKho);
            this.Controls.Add(this.pnlKPI);
            this.Controls.Add(this.grpBoLoc);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTheKho";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Thẻ kho";
            this.Load += new System.EventHandler(this.frmTheKho_Load);
            this.grpBoLoc.ResumeLayout(false);
            this.tlpBoLoc.ResumeLayout(false);
            this.tlpBoLoc.PerformLayout();
            this.pnlKPI.ResumeLayout(false);
            this.tlpKPI.ResumeLayout(false);
            this.pnlKpiTonDau.ResumeLayout(false);
            this.pnlKpiTonDau.PerformLayout();
            this.pnlKpiTongNhap.ResumeLayout(false);
            this.pnlKpiTongNhap.PerformLayout();
            this.pnlKpiTongXuat.ResumeLayout(false);
            this.pnlKpiTongXuat.PerformLayout();
            this.pnlKpiTonCuoi.ResumeLayout(false);
            this.pnlKpiTonCuoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheKho)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
