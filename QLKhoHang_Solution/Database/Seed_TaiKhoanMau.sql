/*
    Tạo hai tài khoản mẫu cho database LTWIN_N4_QLKH_DB.

    Tài khoản: admin     | Vai trò: Quản lý kho | Mật khẩu ban đầu: admin
    Tài khoản: nhanvien  | Vai trò: Thủ kho      | Mật khẩu ban đầu: nhanvien

    Mật khẩu được lưu dưới dạng PBKDF2-SHA256 đúng định dạng PasswordHasher.cs.
    Chạy script một lần trong SSMS trên đúng SQL Server/database cần dùng.
    Script không ghi đè nếu MaNV hoặc TaiKhoan đã tồn tại.
    Hãy đổi mật khẩu ngay sau lần đăng nhập đầu tiên.
*/

USE [LTWIN_N4_QLKH_DB];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

IF OBJECT_ID(N'dbo.NhanVien', N'U') IS NULL
    THROW 51000, N'Không tìm thấy bảng dbo.NhanVien trong database LTWIN_N4_QLKH_DB.', 1;

BEGIN TRY
    BEGIN TRANSACTION;

    IF EXISTS
    (
        SELECT 1
        FROM dbo.NhanVien
        WHERE MaNV IN ('NV0001', 'NV0002')
           OR TaiKhoan IN ('admin', 'nhanvien')
    )
        THROW 51001, N'Mã nhân viên hoặc tên đăng nhập mẫu đã tồn tại. Không có dữ liệu nào bị thay đổi.', 1;

    INSERT INTO dbo.NhanVien (MaNV, HoTen, TaiKhoan, MatKhau, VaiTro)
    VALUES
        ('NV0001', N'Quản trị viên', 'admin',
         'PBKDF2-SHA256$210000$rvcibfmFCKoHbkv9YJ6s8Q==$Jgf9kWYmVmJZ3lRZvgM8bkliYd0UPZSTqYfdJjZNlCk=',
         N'Quản lý kho'),
        ('NV0002', N'Nhân viên kho', 'nhanvien',
         'PBKDF2-SHA256$210000$tQ2QMxy/lN0ABYS/UOycZw==$cI4iQX1f8a5qudjVb+++ZmNj5dE1SkoKZKZuxjEllFU=',
         N'Thủ kho');

    COMMIT TRANSACTION;

    SELECT MaNV, HoTen, TaiKhoan, VaiTro
    FROM dbo.NhanVien
    WHERE TaiKhoan IN ('admin', 'nhanvien')
    ORDER BY MaNV;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO
