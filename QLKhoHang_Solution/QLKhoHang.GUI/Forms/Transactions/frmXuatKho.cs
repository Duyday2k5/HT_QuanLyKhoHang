using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using QLKhoHang.BUS;
using QLKhoHang.DTO;
using QLKhoHang.GUI.Common;
using QLKhoHang.GUI.Helpers;

namespace QLKhoHang.GUI.Forms.Transactions
{
    public partial class frmXuatKho : Form
    {
        private readonly PhieuXuatBUS _phieuXuatBUS = new PhieuXuatBUS();
        private readonly BindingList<ChiTietPhieuXuatDTO> _gioXuat = new BindingList<ChiTietPhieuXuatDTO>();
        private DataTable _dtHangHoa;
        private int _tonKhoHienTai = 0;

        public frmXuatKho()
        {
            InitializeComponent();
            this.Load += frmXuatKho_Load; // <--- THÊM DÒNG KÍCH HOẠT MỌI SỰ KIỆN!
        }

        private void frmXuatKho_Load(object sender, EventArgs e)
        {
            try
            {
                KhoiTaoThongTinNguoiDung();
                KhoiTaoCauTrucBangChiTiet();
                TaiDanhSachHangHoa();
                LamMoiPhieu();

                // Gắn các sự kiện nghiệp vụ
                cboHangHoa.SelectedIndexChanged += CboHangHoa_SelectedIndexChanged;
                numSoLuong.ValueChanged += TinhToanThanhTienTamTinh;
                numDonGia.ValueChanged += TinhToanThanhTienTamTinh;
                numSoLuong.KeyPress += (s, ev) =>
                {
                    if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar))
                    {
                        ev.Handled = true;
                    }
                };
                btnThemDong.Click += BtnThemDong_Click;
                btnLuuPhieu.Click += BtnLuuPhieu_Click;
                btnHuy.Click += BtnHuy_Click;
                dgvChiTiet.CellContentClick += DgvChiTiet_CellContentClick;
                btnTimNhanh.Click += BtnTimNhanh_Click;
                this.KeyDown += (s, ev) => { if (ev.KeyCode == Keys.F2) btnTimNhanh.PerformClick(); };
                this.KeyPreview = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo màn hình Xuất kho: " + ex.Message, "Thông báo lỗi",
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

        private void KhoiTaoCauTrucBangChiTiet()
        {
            UIThemeHelper.ApplyStandardGridStyle(dgvChiTiet);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cột 1: STT
            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn
            {
                HeaderText = "STT",
                Width = 50,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvChiTiet.Columns.Add(colSTT);

            // Cột 2: Mã SP
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSP",
                HeaderText = "Mã SP",
                Width = 90,
                ReadOnly = true
            });

            // Cột 3: Tên hàng hóa
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSP",
                HeaderText = "Tên hàng hóa",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // Cột 4: ĐVT
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonViTinh",
                HeaderText = "ĐVT",
                Width = 80,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Cột 5: Số lượng xuất
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuongXuat",
                HeaderText = "SL xuất",
                Width = 90,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "N0" }
            });

            // Cột 6: Đơn giá xuất
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGiaXuat",
                HeaderText = "Đơn giá xuất",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });

            // Cột 7: Thành tiền
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThanhTien",
                HeaderText = "Thành tiền",
                Width = 140,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0", Font = new Font("Segoe UI", 9.75F, FontStyle.Bold) }
            });

            // Cột 8: Nút Xóa
            DataGridViewButtonColumn colXoa = new DataGridViewButtonColumn
            {
                Name = "btnColXoa",
                HeaderText = "Thao tác",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };
            colXoa.DefaultCellStyle.ForeColor = Color.Red;
            dgvChiTiet.Columns.Add(colXoa);

            // Gán dữ liệu vào DataGridView
            dgvChiTiet.DataSource = _gioXuat;
            dgvChiTiet.RowPostPaint += (s, ev) =>
            {
                dgvChiTiet.Rows[ev.RowIndex].Cells[0].Value = (ev.RowIndex + 1).ToString();
            };
        }

        private void TaiDanhSachHangHoa()
        {
            _dtHangHoa = _phieuXuatBUS.LayDanhSachHangHoa();
            cboHangHoa.DataSource = _dtHangHoa;
            cboHangHoa.DisplayMember = "HienThi";
            cboHangHoa.ValueMember = "MaSP";

            if (_dtHangHoa.Rows.Count > 0)
            {
                cboHangHoa.SelectedIndex = 0;
                CapNhatThongTinHangChon();
            }
        }

        private void CboHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatThongTinHangChon();
        }

        private void CapNhatThongTinHangChon()
        {
            if (cboHangHoa.SelectedValue == null || _dtHangHoa == null) return;

            string maSP = cboHangHoa.SelectedValue.ToString();
            DataRow[] rows = _dtHangHoa.Select(string.Format("MaSP = '{0}'", maSP));
            if (rows.Length > 0)
            {
                lblDVT.Text = rows[0]["DonViTinh"].ToString();
                decimal giaNhap = Convert.ToDecimal(rows[0]["GiaNhapGanNhat"]);
                numDonGia.Value = giaNhap > 0 ? giaNhap : 0;

                // Lấy tồn kho thực tế từ CSDL
                _tonKhoHienTai = _phieuXuatBUS.LaySoLuongTonHienTai(maSP);
                lblTonKho.Text = _tonKhoHienTai.ToString("N0");

                if (_tonKhoHienTai <= 0)
                {
                    lblTonKho.ForeColor = Color.Red;
                }
                else
                {
                    lblTonKho.ForeColor = Color.FromArgb(13, 148, 136);
                }

                TinhToanThanhTienTamTinh(null, null);
            }
        }

        private void TinhToanThanhTienTamTinh(object sender, EventArgs e)
        {
            decimal thanhTien = numSoLuong.Value * numDonGia.Value;
            lblThanhTien.Text = thanhTien.ToString("N0", new CultureInfo("vi-VN")) + " đ";
        }

        private void BtnThemDong_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboHangHoa.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn mặt hàng cần xuất.", "Nhắc nhở",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maSP = cboHangHoa.SelectedValue.ToString();
                DataRow[] rows = _dtHangHoa.Select(string.Format("MaSP = '{0}'", maSP));
                if (rows.Length == 0) return;

                string tenSP = rows[0]["TenSP"].ToString();
                string dvt = rows[0]["DonViTinh"].ToString();
                int soLuongXuat = (int)numSoLuong.Value;
                decimal donGiaXuat = numDonGia.Value;

                // Bẫy chặn xuất vượt tồn ngay trên giao diện
                if (_tonKhoHienTai <= 0)
                {
                    MessageBox.Show(
                        $"Sản phẩm '{tenSP}' ({maSP}) hiện đã hết hàng trong kho (Tồn kho = 0)!\nKhông thể xuất mặt hàng này.",
                        "CẢNH BÁO XUẤT VƯỢT TỒN KHO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // NGHIỆP VỤ CỐT LÕI: Kiểm tra chặn xuất âm
                _phieuXuatBUS.ThemHoacCapNhatGioXuat(_gioXuat, maSP, tenSP, dvt, soLuongXuat, donGiaXuat, _tonKhoHienTai);

                _gioXuat.ResetBindings();
                CapNhatTongTien();

                numSoLuong.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CẢNH BÁO TỒN KHO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvChiTiet.Columns[e.ColumnIndex].Name == "btnColXoa")
            {
                ChiTietPhieuXuatDTO item = _gioXuat[e.RowIndex];
                DialogResult hoi = MessageBox.Show(
                    string.Format("Bạn có chắc chắn muốn bỏ mặt hàng '{0}' khỏi phiếu xuất?", item.TenSP),
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (hoi == DialogResult.Yes)
                {
                    _gioXuat.RemoveAt(e.RowIndex);
                    CapNhatTongTien();
                }
            }
        }

        private void CapNhatTongTien()
        {
            decimal tong = _phieuXuatBUS.TinhTongTien(_gioXuat);
            lblTongTien.Text = tong.ToString("N0", new CultureInfo("vi-VN")) + " VNĐ";
        }

        private void LamMoiPhieu()
        {
            dtpNgayXuat.Value = DateTime.Now;
            txtMaPX.Text = _phieuXuatBUS.SinhMaPhieuXuatMoi(dtpNgayXuat.Value);
            txtNguoiNhan.Clear();
            txtGhiChu.Clear();
            _gioXuat.Clear();
            CapNhatTongTien();
            numSoLuong.Value = 1;

            if (cboLyDoXuat.Items.Count > 0)
                cboLyDoXuat.SelectedIndex = 0;
            if (_dtHangHoa != null && _dtHangHoa.Rows.Count > 0)
                cboHangHoa.SelectedIndex = 0;
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn làm mới toàn bộ phiếu xuất hiện tại không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                LamMoiPhieu();
            }
        }

        private void BtnLuuPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNguoiNhan.Text))
                {
                    MessageBox.Show("Vui lòng nhập Người hoặc Đơn vị nhận hàng.", "Thiếu thông tin",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNguoiNhan.Focus();
                    return;
                }

                if (_gioXuat.Count == 0)
                {
                    MessageBox.Show("Phiếu xuất phải có ít nhất 1 mặt hàng trong bảng chi tiết.", "Chưa có hàng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maNV = SessionManager.DaDangNhap ? SessionManager.NguoiDungHienTai.MaNV : "NV01";

                PhieuXuatDTO phieu = new PhieuXuatDTO
                {
                    MaPX = txtMaPX.Text.Trim(),
                    NgayXuat = dtpNgayXuat.Value,
                    MaNV = maNV,
                    NguoiNhan = txtNguoiNhan.Text.Trim(),
                    LyDoXuat = cboLyDoXuat.Text.Trim(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                DialogResult xacNhan = MessageBox.Show(
                    string.Format("XÁC NHẬN LƯU PHIẾU XUẤT:\n- Số phiếu: {0}\n- Người nhận: {1}\n- Tổng giá trị: {2}\n\nDữ liệu sẽ được ghi vào CSDL và tự động TRỪ TỒN KHO!",
                    phieu.MaPX, phieu.NguoiNhan, lblTongTien.Text),
                    "Xác nhận xuất kho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (xacNhan != DialogResult.Yes) return;

                _phieuXuatBUS.LuuPhieuXuat(phieu, _gioXuat);

                MessageBox.Show("Lập phiếu xuất kho thành công! Số lượng tồn kho đã được trừ tương ứng.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TaiDanhSachHangHoa();
                LamMoiPhieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu xuất kho:\n" + ex.Message, "Lỗi nghiệp vụ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Giữ lại 2 hàm sự kiện thừa do lỡ click đúp trên Designer để không bị lỗi liên kết
        private void txtNguoiNhan_TextChanged(object sender, EventArgs e)
        {
        }
        private void BtnTimNhanh_Click(object sender, EventArgs e)
        {
            using (frmTimKiemNhanh popup = new frmTimKiemNhanh())
            {
                if (popup.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(popup.MaSPDuocChon))
                {
                    cboHangHoa.SelectedValue = popup.MaSPDuocChon;
                    numSoLuong.Focus();
                    numSoLuong.Select(0, numSoLuong.Text.Length);
                }
            }
        }
    }
}