namespace LTWIN_N4_QLKH.GUI.Forms.Inventory
{
    partial class frmBaoCaoTonKho
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabBaoCao;
        private System.Windows.Forms.TabPage tabTonKho;
        private System.Windows.Forms.TabPage tabDoanhThu;

        // --- Controls Tab Tồn Kho ---
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
        private System.Windows.Forms.Label lblTieuDeTongMaHang;
        private System.Windows.Forms.Label lblTongMaHang;
        private System.Windows.Forms.Panel pnlKpiNhap;
        private System.Windows.Forms.Label lblTieuDeTongSLNhap;
        private System.Windows.Forms.Label lblTongSLNhap;
        private System.Windows.Forms.Panel pnlKpiXuat;
        private System.Windows.Forms.Label lblTieuDeTongSLXuat;
        private System.Windows.Forms.Label lblTongSLXuat;
        private System.Windows.Forms.Panel pnlKpiGiaTri;
        private System.Windows.Forms.Label lblTieuDeTongGiaTriTon;
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

        // --- Controls Tab Doanh Thu ---
        private System.Windows.Forms.GroupBox grpBoLocDT;
        private System.Windows.Forms.Label lblCheDoDT;
        private System.Windows.Forms.ComboBox cboCheDoDT;
        private System.Windows.Forms.Label lblTuNgayDT;
        private System.Windows.Forms.DateTimePicker dtpTuNgayDT;
        private System.Windows.Forms.Label lblDenNgayDT;
        private System.Windows.Forms.DateTimePicker dtpDenNgayDT;
        private System.Windows.Forms.Label lblThangDT;
        private System.Windows.Forms.ComboBox cboThangDT;
        private System.Windows.Forms.Label lblNamDT;
        private System.Windows.Forms.NumericUpDown numNamDT;
        private System.Windows.Forms.Label lblTimKiemDT;
        private System.Windows.Forms.TextBox txtTimKiemDT;
        private System.Windows.Forms.Button btnLocDT;
        private System.Windows.Forms.Button btnXuatExcelDT;

        private System.Windows.Forms.Panel pnlThongKeDT;
        private System.Windows.Forms.TableLayoutPanel tlpThongKeDT;
        private System.Windows.Forms.Panel pnlKpiDoanhThu;
        private System.Windows.Forms.Label lblTieuDeTongDoanhThu;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Panel pnlKpiSoPhieu;
        private System.Windows.Forms.Label lblTieuDeTongSoPhieu;
        private System.Windows.Forms.Label lblTongSoPhieu;
        private System.Windows.Forms.Panel pnlKpiSoLuongXuat;
        private System.Windows.Forms.Label lblTieuDeTongSLXuatDT;
        private System.Windows.Forms.Label lblTongSLXuatDT;
        private System.Windows.Forms.Panel pnlKpiDoanhThuTB;
        private System.Windows.Forms.Label lblTieuDeDoanhThuTB;
        private System.Windows.Forms.Label lblDoanhThuTB;

