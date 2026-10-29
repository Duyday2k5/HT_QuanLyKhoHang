using System;
using System.Drawing;
using System.Windows.Forms;
using QLKhoHang.GUI.Helpers;

namespace QLKhoHang.GUI.Forms.MasterData
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            SetupUI();
        }

        private void SetupUI()
        {
            // Thiết lập font chuẩn Segoe UI theo Mục 1.3 Báo cáo tiểu luận
            this.Font = UIThemeHelper.ControlFont;

            // Định dạng nút bấm chuẩn bảng màu UIThemeHelper
            UIThemeHelper.ApplyButtonStyle(btnDong, UIThemeHelper.ButtonType.Neutral);

            // Bật phím Esc để đóng nhanh hộp thoại
            this.CancelButton = btnDong;

            // Khắc phục triệt để lỗi mã hóa font: Gán trực tiếp chuỗi Unicode chuẩn
            this.Text = "Giới thiệu phần mềm & Đề tài";

            if (lblHeaderTitle != null)
            {
                lblHeaderTitle.UseMnemonic = false;
                lblHeaderTitle.Text = "GIỚI THIỆU PHẦN MỀM & DỰ ÁN";
            }

            if (lblSubHeader != null)
            {
                lblSubHeader.UseMnemonic = false;
                lblSubHeader.Text = "Hệ thống Quản lý Kho hàng Tiêu dùng nhanh & Bách hóa";
            }

            if (grpThongTin != null)
            {
                grpThongTin.Text = "THÔNG TIN ĐỀ TÀI TIỂU LUẬN";
            }

            if (lblTenDeTai != null)
            {
                lblTenDeTai.Text = "• Đề tài: PHẦN MỀM QUẢN LÝ KHO HÀNG";
            }

            if (lblNganhHang != null)
            {
                lblNganhHang.Text = "• Mô hình nghiệp vụ: Kho hàng tiêu dùng nhanh (FMCG) / Bách hóa tổng hợp";
            }

            if (lblNenTang != null)
            {
                lblNenTang.UseMnemonic = false;
                lblNenTang.Text = "• Công nghệ: C# Windows Forms (.NET Framework 4.8) & SQL Server";
            }

            if (lblPhienBan != null)
            {
                lblPhienBan.Text = "• Phiên bản: Release v1.0.0 (Niên khóa 2026)";
            }

            if (grpPhanCong != null)
            {
                grpPhanCong.Text = "MA TRẬN PHÂN CHIA NHIỆM VỤ NHÓM (25% / THÀNH VIÊN)";
            }

            if (lblTV1 != null)
            {
                lblTV1.UseMnemonic = false;
                lblTV1.Text = "• Thành viên 1: Nguyễn Quốc Bảo - MSSV: 231A290098 (Kiến trúc & CSDL):\r\n  Quản trị Git repo, Script CSDL QLKhoHang chuẩn, DatabaseHelper.cs, Phân quyền RBAC, Sao lưu CSDL.";
            }

            if (lblTV2 != null)
            {
                lblTV2.UseMnemonic = false;
                lblTV2.Text = "• Thành viên 2: Đỗ Lê Tuấn Đạt - MSSV: 231A290089 (Master Data):\r\n  Quản lý Hàng hóa, Nhà cung cấp, frmAbout, UIThemeHelper, Cảnh báo tồn kho, Seed Data SQL FMCG.";
            }

            if (lblTV3 != null)
            {
                lblTV3.UseMnemonic = false;
                lblTV3.Text = "• Thành viên 3: Bùi Quang Duy - MSSV: 231A290127 (Transactions):\r\n  Lập phiếu Nhập kho, Xuất kho, Kiểm kê & Cân bằng kho, SqlTransaction ACID, Chặn xuất vượt tồn.";
            }

            if (lblTV4 != null)
            {
                lblTV4.UseMnemonic = false;
                lblTV4.Text = "• Thành viên 4: Nguyễn Nhật Duy (NT) - MSSV: 231A010060 (Báo cáo & QA):\r\n  Thẻ kho, Báo cáo Nhập-Xuất-Tồn, Xuất Excel ClosedXML, Biểu đồ luân chuyển, Test Cases kiểm thử.";
            }

            if (lblCopyright != null)
            {
                lblCopyright.Text = "© 2026 Nhóm Đồ Án Quản Lý Kho Hàng. All rights reserved.";
            }

            if (btnDong != null)
            {
                btnDong.Text = "Đóng";
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTV4_Click(object sender, EventArgs e)
        {

        }
    }
}
