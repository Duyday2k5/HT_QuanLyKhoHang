using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using LTWIN_N4_QLKH.BUS;
using LTWIN_N4_QLKH.DTO;
using LTWIN_N4_QLKH.GUI.Common;
using LTWIN_N4_QLKH.GUI.Helpers;

namespace LTWIN_N4_QLKH.GUI.Forms.Transactions
{
    public partial class frmNhapKho : Form
    {
        private readonly PhieuNhapBUS _phieuNhapBUS = new PhieuNhapBUS();
        private readonly BindingList<ChiTietPhieuNhapDTO> _gioHang = new BindingList<ChiTietPhieuNhapDTO>();
        private DataTable _dtHangHoa;
        private DataTable _dtNhaCungCap;

        public frmNhapKho()
        {
            InitializeComponent();
            UIThemeHelper.ApplyFormHeaderAndIcon(this, "Quản lý Nhập kho & Lập phiếu nhập", UIThemeHelper.FormIconType.NhapKho);
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            try
            {
                KhoiTaoThongTinNguoiDung();
                KhoiTaoCauTrucBangChiTiet();
                TaiDanhSachNhaCungCap();
                TaiDanhSachHangHoa();
                LamMoiPhieu();

                // Gắn các sự kiện tính toán tự động
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
                MessageBox.Show("Lỗi khởi tạo màn hình Nhập kho: " + ex.Message, "Thông báo lỗi",
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
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
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
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });

            // Cột 5: Số lượng
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuongNhap",
                HeaderText = "Số lượng",
                Width = 90,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft, Format = "N0" }
            });

            // Cột 6: Đơn giá
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGiaNhap",
                HeaderText = "Đơn giá nhập",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft, Format = "N0" }
            });

            // Cột 7: Thành tiền
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThanhTien",
                HeaderText = "Thành tiền",
                Width = 140,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft, Format = "N0", Font = new Font("Segoe UI", 9.75F, FontStyle.Bold) }
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
            dgvChiTiet.DataSource = _gioHang;
            dgvChiTiet.RowPostPaint += (s, ev) =>
            {
                dgvChiTiet.Rows[ev.RowIndex].Cells[0].Value = (ev.RowIndex + 1).ToString();
            };
        }

        private void TaiDanhSachNhaCungCap()
        {
            _dtNhaCungCap = _phieuNhapBUS.LayDanhSachNhaCungCap();
            cboNhaCungCap.DataSource = _dtNhaCungCap;
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNCC";
            if (_dtNhaCungCap.Rows.Count > 0)
                cboNhaCungCap.SelectedIndex = 0;
        }

        private void TaiDanhSachHangHoa()
        {
            _dtHangHoa = _phieuNhapBUS.LayDanhSachHangHoa();
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
                decimal giaGanNhat = Convert.ToDecimal(rows[0]["GiaNhapGanNhat"]);
                numDonGia.Value = giaGanNhat > 0 ? giaGanNhat : 0;
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
                    MessageBox.Show("Vui lòng chọn mặt hàng cần nhập.", "Nhắc nhở",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maSP = cboHangHoa.SelectedValue.ToString();
                DataRow[] rows = _dtHangHoa.Select(string.Format("MaSP = '{0}'", maSP));
                if (rows.Length == 0) return;

                string tenSP = rows[0]["TenSP"].ToString();
                string dvt = rows[0]["DonViTinh"].ToString();
                int soLuong = (int)numSoLuong.Value;
                decimal donGia = numDonGia.Value;

                _phieuNhapBUS.ThemHoacCapNhatGioHang(_gioHang, maSP, tenSP, dvt, soLuong, donGia);

                // Làm mới danh sách hiển thị
                _gioHang.ResetBindings();
                CapNhatTongTien();

                // Đặt lại số lượng về 1 để nhập món tiếp theo
                numSoLuong.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Kiểm tra click vào nút Xóa
            if (dgvChiTiet.Columns[e.ColumnIndex].Name == "btnColXoa")
            {
                ChiTietPhieuNhapDTO item = _gioHang[e.RowIndex];
                DialogResult hoi = MessageBox.Show(
                    string.Format("Bạn có chắc chắn muốn bỏ mặt hàng '{0}' khỏi phiếu?", item.TenSP),
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (hoi == DialogResult.Yes)
                {
                    _gioHang.RemoveAt(e.RowIndex);
                    CapNhatTongTien();
                }
            }
        }

        private void CapNhatTongTien()
        {
            decimal tong = _phieuNhapBUS.TinhTongTien(_gioHang);
            lblTongTien.Text = tong.ToString("N0", new CultureInfo("vi-VN")) + " VNĐ";
        }

        private void LamMoiPhieu()
        {
            dtpNgayNhap.Value = DateTime.Now;
            txtMaPN.Text = _phieuNhapBUS.SinhMaPhieuNhapMoi(dtpNgayNhap.Value);
            txtGhiChu.Clear();
            _gioHang.Clear();
            CapNhatTongTien();
            numSoLuong.Value = 1;

            if (_dtNhaCungCap != null && _dtNhaCungCap.Rows.Count > 0)
                cboNhaCungCap.SelectedIndex = 0;
            if (_dtHangHoa != null && _dtHangHoa.Rows.Count > 0)
                cboHangHoa.SelectedIndex = 0;
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn làm mới toàn bộ phiếu nhập hiện tại không?",
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
                if (cboNhaCungCap.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn Nhà cung cấp giao hàng.", "Thiếu thông tin",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_gioHang.Count == 0)
                {
                    MessageBox.Show("Phiếu nhập phải có ít nhất 1 mặt hàng trong bảng chi tiết.", "Chưa có hàng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maNV = SessionManager.DaDangNhap ? SessionManager.NguoiDungHienTai.MaNV : "NV01";

                PhieuNhapDTO phieu = new PhieuNhapDTO
                {
                    MaPN = txtMaPN.Text.Trim(),
                    NgayNhap = dtpNgayNhap.Value,
                    MaNCC = cboNhaCungCap.SelectedValue.ToString(),
                    MaNV = maNV,
                    GhiChu = txtGhiChu.Text.Trim()
                };

                DialogResult xacNhan = MessageBox.Show(
                    string.Format("XÁC NHẬN LƯU PHIẾU:\n- Số phiếu: {0}\n- Tổng tiền: {1}\n- Số mặt hàng: {2}\n\nDữ liệu sẽ được ghi vào CSDL và tự động CỘNG TỒN KHO!",
                    phieu.MaPN, lblTongTien.Text, _gioHang.Count),
                    "Xác nhận nhập kho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (xacNhan != DialogResult.Yes) return;

                // Gọi nghiệp vụ lưu qua BUS -> DAL (SqlTransaction)
                _phieuNhapBUS.LuuPhieuNhap(phieu, _gioHang);

                MessageBox.Show("Lập phiếu nhập kho thành công! Số lượng tồn kho đã được cập nhật.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới lại bảng hàng hóa trong bộ nhớ để cập nhật tồn kho mới
                TaiDanhSachHangHoa();
                LamMoiPhieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập kho:\n" + ex.Message, "Lỗi nghiệp vụ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void dgvChiTiet_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}