# QLKhoHang

Ứng dụng quản lý kho hàng của nhóm, xây dựng bằng Windows Forms và .NET Framework 4.8. Nhánh TV1 hiện triển khai nền tảng CSDL, xác thực, session và shell chính.

## Mở dự án

1. Cài Visual Studio 2022 với workload **.NET desktop development** và .NET Framework 4.8 Developer Pack.
2. Mở `QLKhoHang_Solution/QLKhoHang_Solution.sln`.
3. Chọn `QLKhoHang.GUI` làm Startup Project.

## Cấu trúc

- `QLKhoHang.GUI`: Windows Forms; không truy cập DAL trực tiếp.
- `QLKhoHang.BUS`: kiểm tra dữ liệu và xử lý nghiệp vụ.
- `QLKhoHang.DAL`: truy cập SQL Server, dùng truy vấn có tham số.
- `QLKhoHang.DTO`: đối tượng trao đổi giữa các tầng.
- `QLKhoHang_Solution/Database/Database_Init.sql`: script tạo database và 7 bảng cốt lõi; script chỉ tạo đối tượng còn thiếu, không xóa dữ liệu.

Luồng phụ thuộc: GUI → BUS → DAL; DTO được tham chiếu ở các tầng cần trao đổi dữ liệu.

## Cấu hình SQL Server

Trong `QLKhoHang_Solution/QLKhoHang.GUI/App.config`, connection string dùng Windows Authentication, instance mặc định `BAOCRY\SQLEXPRESS02` và database `QLKhoHang`. Form Kết nối CSDL có thể kiểm tra rồi lưu tên instance riêng trong Local AppData của Windows user; connection string gốc vẫn tập trung trong `App.config`. Tài khoản Windows chạy ứng dụng cần có quyền SQL Server. Tên connection string là `QLKhoHangConnection`.

Chỉ chạy script trên instance/database đã xác nhận. Không dùng thông tin đăng nhập production trong repository.

## Module dự kiến

- Đăng nhập, phiên làm việc, phân quyền và đổi mật khẩu.
- Quản lý nhân viên, nhà cung cấp và hàng hóa.
- Phiếu nhập, phiếu xuất và cập nhật tồn kho.
- Kiểm kê, báo cáo và sao lưu/khôi phục dữ liệu.

## Nhóm thực hiện

Nhóm gồm 4 thành viên, tỷ trọng đóng góp 25% mỗi người:

- **TV1**: Nguyễn Quốc Bảo (MSSV: `231A290098`) - Kiến trúc hệ thống, CSDL, xác thực & phân quyền RBAC, shell chính (`feature/auth-main-db`).
- **TV2**: Đỗ Lê Tuấn Đạt (MSSV: `231A290089`) - Danh mục hàng hóa, nhà cung cấp, giới thiệu phần mềm & UI theme (`feature/master-data`).
- **TV3**: Bùi Quang Duy (MSSV: `231A290127`) - Nghiệp vụ: phiếu nhập kho, xuất kho, kiểm kê & cân bằng kho (`feature/transactions-warehouse`).
- **TV4**: Nguyễn Nhật Duy (MSSV: `231A010060`) - Báo cáo & thống kê: thẻ kho, báo cáo NXT, xuất Excel & kiểm thử QA (`feature/inventory-reports`).

## Nhánh làm việc

TV1 làm trên `feature/auth-main-db`. Không commit trực tiếp lên `main`; các chức năng nhập, xuất và kiểm kê phải dùng transaction và rollback khi lỗi.
