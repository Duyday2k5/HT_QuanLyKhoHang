using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LTWIN_N4_QLKH.BUS;
using LTWIN_N4_QLKH.DTO;
using LTWIN_N4_QLKH.GUI.Common;
using LTWIN_N4_QLKH.GUI.Helpers;

namespace LTWIN_N4_QLKH.GUI.Forms.Transactions
{
    public partial class frmKiemKe : Form
    {
        private readonly KiemKeBUS _kiemKeBUS = new KiemKeBUS();
        private List<KiemKeItemDTO> _danhSachKiemKe = new List<KiemKeItemDTO>();

        public frmKiemKe()
        {
            InitializeComponent();
            this.Load += FrmKiemKe_Load;
        }

        private void FrmKiemKe_Load(object sender, EventArgs e)
        {
            try
            {
                KhoiTaoThongTinNguoiDung();
                KhoiTaoCauTrucBang();
                LamMoiPhieu();

                // Gắn sự kiện các nút
                btnTaiDuLieu.Click += BtnTaiDuLieu_Click;
                btnCanBang.Click += BtnCanBang_Click;
                btnHuy.Click += BtnHuy_Click;
                dgvKiemKe.CellValueChanged += DgvKiemKe_CellValueChanged;
                dgvKiemKe.CellFormatting += DgvKiemKe_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo màn hình Kiểm kê: " + ex.Message, "Thông báo lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KhoiTaoThongTinNguoiDung()
        {
            if (SessionManager.DaDangNhap)
            {
                lblNhanVien.Text = SessionManager.NguoiDungHienTai.HoTen;
            }
            else
            {
                lblNhanVien.Text = "Quản trị viên (Demo)";
            }
        }

        private void KhoiTaoCauTrucBang()
        {
            UIThemeHelper.ApplyStandardGridStyle(dgvKiemKe);
            dgvKiemKe.ReadOnly = false;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvKiemKe.AutoGenerateColumns = false;
            dgvKiemKe.Columns.Clear();
            dgvKiemKe.AllowUserToAddRows = false;
            dgvKiemKe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKiemKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cột 1: Mã SP (Chỉ đọc)
            dgvKiemKe.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSP",
                HeaderText = "Mã SP",
                Width = 90,
                ReadOnly = true
            });

            // Cột 2: Tên hàng hóa (Chỉ đọc)
            dgvKiemKe.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSP",
                HeaderText = "Tên hàng hóa",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // Cột 3: ĐVT (Chỉ đọc)
            dgvKiemKe.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonViTinh",
                HeaderText = "ĐVT",
                Width = 80,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Cột 4: Tồn sổ sách (Chỉ đọc)
            dgvKiemKe.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TonSoSach",
                HeaderText = "Tồn sổ sách",
                Width = 110,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) }
            });

            // Cột 5: Thực đếm (CHO PHÉP GÕ SỐ TRỰC TIẾP)
            DataGridViewTextBoxColumn colThucDem = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThucDem",
                HeaderText = "Thực đếm (Gõ)",
                Width = 130,
                ReadOnly = false, // Cho phép sửa
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    BackColor = Color.FromArgb(254, 243, 199), // Màu vàng nhạt nổi bật
                    ForeColor = Color.FromArgb(146, 64, 14)
                }
            };
            dgvKiemKe.Columns.Add(colThucDem);

            // Cột 6: Độ lệch (Tự tính)
            dgvKiemKe.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DoLech",
                HeaderText = "Độ lệch",
                Width = 90,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) }
            });

            // Cột 7: Kết luận (Tự hiển thị)
            dgvKiemKe.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "KetLuan",
                HeaderText = "Kết luận kiểm đếm",
                Width = 150,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) }
            });

            // Header styling
            dgvKiemKe.EnableHeadersVisualStyles = false;
            dgvKiemKe.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 44, 59);
            dgvKiemKe.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKiemKe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }

        private void LamMoiPhieu()
        {
            dtpNgayKK.Value = DateTime.Now;
            txtMaKK.Text = _kiemKeBUS.SinhMaPhieuKiemKe(dtpNgayKK.Value);
            txtGhiChu.Text = "Kiểm kê định kỳ";
            _danhSachKiemKe.Clear();
            dgvKiemKe.DataSource = null;
            CapNhatThongKeLech();
        }

        private void BtnTaiDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                _danhSachKiemKe = _kiemKeBUS.LayDanhSachHangHoaKiemKe();
                if (_danhSachKiemKe.Count == 0)
                {
                    MessageBox.Show("Hiện tại trong kho chưa có mặt hàng nào để kiểm kê.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dgvKiemKe.DataSource = null;
                dgvKiemKe.DataSource = _danhSachKiemKe;
                CapNhatThongKeLech();

                MessageBox.Show("Đã tải xong toàn bộ danh mục hàng hóa trong kho!\nBạn hãy nhập số lượng thực tế kiểm đếm được vào cột 'Thực đếm (Gõ)'.",
                    "Tải dữ liệu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hàng hóa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvKiemKe_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Khi sửa ô Thực đếm -> ép DataGridView refresh lại để tính lại Độ lệch và Kết luận
            dgvKiemKe.InvalidateRow(e.RowIndex);
            CapNhatThongKeLech();
        }

        private void DgvKiemKe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || _danhSachKiemKe == null || e.RowIndex >= _danhSachKiemKe.Count) return;

            KiemKeItemDTO item = _danhSachKiemKe[e.RowIndex];

            // Tô màu cột Độ lệch và Kết luận
            if (dgvKiemKe.Columns[e.ColumnIndex].DataPropertyName == "DoLech" ||
                dgvKiemKe.Columns[e.ColumnIndex].DataPropertyName == "KetLuan")
            {
                if (item.DoLech < 0)
                {
                    e.CellStyle.ForeColor = Color.Red; // Thiếu hàng -> Màu đỏ
                }
                else if (item.DoLech > 0)
                {
                    e.CellStyle.ForeColor = Color.Green; // Thừa hàng -> Màu xanh lá
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Gray; // Khớp kho -> Màu xám
                }
            }
        }

        private void CapNhatThongKeLech()
        {
            int soMatHangLech = 0;
            if (_danhSachKiemKe != null)
            {
                foreach (var item in _danhSachKiemKe)
                {
                    if (item.DoLech != 0) soMatHangLech++;
                }
            }
            lblSoLuongLech.Text = soMatHangLech.ToString() + " SP";
            lblSoLuongLech.ForeColor = soMatHangLech > 0 ? Color.Red : Color.FromArgb(13, 148, 136);
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn làm mới toàn bộ phiếu kiểm kê không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                LamMoiPhieu();
            }
        }

        private void BtnCanBang_Click(object sender, EventArgs e)
        {
            try
            {
                if (_danhSachKiemKe == null || _danhSachKiemKe.Count == 0)
                {
                    MessageBox.Show("Vui lòng bấm 'TẢI DANH SÁCH HÀNG' trước khi thực hiện cân bằng kho.", "Chưa có dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<KiemKeItemDTO> danhSachLech = _kiemKeBUS.LocDanhSachCoDoLech(_danhSachKiemKe);
                if (danhSachLech.Count == 0)
                {
                    MessageBox.Show("Tất cả mặt hàng đều đã KHỚP KHO (Độ lệch = 0)!\nKhông có mặt hàng nào cần cân bằng tồn kho.",
                        "Kho đã khớp hoàn toàn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult xacNhan = MessageBox.Show(
                    string.Format("CẢNH BÁO CÂN BẰNG TỒN KHO:\n- Phát hiện {0} mặt hàng có chênh lệch giữa sổ sách và thực tế.\n\nHệ thống sẽ tự động cập nhật số lượng tồn kho của các mặt hàng này về đúng số lượng THỰC ĐẾM.\n\nBạn có chắc chắn muốn thực hiện không?",
                    danhSachLech.Count),
                    "Xác nhận cân bằng kho", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (xacNhan != DialogResult.Yes) return;

                string maNV = SessionManager.DaDangNhap ? SessionManager.NguoiDungHienTai.MaNV : "NV01";

                // Thực thi cân bằng kho qua BUS -> DAL (SqlTransaction)
                _kiemKeBUS.CanBangKhoTuDong(
                    txtMaKK.Text.Trim(),
                    dtpNgayKK.Value,
                    maNV,
                    txtTenKho.Text.Trim(),
                    txtGhiChu.Text.Trim(),
                    _danhSachKiemKe);

                MessageBox.Show("Cân bằng tồn kho tự động thành công!\nSố lượng tồn kho trong CSDL đã được điều chỉnh khớp với thực tế kiểm kê.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại danh sách mới để kiểm tra
                BtnTaiDuLieu_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cân bằng kho:\n" + ex.Message, "Lỗi nghiệp vụ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}