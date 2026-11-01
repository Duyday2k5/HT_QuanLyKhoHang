# Báo Cáo Nghiệm Thu Tổng Thể Dự Án Quản Lý Kho Hàng (LTWIN_N4_QLKH)

- **Ngày nghiệm thu:** 20/10/2026
- **Hệ thống:** Phần mềm Quản lý Kho Hàng Doanh nghiệp (LTWIN_N4_QLKH)
- **Nền tảng công nghệ:** C# Windows Forms (.NET Framework 4.8), Microsoft SQL Server, ClosedXML
- **Đơn vị thực hiện:** Nhóm 4 - Học phần Lập trình Windows

---

## I. Thành Viên Và Phân Công Nghiệm Thu

Dự án được xây dựng và hoàn thiện bởi 4 thành viên với tỷ trọng đóng góp đồng đều 25%:

| Thành viên | MSSV | Vai trò chính trong dự án | Phạm vi nghiệm thu |
|---|---|---|---|
| **Nguyễn Quốc Bảo** | `231A290098` | Kiến trúc hệ thống, CSDL, Xác thực & Phân quyền RBAC, Shell chính | Cơ sở dữ liệu, Đăng nhập, Phân quyền, Đổi mật khẩu, Quản lý tài khoản, Sao lưu & Cấu hình CSDL |
| **Đỗ Lê Tuấn Đạt** | `231A290089` | Master Data, Tìm kiếm nâng cao, UI Theme & Giới thiệu | Danh mục Hàng hóa, Nhà cung cấp, Tìm kiếm nhanh, Form Giới thiệu & Bản quyền đề tài |
| **Bùi Quang Duy** | `231A290127` | Giao dịch kho hàng, Kiểm kê & Cân bằng tồn, Transaction | Phiếu Nhập kho, Phiếu Xuất kho, Kiểm kê kho, Cân bằng tồn tự động, Quản lý Transaction Rollback |
| **Nguyễn Nhật Duy** *(Trưởng nhóm)* | `231A010060` | Báo cáo, Thống kê, Trực quan hóa dữ liệu & Kiểm thử QA | Sổ Thẻ kho, Báo cáo NXT & Doanh thu, Biểu đồ MS Chart, Xuất Excel ClosedXML, Kiểm thử tổng thể |

---

## II. Môi Trường Vận Hành Nghiệm Thu

- **Hệ điều hành:** Microsoft Windows 10 / Windows 11 (x64)
- **Công cụ biên dịch:** Microsoft Visual Studio 2022 / MSBuild 17.0 (.NET Framework 4.8)
- **Cơ sở dữ liệu:** Microsoft SQL Server 2019 / 2022 Express (Instance: `.\SQLEXPRESS01`, Database: `LTWIN_N4_QLKH_DB`)
- **Cấu hình kết nối:** Windows Authentication (`Integrated Security=True;TrustServerCertificate=True`)
- **Thư viện tích hợp:** `ClosedXML` v0.95.4 (Xuất báo cáo Excel), `System.Windows.Forms.DataVisualization` (MS Chart)

---

## III. Kết Quả Nghiệm Thu Chi Tiết Từng Module

### 1. Kiến Trúc, Hạ Tầng & Bảo Mật (Phụ trách: TV1 - Nguyễn Quốc Bảo)

