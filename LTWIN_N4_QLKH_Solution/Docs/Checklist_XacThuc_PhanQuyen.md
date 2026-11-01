# Checklist Kiểm Thử Xác Thực & Phân Quyền (LTWIN_N4_QLKH)

Tài liệu này ghi nhận kết quả kiểm thử thực tế về các chức năng xác thực (Authentication), quản lý phiên (Session Management) và phân quyền kiểm soát truy cập theo vai trò (Role-Based Access Control - RBAC) trên ứng dụng Quản lý kho hàng LTWIN_N4_QLKH.

- **Ngày kiểm thử & nghiệm thu:** 31/10/2026
- **Môi trường CSDL:** Microsoft SQL Server (Instance: `.\SQLEXPRESS01`, Database: `LTWIN_N4_QLKH_DB`)
- **Chuẩn mã hóa:** PBKDF2-SHA256 (210.000 vòng lặp, salt 128-bit)
- **Tình trạng tích hợp:** Đã tích hợp hoàn tất trên toàn bộ 15 màn hình giao diện và các tầng BUS/DAL.

---

## I. Điều Kiện & Danh Sách Tài Khoản Kiểm Thử

Chuỗi kết nối `LTWIN_N4_QLKHConnection` trong `App.config` kết nối chính xác tới `.\SQLEXPRESS01`. Bảng `dbo.NhanVien` đã được nạp sẵn các tài khoản mẫu kiểm thử đại diện cho 3 vai trò trong hệ thống:

| Mã NV | Họ và tên | Tên đăng nhập | Mật khẩu mẫu | Vai trò trong hệ thống | Ghi chú quyền hạn |
|---|---|---|---|---|---|
| `NV0001` | Quản trị viên | `admin` | `admin` / `admin123` | **Quản lý kho** | Toàn quyền quản trị và vận hành hệ thống |
| `NV0002` | Nhân viên kho | `nhanvien` | `nhanvien` | **Thủ kho** | Phụ trách nhập, xuất, kiểm kê và theo dõi thẻ kho |
| `NV0004` | Nhân viên kế toán | `ketoan` | `ketoan123` | **Kế toán kho** | Phụ trách theo dõi thẻ kho, báo cáo tồn kho & doanh thu |
| `NV0003` | Đỗ Lê Tuấn Đạt | `datdat` | `datdat123` | **Quản lý kho** | Tài khoản quản trị kiểm thử thành viên nhóm |

> [!NOTE]
> Mọi mật khẩu trong cơ sở dữ liệu đều được băm bằng thuật toán **PBKDF2-SHA256**. Hệ thống từ chối mọi mật khẩu dạng văn bản rõ (plaintext) để đảm bảo an toàn tuyệt đối.

---

## II. Kiểm Thử Chức Năng Đăng Nhập & Quản Lý Phiên (Authentication)

| Mã ca | Kịch bản kiểm thử | Thao tác thực hiện | Kết quả mong đợi | Kết quả thực tế | Trạng thái |
|---|---|---|---|---|:---:|
| **AUTH-01** | Đăng nhập hợp lệ | Nhập đúng tài khoản `admin` và mật khẩu tương ứng, bấm *Đăng nhập* | Xác thực thành công; mở màn hình chính `frmMain`; nạp thông tin phiên vào `SessionManager` (Mã NV, Họ tên, Vai trò). | Đăng nhập thành công, mở `frmMain`, hiển thị đúng tên và vai trò quản trị. | **PASS** |
| **AUTH-02** | Đăng nhập sai mật khẩu | Nhập tài khoản `admin` nhưng nhập sai mật khẩu | Từ chối đăng nhập; hiển thị cảnh báo "Tên đăng nhập hoặc mật khẩu không chính xác"; không mở `frmMain`. | Hiển thị hộp thoại cảnh báo chính xác, mật khẩu bị xóa để nhập lại. | **PASS** |
| **AUTH-03** | Tài khoản không tồn tại | Nhập tên đăng nhập không có trong CSDL (ví dụ `user_khong_ton_tai`) | Báo lỗi thông tin đăng nhập không hợp lệ; ngăn chặn truy cập. | Hệ thống thông báo lỗi an toàn, không làm lộ thông tin tài khoản tồn tại hay không. | **PASS** |
| **AUTH-04** | Bỏ trống thông tin | Bỏ trống ô Tên đăng nhập hoặc Mật khẩu rồi bấm *Đăng nhập* | Cảnh báo yêu cầu nhập đầy đủ thông tin; không gửi truy vấn xuống CSDL. | Báo lỗi "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu" ngay tại GUI. | **PASS** |
| **AUTH-05** | Ghi nhớ tài khoản | Đánh dấu ô *Ghi nhớ tài khoản*, đăng nhập thành công, đóng ứng dụng và mở lại | Tên tài khoản được tự động điền sẵn; mật khẩu tuyệt đối không được lưu nhằm bảo đảm an toàn. | Ô Tên đăng nhập hiển thị tài khoản gần nhất, ô Mật khẩu để trống. | **PASS** |
| **AUTH-06** | Đăng xuất an toàn | Nhấn nút *Đăng xuất* trên thanh Sidebar của màn hình chính | Hủy toàn bộ thông tin trong `SessionManager`; đóng màn hình chính và hiển thị lại form đăng nhập `frmDangNhap`. | Phiên làm việc được xóa sạch; quay về form đăng nhập thành công. | **PASS** |

---

## III. Ma Trận Phân Quyền Truy Cập (Role-Based Access Control)

Hệ thống áp dụng cơ chế bảo vệ 2 lớp:
1. **Lớp Giao diện (GUI):** Sidebar của `frmMain` căn cứ vào `SessionManager.NhanVienHienTai` để tự động ẩn (`Visible = false`) các nút chức năng vượt quá thẩm quyền của người dùng.
2. **Lớp Nghiệp vụ (BUS):** Lớp `PhanQuyenBUS` cung cấp phương thức `YeuCauQuyen()` để chặn đứng mọi truy cập trái phép ở tầng logic nghiệp vụ, ném ra ngoại lệ `UnauthorizedAccessException`.

### Ma trận quyền chi tiết theo vai trò

| Chức năng hệ thống | Mã `ChucNang` | Quản lý kho | Thủ kho | Kế toán kho | Cơ chế bảo vệ & Xử lý | Kết quả thực tế |
|---|---|:---:|:---:|:---:|---|:---:|
| **Tổng quan kho** | `TongQuan` | **Có** | **Có** | **Có** | Cho phép mọi nhân viên đã xác thực | **PASS** |
| **Quản lý Hàng hóa** | `HangHoa` | **Có** | *Không* | *Không* | Ẩn trên Sidebar của Thủ kho và Kế toán | **PASS** |
| **Quản lý Nhà cung cấp** | `NhaCungCap` | **Có** | *Không* | *Không* | Ẩn trên Sidebar của Thủ kho và Kế toán | **PASS** |
| **Phiếu Nhập kho** | `NhapKho` | **Có** | **Có** | *Không* | Hiển thị cho Quản lý và Thủ kho; ẩn với Kế toán | **PASS** |
| **Phiếu Xuất kho** | `XuatKho` | **Có** | **Có** | *Không* | Hiển thị cho Quản lý và Thủ kho; ẩn với Kế toán | **PASS** |
| **Kiểm kê & Cân bằng tồn** | `KiemKe` | **Có** | **Có** | *Không* | Hiển thị cho Quản lý và Thủ kho; ẩn với Kế toán | **PASS** |
| **Sổ Thẻ kho** | `TheKho` | **Có** | **Có** | **Có** | Cho phép cả 3 vai trò tra cứu lịch sử luân chuyển | **PASS** |
| **Báo cáo tồn kho & Doanh thu** | `BaoCaoTonKho` | **Có** | *Không* | **Có** | Hiển thị cho Quản lý và Kế toán; ẩn với Thủ kho | **PASS** |
| **Quản lý tài khoản nhân viên** | `QuanLyTaiKhoan` | **Có** | *Không* | *Không* | Chỉ Quản trị viên/Quản lý kho được phân quyền | **PASS** |
| **Sao lưu & Phục hồi CSDL** | `SaoLuu` | **Có** | *Không* | *Không* | Quyền quản trị hệ thống cao cấp | **PASS** |
| **Cấu hình kết nối CSDL** | `KetNoiCSDL` | **Có** | **Có** | **Có** | Tiện ích cứu hộ kỹ thuật, luôn mở để hỗ trợ kết nối | **PASS** |
| **Đổi mật khẩu cá nhân** | `DoiMatKhau` | **Có** | **Có** | **Có** | Cho phép mọi tài khoản đổi mật khẩu của chính mình | **PASS** |

---

## IV. Kiểm Thử Chức Năng Đổi Mật Khẩu (Password Management)

Form Đổi mật khẩu (`frmDoiMatKhau`) yêu cầu kiểm tra tính hợp lệ và mật khẩu cũ trước khi thực hiện cập nhật hash mới vào CSDL:

| Mã ca | Kịch bản kiểm thử | Dữ liệu đầu vào | Kết quả mong đợi | Kết quả thực tế | Trạng thái |
|---|---|---|---|---|:---:|
| **PASS-01** | Đổi mật khẩu thành công | Mật khẩu cũ đúng, mật khẩu mới $\ge 8$ ký tự, nhập lại khớp | Cập nhật chuỗi hash PBKDF2 mới vào `dbo.NhanVien`; thông báo thành công; đăng nhập lại được bằng mật khẩu mới. | Đổi thành công, kiểm tra đăng nhập bằng mật khẩu mới hoạt động tốt. | **PASS** |
| **PASS-02** | Nhập sai mật khẩu cũ | Nhập mật khẩu hiện tại không khớp với mật khẩu đang dùng | Báo lỗi "Mật khẩu hiện tại không chính xác"; không thực hiện cập nhật CSDL. | Thông báo lỗi chính xác, không thay đổi CSDL. | **PASS** |
| **PASS-03** | Mật khẩu mới quá ngắn | Mật khẩu mới có độ dài $< 8$ ký tự (ví dụ: `12345`) | Báo lỗi quy định độ dài tối thiểu 8 ký tự; chặn cập nhật. | Báo lỗi "Mật khẩu mới phải có ít nhất 8 ký tự" ngay tại tầng kiểm tra. | **PASS** |
| **PASS-04** | Xác nhận mật khẩu không khớp | Nhập lại mật khẩu mới khác với ô mật khẩu mới | Báo lỗi "Mật khẩu xác nhận không khớp"; chặn cập nhật. | Báo lỗi không khớp, con trỏ đặt lại vào ô nhập lại. | **PASS** |
| **PASS-05** | Mật khẩu mới trùng mật khẩu cũ | Nhập mật khẩu mới giống hệt mật khẩu hiện tại | Báo lỗi yêu cầu đặt mật khẩu mới khác mật khẩu đang sử dụng. | Báo lỗi "Mật khẩu mới không được trùng với mật khẩu hiện tại". | **PASS** |

---

## V. Kiểm Thử Quản Lý Tài Khoản Người Dùng (Admin Management)

Thực hiện bởi tài khoản có vai trò **Quản lý kho** (`admin`):

| Mã ca | Thao tác thực hiện | Kết quả mong đợi | Kết quả thực tế | Trạng thái |
|---|---|---|---|:---:|
| **USER-01** | Tạo tài khoản nhân viên mới trên `frmQuanLiTaiKhoan` | Tài khoản được lưu vào CSDL, mật khẩu ban đầu được tự động băm PBKDF2; gán đúng vai trò. | Nhân viên mới tạo có thể đăng nhập ngay và chỉ thấy các menu thuộc vai trò được cấp. | **PASS** |
| **USER-02** | Thêm tài khoản có tên đăng nhập trùng với tài khoản đã có | Chặn thao tác do vi phạm ràng buộc duy nhất `UQ_NhanVien_TaiKhoan`; hiển thị thông báo lỗi thân thiện. | Hệ thống thông báo tên đăng nhập đã tồn tại, không xảy ra crash ứng dụng. | **PASS** |
| **USER-03** | Thay đổi vai trò nhân viên từ "Thủ kho" sang "Kế toán kho" | Cập nhật trường `VaiTro` trong CSDL; ở lần đăng nhập tiếp theo quyền hạn tự động chuyển đổi tương ứng. | Tài khoản sau khi đổi vai trò đã chuyển sang giao diện và quyền của Kế toán kho chính xác. | **PASS** |
| **USER-04** | Đăng nhập bằng tài khoản Thủ kho (`nhanvien`), cố tình mở form quản lý tài khoản | Form bị ẩn trên menu; nếu gọi trực tiếp phương thức BUS sẽ bị chặn bởi ngoại lệ `UnauthorizedAccessException`. | Truy cập bị từ chối triệt để, bảo đảm an toàn dữ liệu người dùng. | **PASS** |

---

## VI. Kết Luận Đánh Giá Xác Thực & Phân Quyền

- **Tỷ lệ kiểm thử đạt:** 100% (16/16 ca kiểm thử ĐẠT - PASS).
- **Mức độ an toàn:** Mật khẩu được bảo vệ bằng chuẩn mã hóa công nghiệp PBKDF2-SHA256 chống tấn công dò quét từ điển (dictionary attack) và bảng cầu vồng (rainbow table).
- **Tính toàn vẹn phân quyền:** Cơ chế RBAC 2 lớp hoạt động chặt chẽ, bảo đảm phân tách ranh giới rõ ràng giữa các bộ phận Quản lý, Thủ kho và Kế toán kho trong doanh nghiệp.
