create database DBShoes
use DBShoes

SET DATEFORMAT DMY

CREATE TABLE THE
(
	MATHE INT IDENTITY CONSTRAINT PK_MATHE PRIMARY KEY,
	SOTHE CHAR(12),
	TENNGANHANG VARCHAR(50),
	CHUTAIKHOAN NVARCHAR(50)
)

CREATE TABLE KHACHHANG
(
	MAKH INT IDENTITY CONSTRAINT PK_MAKH PRIMARY KEY,
	HOTEN NVARCHAR(50),
	SDT CHAR(10),
	DIACHI NVARCHAR(50),
	MATHE INT CONSTRAINT FK_MATHE_THE FOREIGN KEY REFERENCES THE(MATHE)
)

CREATE TABLE NHANVIEN
(
	MANV INT IDENTITY CONSTRAINT PK_MANV PRIMARY KEY,
	TENNV NVARCHAR(50),
	SDT CHAR(10),
	DIACHI NVARCHAR(50),
	NGAYVAOLAM DATE,
	LUONG INT
)
CREATE TABLE THUONGHIEU
(
	MATH INT IDENTITY CONSTRAINT PK_MATH PRIMARY KEY,
	TENTH VARCHAR (20),
)

CREATE TABLE NHACUNGCAP
(
	MANCC INT IDENTITY CONSTRAINT PK_MANCC PRIMARY KEY,
	TENNCC NVARCHAR (100),
)

CREATE TABLE SANPHAM
(
	MASP INT IDENTITY CONSTRAINT PK_MASP PRIMARY KEY,
	TENSP VARCHAR (100) UNIQUE NOT NULL,
	MATH INT CONSTRAINT FK_MATH_THUONGHIEU FOREIGN KEY REFERENCES THUONGHIEU(MATH),
	MANCC INT CONSTRAINT FK_MANCC_NHACUNGCAP FOREIGN KEY REFERENCES NHACUNGCAP(MANCC),
	MAUSAC NVARCHAR(10),
	KICHCO INT,
	SL INT,
	MOTA NVARCHAR(500),
	HINH VARCHAR(100),
	GIA INT
)

CREATE TABLE KHUYENMAI
(
	MAKM INT IDENTITY CONSTRAINT PK_MAKM PRIMARY KEY,
	TENKM NVARCHAR(20),
	TRIGIA INT,
	NGAYBD DATE,
	NGAYKT DATE
)

CREATE TABLE DATHANG
(
	MADH INT IDENTITY CONSTRAINT PK_MADH PRIMARY KEY,
	MAKH INT CONSTRAINT FK_MAKH_KHACHHANG FOREIGN KEY REFERENCES KHACHHANG(MAKH),
	MAKM INT CONSTRAINT FK_MAKM_KHUYENMAI FOREIGN KEY REFERENCES KHUYENMAI(MAKM),
	NGAYDAT DATE,
	GHICHU NVARCHAR(50),
	TONGTIEN INT,
	HINHTHUCTHANHTOAN NVARCHAR(50)
)


CREATE TABLE HOADON(
	MAHD INT IDENTITY CONSTRAINT PK_MAHD PRIMARY KEY,
	MADH INT CONSTRAINT FK_MADH_DATHANG_HD FOREIGN KEY REFERENCES DATHANG(MADH),
	MANV INT CONSTRAINT FK_MANV_NHANVIEN FOREIGN KEY REFERENCES NHANVIEN(MANV),
	NGAYLAPHD DATE
)

CREATE TABLE THANHTOAN
(
	MATT INT IDENTITY CONSTRAINT PK_MATT PRIMARY KEY,
	MADH INT CONSTRAINT FK_MADH_DATHANG_TT FOREIGN KEY REFERENCES DATHANG(MADH),
	NGAYTHANHTOAN DATE,
	SOTIEN INT
)

CREATE TABLE GIAOHANG
(
	MAGH INT IDENTITY CONSTRAINT PK_MAGH PRIMARY KEY,
	MADH INT CONSTRAINT FK_MADH_DATHANG_GH FOREIGN KEY REFERENCES DATHANG(MADH),
	TENTAIXE NVARCHAR(50),
	NGAYGIAO DATE,
	DAGIAO BIT,
	DATHANHTOAN BIT
)

