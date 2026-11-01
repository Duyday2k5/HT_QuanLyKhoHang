/*
    LTWIN_N4_QLKH_DB database bootstrap
    Schema source: project report, section II, seven-entity schema.
    This script creates missing objects only. It does not drop or overwrite data.
    Review the target SQL Server instance before executing this script.
*/

IF DB_ID(N'LTWIN_N4_QLKH_DB') IS NULL
BEGIN
    CREATE DATABASE [LTWIN_N4_QLKH_DB];
END;
GO

USE [LTWIN_N4_QLKH_DB];
GO

IF OBJECT_ID(N'dbo.NhanVien', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.NhanVien
    (
        MaNV       VARCHAR(10)    NOT NULL,
        HoTen      NVARCHAR(100)  NOT NULL,
        TaiKhoan   VARCHAR(50)    NOT NULL,
        MatKhau    VARCHAR(255)   NOT NULL,
        VaiTro     NVARCHAR(30)   NOT NULL,
        DienThoai  VARCHAR(15)    NULL,
        CONSTRAINT PK_NhanVien PRIMARY KEY (MaNV),
        CONSTRAINT UQ_NhanVien_TaiKhoan UNIQUE (TaiKhoan),
        CONSTRAINT CK_NhanVien_VaiTro CHECK
            (VaiTro IN (N'Quản lý kho', N'Thủ kho', N'Kế toán kho'))
    );
END;
GO

IF OBJECT_ID(N'dbo.NhaCungCap', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.NhaCungCap
    (
        MaNCC       VARCHAR(15)    NOT NULL,
        TenNCC      NVARCHAR(150)  NOT NULL,
        DienThoai   VARCHAR(20)    NOT NULL,
        Email       VARCHAR(100)   NULL,
        DiaChi      NVARCHAR(250)  NULL,
        NguoiLienHe NVARCHAR(100)  NULL,
        CONSTRAINT PK_NhaCungCap PRIMARY KEY (MaNCC)
    );
END;
GO

IF OBJECT_ID(N'dbo.HangHoa', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.HangHoa
    (
        MaSP           VARCHAR(20)    NOT NULL,
        TenSP          NVARCHAR(150)  NOT NULL,
        LoaiHang       NVARCHAR(50)   NOT NULL,
        DonViTinh      NVARCHAR(20)   NOT NULL,
        SoLuongTon     INT            NOT NULL
            CONSTRAINT DF_HangHoa_SoLuongTon DEFAULT (0),
        TonToiThieu    INT            NOT NULL
            CONSTRAINT DF_HangHoa_TonToiThieu DEFAULT (10),
        TonToiDa       INT            NOT NULL
            CONSTRAINT DF_HangHoa_TonToiDa DEFAULT (500),
        GiaNhapGanNhat DECIMAL(18, 2) NOT NULL
            CONSTRAINT DF_HangHoa_GiaNhapGanNhat DEFAULT (0),
        CONSTRAINT PK_HangHoa PRIMARY KEY (MaSP),
        CONSTRAINT CK_HangHoa_SoLuongTon CHECK (SoLuongTon >= 0),
        CONSTRAINT CK_HangHoa_TonToiThieu CHECK (TonToiThieu >= 0),
        CONSTRAINT CK_HangHoa_TonToiDa CHECK (TonToiDa >= TonToiThieu),
        CONSTRAINT CK_HangHoa_GiaNhapGanNhat CHECK (GiaNhapGanNhat >= 0)
    );
END;
GO

IF OBJECT_ID(N'dbo.PhieuNhap', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PhieuNhap
    (
        MaPN         VARCHAR(20)    NOT NULL,
        NgayNhap     DATETIME       NOT NULL
            CONSTRAINT DF_PhieuNhap_NgayNhap DEFAULT (GETDATE()),
        MaNCC        VARCHAR(15)    NOT NULL,
        MaNV         VARCHAR(10)    NOT NULL,
        TongTienNhap DECIMAL(18, 2) NOT NULL
            CONSTRAINT DF_PhieuNhap_TongTienNhap DEFAULT (0),
        GhiChu       NVARCHAR(255)  NULL,
        CONSTRAINT PK_PhieuNhap PRIMARY KEY (MaPN),
        CONSTRAINT FK_PhieuNhap_NhaCungCap FOREIGN KEY (MaNCC)
            REFERENCES dbo.NhaCungCap (MaNCC),
        CONSTRAINT FK_PhieuNhap_NhanVien FOREIGN KEY (MaNV)
            REFERENCES dbo.NhanVien (MaNV),
        CONSTRAINT CK_PhieuNhap_TongTienNhap CHECK (TongTienNhap >= 0)
    );
END;
GO

IF OBJECT_ID(N'dbo.ChiTietPhieuNhap', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ChiTietPhieuNhap
    (
        MaPN        VARCHAR(20)    NOT NULL,
        MaSP        VARCHAR(20)    NOT NULL,
        SoLuongNhap INT            NOT NULL,
        DonGiaNhap  DECIMAL(18, 2) NOT NULL,
        ThanhTien   AS (CONVERT(DECIMAL(18, 2), SoLuongNhap * DonGiaNhap)) PERSISTED,
        CONSTRAINT PK_ChiTietPhieuNhap PRIMARY KEY (MaPN, MaSP),
        CONSTRAINT FK_ChiTietPhieuNhap_PhieuNhap FOREIGN KEY (MaPN)
            REFERENCES dbo.PhieuNhap (MaPN),
        CONSTRAINT FK_ChiTietPhieuNhap_HangHoa FOREIGN KEY (MaSP)
            REFERENCES dbo.HangHoa (MaSP),
        CONSTRAINT CK_ChiTietPhieuNhap_SoLuong CHECK (SoLuongNhap > 0),
        CONSTRAINT CK_ChiTietPhieuNhap_DonGia CHECK (DonGiaNhap >= 0)
    );
END;
GO

IF OBJECT_ID(N'dbo.PhieuXuat', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PhieuXuat
    (
        MaPX          VARCHAR(20)    NOT NULL,
        NgayXuat      DATETIME       NOT NULL
            CONSTRAINT DF_PhieuXuat_NgayXuat DEFAULT (GETDATE()),
        MaNV          VARCHAR(10)    NOT NULL,
        NguoiNhan     NVARCHAR(100)  NOT NULL,
        LyDoXuat      NVARCHAR(150)  NOT NULL,
        TongTienXuat  DECIMAL(18, 2) NOT NULL
            CONSTRAINT DF_PhieuXuat_TongTienXuat DEFAULT (0),
        GhiChu        NVARCHAR(255)  NULL,
        CONSTRAINT PK_PhieuXuat PRIMARY KEY (MaPX),
        CONSTRAINT FK_PhieuXuat_NhanVien FOREIGN KEY (MaNV)
            REFERENCES dbo.NhanVien (MaNV),
        CONSTRAINT CK_PhieuXuat_TongTienXuat CHECK (TongTienXuat >= 0)
    );
END;
GO

IF OBJECT_ID(N'dbo.ChiTietPhieuXuat', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ChiTietPhieuXuat
    (
        MaPX        VARCHAR(20)    NOT NULL,
        MaSP        VARCHAR(20)    NOT NULL,
        SoLuongXuat INT            NOT NULL,
        DonGiaXuat  DECIMAL(18, 2) NOT NULL,
        ThanhTien   AS (CONVERT(DECIMAL(18, 2), SoLuongXuat * DonGiaXuat)) PERSISTED,
        CONSTRAINT PK_ChiTietPhieuXuat PRIMARY KEY (MaPX, MaSP),
        CONSTRAINT FK_ChiTietPhieuXuat_PhieuXuat FOREIGN KEY (MaPX)
            REFERENCES dbo.PhieuXuat (MaPX),
        CONSTRAINT FK_ChiTietPhieuXuat_HangHoa FOREIGN KEY (MaSP)
            REFERENCES dbo.HangHoa (MaSP),
        CONSTRAINT CK_ChiTietPhieuXuat_SoLuong CHECK (SoLuongXuat > 0),
        CONSTRAINT CK_ChiTietPhieuXuat_DonGia CHECK (DonGiaXuat >= 0)
    );
END;
GO

IF NOT EXISTS
    (SELECT 1 FROM sys.indexes WHERE name = N'IX_PhieuNhap_MaNCC' AND object_id = OBJECT_ID(N'dbo.PhieuNhap'))
    CREATE INDEX IX_PhieuNhap_MaNCC ON dbo.PhieuNhap (MaNCC);
GO

IF NOT EXISTS
    (SELECT 1 FROM sys.indexes WHERE name = N'IX_PhieuNhap_MaNV' AND object_id = OBJECT_ID(N'dbo.PhieuNhap'))
    CREATE INDEX IX_PhieuNhap_MaNV ON dbo.PhieuNhap (MaNV);
GO

IF NOT EXISTS
    (SELECT 1 FROM sys.indexes WHERE name = N'IX_ChiTietPhieuNhap_MaSP' AND object_id = OBJECT_ID(N'dbo.ChiTietPhieuNhap'))
    CREATE INDEX IX_ChiTietPhieuNhap_MaSP ON dbo.ChiTietPhieuNhap (MaSP);
GO

IF NOT EXISTS
    (SELECT 1 FROM sys.indexes WHERE name = N'IX_PhieuXuat_MaNV' AND object_id = OBJECT_ID(N'dbo.PhieuXuat'))
    CREATE INDEX IX_PhieuXuat_MaNV ON dbo.PhieuXuat (MaNV);
GO

IF NOT EXISTS
    (SELECT 1 FROM sys.indexes WHERE name = N'IX_ChiTietPhieuXuat_MaSP' AND object_id = OBJECT_ID(N'dbo.ChiTietPhieuXuat'))
    CREATE INDEX IX_ChiTietPhieuXuat_MaSP ON dbo.ChiTietPhieuXuat (MaSP);
GO
