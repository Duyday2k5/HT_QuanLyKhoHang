USE [LTWIN_N4_QLKH_DB];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    -- 1. BỔ SUNG THÊM 4 NHÀ CUNG CẤP LỚN (NCC05 -> NCC08)
    IF NOT EXISTS (SELECT 1 FROM dbo.NhaCungCap WHERE MaNCC = 'NCC05')
    BEGIN
        INSERT INTO dbo.NhaCungCap (MaNCC, TenNCC, DienThoai, Email, DiaChi, NguoiLienHe)
        VALUES
            ('NCC05', N'Công ty Cổ phần Hàng tiêu dùng Masan (Masan Consumer)', '02862555660', 'contact@masangroup.com', N'Tầng 12, Tòa nhà MPlaza Saigon, 39 Lê Duẩn, P. Bến Nghé, Quận 1, TP.HCM', N'Nguyễn Trọng Nghĩa'),
            ('NCC06', N'Công ty TNHH Nước Giải Khát Suntory PepsiCo Việt Nam', '02838219359', 'info@suntorypepsico.vn', N'Tầng 5, Cao ốc Sheraton, 88 Đồng Khởi, P. Bến Nghé, Quận 1, TP.HCM', N'Trần Thị Bích'),
            ('NCC07', N'Công ty Cổ phần Mondelez Kinh Đô Việt Nam', '02838270838', 'customercare@mdlz.com', N'Tòa nhà Empress Tower, 138-142 Hai Bà Trưng, P. Đa Kao, Quận 1, TP.HCM', N'Võ Hoàng Long'),
            ('NCC08', N'Công ty TNHH Procter & Gamble Việt Nam (P&G)', '02743747000', 'pgconsumer@pg.com', N'KCN Việt Nam - Singapore (VSIP 1), Thuận An, Bình Dương', N'Lê Minh Tuấn');
    END;

    -- 2. BỔ SUNG THÊM 20 SẢN PHẨM MỚI (HH21 -> HH40)
    -- Bao gồm các kịch bản thực tế để test form Thẻ Kho, Báo cáo tồn kho & Cảnh báo:
    -- + Tồn kho dưới mức tối thiểu (cảnh báo đỏ thiếu hàng)
    -- + Hết hàng hoàn toàn (Tồn = 0)
    -- + Tồn kho vượt mức tối đa (cảnh báo vượt sức chứa kho)
    -- + Tồn kho ở ngưỡng an toàn chuẩn
    IF NOT EXISTS (SELECT 1 FROM dbo.HangHoa WHERE MaSP = 'HH21')
    BEGIN
        INSERT INTO dbo.HangHoa (MaSP, TenSP, LoaiHang, DonViTinh, SoLuongTon, TonToiThieu, TonToiDa, GiaNhapGanNhat)
        VALUES
            -- Phân nhóm 1: Thực phẩm ăn liền & Gia vị (7 SP)
            ('HH21', N'Mì khoai tây Omachi sườn hầm ngũ quả 80g', N'Thực phẩm ăn liền', N'Thùng', 140, 20, 400, 215000),
            ('HH22', N'Nước tương Chinsu tỏi ớt 330ml', N'Thực phẩm ăn liền', N'Chai', 0, 15, 200, 18000),       -- Hết hàng hoàn toàn (Tồn = 0)
            ('HH23', N'Hạt nêm Aji-ngon heo 400g', N'Thực phẩm ăn liền', N'Gói', 85, 15, 250, 31000),
            ('HH24', N'Dầu hào Maggi đậm đặc chai 530g', N'Thực phẩm ăn liền', N'Chai', 320, 10, 300, 34000),       -- Tồn kho 320 > Max 300 (Vượt định mức tối đa)
            ('HH25', N'Bánh quy dinh dưỡng AFC lúa mì 200g', N'Thực phẩm ăn liền', N'Hộp', 60, 10, 150, 28000),
            ('HH26', N'Bánh ChocoPie Orion hộp 12 cái', N'Thực phẩm ăn liền', N'Hộp', 7, 20, 150, 52000),           -- Tồn kho 7 < Min 20 (Cảnh báo tồn thấp)
            ('HH27', N'Đường tinh luyện Biên Hòa Daily 1kg', N'Thực phẩm ăn liền', N'Túi', 180, 25, 500, 25000),

            -- Phân nhóm 2: Đồ uống & Sữa (7 SP)
            ('HH28', N'Nước ngọt Pepsi lon 320ml', N'Đồ uống & Sữa', N'Thùng', 105, 20, 350, 190000),
            ('HH29', N'Nước tăng lực Sting hương dâu 330ml', N'Đồ uống & Sữa', N'Thùng', 125, 20, 300, 210000),
            ('HH30', N'Nước tinh khiết Aquafina 500ml', N'Đồ uống & Sữa', N'Thùng', 280, 20, 250, 88000),          -- Tồn kho 280 > Max 250 (Vượt định mức tối đa)
            ('HH31', N'Sữa chua ăn Vinamilk có đường 100g', N'Đồ uống & Sữa', N'Lốc', 0, 25, 200, 26000),           -- Hết hàng hoàn toàn (Tồn = 0)
            ('HH32', N'Sữa hạt TH true NUT óc chó 180ml', N'Đồ uống & Sữa', N'Lốc', 45, 15, 120, 48000),
            ('HH33', N'Trà Ô Long Tea+ Plus 450ml', N'Đồ uống & Sữa', N'Lốc', 11, 20, 150, 56000),                 -- Tồn kho 11 < Min 20 (Cảnh báo tồn thấp)
            ('HH34', N'Bia Heineken Sleek lon 330ml', N'Đồ uống & Sữa', N'Thùng', 75, 10, 200, 435000),

            -- Phân nhóm 3: Hóa mỹ phẩm & Chăm sóc gia đình (6 SP)
            ('HH35', N'Nước giặt Tide Matic hương sớm mai 3.2kg', N'Hóa mỹ phẩm', N'Túi', 40, 10, 150, 175000),
            ('HH36', N'Nước xả vải Downy huyền bí túi 3L', N'Hóa mỹ phẩm', N'Túi', 6, 15, 120, 185000),             -- Tồn kho 6 < Min 15 (Cảnh báo tồn thấp)
            ('HH37', N'Dầu gội Pantene mượt mà óng ả 650g', N'Hóa mỹ phẩm', N'Chai', 55, 10, 150, 155000),
            ('HH38', N'Sữa tắm Lifebuoy bảo vệ vượt trội 850g', N'Hóa mỹ phẩm', N'Chai', 35, 10, 120, 165000),
            ('HH39', N'Nước tẩy bồn cầu Vim diệt khuẩn 880ml', N'Hóa mỹ phẩm', N'Chai', 0, 10, 100, 36000),         -- Hết hàng hoàn toàn (Tồn = 0)
            ('HH40', N'Nước xịt kính Cif sáng bóng biển 520ml', N'Hóa mỹ phẩm', N'Chai', 45, 10, 100, 27000);
    END;

    COMMIT TRANSACTION;

    PRINT N'==> Bổ sung dữ liệu Master Data thành công!';
    SELECT 'Tong NhaCungCap' AS DanhMuc, COUNT(*) AS SoLuong FROM dbo.NhaCungCap
    UNION ALL
    SELECT 'Tong HangHoa' AS DanhMuc, COUNT(*) AS SoLuong FROM dbo.HangHoa;

END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    RAISERROR(@ErrorMessage, 16, 1);
END CATCH;
GO