CREATE TABLE CHITIETDH
(
	MACTDH INT IDENTITY CONSTRAINT PK_MACTDH PRIMARY KEY,
	MADH INT CONSTRAINT FK_MADH_DATHANG_CTDH FOREIGN KEY REFERENCES DATHANG(MADH),
	MASP INT CONSTRAINT FK_MASP_SANPHAM_DH FOREIGN KEY REFERENCES SANPHAM(MASP),
	SL INT,
)

----------------------------------------------------------------------
INSERT INTO THE (SOTHE, TENNGANHANG, CHUTAIKHOAN)
VALUES ('11111111','Sacombank',N'Trần Văn A'),
('22222222','TPBank',N'Lê Văn B')
----------------------------------------------------------------------
INSERT INTO THUONGHIEU (TENTH)
VALUES ('Nike'), ('Puma'), ('Jordan'), ('Addidas'), ('Reebok'), ('Converse')
----------------------------------------------------------------------------------------------------
INSERT INTO NHACUNGCAP(TENNCC)
VALUES (N'Công ty cổ phần DS'), (N'Trung tâm thương mại Ns-Hefls'), (N'Công ty CTO')
----------------------------------------------------------------------------------------------------
INSERT INTO SANPHAM (TENSP, MATH, MANCC, MAUSAC, KICHCO, SL, MOTA, HINH, GIA)
VALUES ('Nike Waffle One SE', 1, 2, N'Đỏ', 40, 5, N'Mang đến một diện mạo mới cho phiên bản Waffle mang tính biểu tượng, thiết kế độc đáo cân bằng
mọi thứ bạn yêu thích nhất về loạt sản phẩm của Nike với những cải tiến mới mẻ', 'nike-waffle-one-se.jpg', 1200000),
('Nike Zoom Fly 5 Premium', 1, 2, N'Xám', 41, 19, N'Thu hẹp khoảng cách giữa thời gian tập luyện cuối tuần của bạn và cuộc đua ngày mai trong thiết kế bền bỉ này. 
Đây là bước ngoặt rực rỡ lấy cảm hứng từ những nhà sáng tạo thông qua kết nối.', 'nike-zoom-fly-5-premium.jpg', 2200000),
('Puma X Pokemon RS-X Pikachu', 2, 1, N'Vàng', 39, 12, N'RS-X Pikachu đến như một tia sét cho PUMA x POKÉMON. Hình bóng retro trong tương lai xuất hiện với màu vàng điện,
với đồ trang sức Pikachu và thương hiệu PUMA x POKÉMON đích thực.', 'puma-x-pokemon-rs-x-pikachu.jpg', 1500000),
('Puma RS-X Final Round Little Kid', 2, 2, N'Xám', 43, 10, N'Hình bóng RS-X cổ điển mà bạn từng thấy nay đã trở lại với diện mạo mới - một đường màu đơn giản với 
các điểm nhấn bắt mắt. Điểm nhấn của thiết kế này nằm ở các đốm hoạ tiết và đường sọc gân.', 'puma-rs-x-final-round-little-kid.jpg', 3300000),
('Air Jordan 1 Mid', 3, 1, N'Trắng', 38, 21, N'Mang phong cách thể thao và sự thoải mái cao cấp đến một cái nhìn mang tính biểu tượng, với lớp đệm dày dặn mang lại 
cho bạn một ngày mới năng động.', 'air-jordan-1-mid.jpg', 1700000),
('Jordan Jumpman Team II', 3, 1, N'Đỏ', 40, 7, N'Các miếng đệm phía trước giữ cho bạn thoải mái và hoạ tiết được làm nổi bật bởi các chi tiết mang tính biểu 
tượng của Jordan như tấm da lúm đồng tiền và viên ngọc logo Jumpman.', 'jordan-jumman-team-ii.jpg', 1200000),
('Addidas Court Stabil', 4, 2, N'Trắng', 44, 5, N'Chất lượng tốt nhất với mô cảm biến dưới đế, mô hình này thường được chọn bởi hầu hết các vận động viên chuyên
nghiệp vì nó là sản phẩm cao cấp nhất của Addidas.', 'addidas-court-stabil.jpg', 1700000),
('Addidas Continent 80', 4, 1, N'Hồng', 42, 8, N'Đôi giày này ghi lại tất cả những rung cảm cổ điển của những chiếc giày thể thao da cổ điển thập niên 80. 
Các cupsole cao su tách rời và lớp lót terry của Pháp tạo nêh hương vị hoài cổ.', 'addidas-continental-80-shoes.jpg', 2100000),
('Reebok Pump Omni Zone II', 5, 3, N'Trắng', 43, 10, N'Pump Omni Zone II là bản gốc được Brown mặc trong Dunk Contest 91. Đây chắc chắn là đôi giày thể thao nổi 
tiếng nhất của gia đình Reebok "Pump" được tạo ra vào cuối những năm 80.', 'reebok-pump-omi-zone-2.jpg', 1200000),
('Reebok Pump Omni Zone Retro', 5, 3, N'Trắng', 39, 11, N'Ra mắt vào những năm 90 và là một phần trong dòng sản phẩm "Pump" nổi tiếng của Reebok. Đôi giày thể thao 
bóng rổ này chống va đập tối ưu và đế ngoài bằng cao su với hoa văn xương cá.', 'reebok-pump-omi-zone-retro.jpg', 3100000),
('Converse Chuck Taylor All Star Extra', 6, 3, N'Trắng', 41, 13, N'Lấy cảm hứng từ vẻ ngoài mang tính biểu tượng của các ban nhạc nữ thập niên 90, những nền tảng này 
Chucks chắc chắn sẽ quay đầu. Canvas có thể tinh tế hoặc sắc sảo tùy thích, trong khi đế xếp chồng lên nhau sẽ đưa bạn lên cao hơn.', 'converse-chuck-taylor-all-star-extra.jpg', 2500000),
('Converse Chuck 70 Print', 6, 3, N'Đen', 40, 3, N'Cổ điển hàng ngày, đi kèm với bất kỳ trang phục nào đã trở lại để tạo ra một làn sóng mới. Lần này, biểu tượng 
giữ cho nó sự bóng bẩy với các hoạ tiết đốm lửa rực rỡ bắt mắt.', 'converse-chuck-70-print.jpg', 1300000)
----------------------------------------------------------------------------------------------------
INSERT INTO KHUYENMAI (TENKM, TRIGIA, NGAYBD, NGAYKT)
VALUES (N'Bão Sale', 200000,'1/10/2022','10/12/2022'),
(N'Siêu Sale', 100000,'12/11/2022','11/12/2022'),
(N'Black Friday', 500000,'20/11/2022','20/11/2022')
----------------------------------------------------------------------------------------------------
INSERT INTO NHANVIEN (TENNV, SDT, DIACHI, NGAYVAOLAM, LUONG)
VALUES(N'Trần Hiền Thảo', '0981777889', N'72 Bình Thạnh', '02/09/2022', 5000000),
(N'Đoàn Thị Phương Thảo', '0981733456', N'812 An Lạc', '08/02/2022', 6000000),
(N'Đặng Thế Nghĩa', '0912683342', N'2/182 Tân Phú', '10/03/2022', 7000000)
----------------------------------------------------------------------------------------------------
INSERT INTO KHACHHANG (HOTEN, SDT, DIACHI, MATHE)
VALUES(N'Trần Văn A', '0982673457', N'34 Chợ Bàn Cờ', 1),
(N'Lê Văn B', '0923765893', N'123 Âu Cơ', 2),
(N'Trần Văn C', '0953454634', N'3/122 Trung Chánh', NULL)
----------------------------------------------------------------------------------------------------
INSERT INTO DATHANG (MAKH, MAKM, NGAYDAT, GHICHU, HINHTHUCTHANHTOAN)
VALUES(1,1,'10/12/2022', N'Lần 1 mua hàng nè', N'Chuyển khoản')
----------------------------------------------------------------------------------------------------
INSERT INTO CHITIETDH (MADH, MASP, SL)
VALUES(1,3,1),
(1,1,1),
(1,2,1)
---------------------------------------------------------------------------------------------------
INSERT INTO GIAOHANG (MADH, TENTAIXE, NGAYGIAO)
VALUES(1, N'La Văn Nghị', '11/12/2022')
---------------------------------------------------------------------------------------------------
INSERT INTO THANHTOAN (MADH, NGAYTHANHTOAN)
VALUES (1, GETDATE())