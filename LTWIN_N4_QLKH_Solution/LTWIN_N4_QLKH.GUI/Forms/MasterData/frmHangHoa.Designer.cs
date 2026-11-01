namespace LTWIN_N4_QLKH.GUI.Forms.MasterData
{
    partial class frmHangHoa
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.pnlCongCu = new System.Windows.Forms.Panel();
            this.lblLocLoai = new System.Windows.Forms.Label();
            this.cboLocLoai = new System.Windows.Forms.ComboBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.lblSapXep = new System.Windows.Forms.Label();
            this.cboSapXep = new System.Windows.Forms.ComboBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.numTonMax = new System.Windows.Forms.NumericUpDown();
            this.lblTonMax = new System.Windows.Forms.Label();
            this.numTonMin = new System.Windows.Forms.NumericUpDown();
            this.lblTonMin = new System.Windows.Forms.Label();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.lblGiaNhap = new System.Windows.Forms.Label();
            this.cboDVT = new System.Windows.Forms.ComboBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.cboLoaiHang = new System.Windows.Forms.ComboBox();
            this.lblLoaiHang = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblChuThichCanhBao = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.pnlCongCu.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTonMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTonMin)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlMain.Controls.Add(this.dgvHangHoa);
            this.pnlMain.Controls.Add(this.pnlCongCu);
            this.pnlMain.Controls.Add(this.grpThongTin);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(16);
            this.pnlMain.Size = new System.Drawing.Size(1020, 680);
            this.pnlMain.TabIndex = 0;
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHangHoa.Location = new System.Drawing.Point(16, 294);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.RowHeadersWidth = 51;
            this.dgvHangHoa.RowTemplate.Height = 24;
            this.dgvHangHoa.Size = new System.Drawing.Size(988, 370);
            this.dgvHangHoa.TabIndex = 3;
            this.dgvHangHoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellClick);
            this.dgvHangHoa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellContentClick);
            this.dgvHangHoa.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHangHoa_CellFormatting);
            // 
            // pnlCongCu
            // 
            this.pnlCongCu.Controls.Add(this.lblLocLoai);
            this.pnlCongCu.Controls.Add(this.cboLocLoai);
            this.pnlCongCu.Controls.Add(this.lblLocTrangThai);
            this.pnlCongCu.Controls.Add(this.cboLocTrangThai);
            this.pnlCongCu.Controls.Add(this.lblSapXep);
            this.pnlCongCu.Controls.Add(this.cboSapXep);
            this.pnlCongCu.Controls.Add(this.lblTimKiem);
            this.pnlCongCu.Controls.Add(this.txtTimKiem);
            this.pnlCongCu.Controls.Add(this.btnTim);
            this.pnlCongCu.Controls.Add(this.lblKetQua);
            this.pnlCongCu.Controls.Add(this.btnLamMoi);
            this.pnlCongCu.Controls.Add(this.btnXoa);
            this.pnlCongCu.Controls.Add(this.btnLuu);
            this.pnlCongCu.Controls.Add(this.btnThem);
            this.pnlCongCu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCongCu.Location = new System.Drawing.Point(16, 206);
            this.pnlCongCu.Name = "pnlCongCu";
            this.pnlCongCu.Size = new System.Drawing.Size(988, 88);
            this.pnlCongCu.TabIndex = 2;
            // 
            // lblLocLoai
            // 
            this.lblLocLoai.AutoSize = true;
            this.lblLocLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLocLoai.Location = new System.Drawing.Point(2, 53);
            this.lblLocLoai.Name = "lblLocLoai";
            this.lblLocLoai.Size = new System.Drawing.Size(84, 21);
            this.lblLocLoai.TabIndex = 7;
            this.lblLocLoai.Text = "Nhóm loại:";
            // 
            // cboLocLoai
            // 
            this.cboLocLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLocLoai.FormattingEnabled = true;
            this.cboLocLoai.Location = new System.Drawing.Point(88, 49);
            this.cboLocLoai.Name = "cboLocLoai";
            this.cboLocLoai.Size = new System.Drawing.Size(130, 29);
            this.cboLocLoai.TabIndex = 8;
            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLocTrangThai.Location = new System.Drawing.Point(224, 53);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Size = new System.Drawing.Size(70, 21);
            this.lblLocTrangThai.TabIndex = 9;
            this.lblLocTrangThai.Text = "Tồn kho:";
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Location = new System.Drawing.Point(296, 49);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(150, 29);
            this.cboLocTrangThai.TabIndex = 10;
            // 
            // lblSapXep
            // 
            this.lblSapXep.AutoSize = true;
            this.lblSapXep.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSapXep.Location = new System.Drawing.Point(452, 53);
            this.lblSapXep.Name = "lblSapXep";
            this.lblSapXep.Size = new System.Drawing.Size(68, 21);
            this.lblSapXep.TabIndex = 11;
            this.lblSapXep.Text = "Sắp xếp:";
            // 
            // cboSapXep
            // 
            this.cboSapXep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSapXep.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboSapXep.FormattingEnabled = true;
            this.cboSapXep.Location = new System.Drawing.Point(522, 49);
            this.cboSapXep.Name = "cboSapXep";
            this.cboSapXep.Size = new System.Drawing.Size(145, 29);
            this.cboSapXep.TabIndex = 12;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTimKiem.Location = new System.Drawing.Point(673, 53);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(68, 21);
            this.lblTimKiem.TabIndex = 13;
            this.lblTimKiem.Text = "Từ khóa:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(743, 49);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(145, 29);
            this.txtTimKiem.TabIndex = 14;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // btnTim
            // 
            this.btnTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTim.Location = new System.Drawing.Point(894, 46);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(90, 34);
            this.btnTim.TabIndex = 15;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKetQua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblKetQua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblKetQua.Location = new System.Drawing.Point(670, 14);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(314, 23);
            this.lblKetQua.TabIndex = 6;
            this.lblKetQua.Text = "Tổng số: 0 sản phẩm";
            this.lblKetQua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(336, 8);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(105, 34);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(225, 8);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(105, 34);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(114, 8);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(105, 34);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(3, 8);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(105, 34);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "+ Thêm mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // grpThongTin
            // 
            this.grpThongTin.BackColor = System.Drawing.Color.White;
            this.grpThongTin.Controls.Add(this.numTonMax);
            this.grpThongTin.Controls.Add(this.lblTonMax);
            this.grpThongTin.Controls.Add(this.numTonMin);
            this.grpThongTin.Controls.Add(this.lblTonMin);
            this.grpThongTin.Controls.Add(this.txtGiaNhap);
            this.grpThongTin.Controls.Add(this.lblGiaNhap);
            this.grpThongTin.Controls.Add(this.cboDVT);
            this.grpThongTin.Controls.Add(this.lblDVT);
            this.grpThongTin.Controls.Add(this.cboLoaiHang);
            this.grpThongTin.Controls.Add(this.lblLoaiHang);
            this.grpThongTin.Controls.Add(this.txtTenSP);
            this.grpThongTin.Controls.Add(this.lblTenSP);
            this.grpThongTin.Controls.Add(this.txtMaSP);
            this.grpThongTin.Controls.Add(this.lblMaSP);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpThongTin.Location = new System.Drawing.Point(16, 56);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(988, 150);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "THÔNG TIN CHI TIẾT SẢN PHẨM";
            // 
            // numTonMax
            // 
            this.numTonMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTonMax.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numTonMax.Location = new System.Drawing.Point(865, 105);
            this.numTonMax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTonMax.Name = "numTonMax";
            this.numTonMax.Size = new System.Drawing.Size(105, 30);
            this.numTonMax.TabIndex = 13;
            this.numTonMax.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblTonMax
            // 
            this.lblTonMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTonMax.AutoSize = true;
            this.lblTonMax.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTonMax.Location = new System.Drawing.Point(768, 108);
            this.lblTonMax.Name = "lblTonMax";
            this.lblTonMax.Size = new System.Drawing.Size(92, 23);
            this.lblTonMax.TabIndex = 12;
            this.lblTonMax.Text = "Tồn tối đa:";
            // 
            // numTonMin
            // 
            this.numTonMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTonMin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numTonMin.Location = new System.Drawing.Point(636, 105);
            this.numTonMin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTonMin.Name = "numTonMin";
            this.numTonMin.Size = new System.Drawing.Size(110, 30);
            this.numTonMin.TabIndex = 11;
            this.numTonMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblTonMin
            // 
            this.lblTonMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTonMin.AutoSize = true;
            this.lblTonMin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTonMin.Location = new System.Drawing.Point(510, 108);
            this.lblTonMin.Name = "lblTonMin";
            this.lblTonMin.Size = new System.Drawing.Size(112, 23);
            this.lblTonMin.TabIndex = 10;
            this.lblTonMin.Text = "Tồn tối thiểu:";
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGiaNhap.Location = new System.Drawing.Point(135, 105);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(345, 30);
            this.txtGiaNhap.TabIndex = 9;
            this.txtGiaNhap.Text = "0";
            // 
            // lblGiaNhap
            // 
            this.lblGiaNhap.AutoSize = true;
            this.lblGiaNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGiaNhap.Location = new System.Drawing.Point(18, 108);
            this.lblGiaNhap.Name = "lblGiaNhap";
            this.lblGiaNhap.Size = new System.Drawing.Size(118, 23);
            this.lblGiaNhap.TabIndex = 8;
            this.lblGiaNhap.Text = "Đơn giá nhập:";
            // 
            // cboDVT
            // 
            this.cboDVT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDVT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDVT.FormattingEnabled = true;
            this.cboDVT.Location = new System.Drawing.Point(636, 68);
            this.cboDVT.Name = "cboDVT";
            this.cboDVT.Size = new System.Drawing.Size(334, 31);
            this.cboDVT.TabIndex = 7;
            // 
            // lblDVT
            // 
            this.lblDVT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDVT.AutoSize = true;
            this.lblDVT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDVT.Location = new System.Drawing.Point(510, 71);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(98, 23);
            this.lblDVT.TabIndex = 6;
            this.lblDVT.Text = "Đơn vị tính:";
            // 
            // cboLoaiHang
            // 
            this.cboLoaiHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiHang.FormattingEnabled = true;
            this.cboLoaiHang.Location = new System.Drawing.Point(636, 31);
            this.cboLoaiHang.Name = "cboLoaiHang";
            this.cboLoaiHang.Size = new System.Drawing.Size(334, 31);
            this.cboLoaiHang.TabIndex = 5;
            // 
            // lblLoaiHang
            // 
            this.lblLoaiHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoaiHang.AutoSize = true;
            this.lblLoaiHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLoaiHang.Location = new System.Drawing.Point(510, 34);
            this.lblLoaiHang.Name = "lblLoaiHang";
            this.lblLoaiHang.Size = new System.Drawing.Size(89, 23);
            this.lblLoaiHang.TabIndex = 4;
            this.lblLoaiHang.Text = "Loại hàng:";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenSP.Location = new System.Drawing.Point(135, 68);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(345, 30);
            this.txtTenSP.TabIndex = 3;
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenSP.Location = new System.Drawing.Point(18, 71);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(64, 23);
            this.lblTenSP.TabIndex = 2;
            this.lblTenSP.Text = "Tên SP:";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaSP.Location = new System.Drawing.Point(135, 31);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(345, 30);
            this.txtMaSP.TabIndex = 1;
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaSP.Location = new System.Drawing.Point(18, 34);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(62, 23);
            this.lblMaSP.TabIndex = 0;
            this.lblMaSP.Text = "Mã SP:";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblChuThichCanhBao);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(16, 16);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(988, 40);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblChuThichCanhBao
            // 
            this.lblChuThichCanhBao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChuThichCanhBao.AutoSize = true;
            this.lblChuThichCanhBao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblChuThichCanhBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lblChuThichCanhBao.Location = new System.Drawing.Point(620, 10);
            this.lblChuThichCanhBao.Name = "lblChuThichCanhBao";
            this.lblChuThichCanhBao.Size = new System.Drawing.Size(355, 20);
            this.lblChuThichCanhBao.TabIndex = 1;
            this.lblChuThichCanhBao.Text = "● Màu đỏ: Hàng tồn chạm hoặc dưới ngưỡng tối thiểu";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(416, 35);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ DANH MỤC HÀNG HÓA";
            // 
            // frmHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 680);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmHangHoa";
            this.Text = "Quản lý Danh mục Hàng hóa";
            this.Load += new System.EventHandler(this.frmHangHoa_Load);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.pnlCongCu.ResumeLayout(false);
            this.pnlCongCu.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTonMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTonMin)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblChuThichCanhBao;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblLoaiHang;
        private System.Windows.Forms.ComboBox cboLoaiHang;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.ComboBox cboDVT;
        private System.Windows.Forms.Label lblGiaNhap;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Label lblTonMin;
        private System.Windows.Forms.NumericUpDown numTonMin;
        private System.Windows.Forms.Label lblTonMax;
        private System.Windows.Forms.NumericUpDown numTonMax;
        private System.Windows.Forms.Panel pnlCongCu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Label lblLocLoai;
        private System.Windows.Forms.ComboBox cboLocLoai;
        private System.Windows.Forms.Label lblLocTrangThai;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Label lblSapXep;
        private System.Windows.Forms.ComboBox cboSapXep;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvHangHoa;
    }
}
