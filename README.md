# LTWIN_N4_QLKH

Ứng dụng quản lý kho hàng của nhóm, xây dựng bằng Windows Forms và .NET Framework 4.8. Dự án phát triển theo mô hình 3 lớp chuẩn nghiệp vụ.

## Mở dự án

1. Cài Visual Studio 2022 với workload **.NET desktop development** và .NET Framework 4.8 Developer Pack.
2. Mở `QLKhoHang_Solution/LTWIN_N4_QLKH_Solution.sln`.
3. Chọn `LTWIN_N4_QLKH.GUI` làm Startup Project.

## Cấu trúc

- `LTWIN_N4_QLKH.GUI`: Giao diện Windows Forms; không truy cập DAL trực tiếp.
- `LTWIN_N4_QLKH.BUS`: Kiểm tra dữ liệu và xử lý nghiệp vụ.
- `LTWIN_N4_QLKH.DAL`: Truy cập SQL Server, dùng truy vấn có tham số.
- `LTWIN_N4_QLKH.DTO`: Đối tượng trao đổi giữa các tầng.
- `QLKhoHang_Solution/Database/Database_Init.sql`: Script tạo database `LTWIN_N4_QLKH_DB` và các bảng cốt lõi.

Luồng phụ thuộc: GUI → BUS → DAL; DTO được tham chiếu ở các tầng cần trao đổi dữ liệu.

## Cấu hình SQL Server

Trong `QLKhoHang_Solution/LTWIN_N4_QLKH.GUI/App.config`, connection string dùng Windows Authentication, database `LTWIN_N4_QLKH_DB`. Form Kết nối CSDL có thể kiểm tra rồi lưu tên instance riêng trong Local AppData của Windows user; connection string gốc vẫn tập trung trong `App.config`. Tên connection string là `LTWIN_N4_QLKHConnection`.

## Module chức năng

- Đăng nhập, phiên làm việc, phân quyền RBAC và đổi mật khẩu.
- Quản lý danh mục nhân viên, nhà cung cấp và hàng hóa.
- Quản lý phiếu nhập kho, phiếu xuất kho và cập nhật tồn kho tự động.
- Kiểm kê kho hàng, thẻ kho, báo cáo Nhập-Xuất-Tồn xuất Excel ClosedXML.
- Sao lưu và khôi phục dữ liệu an toàn.

## Nhóm thực hiện

Nhóm gồm 4 thành viên, tỷ trọng đóng góp 25% mỗi người:

- **TV1**: Nguyễn Quốc Bảo (MSSV: `231A290098`) - Kiến trúc hệ thống, CSDL, xác thực & phân quyền RBAC, shell chính (`feature/auth-main-db`).
- **TV2**: Đỗ Lê Tuấn Đạt (MSSV: `231A290089`) - Danh mục hàng hóa, nhà cung cấp, giới thiệu phần mềm & UI theme (`feature/master-data`).
- **TV3**: Bùi Quang Duy (MSSV: `231A290127`) - Nghiệp vụ: phiếu nhập kho, xuất kho, kiểm kê & cân bằng kho (`feature/transactions-warehouse`).
- **TV4**: Nguyễn Nhật Duy (MSSV: `231A010060`) - Báo cáo & thống kê: thẻ kho, báo cáo NXT, xuất Excel & kiểm thử QA (`feature/inventory-reports`).