        private System.Windows.Forms.SplitContainer splitDoanhThu;
        private System.Windows.Forms.Panel pnlTableDTToolbar;
        private System.Windows.Forms.Label lblTableDTTit;
        private System.Windows.Forms.ComboBox cboKieuXemDT;
        private System.Windows.Forms.Button btnXemChiTietPhieu;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Panel pnlChartDTToolbar;
        private System.Windows.Forms.Label lblChartDTHeader;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tabBaoCao = new System.Windows.Forms.TabControl();
            this.tabTonKho = new System.Windows.Forms.TabPage();
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
            this.pnlThongKe = new System.Windows.Forms.Panel();
            this.tlpThongKe = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpiMaHang = new System.Windows.Forms.Panel();
            this.lblTongMaHang = new System.Windows.Forms.Label();
            this.lblTieuDeTongMaHang = new System.Windows.Forms.Label();
            this.pnlKpiNhap = new System.Windows.Forms.Panel();
            this.lblTongSLNhap = new System.Windows.Forms.Label();
            this.lblTieuDeTongSLNhap = new System.Windows.Forms.Label();
            this.pnlKpiXuat = new System.Windows.Forms.Panel();
            this.lblTongSLXuat = new System.Windows.Forms.Label();
            this.lblTieuDeTongSLXuat = new System.Windows.Forms.Label();
            this.pnlKpiGiaTri = new System.Windows.Forms.Panel();
            this.lblTongGiaTriTon = new System.Windows.Forms.Label();
            this.lblTieuDeTongGiaTriTon = new System.Windows.Forms.Label();
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
            this.tabDoanhThu = new System.Windows.Forms.TabPage();
            this.splitDoanhThu = new System.Windows.Forms.SplitContainer();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.pnlTableDTToolbar = new System.Windows.Forms.Panel();
            this.btnXemChiTietPhieu = new System.Windows.Forms.Button();
            this.cboKieuXemDT = new System.Windows.Forms.ComboBox();
            this.lblTableDTTit = new System.Windows.Forms.Label();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlChartDTToolbar = new System.Windows.Forms.Panel();
            this.lblChartDTHeader = new System.Windows.Forms.Label();
            this.pnlThongKeDT = new System.Windows.Forms.Panel();
            this.tlpThongKeDT = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpiDoanhThu = new System.Windows.Forms.Panel();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblTieuDeTongDoanhThu = new System.Windows.Forms.Label();
            this.pnlKpiSoPhieu = new System.Windows.Forms.Panel();
            this.lblTongSoPhieu = new System.Windows.Forms.Label();
            this.lblTieuDeTongSoPhieu = new System.Windows.Forms.Label();
            this.pnlKpiSoLuongXuat = new System.Windows.Forms.Panel();
            this.lblTongSLXuatDT = new System.Windows.Forms.Label();
            this.lblTieuDeTongSLXuatDT = new System.Windows.Forms.Label();
            this.pnlKpiDoanhThuTB = new System.Windows.Forms.Panel();
            this.lblDoanhThuTB = new System.Windows.Forms.Label();
            this.lblTieuDeDoanhThuTB = new System.Windows.Forms.Label();
            this.grpBoLocDT = new System.Windows.Forms.GroupBox();
            this.btnXuatExcelDT = new System.Windows.Forms.Button();
            this.btnLocDT = new System.Windows.Forms.Button();
            this.txtTimKiemDT = new System.Windows.Forms.TextBox();
            this.lblTimKiemDT = new System.Windows.Forms.Label();
            this.numNamDT = new System.Windows.Forms.NumericUpDown();
            this.lblNamDT = new System.Windows.Forms.Label();
            this.cboThangDT = new System.Windows.Forms.ComboBox();
            this.lblThangDT = new System.Windows.Forms.Label();
            this.dtpDenNgayDT = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgayDT = new System.Windows.Forms.Label();
            this.dtpTuNgayDT = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgayDT = new System.Windows.Forms.Label();
            this.cboCheDoDT = new System.Windows.Forms.ComboBox();
            this.lblCheDoDT = new System.Windows.Forms.Label();
            this.tabBaoCao.SuspendLayout();
            this.tabTonKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBaoCao)).BeginInit();
            this.splitBaoCao.Panel1.SuspendLayout();
            this.splitBaoCao.Panel2.SuspendLayout();
            this.splitBaoCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoTonKho)).BeginInit();
            this.pnlTableToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopHangHoa)).BeginInit();
            this.pnlChartToolbar.SuspendLayout();
            this.pnlThongKe.SuspendLayout();
            this.tlpThongKe.SuspendLayout();
            this.pnlKpiMaHang.SuspendLayout();
            this.pnlKpiNhap.SuspendLayout();
            this.pnlKpiXuat.SuspendLayout();
            this.pnlKpiGiaTri.SuspendLayout();
            this.grpBoLoc.SuspendLayout();
            this.tlpBoLoc.SuspendLayout();
            this.tabDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDoanhThu)).BeginInit();
            this.splitDoanhThu.Panel1.SuspendLayout();
            this.splitDoanhThu.Panel2.SuspendLayout();
            this.splitDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.pnlTableDTToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.pnlChartDTToolbar.SuspendLayout();
            this.pnlThongKeDT.SuspendLayout();
            this.tlpThongKeDT.SuspendLayout();
            this.pnlKpiDoanhThu.SuspendLayout();
            this.pnlKpiSoPhieu.SuspendLayout();
            this.pnlKpiSoLuongXuat.SuspendLayout();
            this.pnlKpiDoanhThuTB.SuspendLayout();
            this.grpBoLocDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamDT)).BeginInit();
            this.SuspendLayout();
            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Controls.Add(this.tabTonKho);
            this.tabBaoCao.Controls.Add(this.tabDoanhThu);
            this.tabBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabBaoCao.Location = new System.Drawing.Point(6, 6);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.Padding = new System.Drawing.Point(16, 8);
            this.tabBaoCao.SelectedIndex = 0;
            this.tabBaoCao.Size = new System.Drawing.Size(1455, 809);
            this.tabBaoCao.TabIndex = 0;
            // 
            // tabTonKho
            // 
            this.tabTonKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tabTonKho.Controls.Add(this.splitBaoCao);
            this.tabTonKho.Controls.Add(this.pnlThongKe);
            this.tabTonKho.Controls.Add(this.grpBoLoc);
            this.tabTonKho.Location = new System.Drawing.Point(4, 42);
            this.tabTonKho.Name = "tabTonKho";
            this.tabTonKho.Padding = new System.Windows.Forms.Padding(6);
            this.tabTonKho.Size = new System.Drawing.Size(1447, 763);
            this.tabTonKho.TabIndex = 0;
            this.tabTonKho.Text = "📦 BÁO CÁO NHẬP - XUẤT - TỒN";
            // 
            // splitBaoCao
            // 
            this.splitBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBaoCao.Location = new System.Drawing.Point(6, 185);
            this.splitBaoCao.Name = "splitBaoCao";
            // 
            // splitBaoCao.Panel1
            // 
            this.splitBaoCao.Panel1.Controls.Add(this.dgvBaoCaoTonKho);
            this.splitBaoCao.Panel1.Controls.Add(this.pnlTableToolbar);
            // 
            // splitBaoCao.Panel2
            // 
            this.splitBaoCao.Panel2.Controls.Add(this.chartTopHangHoa);
            this.splitBaoCao.Panel2.Controls.Add(this.pnlChartToolbar);
            this.splitBaoCao.Size = new System.Drawing.Size(1435, 572);
            this.splitBaoCao.SplitterDistance = 831;
            this.splitBaoCao.TabIndex = 2;
            // 
            // dgvBaoCaoTonKho
            // 
            this.dgvBaoCaoTonKho.AllowUserToAddRows = false;
            this.dgvBaoCaoTonKho.AllowUserToDeleteRows = false;
            this.dgvBaoCaoTonKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCaoTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvBaoCaoTonKho.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(44)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvBaoCaoTonKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBaoCaoTonKho.ColumnHeadersHeight = 36;
            this.dgvBaoCaoTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCaoTonKho.Location = new System.Drawing.Point(0, 32);
            this.dgvBaoCaoTonKho.Name = "dgvBaoCaoTonKho";
            this.dgvBaoCaoTonKho.ReadOnly = true;
            this.dgvBaoCaoTonKho.RowHeadersVisible = false;
            this.dgvBaoCaoTonKho.RowHeadersWidth = 51;
            this.dgvBaoCaoTonKho.RowTemplate.Height = 28;
            this.dgvBaoCaoTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCaoTonKho.Size = new System.Drawing.Size(831, 540);
            this.dgvBaoCaoTonKho.TabIndex = 0;
            this.dgvBaoCaoTonKho.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaoCaoTonKho_CellContentClick_1);
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
            this.pnlTableToolbar.Size = new System.Drawing.Size(831, 32);
            this.pnlTableToolbar.TabIndex = 1;
            // 
            // btnXemCaHaiBang
            // 
            this.btnXemCaHaiBang.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXemCaHaiBang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemCaHaiBang.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXemCaHaiBang.Location = new System.Drawing.Point(631, 3);
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
            this.btnToanManHinhBang.Location = new System.Drawing.Point(711, 3);
            this.btnToanManHinhBang.Name = "btnToanManHinhBang";
            this.btnToanManHinhBang.Size = new System.Drawing.Size(114, 26);
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
            this.lblTableTitle.Size = new System.Drawing.Size(320, 26);
            this.lblTableTitle.TabIndex = 0;
            this.lblTableTitle.Text = "📋 Bảng dữ liệu chi tiết xuất - nhập - tồn";
            this.lblTableTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chartTopHangHoa
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            chartArea1.Name = "chartAreaTop";
            this.chartTopHangHoa.ChartAreas.Add(chartArea1);
            this.chartTopHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "chartLegend";
            this.chartTopHangHoa.Legends.Add(legend1);
            this.chartTopHangHoa.Location = new System.Drawing.Point(0, 32);
            this.chartTopHangHoa.Name = "chartTopHangHoa";
            series1.ChartArea = "chartAreaTop";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.LabelFormat = "N0";
            series1.Legend = "chartLegend";
            series1.Name = "Số lượng Nhập";
            series2.ChartArea = "chartAreaTop";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            series2.IsValueShownAsLabel = true;
            series2.IsXValueIndexed = true;
            series2.LabelFormat = "N0";
            series2.Legend = "chartLegend";
            series2.Name = "Số lượng Xuất";
            this.chartTopHangHoa.Series.Add(series1);
            this.chartTopHangHoa.Series.Add(series2);
            this.chartTopHangHoa.Size = new System.Drawing.Size(600, 540);
            this.chartTopHangHoa.TabIndex = 0;
            title1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
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
            this.pnlChartToolbar.Size = new System.Drawing.Size(600, 32);
            this.pnlChartToolbar.TabIndex = 1;
            // 
            // btnXemCaHaiChart
            // 
            this.btnXemCaHaiChart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXemCaHaiChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemCaHaiChart.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXemCaHaiChart.Location = new System.Drawing.Point(400, 3);
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
            this.btnToanManHinhChart.Location = new System.Drawing.Point(480, 3);
            this.btnToanManHinhChart.Name = "btnToanManHinhChart";
            this.btnToanManHinhChart.Size = new System.Drawing.Size(114, 26);
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
            // pnlThongKe
            // 
            this.pnlThongKe.Controls.Add(this.tlpThongKe);
            this.pnlThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongKe.Location = new System.Drawing.Point(6, 90);
            this.pnlThongKe.Name = "pnlThongKe";
            this.pnlThongKe.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlThongKe.Size = new System.Drawing.Size(1435, 95);
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
            this.tlpThongKe.Location = new System.Drawing.Point(0, 8);
            this.tlpThongKe.Name = "tlpThongKe";
            this.tlpThongKe.RowCount = 1;
            this.tlpThongKe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpThongKe.Size = new System.Drawing.Size(1435, 79);
            this.tlpThongKe.TabIndex = 0;
            // 
            // pnlKpiMaHang
            // 
            this.pnlKpiMaHang.BackColor = System.Drawing.Color.White;
            this.pnlKpiMaHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiMaHang.Controls.Add(this.lblTongMaHang);
            this.pnlKpiMaHang.Controls.Add(this.lblTieuDeTongMaHang);
            this.pnlKpiMaHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiMaHang.Location = new System.Drawing.Point(3, 3);
            this.pnlKpiMaHang.Name = "pnlKpiMaHang";
            this.pnlKpiMaHang.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlKpiMaHang.Size = new System.Drawing.Size(352, 73);
            this.pnlKpiMaHang.TabIndex = 0;
            // 
            // lblTongMaHang
            // 
            this.lblTongMaHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongMaHang.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongMaHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTongMaHang.Location = new System.Drawing.Point(12, 28);
            this.lblTongMaHang.Name = "lblTongMaHang";
            this.lblTongMaHang.Size = new System.Drawing.Size(326, 35);
            this.lblTongMaHang.TabIndex = 0;
            this.lblTongMaHang.Text = "0";
            this.lblTongMaHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTieuDeTongMaHang
            // 
            this.lblTieuDeTongMaHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeTongMaHang.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTongMaHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongMaHang.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongMaHang.Name = "lblTieuDeTongMaHang";
            this.lblTieuDeTongMaHang.Size = new System.Drawing.Size(326, 20);
            this.lblTieuDeTongMaHang.TabIndex = 1;
            this.lblTieuDeTongMaHang.Text = "TỔNG SỐ MẶT HÀNG";
            // 
            // pnlKpiNhap
            // 
            this.pnlKpiNhap.BackColor = System.Drawing.Color.White;
            this.pnlKpiNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiNhap.Controls.Add(this.lblTongSLNhap);
            this.pnlKpiNhap.Controls.Add(this.lblTieuDeTongSLNhap);
            this.pnlKpiNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiNhap.Location = new System.Drawing.Point(361, 3);
            this.pnlKpiNhap.Name = "pnlKpiNhap";
            this.pnlKpiNhap.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlKpiNhap.Size = new System.Drawing.Size(352, 73);
            this.pnlKpiNhap.TabIndex = 1;
            // 
            // lblTongSLNhap
            // 
            this.lblTongSLNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongSLNhap.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongSLNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.lblTongSLNhap.Location = new System.Drawing.Point(12, 28);
            this.lblTongSLNhap.Name = "lblTongSLNhap";
            this.lblTongSLNhap.Size = new System.Drawing.Size(326, 35);
            this.lblTongSLNhap.TabIndex = 0;
            this.lblTongSLNhap.Text = "0";
            this.lblTongSLNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTieuDeTongSLNhap
            // 
            this.lblTieuDeTongSLNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeTongSLNhap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTongSLNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongSLNhap.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongSLNhap.Name = "lblTieuDeTongSLNhap";
            this.lblTieuDeTongSLNhap.Size = new System.Drawing.Size(326, 20);
            this.lblTieuDeTongSLNhap.TabIndex = 1;
            this.lblTieuDeTongSLNhap.Text = "TỔNG SỐ LƯỢNG NHẬP";
            // 
            // pnlKpiXuat
            // 
            this.pnlKpiXuat.BackColor = System.Drawing.Color.White;
            this.pnlKpiXuat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiXuat.Controls.Add(this.lblTongSLXuat);
            this.pnlKpiXuat.Controls.Add(this.lblTieuDeTongSLXuat);
            this.pnlKpiXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiXuat.Location = new System.Drawing.Point(719, 3);
            this.pnlKpiXuat.Name = "pnlKpiXuat";
            this.pnlKpiXuat.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlKpiXuat.Size = new System.Drawing.Size(352, 73);
            this.pnlKpiXuat.TabIndex = 2;
            // 
            // lblTongSLXuat
            // 
            this.lblTongSLXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongSLXuat.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongSLXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTongSLXuat.Location = new System.Drawing.Point(12, 28);
            this.lblTongSLXuat.Name = "lblTongSLXuat";
            this.lblTongSLXuat.Size = new System.Drawing.Size(326, 35);
            this.lblTongSLXuat.TabIndex = 0;
            this.lblTongSLXuat.Text = "0";
            this.lblTongSLXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTieuDeTongSLXuat
            // 
            this.lblTieuDeTongSLXuat.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeTongSLXuat.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTongSLXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongSLXuat.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongSLXuat.Name = "lblTieuDeTongSLXuat";
            this.lblTieuDeTongSLXuat.Size = new System.Drawing.Size(326, 20);
            this.lblTieuDeTongSLXuat.TabIndex = 1;
            this.lblTieuDeTongSLXuat.Text = "TỔNG SỐ LƯỢNG XUẤT";
            // 
            // pnlKpiGiaTri
            // 
            this.pnlKpiGiaTri.BackColor = System.Drawing.Color.White;
            this.pnlKpiGiaTri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiGiaTri.Controls.Add(this.lblTongGiaTriTon);
            this.pnlKpiGiaTri.Controls.Add(this.lblTieuDeTongGiaTriTon);
            this.pnlKpiGiaTri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiGiaTri.Location = new System.Drawing.Point(1077, 3);
            this.pnlKpiGiaTri.Name = "pnlKpiGiaTri";
            this.pnlKpiGiaTri.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlKpiGiaTri.Size = new System.Drawing.Size(355, 73);
            this.pnlKpiGiaTri.TabIndex = 3;
            // 
            // lblTongGiaTriTon
            // 
            this.lblTongGiaTriTon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongGiaTriTon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongGiaTriTon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblTongGiaTriTon.Location = new System.Drawing.Point(12, 28);
            this.lblTongGiaTriTon.Name = "lblTongGiaTriTon";
            this.lblTongGiaTriTon.Size = new System.Drawing.Size(329, 35);
            this.lblTongGiaTriTon.TabIndex = 0;
            this.lblTongGiaTriTon.Text = "0 VNĐ";
            this.lblTongGiaTriTon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTieuDeTongGiaTriTon
            // 
            this.lblTieuDeTongGiaTriTon.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeTongGiaTriTon.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTongGiaTriTon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongGiaTriTon.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongGiaTriTon.Name = "lblTieuDeTongGiaTriTon";
            this.lblTieuDeTongGiaTriTon.Size = new System.Drawing.Size(329, 20);
            this.lblTieuDeTongGiaTriTon.TabIndex = 1;
            this.lblTieuDeTongGiaTriTon.Text = "TỔNG GIÁ TRỊ TỒN KHO";
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Controls.Add(this.tlpBoLoc);
            this.grpBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoLoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpBoLoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpBoLoc.Location = new System.Drawing.Point(6, 6);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.grpBoLoc.Size = new System.Drawing.Size(1435, 84);
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
            this.tlpBoLoc.Size = new System.Drawing.Size(1415, 53);
            this.tlpBoLoc.TabIndex = 0;
            // 
            // lblTuNgayTitle
            // 
            this.lblTuNgayTitle.AutoSize = true;
            this.lblTuNgayTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTuNgayTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTuNgayTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTuNgayTitle.Name = "lblTuNgayTitle";
            this.lblTuNgayTitle.Size = new System.Drawing.Size(206, 20);
            this.lblTuNgayTitle.TabIndex = 0;
            this.lblTuNgayTitle.Text = "Từ ngày";
            this.lblTuNgayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDenNgayTitle
            // 
            this.lblDenNgayTitle.AutoSize = true;
            this.lblDenNgayTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDenNgayTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDenNgayTitle.Location = new System.Drawing.Point(215, 0);
            this.lblDenNgayTitle.Name = "lblDenNgayTitle";
            this.lblDenNgayTitle.Size = new System.Drawing.Size(206, 20);
            this.lblDenNgayTitle.TabIndex = 1;
            this.lblDenNgayTitle.Text = "Đến ngày";
            this.lblDenNgayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLoaiHangTitle
            // 
            this.lblLoaiHangTitle.AutoSize = true;
            this.lblLoaiHangTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiHangTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoaiHangTitle.Location = new System.Drawing.Point(427, 0);
            this.lblLoaiHangTitle.Name = "lblLoaiHangTitle";
            this.lblLoaiHangTitle.Size = new System.Drawing.Size(248, 20);
            this.lblLoaiHangTitle.TabIndex = 2;
            this.lblLoaiHangTitle.Text = "Nhóm loại hàng";
            this.lblLoaiHangTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimKiemTitle
            // 
            this.lblTimKiemTitle.AutoSize = true;
            this.lblTimKiemTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimKiemTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimKiemTitle.Location = new System.Drawing.Point(681, 0);
            this.lblTimKiemTitle.Name = "lblTimKiemTitle";
            this.lblTimKiemTitle.Size = new System.Drawing.Size(305, 20);
            this.lblTimKiemTitle.TabIndex = 3;
            this.lblTimKiemTitle.Text = "Từ khóa tìm kiếm (Mã / Tên SP)";
            this.lblTimKiemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(3, 23);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(206, 30);
            this.dtpTuNgay.TabIndex = 4;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(215, 23);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(206, 30);
            this.dtpDenNgay.TabIndex = 5;
            // 
            // cboLoaiHang
            // 
            this.cboLoaiHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiHang.Location = new System.Drawing.Point(427, 23);
            this.cboLoaiHang.Name = "cboLoaiHang";
            this.cboLoaiHang.Size = new System.Drawing.Size(248, 31);
            this.cboLoaiHang.TabIndex = 6;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(681, 23);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(305, 30);
            this.txtTimKiem.TabIndex = 7;
            // 
            // btnLocBaoCao
            // 
            this.btnLocBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.btnLocBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLocBaoCao.FlatAppearance.BorderSize = 0;
            this.btnLocBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocBaoCao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLocBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnLocBaoCao.Location = new System.Drawing.Point(992, 23);
            this.btnLocBaoCao.Name = "btnLocBaoCao";
            this.btnLocBaoCao.Size = new System.Drawing.Size(206, 27);
            this.btnLocBaoCao.TabIndex = 8;
            this.btnLocBaoCao.Text = "🔍 Tổng hợp";
            this.btnLocBaoCao.UseVisualStyleBackColor = false;
            this.btnLocBaoCao.Click += new System.EventHandler(this.btnLocBaoCao_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(52)))));
            this.btnXuatExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(1204, 23);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(208, 27);
            this.btnXuatExcel.TabIndex = 9;
            this.btnXuatExcel.Text = "📥 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // tabDoanhThu
            // 
            this.tabDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tabDoanhThu.Controls.Add(this.splitDoanhThu);
            this.tabDoanhThu.Controls.Add(this.pnlThongKeDT);
            this.tabDoanhThu.Controls.Add(this.grpBoLocDT);
            this.tabDoanhThu.Location = new System.Drawing.Point(4, 42);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Padding = new System.Windows.Forms.Padding(6);
            this.tabDoanhThu.Size = new System.Drawing.Size(1447, 763);
            this.tabDoanhThu.TabIndex = 1;
            this.tabDoanhThu.Text = "💰 BÁO CÁO DOANH THU XUẤT KHO";
            // 
            // splitDoanhThu
            // 
            this.splitDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDoanhThu.Location = new System.Drawing.Point(6, 185);
            this.splitDoanhThu.Name = "splitDoanhThu";
            // 
            // splitDoanhThu.Panel1
            // 
            this.splitDoanhThu.Panel1.Controls.Add(this.dgvDoanhThu);
            this.splitDoanhThu.Panel1.Controls.Add(this.pnlTableDTToolbar);
            // 
            // splitDoanhThu.Panel2
            // 
            this.splitDoanhThu.Panel2.Controls.Add(this.chartDoanhThu);
            this.splitDoanhThu.Panel2.Controls.Add(this.pnlChartDTToolbar);
            this.splitDoanhThu.Size = new System.Drawing.Size(1435, 572);
            this.splitDoanhThu.SplitterDistance = 831;
            this.splitDoanhThu.TabIndex = 2;
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.AllowUserToDeleteRows = false;
            this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(44)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDoanhThu.ColumnHeadersHeight = 36;
            this.dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThu.Location = new System.Drawing.Point(0, 36);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.RowHeadersVisible = false;
            this.dgvDoanhThu.RowHeadersWidth = 51;
            this.dgvDoanhThu.RowTemplate.Height = 28;
            this.dgvDoanhThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoanhThu.Size = new System.Drawing.Size(831, 536);
            this.dgvDoanhThu.TabIndex = 0;
            this.dgvDoanhThu.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoanhThu_CellDoubleClick);
            // 
            // pnlTableDTToolbar
            // 
            this.pnlTableDTToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlTableDTToolbar.Controls.Add(this.btnXemChiTietPhieu);
            this.pnlTableDTToolbar.Controls.Add(this.cboKieuXemDT);
            this.pnlTableDTToolbar.Controls.Add(this.lblTableDTTit);
            this.pnlTableDTToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTableDTToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlTableDTToolbar.Name = "pnlTableDTToolbar";
            this.pnlTableDTToolbar.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.pnlTableDTToolbar.Size = new System.Drawing.Size(831, 36);
            this.pnlTableDTToolbar.TabIndex = 1;
            // 
            // btnXemChiTietPhieu
            // 
            this.btnXemChiTietPhieu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXemChiTietPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemChiTietPhieu.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXemChiTietPhieu.Location = new System.Drawing.Point(681, 4);
            this.btnXemChiTietPhieu.Name = "btnXemChiTietPhieu";
            this.btnXemChiTietPhieu.Size = new System.Drawing.Size(144, 28);
            this.btnXemChiTietPhieu.TabIndex = 2;
            this.btnXemChiTietPhieu.Text = "🔍 Xem chi tiết phiếu";
            this.btnXemChiTietPhieu.UseVisualStyleBackColor = true;
            this.btnXemChiTietPhieu.Click += new System.EventHandler(this.btnXemChiTietPhieu_Click);
            // 
            // cboKieuXemDT
            // 
            this.cboKieuXemDT.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboKieuXemDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKieuXemDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboKieuXemDT.FormattingEnabled = true;
            this.cboKieuXemDT.Items.AddRange(new object[] {
            "1. Danh sách phiếu xuất",
            "2. Tổng hợp theo mặt hàng",
            "3. Tổng hợp theo từng ngày"});
            this.cboKieuXemDT.Location = new System.Drawing.Point(226, 4);
            this.cboKieuXemDT.Name = "cboKieuXemDT";
            this.cboKieuXemDT.Size = new System.Drawing.Size(220, 28);
            this.cboKieuXemDT.TabIndex = 1;
            this.cboKieuXemDT.SelectedIndexChanged += new System.EventHandler(this.cboKieuXemDT_SelectedIndexChanged);
            // 
            // lblTableDTTit
            // 
            this.lblTableDTTit.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTableDTTit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTableDTTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTableDTTit.Location = new System.Drawing.Point(6, 4);
            this.lblTableDTTit.Name = "lblTableDTTit";
            this.lblTableDTTit.Size = new System.Drawing.Size(220, 28);
            this.lblTableDTTit.TabIndex = 0;
            this.lblTableDTTit.Text = "📋 Dữ liệu doanh thu:";
            this.lblTableDTTit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chartDoanhThu
            // 
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            chartArea2.AxisY.LabelStyle.Format = "N0";
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            chartArea2.Name = "chartAreaDT";
            this.chartDoanhThu.ChartAreas.Add(chartArea2);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            legend2.IsTextAutoFit = false;
            legend2.Name = "legendDT";
            this.chartDoanhThu.Legends.Add(legend2);
            this.chartDoanhThu.Location = new System.Drawing.Point(0, 36);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series3.ChartArea = "chartAreaDT";
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            series3.IsValueShownAsLabel = true;
            series3.IsXValueIndexed = true;
            series3.LabelFormat = "N0";
            series3.Legend = "legendDT";
            series3.Name = "Doanh thu (VNĐ)";
            this.chartDoanhThu.Series.Add(series3);
            this.chartDoanhThu.Size = new System.Drawing.Size(600, 536);
            this.chartDoanhThu.TabIndex = 0;
            title2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            title2.Name = "titleDT";
            title2.Text = "BIỂU ĐỒ PHÂN TÍCH DOANH THU";
            this.chartDoanhThu.Titles.Add(title2);
            // 
            // pnlChartDTToolbar
            // 
            this.pnlChartDTToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlChartDTToolbar.Controls.Add(this.lblChartDTHeader);
            this.pnlChartDTToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChartDTToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlChartDTToolbar.Name = "pnlChartDTToolbar";
            this.pnlChartDTToolbar.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.pnlChartDTToolbar.Size = new System.Drawing.Size(600, 36);
            this.pnlChartDTToolbar.TabIndex = 1;
            // 
            // lblChartDTHeader
            // 
            this.lblChartDTHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblChartDTHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChartDTHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblChartDTHeader.Location = new System.Drawing.Point(6, 4);
            this.lblChartDTHeader.Name = "lblChartDTHeader";
            this.lblChartDTHeader.Size = new System.Drawing.Size(350, 28);
            this.lblChartDTHeader.TabIndex = 0;
            this.lblChartDTHeader.Text = "📈 Sơ đồ phân tích doanh thu";
            this.lblChartDTHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlThongKeDT
            // 
            this.pnlThongKeDT.Controls.Add(this.tlpThongKeDT);
            this.pnlThongKeDT.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongKeDT.Location = new System.Drawing.Point(6, 90);
            this.pnlThongKeDT.Name = "pnlThongKeDT";
            this.pnlThongKeDT.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlThongKeDT.Size = new System.Drawing.Size(1435, 95);
            this.pnlThongKeDT.TabIndex = 1;
            // 
            // tlpThongKeDT
            // 
            this.tlpThongKeDT.ColumnCount = 4;
            this.tlpThongKeDT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpThongKeDT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tlpThongKeDT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongKeDT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongKeDT.Controls.Add(this.pnlKpiDoanhThu, 0, 0);
            this.tlpThongKeDT.Controls.Add(this.pnlKpiSoPhieu, 1, 0);
            this.tlpThongKeDT.Controls.Add(this.pnlKpiSoLuongXuat, 2, 0);
            this.tlpThongKeDT.Controls.Add(this.pnlKpiDoanhThuTB, 3, 0);
            this.tlpThongKeDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongKeDT.Location = new System.Drawing.Point(0, 8);
            this.tlpThongKeDT.Name = "tlpThongKeDT";
            this.tlpThongKeDT.RowCount = 1;
            this.tlpThongKeDT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpThongKeDT.Size = new System.Drawing.Size(1435, 79);
            this.tlpThongKeDT.TabIndex = 0;
            // 
            // pnlKpiDoanhThu
            // 
            this.pnlKpiDoanhThu.BackColor = System.Drawing.Color.White;
            this.pnlKpiDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiDoanhThu.Controls.Add(this.lblTongDoanhThu);
            this.pnlKpiDoanhThu.Controls.Add(this.lblTieuDeTongDoanhThu);
            this.pnlKpiDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiDoanhThu.Location = new System.Drawing.Point(3, 3);
            this.pnlKpiDoanhThu.Name = "pnlKpiDoanhThu";
            this.pnlKpiDoanhThu.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlKpiDoanhThu.Size = new System.Drawing.Size(395, 73);
            this.pnlKpiDoanhThu.TabIndex = 0;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(12, 28);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(369, 35);
            this.lblTongDoanhThu.TabIndex = 0;
            this.lblTongDoanhThu.Text = "0 VNĐ";
            this.lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTieuDeTongDoanhThu
            // 
            this.lblTieuDeTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongDoanhThu.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongDoanhThu.Name = "lblTieuDeTongDoanhThu";
            this.lblTieuDeTongDoanhThu.Size = new System.Drawing.Size(369, 20);
            this.lblTieuDeTongDoanhThu.TabIndex = 1;
            this.lblTieuDeTongDoanhThu.Text = "TỔNG DOANH THU";
            // 
            // pnlKpiSoPhieu
            // 
            this.pnlKpiSoPhieu.BackColor = System.Drawing.Color.White;
            this.pnlKpiSoPhieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiSoPhieu.Controls.Add(this.lblTongSoPhieu);
            this.pnlKpiSoPhieu.Controls.Add(this.lblTieuDeTongSoPhieu);
            this.pnlKpiSoPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiSoPhieu.Location = new System.Drawing.Point(404, 3);
            this.pnlKpiSoPhieu.Name = "pnlKpiSoPhieu";
            this.pnlKpiSoPhieu.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlKpiSoPhieu.Size = new System.Drawing.Size(309, 73);
            this.pnlKpiSoPhieu.TabIndex = 1;
            // 
            // lblTongSoPhieu
            // 
            this.lblTongSoPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongSoPhieu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongSoPhieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTongSoPhieu.Location = new System.Drawing.Point(12, 28);
            this.lblTongSoPhieu.Name = "lblTongSoPhieu";
            this.lblTongSoPhieu.Size = new System.Drawing.Size(283, 35);
            this.lblTongSoPhieu.TabIndex = 0;
            this.lblTongSoPhieu.Text = "0 phiếu";
            this.lblTongSoPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTieuDeTongSoPhieu
            // 
            this.lblTieuDeTongSoPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeTongSoPhieu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTongSoPhieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongSoPhieu.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongSoPhieu.Name = "lblTieuDeTongSoPhieu";
            this.lblTieuDeTongSoPhieu.Size = new System.Drawing.Size(283, 20);
            this.lblTieuDeTongSoPhieu.TabIndex = 1;
            this.lblTieuDeTongSoPhieu.Text = "SỐ PHIẾU XUẤT KHO";
            // 
            // pnlKpiSoLuongXuat
            // 
            this.pnlKpiSoLuongXuat.BackColor = System.Drawing.Color.White;
            this.pnlKpiSoLuongXuat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiSoLuongXuat.Controls.Add(this.lblTongSLXuatDT);
            this.pnlKpiSoLuongXuat.Controls.Add(this.lblTieuDeTongSLXuatDT);
            this.pnlKpiSoLuongXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiSoLuongXuat.Location = new System.Drawing.Point(719, 3);
            this.pnlKpiSoLuongXuat.Name = "pnlKpiSoLuongXuat";
            this.pnlKpiSoLuongXuat.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlKpiSoLuongXuat.Size = new System.Drawing.Size(352, 73);
            this.pnlKpiSoLuongXuat.TabIndex = 2;
            // 
            // lblTongSLXuatDT
            // 
            this.lblTongSLXuatDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongSLXuatDT.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongSLXuatDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblTongSLXuatDT.Location = new System.Drawing.Point(12, 28);
            this.lblTongSLXuatDT.Name = "lblTongSLXuatDT";
            this.lblTongSLXuatDT.Size = new System.Drawing.Size(326, 35);
            this.lblTongSLXuatDT.TabIndex = 0;
            this.lblTongSLXuatDT.Text = "0 sản phẩm";
            this.lblTongSLXuatDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTieuDeTongSLXuatDT
            // 
            this.lblTieuDeTongSLXuatDT.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeTongSLXuatDT.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTongSLXuatDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeTongSLXuatDT.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeTongSLXuatDT.Name = "lblTieuDeTongSLXuatDT";
            this.lblTieuDeTongSLXuatDT.Size = new System.Drawing.Size(326, 20);
            this.lblTieuDeTongSLXuatDT.TabIndex = 1;
            this.lblTieuDeTongSLXuatDT.Text = "TỔNG SỐ LƯỢNG MẶT HÀNG";
            // 
            // pnlKpiDoanhThuTB
            // 
            this.pnlKpiDoanhThuTB.BackColor = System.Drawing.Color.White;
            this.pnlKpiDoanhThuTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKpiDoanhThuTB.Controls.Add(this.lblDoanhThuTB);
            this.pnlKpiDoanhThuTB.Controls.Add(this.lblTieuDeDoanhThuTB);
            this.pnlKpiDoanhThuTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiDoanhThuTB.Location = new System.Drawing.Point(1077, 3);
            this.pnlKpiDoanhThuTB.Name = "pnlKpiDoanhThuTB";
            this.pnlKpiDoanhThuTB.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlKpiDoanhThuTB.Size = new System.Drawing.Size(355, 73);
            this.pnlKpiDoanhThuTB.TabIndex = 3;
            // 
            // lblDoanhThuTB
            // 
            this.lblDoanhThuTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoanhThuTB.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(40)))), ((int)(((byte)(217)))));
            this.lblDoanhThuTB.Location = new System.Drawing.Point(12, 28);
            this.lblDoanhThuTB.Name = "lblDoanhThuTB";
            this.lblDoanhThuTB.Size = new System.Drawing.Size(329, 35);
            this.lblDoanhThuTB.TabIndex = 0;
            this.lblDoanhThuTB.Text = "0 VNĐ";
            this.lblDoanhThuTB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTieuDeDoanhThuTB
            // 
            this.lblTieuDeDoanhThuTB.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeDoanhThuTB.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeDoanhThuTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTieuDeDoanhThuTB.Location = new System.Drawing.Point(12, 8);
            this.lblTieuDeDoanhThuTB.Name = "lblTieuDeDoanhThuTB";
            this.lblTieuDeDoanhThuTB.Size = new System.Drawing.Size(329, 20);
            this.lblTieuDeDoanhThuTB.TabIndex = 1;
            this.lblTieuDeDoanhThuTB.Text = "DOANH THU TRUNG BÌNH / PHIẾU";
            // 
            // grpBoLocDT
            // 
            this.grpBoLocDT.Controls.Add(this.btnXuatExcelDT);
            this.grpBoLocDT.Controls.Add(this.btnLocDT);
            this.grpBoLocDT.Controls.Add(this.txtTimKiemDT);
            this.grpBoLocDT.Controls.Add(this.lblTimKiemDT);
            this.grpBoLocDT.Controls.Add(this.numNamDT);
            this.grpBoLocDT.Controls.Add(this.lblNamDT);
            this.grpBoLocDT.Controls.Add(this.cboThangDT);
            this.grpBoLocDT.Controls.Add(this.lblThangDT);
            this.grpBoLocDT.Controls.Add(this.dtpDenNgayDT);
            this.grpBoLocDT.Controls.Add(this.lblDenNgayDT);
            this.grpBoLocDT.Controls.Add(this.dtpTuNgayDT);
            this.grpBoLocDT.Controls.Add(this.lblTuNgayDT);
            this.grpBoLocDT.Controls.Add(this.cboCheDoDT);
            this.grpBoLocDT.Controls.Add(this.lblCheDoDT);
            this.grpBoLocDT.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoLocDT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpBoLocDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpBoLocDT.Location = new System.Drawing.Point(6, 6);
            this.grpBoLocDT.Name = "grpBoLocDT";
            this.grpBoLocDT.Size = new System.Drawing.Size(1435, 84);
            this.grpBoLocDT.TabIndex = 0;
            this.grpBoLocDT.TabStop = false;
            this.grpBoLocDT.Text = "Tiêu chí thống kê doanh thu";
            // 
            // btnXuatExcelDT
            // 
            this.btnXuatExcelDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(52)))));
            this.btnXuatExcelDT.FlatAppearance.BorderSize = 0;
            this.btnXuatExcelDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcelDT.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcelDT.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcelDT.Location = new System.Drawing.Point(827, 44);
            this.btnXuatExcelDT.Name = "btnXuatExcelDT";
            this.btnXuatExcelDT.Size = new System.Drawing.Size(130, 32);
            this.btnXuatExcelDT.TabIndex = 13;
            this.btnXuatExcelDT.Text = "📥 Xuất Excel";
            this.btnXuatExcelDT.UseVisualStyleBackColor = false;
            this.btnXuatExcelDT.Click += new System.EventHandler(this.btnXuatExcelDT_Click);
            // 
            // btnLocDT
            // 
            this.btnLocDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.btnLocDT.FlatAppearance.BorderSize = 0;
            this.btnLocDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocDT.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLocDT.ForeColor = System.Drawing.Color.White;
            this.btnLocDT.Location = new System.Drawing.Point(687, 44);
            this.btnLocDT.Name = "btnLocDT";
            this.btnLocDT.Size = new System.Drawing.Size(130, 32);
            this.btnLocDT.TabIndex = 12;
            this.btnLocDT.Text = "📊 Thống kê";
            this.btnLocDT.UseVisualStyleBackColor = false;
            this.btnLocDT.Click += new System.EventHandler(this.btnLocDT_Click);
            // 
            // txtTimKiemDT
            // 
            this.txtTimKiemDT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiemDT.Location = new System.Drawing.Point(451, 47);
            this.txtTimKiemDT.Name = "txtTimKiemDT";
            this.txtTimKiemDT.Size = new System.Drawing.Size(220, 29);
            this.txtTimKiemDT.TabIndex = 11;
            // 
            // lblTimKiemDT
            // 
            this.lblTimKiemDT.AutoSize = true;
            this.lblTimKiemDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimKiemDT.Location = new System.Drawing.Point(448, 24);
            this.lblTimKiemDT.Name = "lblTimKiemDT";
            this.lblTimKiemDT.Size = new System.Drawing.Size(197, 20);
            this.lblTimKiemDT.TabIndex = 10;
            this.lblTimKiemDT.Text = "Tìm kiếm (Mã/Người/Lý do):";
            // 
            // numNamDT
            // 
            this.numNamDT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numNamDT.Location = new System.Drawing.Point(308, 47);
            this.numNamDT.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numNamDT.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numNamDT.Name = "numNamDT";
            this.numNamDT.Size = new System.Drawing.Size(95, 29);
            this.numNamDT.TabIndex = 9;
            this.numNamDT.Value = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            this.numNamDT.Visible = false;
            // 
            // lblNamDT
            // 
            this.lblNamDT.AutoSize = true;
            this.lblNamDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNamDT.Location = new System.Drawing.Point(305, 24);
            this.lblNamDT.Name = "lblNamDT";
            this.lblNamDT.Size = new System.Drawing.Size(44, 20);
            this.lblNamDT.TabIndex = 8;
            this.lblNamDT.Text = "Năm:";
            this.lblNamDT.Visible = false;
            // 
            // cboThangDT
            // 
            this.cboThangDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThangDT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboThangDT.FormattingEnabled = true;
            this.cboThangDT.Location = new System.Drawing.Point(168, 47);
            this.cboThangDT.Name = "cboThangDT";
            this.cboThangDT.Size = new System.Drawing.Size(125, 29);
            this.cboThangDT.TabIndex = 7;
            this.cboThangDT.Visible = false;
            // 
            // lblThangDT
            // 
            this.lblThangDT.AutoSize = true;
            this.lblThangDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThangDT.Location = new System.Drawing.Point(165, 24);
            this.lblThangDT.Name = "lblThangDT";
            this.lblThangDT.Size = new System.Drawing.Size(53, 20);
            this.lblThangDT.TabIndex = 6;
            this.lblThangDT.Text = "Tháng:";
            this.lblThangDT.Visible = false;
            // 
            // dtpDenNgayDT
            // 
            this.dtpDenNgayDT.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgayDT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDenNgayDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgayDT.Location = new System.Drawing.Point(308, 47);
            this.dtpDenNgayDT.Name = "dtpDenNgayDT";
            this.dtpDenNgayDT.Size = new System.Drawing.Size(125, 29);
            this.dtpDenNgayDT.TabIndex = 5;
            // 
            // lblDenNgayDT
            // 
            this.lblDenNgayDT.AutoSize = true;
            this.lblDenNgayDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDenNgayDT.Location = new System.Drawing.Point(305, 24);
            this.lblDenNgayDT.Name = "lblDenNgayDT";
            this.lblDenNgayDT.Size = new System.Drawing.Size(75, 20);
            this.lblDenNgayDT.TabIndex = 4;
            this.lblDenNgayDT.Text = "Đến ngày:";
            // 
            // dtpTuNgayDT
            // 
            this.dtpTuNgayDT.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgayDT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTuNgayDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgayDT.Location = new System.Drawing.Point(168, 47);
            this.dtpTuNgayDT.Name = "dtpTuNgayDT";
            this.dtpTuNgayDT.Size = new System.Drawing.Size(125, 29);
            this.dtpTuNgayDT.TabIndex = 3;
            // 
            // lblTuNgayDT
            // 
            this.lblTuNgayDT.AutoSize = true;
            this.lblTuNgayDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTuNgayDT.Location = new System.Drawing.Point(165, 24);
            this.lblTuNgayDT.Name = "lblTuNgayDT";
            this.lblTuNgayDT.Size = new System.Drawing.Size(65, 20);
            this.lblTuNgayDT.TabIndex = 2;
            this.lblTuNgayDT.Text = "Từ ngày:";
            // 
            // cboCheDoDT
            // 
            this.cboCheDoDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheDoDT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCheDoDT.FormattingEnabled = true;
            this.cboCheDoDT.Items.AddRange(new object[] {
            "Khoảng thời gian",
            "Theo ngày",
            "Theo tháng"});
            this.cboCheDoDT.Location = new System.Drawing.Point(12, 47);
            this.cboCheDoDT.Name = "cboCheDoDT";
            this.cboCheDoDT.Size = new System.Drawing.Size(140, 29);
            this.cboCheDoDT.TabIndex = 1;
            this.cboCheDoDT.SelectedIndexChanged += new System.EventHandler(this.cboCheDoDT_SelectedIndexChanged);
            // 
            // lblCheDoDT
            // 
            this.lblCheDoDT.AutoSize = true;
            this.lblCheDoDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheDoDT.Location = new System.Drawing.Point(10, 24);
            this.lblCheDoDT.Name = "lblCheDoDT";
            this.lblCheDoDT.Size = new System.Drawing.Size(91, 20);
            this.lblCheDoDT.TabIndex = 0;
            this.lblCheDoDT.Text = "Chế độ xem:";
            // 
            // frmBaoCaoTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1467, 821);
            this.Controls.Add(this.tabBaoCao);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBaoCaoTonKho";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "Báo cáo Tồn kho & Doanh thu xuất kho";
            this.Load += new System.EventHandler(this.frmBaoCaoTonKho_Load);
            this.Resize += new System.EventHandler(this.frmBaoCaoTonKho_Resize);
            this.tabBaoCao.ResumeLayout(false);
            this.tabTonKho.ResumeLayout(false);
            this.splitBaoCao.Panel1.ResumeLayout(false);
            this.splitBaoCao.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBaoCao)).EndInit();
            this.splitBaoCao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoTonKho)).EndInit();
            this.pnlTableToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTopHangHoa)).EndInit();
            this.pnlChartToolbar.ResumeLayout(false);
            this.pnlThongKe.ResumeLayout(false);
            this.tlpThongKe.ResumeLayout(false);
            this.pnlKpiMaHang.ResumeLayout(false);
            this.pnlKpiNhap.ResumeLayout(false);
            this.pnlKpiXuat.ResumeLayout(false);
            this.pnlKpiGiaTri.ResumeLayout(false);
            this.grpBoLoc.ResumeLayout(false);
            this.tlpBoLoc.ResumeLayout(false);
            this.tlpBoLoc.PerformLayout();
            this.tabDoanhThu.ResumeLayout(false);
            this.splitDoanhThu.Panel1.ResumeLayout(false);
            this.splitDoanhThu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDoanhThu)).EndInit();
            this.splitDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.pnlTableDTToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.pnlChartDTToolbar.ResumeLayout(false);
            this.pnlThongKeDT.ResumeLayout(false);
            this.tlpThongKeDT.ResumeLayout(false);
            this.pnlKpiDoanhThu.ResumeLayout(false);
            this.pnlKpiSoPhieu.ResumeLayout(false);
            this.pnlKpiSoLuongXuat.ResumeLayout(false);
            this.pnlKpiDoanhThuTB.ResumeLayout(false);
            this.grpBoLocDT.ResumeLayout(false);
            this.grpBoLocDT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamDT)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