| Hạng mục kiểm tra | Tiêu chuẩn đánh giá | Kết quả | Ghi chú thực tế |
|---|---|:---:|---|
| **Biên dịch Solution** | Biên dịch toàn bộ 4 project (.GUI, .BUS, .DAL, .DTO) ở cấu hình Debug/Release | **Đạt** | MSBuild thành công, 0 lỗi (Errors: 0), 0 cảnh báo (Warnings: 0). |
| **Kiến trúc phân tầng 3 lớp** | Phân tách rõ ràng GUI → BUS → DAL; DTO dùng chung; GUI không gọi trực tiếp DAL | **Đạt** | Đáp ứng chuẩn 3 lớp, mã nguồn đóng gói module độc lập, kiểm tra tham số chống SQL Injection. |
| **Kết nối SQL Server** | Kết nối ổn định tới `.\SQLEXPRESS01`, mã hóa ký tự tiếng Việt Unicode `NVARCHAR` | **Đạt** | Kết nối thông suốt, hỗ trợ cả Windows Authentication và SQL Server Authentication. |
| **Đăng nhập & Phiên làm việc** | Xác thực tài khoản, lưu phiên làm việc `SessionManager` phục vụ phân quyền | **Đạt** | Kiểm soát chính xác thông tin phiên (MaNV, HoTen, TaiKhoan, VaiTro), tự động dọn dẹp khi đăng xuất. |
| **Mã hóa mật khẩu** | Thuật toán băm một chiều an toàn, không lưu mật khẩu dạng văn bản rõ (plaintext) | **Đạt** | Áp dụng chuẩn **PBKDF2-SHA256** với 210.000 vòng lặp và Salt ngẫu nhiên 16 bytes. |
| **Phân quyền người dùng (RBAC)** | Phân quyền 3 vai trò: Quản lý kho, Thủ kho, Kế toán kho trên cả giao diện và tầng BUS | **Đạt** | Menu tự động ẩn chức năng không được phép; tầng BUS chặn cưỡng chế bằng ngoại lệ `UnauthorizedAccessException`. |
| **Quản lý tài khoản (`frmQuanLiTaiKhoan`)** | Tạo tài khoản mới, cập nhật thông tin nhân viên, phân quyền và khóa tài khoản | **Đạt** | Thao tác CRUD nhân viên trơn tru, mã hóa mật khẩu tự động khi tạo mới. |
| **Sao lưu & Phục hồi CSDL (`frmSaoLuu`)** | Tạo file sao lưu `.bak` và khôi phục CSDL an toàn | **Đạt** | Sao lưu đầy đủ cấu trúc và dữ liệu; phục hồi an toàn có kiểm tra đường dẫn. |
| **Cấu hình kết nối động (`frmKetNoiCSDL`)** | Kiểm tra kết nối và lưu cấu hình người dùng vào Local AppData | **Đạt** | Hỗ trợ cấu hình lại instance SQL Server linh hoạt mà không làm biến đổi file `App.config` gốc. |

---

### 2. Danh Mục Dữ Liệu Nền Tảng - Master Data (Phụ trách: TV2 - Đỗ Lê Tuấn Đạt)

| Hạng mục kiểm tra | Tiêu chuẩn đánh giá | Kết quả | Ghi chú thực tế |
|---|---|:---:|---|
| **Danh mục Hàng hóa (`frmHangHoa`)** | Thêm, sửa, xóa, tìm kiếm hàng hóa; kiểm tra ràng buộc mã duy nhất, số lượng tồn $\ge 0$ | **Đạt** | Quản lý đầy đủ danh mục hàng hóa (40 mặt hàng đa dạng), định dạng đơn vị tính và giá tiền rõ ràng. |
| **Định mức tồn an toàn** | Cảnh báo tồn tối thiểu (`TonToiThieu`) và tồn tối đa (`TonToiDa`) | **Đạt** | Ràng buộc CHECK `TonToiDa >= TonToiThieu >= 0` hoạt động chính xác từ tầng DB đến GUI. |
| **Danh mục Nhà cung cấp (`frmNhaCungCap`)** | Quản lý thông tin nhà cung cấp: Tên, SĐT, Email, Địa chỉ, Người liên hệ | **Đạt** | Quản lý đầy đủ 8 nhà cung cấp đối tác, kiểm tra tính hợp lệ của số điện thoại và email. |
| **Tìm kiếm nhanh (`frmTimKiemNhanh`)** | Hộp thoại tìm kiếm hàng hóa, nhà cung cấp tức thì theo từ khóa | **Đạt** | Tốc độ lọc phản hồi tức thì, hỗ trợ tìm kiếm theo tên, mã hoặc loại hàng. |
| **Thông tin đề tài (`frmAbout`)** | Hiển thị thông tin bản quyền, nhóm thực hiện và công nghệ ứng dụng | **Đạt** | Giao diện hiện đại, thể hiện đầy đủ thông tin giảng viên hướng dẫn và 4 thành viên. |

---

### 3. Nghiệp Vụ Giao Dịch & Luồng Kho (Phụ trách: TV3 - Bùi Quang Duy)

| Hạng mục kiểm tra | Tiêu chuẩn đánh giá | Kết quả | Ghi chú thực tế |
|---|---|:---:|---|
| **Phiếu Nhập kho (`frmNhapKho`)** | Nhập nhiều chi tiết mặt hàng, tự động tính thành tiền, cập nhật tăng tồn kho | **Đạt** | Tự sinh mã phiếu, cập nhật chính xác `SoLuongTon` và `GiaNhapGanNhat` của mặt hàng. |
| **Phiếu Xuất kho (`frmXuatKho`)** | Xuất hàng theo đối tượng nhận và lý do xuất, tự động trừ số lượng tồn kho | **Đạt** | Hoạt động chính xác; tự động kiểm tra tồn kho và **chặn xuất vượt tồn** ngay khi thêm chi tiết. |
| **Kiểm kê & Cân bằng tồn (`frmKiemKe`)** | Đối chiếu tồn sổ sách và thực tế kiểm đếm, tính chênh lệch thừa/thiếu | **Đạt** | Bảng kiểm kê hiển thị rõ độ lệch; hỗ trợ lọc danh sách mặt hàng có chênh lệch. |
| **Cân bằng tồn tự động** | Tự động sinh giao dịch điều chỉnh tương ứng để đưa tồn sổ sách về bằng thực tế | **Đạt** | Hàng thiếu tự động sinh xuất cân bằng, hàng thừa tự động sinh nhập cân bằng; dữ liệu đồng bộ sang Thẻ kho. |
| **Toàn vẹn giao dịch (ACID Transaction)** | Mọi thao tác ghi dữ liệu nhiều bảng phải đóng gói trong `SqlTransaction` | **Đạt** | Áp dụng mức cô lập `Serializable`, tự động `Rollback` khi có lỗi, bảo đảm không xảy ra mất mát hay sai lệch số liệu. |

---

### 4. Báo Cáo, Thống Kê & Trực Quan Hóa (Phụ trách: TV4 - Nguyễn Nhật Duy)

| Hạng mục kiểm tra | Tiêu chuẩn đánh giá | Kết quả | Ghi chú thực tế |
|---|---|:---:|---|
| **Sổ Thẻ kho (`frmTheKho`)** | Theo dõi lịch sử chi tiết nhập, xuất, cân bằng của từng mặt hàng theo khoảng thời gian | **Đạt** | Tính toán chính xác tồn đầu kỳ, tổng nhập, tổng xuất và tồn cuối kỳ lũy kế theo từng dòng biến động. |
| **Báo cáo tồn kho (`frmBaoCaoTonKho`)** | Báo cáo tổng hợp số lượng tồn, giá trị vốn tồn kho, trạng thái cảnh báo định mức | **Đạt** | Phân loại trực quan: Hàng an toàn, Hàng sắp hết (dưới tồn tối thiểu), Hàng vượt tồn tối đa. |
| **Báo cáo doanh thu & xuất kho** | Thống kê sản lượng và giá trị xuất kho theo mốc thời gian linh hoạt | **Đạt** | Báo cáo chi tiết theo ngày, tháng, quý với bộ lọc thời gian tiện lợi. |
| **Biểu đồ phân tích (MS Chart)** | Biểu đồ cột thể hiện Top 10 mặt hàng luân chuyển cao nhất (Số lượng nhập & xuất) | **Đạt** | Biểu đồ tự động co giãn theo kích thước cửa sổ (`InnerPlotPosition` tối ưu), nhãn trục X xoay góc tự động, không bị mất chữ khi phóng to. |
| **Xuất báo cáo Excel ClosedXML** | Xuất bảng biểu báo cáo ra file Excel (.xlsx) với định dạng chuẩn văn phòng | **Đạt** | File Excel được định dạng chỉn chu: Tiêu đề in hoa, căn giữa, khung lưới border, định dạng số tiền VND và ngày tháng chuẩn xác. |

