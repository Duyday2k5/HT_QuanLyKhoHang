/*
    Tạo các tài khoản mẫu cho database LTWIN_N4_QLKH_DB đại diện 3 vai trò:

    1. Tài khoản: admin     | Vai trò: Quản lý kho | Mật khẩu ban đầu: admin
    2. Tài khoản: nhanvien  | Vai trò: Thủ kho      | Mật khẩu ban đầu: nhanvien
    3. Tài khoản: ketoan    | Vai trò: Kế toán kho  | Mật khẩu ban đầu: ketoan123

    Mật khẩu được lưu dưới dạng PBKDF2-SHA256 đúng định dạng PasswordHasher.cs.
    Chạy script một lần trong SSMS trên đúng SQL Server/database cần dùng.
    Script không ghi đè nếu MaNV hoặc TaiKhoan đã tồn tại.
*/

USE [LTWIN_N4_QLKH_DB];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

IF OBJECT_ID(N'dbo.NhanVien', N'U') IS NULL
    THROW 51000, N'Không tìm thấy bảng dbo.NhanVien trong database LTWIN_N4_QLKH_DB.', 1;

BEGIN TRY
    BEGIN TRANSACTION;

    IF NOT EXISTS (SELECT 1 FROM dbo.NhanVien WHERE MaNV = 'NV0001' OR TaiKhoan = 'admin')
    BEGIN
        INSERT INTO dbo.NhanVien (MaNV, HoTen, TaiKhoan, MatKhau, VaiTro, DienThoai)
        VALUES ('NV0001', N'Quản trị viên', 'admin',
                'PBKDF2-SHA256$210000$rvcibfmFCKoHbkv9YJ6s8Q==$Jgf9kWYmVmJZ3lRZvgM8bkliYd0UPZSTqYfdJjZNlCk=',
                N'Quản lý kho', '0901234567');
    END;

    IF NOT EXISTS (SELECT 1 FROM dbo.NhanVien WHERE MaNV = 'NV0002' OR TaiKhoan = 'nhanvien')
    BEGIN
        INSERT INTO dbo.NhanVien (MaNV, HoTen, TaiKhoan, MatKhau, VaiTro, DienThoai)
        VALUES ('NV0002', N'Nhân viên kho', 'nhanvien',
                'PBKDF2-SHA256$210000$tQ2QMxy/lN0ABYS/UOycZw==$cI4iQX1f8a5qudjVb+++ZmNj5dE1SkoKZKZuxjEllFU=',
                N'Thủ kho', '0902345678');
    END;

    IF NOT EXISTS (SELECT 1 FROM dbo.NhanVien WHERE MaNV = 'NV0004' OR TaiKhoan = 'ketoan')
    BEGIN
        INSERT INTO dbo.NhanVien (MaNV, HoTen, TaiKhoan, MatKhau, VaiTro, DienThoai)
        VALUES ('NV0004', N'Nhân viên kế toán', 'ketoan',
                'PBKDF2-SHA256$210000$g/9kUfytqJk6MEKH6eoIBA==$yL+NGvLFdLbGh3Nwc8jJF5gg0ttBCKAh8R4LhLbGfBQ=',
                N'Kế toán kho', '0912345678');
    END;

    COMMIT TRANSACTION;

    SELECT MaNV, HoTen, TaiKhoan, VaiTro, DienThoai
    FROM dbo.NhanVien
    ORDER BY MaNV;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO
