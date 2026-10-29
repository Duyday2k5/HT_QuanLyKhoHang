# Checklist đăng nhập và phân quyền

Đây là các ca kiểm tra cần chạy thủ công trên máy có kết nối được SQL Server. Chưa ca nào được đánh dấu PASS chỉ dựa trên build.

## Điều kiện trước khi kiểm tra

- Kết nối `LTWIN_N4_QLKHConnection` trỏ tới đúng instance và database `LTWIN_N4_QLKH_DB`.
- Bảng `dbo.NhanVien` có tài khoản mẫu cho từng vai trò.
- `MatKhau` lưu theo định dạng PBKDF2-SHA256 do ứng dụng tạo; mật khẩu dạng rõ không được chấp nhận.
- Các chức năng nghiệp vụ trên menu hiện là điểm tích hợp khung. Form Hàng hóa, Nhập/Xuất, Kiểm kê, Thẻ kho, Báo cáo, Sao lưu và cấu hình DB chưa được tích hợp.

## Đăng nhập

| Ca | Thao tác | Kết quả mong đợi |
|---|---|---|
| AUTH-01 | Nhập đúng tài khoản, mật khẩu và chọn đúng vai trò | Mở `frmMain`, session chỉ chứa mã nhân viên, họ tên, tài khoản và vai trò |
| AUTH-02 | Nhập sai mật khẩu hoặc tài khoản không tồn tại | Báo thông tin đăng nhập không đúng; không mở `frmMain` |
| AUTH-03 | Nhập đúng thông tin nhưng chọn sai vai trò | Từ chối đăng nhập |
| AUTH-04 | Bỏ trống tài khoản hoặc mật khẩu | Báo trường còn thiếu; không truy vấn đăng nhập |
| AUTH-05 | Đánh dấu ghi nhớ tài khoản rồi đóng/mở ứng dụng | Chỉ tài khoản được lưu; mật khẩu không được lưu |
| AUTH-06 | Đăng xuất | Session bị xóa và quay lại màn hình đăng nhập |

## Ma trận quyền menu

| Chức năng | Quản lý kho | Thủ kho | Kế toán kho |
|---|:---:|:---:|:---:|
| Tổng quan | Có | Có | Có |
| Hàng hóa, nhà cung cấp | Có | Không | Không |
| Nhập kho, xuất kho, kiểm kê | Có | Có | Không |
| Thẻ kho | Có | Có | Có |
| Báo cáo nhập - xuất - tồn | Có | Không | Có |
| Quản lý tài khoản, sao lưu, kết nối CSDL | Có | Không | Không |
| Đổi mật khẩu | Có | Có | Có |

Kiểm tra từng vai trò: đăng nhập, xác nhận chỉ thấy chức năng được cấp; thử điều hướng tới chức năng bị cấm phải bị chặn bởi `PhanQuyenBUS.YeuCauQuyen`. Khi các màn hình nghiệp vụ được bổ sung, BUS xử lý thao tác cũng phải kiểm tra quyền trước khi gọi DAL.

## Đổi mật khẩu

| Ca | Thao tác | Kết quả mong đợi |
|---|---|---|
| PASS-01 | Đổi với mật khẩu hiện tại đúng, mật khẩu mới hợp lệ và xác nhận khớp | Cập nhật hash; đăng nhập lại bằng mật khẩu mới thành công |
| PASS-02 | Nhập sai mật khẩu hiện tại | Không cập nhật mật khẩu |
| PASS-03 | Mật khẩu mới ngắn hơn 8 ký tự | Báo lỗi kiểm tra; không cập nhật |
| PASS-04 | Xác nhận mật khẩu mới không khớp | Báo lỗi; không cập nhật |
| PASS-05 | Mật khẩu mới trùng mật khẩu hiện tại | Báo lỗi; không cập nhật |

Ghi kết quả PASS/FAIL, tài khoản/vai trò đã dùng và thông báo lỗi thực tế sau khi chạy trên SQL Server.