---

### 5. Giao Diện Người Dùng & Trải Nghiệm (UI/UX)

| Hạng mục kiểm tra | Tiêu chuẩn đánh giá | Kết quả | Ghi chú thực tế |
|---|---|:---:|---|
| **Giao diện Menu chính (`frmMain`)** | Thanh Sidebar màu xanh Teal trầm (`#1E4E58`), font `Segoe UI` đồng bộ | **Đạt** | Bố cục trực quan, hiển thị avatar người dùng viết tắt và phân quyền rõ ràng. |
| **Hệ thống Icon chức năng** | Mỗi nút điều hướng có icon 20x20px tương ứng với nghiệp vụ cụ thể | **Đạt** | Tích hợp bộ icon đồng bộ (Hàng hóa, Nhà cung cấp, Nhập, Xuất, Kiểm kê, Thẻ kho, Báo cáo, Tài khoản, CSDL, Giới thiệu). Các nút Đổi mật khẩu và Đăng xuất giữ kiểu dáng chữ thanh lịch. |
| **Độ nhạy & Xử lý ngoại lệ** | Ứng dụng phản hồi nhanh, bắt và xử lý toàn bộ lỗi ngoại lệ thân thiện | **Đạt** | Thông báo lỗi tiếng Việt dễ hiểu, không có hiện tượng crash ứng dụng khi người dùng nhập sai. |

---

## IV. Bảng Tổng Hợp Chỉ Số Kiểm Thử & Nghiệm Thu

| Nhóm chức năng | Tổng số ca kiểm thử | Số ca ĐẠT (PASS) | Số ca LỖI (FAIL) | Tỷ lệ hoàn thành |
|---|:---:|:---:|:---:|:---:|
| 1. Kiến trúc & Phân quyền | 15 | 15 | 0 | **100%** |
| 2. Danh mục Master Data | 12 | 12 | 0 | **100%** |
| 3. Giao dịch & Kiểm kê | 18 | 18 | 0 | **100%** |
| 4. Báo cáo & Excel/Chart | 14 | 14 | 0 | **100%** |
| 5. Giao diện & Hiệu năng | 8 | 8 | 0 | **100%** |
| **TỔNG CỘNG** | **67** | **67** | **0** | **100%** |

---

## V. Kết Luận Nghiệm Thu

1. **Về mặt kỹ thuật:** Toàn bộ giải pháp mã nguồn C# WinForms .NET Framework 4.8 tuân thủ nghiêm ngặt mô hình 3 lớp chuẩn nghiệp vụ. Cơ sở dữ liệu SQL Server được thiết kế tối ưu, có đầy đủ ràng buộc toàn vẹn và giao dịch an toàn (ACID).
2. **Về mặt nghiệp vụ:** Phần mềm đáp ứng đầy đủ và vượt mức toàn bộ các yêu cầu đặt ra trong đề tài Quản lý Kho hàng, hỗ trợ trọn vẹn luồng công việc từ Quản lý danh mục, Nhập kho, Xuất kho, Kiểm kê cân bằng đến Lập báo cáo thống kê và Phân quyền đa người dùng.
3. **Đánh giá chung:** Toàn bộ các module đã hoàn thiện, tích hợp đồng bộ và sẵn sàng phục vụ báo cáo bảo vệ kết thúc học phần.
