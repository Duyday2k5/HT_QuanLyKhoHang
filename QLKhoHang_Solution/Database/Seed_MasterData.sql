/*
    Seed_MasterData.sql - Bộ dữ liệu mẫu cho Thành viên 2 (Master Data)
    Đề tài: Phần mềm Quản lý Kho hàng
    Mô hình: Hàng tiêu dùng nhanh (FMCG) / Bách hóa tổng hợp
    Quy chuẩn: 4 Nhà cung cấp & 20 Sản phẩm FMCG thuộc 3 nhóm hàng
*/

USE [LTWIN_N4_QLKH_DB];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    -- 1. NẠP DỮ LIỆU BẢNG NHÀ CUNG CẤP (4 ĐỐI TÁC FMCG HÀNG ĐẦU)
    IF NOT EXISTS (SELECT 1 FROM dbo.NhaCungCap WHERE MaNCC = 'NCC01')
    BEGIN
        INSERT INTO dbo.NhaCungCap (MaNCC, TenNCC, DienThoai, Email, DiaChi, NguoiLienHe)
        VALUES
            ('NCC01', N'Công ty Cổ phần Acecook Việt Nam', '02838154064', 'contact@acecookvietnam.com', N'Lô II-3, Đường số 11, KCN Tân Bình, P. Tây Thạnh, Q. Tân Phú, TP.HCM', N'Nguyễn Văn An'),
            ('NCC02', N'Công ty Cổ phần Sữa Việt Nam (Vinamilk)', '02854155555', 'vinamilk@vinamilk.com.vn', N'Số 10 Tân Trào, P. Tân Phú, Quận 7, TP.HCM', N'Trần Thị Mai'),
            ('NCC03', N'Công ty TNHH Quốc tế Unilever Việt Nam', '02854135686', 'chamsockhachhang@unilever.com', N'A2-3, KCN Tây Bắc Củ Chi, Xã Tân An Hội, Huyện Củ Chi, TP.HCM', N'Lê Hoàng Nam'),
            ('NCC04', N'Công ty TNHH Nước Giải Khát Coca-Cola Việt Nam', '02838961000', 'coke.vietnam@coca-cola.com', N'Số 485 Xa lộ Hà Nội, P. Linh Trung, TP. Thủ Đức, TP.HCM', N'Phạm Thu Hà');
    END;

    -- 2. NẠP DỮ LIỆU BẢNG HÀNG HÓA (20 SẢN PHẨM PHÂN BỔ ĐỀU 3 NHÓM NGÀNH HÀNG)
    -- Nhóm 1: Thực phẩm ăn liền & Đồ khô (7 SP)
    -- Nhóm 2: Đồ uống & Sữa (7 SP)
    -- Nhóm 3: Hóa mỹ phẩm & Chăm sóc gia đình (6 SP)
    IF NOT EXISTS (SELECT 1 FROM dbo.HangHoa WHERE MaSP = 'HH01')
    BEGIN
        INSERT INTO dbo.HangHoa (MaSP, TenSP, LoaiHang, DonViTinh, SoLuongTon, TonToiThieu, TonToiDa, GiaNhapGanNhat)
        VALUES
            -- Phân nhóm 1: Thực phẩm ăn liền & Đồ khô
            ('HH01', N'Mì Hảo Hảo tôm chua cay 75g', N'Thực phẩm ăn liền', N'Thùng', 120, 20, 500, 105000),
            ('HH02', N'Mì Đệ Nhất thịt bằm', N'Thực phẩm ăn liền', N'Thùng', 85, 15, 300, 142000),
            ('HH03', N'Hủ tiếu Nam Vang Nhịp Sống', N'Thực phẩm ăn liền', N'Thùng', 40, 10, 200, 185000),
            ('HH04', N'Dầu ăn đậu nành Simply 1L', N'Thực phẩm ăn liền', N'Thùng', 60, 10, 250, 550000),
            ('HH05', N'Nước mắm Nam Ngư Đệ Nhị 900ml', N'Thực phẩm ăn liền', N'Thùng', 50, 10, 200, 240000),
            ('HH06', N'Hạt nêm Knorr thịt thăn 400g', N'Thực phẩm ăn liền', N'Gói', 150, 20, 400, 32000),
            ('HH07', N'Gạo Ông Cua ST25 túi 5kg', N'Thực phẩm ăn liền', N'Túi', 9, 15, 100, 175000), -- Tồn kho 9 < Min 15 (để test cảnh báo đỏ)

            -- Phân nhóm 2: Đồ uống & Sữa
            ('HH08', N'Sữa tươi Vinamilk có đường 1L', N'Đồ uống & Sữa', N'Thùng', 8, 20, 300, 360000), -- Tồn kho 8 < Min 20 (để test cảnh báo đỏ theo mockup)
            ('HH09', N'Sữa đặc có đường Ông Thọ đỏ 380g', N'Đồ uống & Sữa', N'Hộp', 180, 25, 400, 22000),
            ('HH10', N'Nước ngọt Coca-Cola Sleek lon 320ml', N'Đồ uống & Sữa', N'Thùng', 95, 20, 300, 195000),
            ('HH11', N'Nước khoáng thiên nhiên Lavie 500ml', N'Đồ uống & Sữa', N'Thùng', 70, 15, 250, 92000),
            ('HH12', N'Cà phê hòa tan G7 3in1 hộp 18 gói', N'Đồ uống & Sữa', N'Hộp', 110, 20, 300, 48000),
            ('HH13', N'Trà xanh Không Độ 455ml', N'Đồ uống & Sữa', N'Lốc', 45, 10, 150, 52000),
            ('HH14', N'Nước tăng lực Red Bull lon 250ml', N'Đồ uống & Sữa', N'Thùng', 6, 15, 200, 245000), -- Tồn kho 6 < Min 15 (cảnh báo đỏ)

            -- Phân nhóm 3: Hóa mỹ phẩm & Chăm sóc gia đình
            ('HH15', N'Bột giặt OMO Comfort tinh dầu thơm 3kg', N'Hóa mỹ phẩm', N'Túi', 30, 10, 200, 145000),
            ('HH16', N'Nước rửa chén Sunlight chanh 750g', N'Hóa mỹ phẩm', N'Chai', 80, 15, 250, 28000),
            ('HH17', N'Nước lau sàn Sunlight hương hoa hạ 1kg', N'Hóa mỹ phẩm', N'Chai', 65, 10, 200, 31000),
            ('HH18', N'Dầu gội Clear thảo dược sạch gàu 630g', N'Hóa mỹ phẩm', N'Chai', 40, 10, 150, 168000),
            ('HH19', N'Kem đánh răng P/S bảo vệ 123 230g', N'Hóa mỹ phẩm', N'Hộp', 120, 20, 300, 35000),
            ('HH20', N'Nước xả vải Comfort một lần xả túi 1.8L', N'Hóa mỹ phẩm', N'Túi', 5, 15, 150, 99000); -- Tồn kho 5 < Min 15 (cảnh báo đỏ)
    END;

    COMMIT TRANSACTION;

    PRINT N'==> Nạp dữ liệu Master Data thành công!';
    SELECT 'NhaCungCap' AS LoaiBang, COUNT(*) AS SoLuong FROM dbo.NhaCungCap
    UNION ALL
    SELECT 'HangHoa' AS LoaiBang, COUNT(*) AS SoLuong FROM dbo.HangHoa;

END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    RAISERROR(@ErrorMessage, 16, 1);
END CATCH;
GO

SELECT MaSP, TenSP, LoaiHang, SoLuongTon, TonToiThieu
FROM dbo.HangHoa
WHERE SoLuongTon <= TonToiThieu;