using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLKhoHang.BUS;
using QLKhoHang.GUI.Helpers;

namespace QLKhoHang.GUI.Forms.Transactions
{
    public partial class frmTimKiemNhanh : Form
    {
        private readonly PhieuNhapBUS _bus = new PhieuNhapBUS();
        private DataTable _dtHangHoa;

        // Biến lưu mã sản phẩm được người dùng chọn
        public string MaSPDuocChon { get; private set; }

        public frmTimKiemNhanh()
        {
            InitializeComponent();
            this.Load += FrmTimKiemNhanh_Load;
        }

        private void FrmTimKiemNhanh_Load(object sender, EventArgs e)
        {
            try
            {
                KhoiTaoCauTrucBang();
                TaiDanhSachHangHoa();

                // Gắn sự kiện
                btnTim.Click += BtnTim_Click;
                txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
                btnChon.Click += BtnChon_Click;
                btnDong.Click += (s, ev) => this.Close();
                dgvTimKiem.CellDoubleClick += DgvTimKiem_CellDoubleClick;

                // Mặc định focus vào ô gõ tìm kiếm
                txtTimKiem.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo danh sách tìm kiếm: " + ex.Message, "Thông báo lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KhoiTaoCauTrucBang()
        {
            UIThemeHelper.ApplyStandardGridStyle(dgvTimKiem);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvTimKiem.AutoGenerateColumns = false;
            dgvTimKiem.Columns.Clear();
            dgvTimKiem.ReadOnly = true;
            dgvTimKiem.AllowUserToAddRows = false;
            dgvTimKiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTimKiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cột 1: Mã SP
            dgvTimKiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSP",
                HeaderText = "Mã SP",
                Width = 90,
                ReadOnly = true
            });

            // Cột 2: Tên hàng hóa
            dgvTimKiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSP",
                HeaderText = "Tên mặt hàng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // Cột 3: Loại hàng
            dgvTimKiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LoaiHang",
                HeaderText = "Nhóm loại",
                Width = 110,
                ReadOnly = true
            });

            // Cột 4: ĐVT
            dgvTimKiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonViTinh",
                HeaderText = "ĐVT",
                Width = 70,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Cột 5: Tồn kho
            dgvTimKiem.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuongTon",
                HeaderText = "Tồn kho",
                Width = 80,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) }
            });

            // Header styling
            dgvTimKiem.EnableHeadersVisualStyles = false;
            dgvTimKiem.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 44, 59);
            dgvTimKiem.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTimKiem.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvTimKiem.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
        }

        private void TaiDanhSachHangHoa()
        {
            _dtHangHoa = _bus.LayDanhSachHangHoa();
            dgvTimKiem.DataSource = _dtHangHoa;
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ThucHienTimKiem();
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            ThucHienTimKiem();
        }

        private void ThucHienTimKiem()
        {
            if (_dtHangHoa == null) return;

            string tuKhoa = txtTimKiem.Text.Trim().Replace("'", "''");
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                _dtHangHoa.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                // Tìm kiếm linh hoạt theo cả Mã sản phẩm HOẶC Tên sản phẩm
                _dtHangHoa.DefaultView.RowFilter = string.Format("MaSP LIKE '%{0}%' OR TenSP LIKE '%{0}%'", tuKhoa);
            }
        }

        private void DgvTimKiem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                XacNhanChonHang();
            }
        }

        private void BtnChon_Click(object sender, EventArgs e)
        {
            XacNhanChonHang();
        }

        private void XacNhanChonHang()
        {
            if (dgvTimKiem.CurrentRow != null)
            {
                MaSPDuocChon = dgvTimKiem.CurrentRow.Cells[0].Value?.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng trên bảng danh sách.", "Nhắc nhở",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}