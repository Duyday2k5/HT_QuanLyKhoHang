namespace LTWIN_N4_QLKH.GUI.Forms.Inventory
{
    partial class frmBaoCaoTonKho
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.TableLayoutPanel tlpBoLoc;
        private System.Windows.Forms.Label lblTuNgayTitle;
        private System.Windows.Forms.Label lblDenNgayTitle;
        private System.Windows.Forms.Label lblLoaiHangTitle;
        private System.Windows.Forms.Label lblTimKiemTitle;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.ComboBox cboLoaiHang;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnLocBaoCao;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Panel pnlThongKe;
        private System.Windows.Forms.TableLayoutPanel tlpThongKe;
        private System.Windows.Forms.Panel pnlKpiMaHang;
        private System.Windows.Forms.Panel pnlKpiNhap;
        private System.Windows.Forms.Panel pnlKpiXuat;
        private System.Windows.Forms.Panel pnlKpiGiaTri;
        private System.Windows.Forms.Label lblTieuDeTongMaHang;
        private System.Windows.Forms.Label lblTieuDeTongSLNhap;
        private System.Windows.Forms.Label lblTieuDeTongSLXuat;
        private System.Windows.Forms.Label lblTieuDeTongGiaTriTon;
        private System.Windows.Forms.Label lblTongMaHang;
        private System.Windows.Forms.Label lblTongSLNhap;
        private System.Windows.Forms.Label lblTongSLXuat;
        private System.Windows.Forms.Label lblTongGiaTriTon;
        private System.Windows.Forms.SplitContainer splitBaoCao;
        private System.Windows.Forms.Panel pnlTableToolbar;
        private System.Windows.Forms.Label lblTableTitle;
        private System.Windows.Forms.Button btnToanManHinhBang;
        private System.Windows.Forms.Button btnXemCaHaiBang;
        private System.Windows.Forms.DataGridView dgvBaoCaoTonKho;
        private System.Windows.Forms.Panel pnlChartToolbar;
        private System.Windows.Forms.Label lblChartHeader;
        private System.Windows.Forms.Button btnToanManHinhChart;
        private System.Windows.Forms.Button btnXemCaHaiChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopHangHoa;
        private System.Windows.Forms.DataVisualization.Charting.Series seriesSoLuongNhap;
        private System.Windows.Forms.DataVisualization.Charting.Series seriesSoLuongXuat;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.grpBoLoc = new System.Windows.Forms.GroupBox();
            this.tlpBoLoc = new System.Windows.Forms.TableLayoutPanel();
            this.lblTuNgayTitle = new System.Windows.Forms.Label();
            this.lblDenNgayTitle = new System.Windows.Forms.Label();
            this.lblLoaiHangTitle = new System.Windows.Forms.Label();
            this.lblTimKiemTitle = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.cboLoaiHang = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnLocBaoCao = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.pnlThongKe = new System.Windows.Forms.Panel();
            this.tlpThongKe = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpiMaHang = new System.Windows.Forms.Panel();
            this.lblTieuDeTongMaHang = new System.Windows.Forms.Label();
            this.lblTongMaHang = new System.Windows.Forms.Label();
            this.pnlKpiNhap = new System.Windows.Forms.Panel();
            this.lblTieuDeTongSLNhap = new System.Windows.Forms.Label();
            this.lblTongSLNhap = new System.Windows.Forms.Label();
            this.pnlKpiXuat = new System.Windows.Forms.Panel();
            this.lblTieuDeTongSLXuat = new System.Windows.Forms.Label();
            this.lblTongSLXuat = new System.Windows.Forms.Label();
            this.pnlKpiGiaTri = new System.Windows.Forms.Panel();
            this.lblTieuDeTongGiaTriTon = new System.Windows.Forms.Label();
            this.lblTongGiaTriTon = new System.Windows.Forms.Label();
            this.splitBaoCao = new System.Windows.Forms.SplitContainer();
            this.dgvBaoCaoTonKho = new System.Windows.Forms.DataGridView();
            this.pnlTableToolbar = new System.Windows.Forms.Panel();
            this.btnXemCaHaiBang = new System.Windows.Forms.Button();
            this.btnToanManHinhBang = new System.Windows.Forms.Button();
            this.lblTableTitle = new System.Windows.Forms.Label();
            this.chartTopHangHoa = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlChartToolbar = new System.Windows.Forms.Panel();
            this.btnXemCaHaiChart = new System.Windows.Forms.Button();
            this.btnToanManHinhChart = new System.Windows.Forms.Button();
            this.lblChartHeader = new System.Windows.Forms.Label();
            this.grpBoLoc.SuspendLayout();
            this.tlpBoLoc.SuspendLayout();
            this.pnlThongKe.SuspendLayout();
            this.tlpThongKe.SuspendLayout();
            this.pnlKpiMaHang.SuspendLayout();
            this.pnlKpiNhap.SuspendLayout();
            this.pnlKpiXuat.SuspendLayout();
            this.pnlKpiGiaTri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBaoCao)).BeginInit();
            this.splitBaoCao.Panel1.SuspendLayout();
            this.splitBaoCao.Panel2.SuspendLayout();
            this.splitBaoCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoTonKho)).BeginInit();
            this.pnlTableToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopHangHoa)).BeginInit();
            this.pnlChartToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Controls.Add(this.tlpBoLoc);
            this.grpBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoLoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoLoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpBoLoc.Location = new System.Drawing.Point(12, 12);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.grpBoLoc.Size = new System.Drawing.Size(1443, 84);
            this.grpBoLoc.TabIndex = 0;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Bộ lọc báo cáo";
            // 
            // tlpBoLoc
            // 
            this.tlpBoLoc.ColumnCount = 6;
            this.tlpBoLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpBoLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpBoLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpBoLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tlpBoLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpBoLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpBoLoc.Controls.Add(this.lblTuNgayTitle, 0, 0);
            this.tlpBoLoc.Controls.Add(this.lblDenNgayTitle, 1, 0);
            this.tlpBoLoc.Controls.Add(this.lblLoaiHangTitle, 2, 0);
            this.tlpBoLoc.Controls.Add(this.lblTimKiemTitle, 3, 0);
            this.tlpBoLoc.Controls.Add(this.dtpTuNgay, 0, 1);
            this.tlpBoLoc.Controls.Add(this.dtpDenNgay, 1, 1);
            this.tlpBoLoc.Controls.Add(this.cboLoaiHang, 2, 1);
            this.tlpBoLoc.Controls.Add(this.txtTimKiem, 3, 1);
            this.tlpBoLoc.Controls.Add(this.btnLocBaoCao, 4, 1);
            this.tlpBoLoc.Controls.Add(this.btnXuatExcel, 5, 1);
            this.tlpBoLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBoLoc.Location = new System.Drawing.Point(10, 27);
            this.tlpBoLoc.Name = "tlpBoLoc";
            this.tlpBoLoc.RowCount = 2;
            this.tlpBoLoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBoLoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBoLoc.Size = new System.Drawing.Size(1423, 53);
            this.tlpBoLoc.TabIndex = 0;
            // 
            // lblTuNgayTitle
            // 
            this.lblTuNgayTitle.AutoSize = true;
            this.lblTuNgayTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTuNgayTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgayTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTuNgayTitle.Name = "lblTuNgayTitle";
            this.lblTuNgayTitle.Size = new System.Drawing.Size(207, 20);
            this.lblTuNgayTitle.TabIndex = 0;
            this.lblTuNgayTitle.Text = "Từ ngày";
            this.lblTuNgayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDenNgayTitle
            // 
            this.lblDenNgayTitle.AutoSize = true;
            this.lblDenNgayTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDenNgayTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgayTitle.Location = new System.Drawing.Point(216, 0);
            this.lblDenNgayTitle.Name = "lblDenNgayTitle";
            this.lblDenNgayTitle.Size = new System.Drawing.Size(207, 20);
            this.lblDenNgayTitle.TabIndex = 1;
            this.lblDenNgayTitle.Text = "Đến ngày";
            this.lblDenNgayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLoaiHangTitle
            // 
            this.lblLoaiHangTitle.AutoSize = true;
            this.lblLoaiHangTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiHangTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiHangTitle.Location = new System.Drawing.Point(429, 0);
            this.lblLoaiHangTitle.Name = "lblLoaiHangTitle";
            this.lblLoaiHangTitle.Size = new System.Drawing.Size(250, 20);
            this.lblLoaiHangTitle.TabIndex = 2;
            this.lblLoaiHangTitle.Text = "Nhóm hàng";
            this.lblLoaiHangTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimKiemTitle
            // 
            this.lblTimKiemTitle.AutoSize = true;
            this.lblTimKiemTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimKiemTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiemTitle.Location = new System.Drawing.Point(685, 0);
            this.lblTimKiemTitle.Name = "lblTimKiemTitle";
            this.lblTimKiemTitle.Size = new System.Drawing.Size(307, 20);
            this.lblTimKiemTitle.TabIndex = 3;
            this.lblTimKiemTitle.Text = "Tìm mã hoặc tên sản phẩm";
            this.lblTimKiemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(3, 23);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(207, 30);
            this.dtpTuNgay.TabIndex = 4;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(216, 23);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(207, 30);
            this.dtpDenNgay.TabIndex = 5;
            // 
            // cboLoaiHang
            // 
            this.cboLoaiHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiHang.FormattingEnabled = true;
            this.cboLoaiHang.Location = new System.Drawing.Point(429, 23);
            this.cboLoaiHang.Name = "cboLoaiHang";
            this.cboLoaiHang.Size = new System.Drawing.Size(250, 31);
            this.cboLoaiHang.TabIndex = 6;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(685, 23);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(307, 30);
            this.txtTimKiem.TabIndex = 7;
            // 
            // btnLocBaoCao
            // 
            this.btnLocBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLocBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLocBaoCao.FlatAppearance.BorderSize = 0;
            this.btnLocBaoCao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnLocBaoCao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnLocBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnLocBaoCao.Location = new System.Drawing.Point(998, 23);
            this.btnLocBaoCao.Name = "btnLocBaoCao";
            this.btnLocBaoCao.Size = new System.Drawing.Size(207, 27);
            this.btnLocBaoCao.TabIndex = 8;
            this.btnLocBaoCao.Text = "TỔNG HỢP BÁO CÁO";
            this.btnLocBaoCao.UseVisualStyleBackColor = false;
            this.btnLocBaoCao.Click += new System.EventHandler(this.btnLocBaoCao_Click);
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
            this.btnXuatExcel.Location = new System.Drawing.Point(1211, 23);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(209, 27);
            this.btnXuatExcel.TabIndex = 9;
            this.btnXuatExcel.Text = "XUẤT EXCEL (.XLSX)";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // pnlThongKe
            // 
            this.pnlThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlThongKe.Controls.Add(this.tlpThongKe);
            this.pnlThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongKe.Location = new System.Drawing.Point(12, 96);
            this.pnlThongKe.Name = "pnlThongKe";
            this.pnlThongKe.Padding = new System.Windows.Forms.Padding(4);
            this.pnlThongKe.Size = new System.Drawing.Size(1443, 72);
            this.pnlThongKe.TabIndex = 1;
            // 
            // tlpThongKe
            // 
            this.tlpThongKe.ColumnCount = 4;
            this.tlpThongKe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongKe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongKe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongKe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongKe.Controls.Add(this.pnlKpiMaHang, 0, 0);
            this.tlpThongKe.Controls.Add(this.pnlKpiNhap, 1, 0);
            this.tlpThongKe.Controls.Add(this.pnlKpiXuat, 2, 0);
            this.tlpThongKe.Controls.Add(this.pnlKpiGiaTri, 3, 0);
            this.tlpThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongKe.Location = new System.Drawing.Point(4, 4);
            this.tlpThongKe.Name = "tlpThongKe";
            this.tlpThongKe.RowCount = 1;
            this.tlpThongKe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpThongKe.Size = new System.Drawing.Size(1435, 64);
            this.tlpThongKe.TabIndex = 0;
            // 
            // pnlKpiMaHang
            // 
            this.pnlKpiMaHang.BackColor = System.Drawing.Color.White;
            this.pnlKpiMaHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiMaHang.Controls.Add(this.lblTieuDeTongMaHang);
            this.pnlKpiMaHang.Controls.Add(this.lblTongMaHang);
            this.pnlKpiMaHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiMaHang.Location = new System.Drawing.Point(3, 0);
            this.pnlKpiMaHang.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.pnlKpiMaHang.Name = "pnlKpiMaHang";
            this.pnlKpiMaHang.Size = new System.Drawing.Size(349, 64);
            this.pnlKpiMaHang.TabIndex = 0;
            // 
            // lblTieuDeTongMaHang
            // 
            this.lblTieuDeTongMaHang.AutoSize = true;
            this.lblTieuDeTongMaHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTongMaHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongMaHang.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongMaHang.Name = "lblTieuDeTongMaHang";
            this.lblTieuDeTongMaHang.Size = new System.Drawing.Size(177, 23);
            this.lblTieuDeTongMaHang.TabIndex = 0;
            this.lblTieuDeTongMaHang.Text = "TỔNG SỐ MẶT HÀNG";
            // 
            // lblTongMaHang
            // 
            this.lblTongMaHang.AutoSize = true;
            this.lblTongMaHang.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongMaHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTongMaHang.Location = new System.Drawing.Point(12, 35);
            this.lblTongMaHang.Name = "lblTongMaHang";
            this.lblTongMaHang.Size = new System.Drawing.Size(28, 32);
            this.lblTongMaHang.TabIndex = 1;
            this.lblTongMaHang.Text = "0";
            // 
            // pnlKpiNhap
            // 
            this.pnlKpiNhap.BackColor = System.Drawing.Color.White;
            this.pnlKpiNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiNhap.Controls.Add(this.lblTieuDeTongSLNhap);
            this.pnlKpiNhap.Controls.Add(this.lblTongSLNhap);
            this.pnlKpiNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiNhap.Location = new System.Drawing.Point(361, 0);
            this.pnlKpiNhap.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.pnlKpiNhap.Name = "pnlKpiNhap";
            this.pnlKpiNhap.Size = new System.Drawing.Size(349, 64);
            this.pnlKpiNhap.TabIndex = 1;
            // 
            // lblTieuDeTongSLNhap
            // 
            this.lblTieuDeTongSLNhap.AutoSize = true;
            this.lblTieuDeTongSLNhap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTongSLNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongSLNhap.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongSLNhap.Name = "lblTieuDeTongSLNhap";
            this.lblTieuDeTongSLNhap.Size = new System.Drawing.Size(171, 23);
            this.lblTieuDeTongSLNhap.TabIndex = 0;
            this.lblTieuDeTongSLNhap.Text = "TỔNG LƯỢNG NHẬP";
            // 
            // lblTongSLNhap
            // 
            this.lblTongSLNhap.AutoSize = true;
            this.lblTongSLNhap.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSLNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.lblTongSLNhap.Location = new System.Drawing.Point(12, 35);
            this.lblTongSLNhap.Name = "lblTongSLNhap";
            this.lblTongSLNhap.Size = new System.Drawing.Size(28, 32);
            this.lblTongSLNhap.TabIndex = 1;
            this.lblTongSLNhap.Text = "0";
            // 
            // pnlKpiXuat
            // 
            this.pnlKpiXuat.BackColor = System.Drawing.Color.White;
            this.pnlKpiXuat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiXuat.Controls.Add(this.lblTieuDeTongSLXuat);
            this.pnlKpiXuat.Controls.Add(this.lblTongSLXuat);
            this.pnlKpiXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiXuat.Location = new System.Drawing.Point(719, 0);
            this.pnlKpiXuat.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.pnlKpiXuat.Name = "pnlKpiXuat";
            this.pnlKpiXuat.Size = new System.Drawing.Size(349, 64);
            this.pnlKpiXuat.TabIndex = 2;
            // 
            // lblTieuDeTongSLXuat
            // 
            this.lblTieuDeTongSLXuat.AutoSize = true;
            this.lblTieuDeTongSLXuat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTongSLXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongSLXuat.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongSLXuat.Name = "lblTieuDeTongSLXuat";
            this.lblTieuDeTongSLXuat.Size = new System.Drawing.Size(167, 23);
            this.lblTieuDeTongSLXuat.TabIndex = 0;
            this.lblTieuDeTongSLXuat.Text = "TỔNG LƯỢNG XUẤT";
            // 
            // lblTongSLXuat
            // 
            this.lblTongSLXuat.AutoSize = true;
            this.lblTongSLXuat.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSLXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTongSLXuat.Location = new System.Drawing.Point(12, 35);
            this.lblTongSLXuat.Name = "lblTongSLXuat";
            this.lblTongSLXuat.Size = new System.Drawing.Size(28, 32);
            this.lblTongSLXuat.TabIndex = 1;
            this.lblTongSLXuat.Text = "0";
            // 
            // pnlKpiGiaTri
            // 
            this.pnlKpiGiaTri.BackColor = System.Drawing.Color.White;
            this.pnlKpiGiaTri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiGiaTri.Controls.Add(this.lblTieuDeTongGiaTriTon);
            this.pnlKpiGiaTri.Controls.Add(this.lblTongGiaTriTon);
            this.pnlKpiGiaTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiGiaTri.Location = new System.Drawing.Point(1077, 0);
            this.pnlKpiGiaTri.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlKpiGiaTri.Name = "pnlKpiGiaTri";
            this.pnlKpiGiaTri.Size = new System.Drawing.Size(358, 64);
            this.pnlKpiGiaTri.TabIndex = 3;
            // 
            // lblTieuDeTongGiaTriTon
            // 
            this.lblTieuDeTongGiaTriTon.AutoSize = true;
            this.lblTieuDeTongGiaTriTon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTongGiaTriTon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongGiaTriTon.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongGiaTriTon.Name = "lblTieuDeTongGiaTriTon";
            this.lblTieuDeTongGiaTriTon.Size = new System.Drawing.Size(205, 23);
            this.lblTieuDeTongGiaTriTon.TabIndex = 0;
            this.lblTieuDeTongGiaTriTon.Text = "TỔNG GIÁ TRỊ TỒN CUỐI";
            // 
            // lblTongGiaTriTon
            // 
            this.lblTongGiaTriTon.AutoSize = true;
            this.lblTongGiaTriTon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongGiaTriTon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTongGiaTriTon.Location = new System.Drawing.Point(12, 35);
            this.lblTongGiaTriTon.Name = "lblTongGiaTriTon";
            this.lblTongGiaTriTon.Size = new System.Drawing.Size(28, 32);
            this.lblTongGiaTriTon.TabIndex = 1;
            this.lblTongGiaTriTon.Text = "0";
            // 
            // splitBaoCao
            // 
            this.splitBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBaoCao.Location = new System.Drawing.Point(12, 168);
            this.splitBaoCao.Name = "splitBaoCao";
            // 
            // splitBaoCao.Panel1
            // 
            this.splitBaoCao.Panel1.Controls.Add(this.dgvBaoCaoTonKho);
            this.splitBaoCao.Panel1.Controls.Add(this.pnlTableToolbar);
            this.splitBaoCao.Panel1MinSize = 380;
            // 
            // splitBaoCao.Panel2
            // 
            this.splitBaoCao.Panel2.Controls.Add(this.chartTopHangHoa);
            this.splitBaoCao.Panel2.Controls.Add(this.pnlChartToolbar);
            this.splitBaoCao.Panel2MinSize = 280;
            this.splitBaoCao.Size = new System.Drawing.Size(1443, 641);
            this.splitBaoCao.SplitterDistance = 840;
            this.splitBaoCao.SplitterWidth = 6;
            this.splitBaoCao.TabIndex = 2;
            // 
            // dgvBaoCaoTonKho
            // 
            this.dgvBaoCaoTonKho.AllowUserToAddRows = false;
            this.dgvBaoCaoTonKho.AllowUserToDeleteRows = false;
            this.dgvBaoCaoTonKho.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvBaoCaoTonKho.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBaoCaoTonKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCaoTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvBaoCaoTonKho.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBaoCaoTonKho.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBaoCaoTonKho.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBaoCaoTonKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBaoCaoTonKho.ColumnHeadersHeight = 40;
            this.dgvBaoCaoTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBaoCaoTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCaoTonKho.EnableHeadersVisualStyles = false;
            this.dgvBaoCaoTonKho.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvBaoCaoTonKho.Location = new System.Drawing.Point(0, 32);
            this.dgvBaoCaoTonKho.MultiSelect = false;
            this.dgvBaoCaoTonKho.Name = "dgvBaoCaoTonKho";
            this.dgvBaoCaoTonKho.ReadOnly = true;
            this.dgvBaoCaoTonKho.RowHeadersVisible = false;
            this.dgvBaoCaoTonKho.RowHeadersWidth = 51;
            this.dgvBaoCaoTonKho.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBaoCaoTonKho.RowTemplate.Height = 34;
            this.dgvBaoCaoTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCaoTonKho.Size = new System.Drawing.Size(840, 609);
            this.dgvBaoCaoTonKho.TabIndex = 0;
            this.dgvBaoCaoTonKho.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaoCaoTonKho_CellContentClick);
            this.dgvBaoCaoTonKho.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBaoCaoTonKho_CellFormatting);
            // 
            // pnlTableToolbar
            // 
            this.pnlTableToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlTableToolbar.Controls.Add(this.btnXemCaHaiBang);
            this.pnlTableToolbar.Controls.Add(this.btnToanManHinhBang);
            this.pnlTableToolbar.Controls.Add(this.lblTableTitle);
            this.pnlTableToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTableToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlTableToolbar.Name = "pnlTableToolbar";
            this.pnlTableToolbar.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.pnlTableToolbar.Size = new System.Drawing.Size(840, 32);
            this.pnlTableToolbar.TabIndex = 1;
            // 
            // btnXemCaHaiBang
            // 
            this.btnXemCaHaiBang.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXemCaHaiBang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemCaHaiBang.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXemCaHaiBang.Location = new System.Drawing.Point(634, 3);
            this.btnXemCaHaiBang.Name = "btnXemCaHaiBang";
            this.btnXemCaHaiBang.Size = new System.Drawing.Size(80, 26);
            this.btnXemCaHaiBang.TabIndex = 2;
            this.btnXemCaHaiBang.Text = "⊞ Cả hai";
            this.btnXemCaHaiBang.UseVisualStyleBackColor = true;
            this.btnXemCaHaiBang.Click += new System.EventHandler(this.btnXemCaHai_Click);
            // 
            // btnToanManHinhBang
            // 
            this.btnToanManHinhBang.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnToanManHinhBang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToanManHinhBang.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnToanManHinhBang.Location = new System.Drawing.Point(714, 3);
            this.btnToanManHinhBang.Name = "btnToanManHinhBang";
            this.btnToanManHinhBang.Size = new System.Drawing.Size(120, 26);
            this.btnToanManHinhBang.TabIndex = 1;
            this.btnToanManHinhBang.Text = "⛶ Mở rộng bảng";
            this.btnToanManHinhBang.UseVisualStyleBackColor = true;
            this.btnToanManHinhBang.Click += new System.EventHandler(this.btnToanManHinhBang_Click);
            // 
            // lblTableTitle
            // 
            this.lblTableTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTableTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTableTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTableTitle.Location = new System.Drawing.Point(6, 3);
            this.lblTableTitle.Name = "lblTableTitle";
            this.lblTableTitle.Size = new System.Drawing.Size(260, 26);
            this.lblTableTitle.TabIndex = 0;
            this.lblTableTitle.Text = "📋 Dữ liệu chi tiết xuất - nhập - tồn";
            this.lblTableTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chartTopHangHoa
            // 
            this.chartTopHangHoa.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chartTopHangHoa.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelStyle.Angle = -45;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.Format = "N0";
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "chartAreaTop";
            this.chartTopHangHoa.ChartAreas.Add(chartArea1);
            this.chartTopHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "chartLegend";
            this.chartTopHangHoa.Legends.Add(legend1);
            this.chartTopHangHoa.Location = new System.Drawing.Point(0, 32);
            this.chartTopHangHoa.Name = "chartTopHangHoa";
            series1.ChartArea = "chartAreaTop";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "N0";
            series1.Legend = "chartLegend";
            series1.Name = "Số lượng Nhập";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.ChartArea = "chartAreaTop";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            series2.IsValueShownAsLabel = true;
            series2.LabelFormat = "N0";
            series2.Legend = "chartLegend";
            series2.Name = "Số lượng Xuất";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartTopHangHoa.Series.Add(series1);
            this.chartTopHangHoa.Series.Add(series2);
            this.chartTopHangHoa.Size = new System.Drawing.Size(597, 609);
            this.chartTopHangHoa.TabIndex = 0;
            this.chartTopHangHoa.Text = "Top sản phẩm nhập xuất";
            title1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "chartTitle";
            title1.Text = "TOP 10 MẶT HÀNG LUÂN CHUYỂN CAO NHẤT";
            this.chartTopHangHoa.Titles.Add(title1);
            // 
            // pnlChartToolbar
            // 
            this.pnlChartToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlChartToolbar.Controls.Add(this.btnXemCaHaiChart);
            this.pnlChartToolbar.Controls.Add(this.btnToanManHinhChart);
            this.pnlChartToolbar.Controls.Add(this.lblChartHeader);
            this.pnlChartToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChartToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlChartToolbar.Name = "pnlChartToolbar";
            this.pnlChartToolbar.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.pnlChartToolbar.Size = new System.Drawing.Size(597, 32);
            this.pnlChartToolbar.TabIndex = 1;
            // 
            // btnXemCaHaiChart
            // 
            this.btnXemCaHaiChart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXemCaHaiChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemCaHaiChart.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXemCaHaiChart.Location = new System.Drawing.Point(391, 3);
            this.btnXemCaHaiChart.Name = "btnXemCaHaiChart";
            this.btnXemCaHaiChart.Size = new System.Drawing.Size(80, 26);
            this.btnXemCaHaiChart.TabIndex = 2;
            this.btnXemCaHaiChart.Text = "⊞ Cả hai";
            this.btnXemCaHaiChart.UseVisualStyleBackColor = true;
            this.btnXemCaHaiChart.Click += new System.EventHandler(this.btnXemCaHai_Click);
            // 
            // btnToanManHinhChart
            // 
            this.btnToanManHinhChart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnToanManHinhChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToanManHinhChart.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnToanManHinhChart.Location = new System.Drawing.Point(471, 3);
            this.btnToanManHinhChart.Name = "btnToanManHinhChart";
            this.btnToanManHinhChart.Size = new System.Drawing.Size(120, 26);
            this.btnToanManHinhChart.TabIndex = 1;
            this.btnToanManHinhChart.Text = "⛶ Mở rộng sơ đồ";
            this.btnToanManHinhChart.UseVisualStyleBackColor = true;
            this.btnToanManHinhChart.Click += new System.EventHandler(this.btnToanManHinhChart_Click);
            // 
            // lblChartHeader
            // 
            this.lblChartHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblChartHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChartHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblChartHeader.Location = new System.Drawing.Point(6, 3);
            this.lblChartHeader.Name = "lblChartHeader";
            this.lblChartHeader.Size = new System.Drawing.Size(260, 26);
            this.lblChartHeader.TabIndex = 0;
            this.lblChartHeader.Text = "📊 Sơ đồ luân chuyển mặt hàng";
            this.lblChartHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBaoCaoTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1467, 821);
            this.Controls.Add(this.splitBaoCao);
            this.Controls.Add(this.pnlThongKe);
            this.Controls.Add(this.grpBoLoc);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "frmBaoCaoTonKho";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Báo cáo tồn kho";
            this.Load += new System.EventHandler(this.frmBaoCaoTonKho_Load);
            this.Resize += new System.EventHandler(this.frmBaoCaoTonKho_Resize);
            this.grpBoLoc.ResumeLayout(false);
            this.tlpBoLoc.ResumeLayout(false);
            this.tlpBoLoc.PerformLayout();
            this.pnlThongKe.ResumeLayout(false);
            this.tlpThongKe.ResumeLayout(false);
            this.pnlKpiMaHang.ResumeLayout(false);
            this.pnlKpiMaHang.PerformLayout();
            this.pnlKpiNhap.ResumeLayout(false);
            this.pnlKpiNhap.PerformLayout();
            this.pnlKpiXuat.ResumeLayout(false);
            this.pnlKpiXuat.PerformLayout();
            this.pnlKpiGiaTri.ResumeLayout(false);
            this.pnlKpiGiaTri.PerformLayout();
            this.splitBaoCao.Panel1.ResumeLayout(false);
            this.splitBaoCao.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBaoCao)).EndInit();
            this.splitBaoCao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoTonKho)).EndInit();
            this.pnlTableToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTopHangHoa)).EndInit();
            this.pnlChartToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
