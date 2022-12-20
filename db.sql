create database DBShoes 
use DBShoes 

SET DATEFORMAT DMY

CREATE TABLE LOAIKH
(
	MALKH INT IDENTITY CONSTRAINT PK_MALKH PRIMARY KEY,
	TENLKH NVARCHAR(50)
)
CREATE TABLE KHACHHANG 
(
	MAKH INT IDENTITY CONSTRAINT PK_MAKH PRIMARY KEY,
	HOTEN NVARCHAR(50),
	SDT CHAR(10),
	DIACHI NVARCHAR(50),
	MALKH INT CONSTRAINT FK_MALKH_LOAIKH FOREIGN KEY REFERENCES LOAIKH(MALKH)
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
	TENTH VARCHAR (20)
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

CREATE TABLE TAIXE
(
	MATX INT IDENTITY CONSTRAINT PK_MATX PRIMARY KEY,
	TENTX NVARCHAR(50),
	SDT CHAR(10),
	LUONG INT
)

CREATE TABLE GIAOHANG
(
	MAGH INT IDENTITY CONSTRAINT PK_MAGH PRIMARY KEY,
	MATX INT CONSTRAINT FK_MATX_TAIXE FOREIGN KEY REFERENCES TAIXE(MATX),
	NGAYGIAO DATE,
	NGAYHOANTHANH DATE
)

CREATE TABLE DATHANG
(
	MADH INT IDENTITY CONSTRAINT PK_MADH PRIMARY KEY,
	MAKH INT CONSTRAINT FK_MAKH_KHACHHANG FOREIGN KEY REFERENCES KHACHHANG(MAKH),
	MAKM INT CONSTRAINT FK_MAKM_KHUYENMAI FOREIGN KEY REFERENCES KHUYENMAI(MAKM),
	MAGH INT CONSTRAINT FK_MAGH_GIAOHANG FOREIGN KEY REFERENCES GIAOHANG(MAGH),
	SOTHE CHAR(12),
	NGAYDAT DATE,
	GHICHU NVARCHAR(50),
	DATHANHTOAN BIT
)

CREATE TABLE HOADON
(
	MAHD INT CONSTRAINT PK_MAHD PRIMARY KEY CONSTRAINT FK_MADH_DATHANG_HD FOREIGN KEY REFERENCES DATHANG(MADH),
	MANV INT CONSTRAINT FK_MANV_NHANVIEN FOREIGN KEY REFERENCES NHANVIEN(MANV),
	NGAYLAPHD DATE
)

CREATE TABLE CHITIETDH
(
	MACTDH INT IDENTITY CONSTRAINT PK_MACTDH PRIMARY KEY,
	MADH INT CONSTRAINT FK_MADH_DATHANG FOREIGN KEY REFERENCES DATHANG(MADH),
	MASP INT CONSTRAINT FK_MASP_SANPHAM_DH FOREIGN KEY REFERENCES SANPHAM(MASP),
	SL INT,
)	

CREATE TABLE DANHGIA
(
	MADG INT IDENTITY CONSTRAINT PK_MADG PRIMARY KEY CONSTRAINT FK_MADG_CTDH FOREIGN KEY REFERENCES CHITIETDH(MACTDH),
	NGAYDG DATE,
	TILE INT CHECK(TILE > 0 AND TILE < 6),
	DANHGIA NVARCHAR(200)
)

CREATE TABLE CATRUC
(
	MACT INT IDENTITY CONSTRAINT PK_MACT PRIMARY KEY,
	BUOI NVARCHAR(10),
	GIOBD INT,
	GIOKT INT
)

CREATE TABLE CHITIETCT
( 
	MACTCT INT IDENTITY CONSTRAINT PK_MACTCT PRIMARY KEY,
	MACT INT CONSTRAINT FK_MACT_CATRUC FOREIGN KEY REFERENCES CATRUC(MACT),
	MANV INT CONSTRAINT FK_MANV_NHANVIEN_CTCT FOREIGN KEY REFERENCES NHANVIEN(MANV)
)
-------------------------------------------------------------------------------
INSERT INTO THUONGHIEU (TENTH)
VALUES ('Nike'), ('Puma'), ('Jordan'), ('Addidas'), ('Reebok'), ('Converse')
----------------------------------------------------------------------------------------------------
INSERT INTO NHACUNGCAP(TENNCC)
VALUES (N'Công ty cổ phần DS'), (N'Trung tâm thương mại Ns-Hefls'), (N'Công ty CTO'), (N'Trung tâm thương mại NDS'), (N'Công ty Suow'), (N'Cửa hàng chuyên cung cấp giày Noáde')
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
giữ cho nó sự bóng bẩy với các hoạ tiết đốm lửa rực rỡ bắt mắt.', 'converse-chuck-70-print.jpg', 1300000),
('Reebok Maison Margiela', 5, 2, N'Đen', 42, 5, N'Sự hợp tác mới nhất của Maison Margiela x Reebok giới thiệu một loạt các tác phẩm kinh điển của Reebok thông qua mã chữ ký hồi 
ức một thời của Maison Margiela', 'reebok-maison-margiela.jpg', 1400000),
('Adidas Wander Terrex Hiker', 4, 3, N'Xám', 41, 6, N'Ra mắt đầu năm 2020 với một dáng hình truyền thống pha lẫn nét phá cách độc đáo cùng thiết kế tinh tế, hứa hẹn sẽ đem lại 
trải nghiệm hoàn toàn mới lạ','adidas-wander-terrex-hiker.jpg', 2000000),
('Nike Techloom Zipline', 1, 2, N'Đen', 40, 4, N'Phiên bản Techloom với thiết kế vượt trội bứt phá mọi giới hạn nhận thức từ những bộ óc tư duy sáng tạo độc đáo nhất','nike-techloom-zipline.jpg', 2350000)
----------------------------------------------------------------------------------------------------
INSERT INTO KHUYENMAI (TENKM, TRIGIA, NGAYBD, NGAYKT)
VALUES (N'Bão Sale', 300000,'1/10/2022','10/12/2022'),
(N'Siêu Sale', 400000,'12/11/2022','11/12/2022'),
(N'Black Friday', 500000,'20/11/2022','20/11/2022')
----------------------------------------------------------------------------------------------------
INSERT INTO LOAIKH (TENLKH)
VALUES (N'Bình dân'), (N'Trung cấp'), (N'Cao cấp')
----------------------------------------------------------------------------------------------------
INSERT INTO NHANVIEN (TENNV, SDT, DIACHI, NGAYVAOLAM, LUONG)
VALUES(N'Trần Hiền Thảo', '0981777889', N'72 Bình Thạnh', '02/09/2022', 5000000),
(N'Đoàn Thị Phương Thảo', '0981733456', N'812 An Lạc', '08/02/2022', 6000000),
(N'Đặng Thế Nghĩa', '0912683342', N'2/182 Tân Phú', '10/03/2022', 7000000)
----------------------------------------------------------------------------------------------------
INSERT INTO CATRUC (BUOI, GIOBD, GIOKT)
VALUES (N'Sáng', 7, 11),
(N'Trưa', 13, 17),
(N'Tối', 18, 22)
----------------------------------------------------------------------------------------------------
INSERT INTO CHITIETCT (MACT, MANV)
VALUES (1,1), (1,2), (1,3),
(2,1), (2,3),
(3,2), (3,3)
----------------------------------------------------------------------------------------------------
INSERT INTO KHACHHANG (HOTEN, SDT, DIACHI, MALKH)
VALUES(N'Trần Văn A', '0982673457', N'34 Chợ Bàn Cờ', 1),
(N'Lê Văn B', '0923765893', N'123 Âu Cơ', 2),
(N'Trần Văn C', '0953454634', N'3/122 Trung Chánh', 3)
-----------------------------------------------------------------------------------------------------
INSERT INTO TAIXE (TENTX, SDT, LUONG)
VALUES(N'Cao Văn Lực', 0923525259, 1000000),
(N'Nguyễn Thiện Thuận', 0938958742, 700000),
(N'Yên Văn Bá', 0939857293, 700000),
(N'Đỗ Cao Nhân', 0983756642, 800000)
-----------------------------------------------------------------------------------------------------
INSERT INTO GIAOHANG (MATX, NGAYGIAO, NGAYHOANTHANH)
VALUES(1,'12/12/2022', NULL),
(2,'12/12/2022', NULL)
-----------------------------------------------------------------------------------------------------
INSERT INTO DATHANG (MAKH, MAKM, MAGH, SOTHE, NGAYDAT, GHICHU, DATHANHTOAN)
VALUES(1,1,1,NULL,'10/12/2022',N'Test',1),
(2,2,2,NULL,'11/12/2022',N'Lần 2 nè', 0)
-----------------------------------------------------------------------------------------------------
INSERT INTO CHITIETDH (MADH, MASP, SL)
VALUES(1,1,2),
(1,2,1), (1,4,2),
(1,5,1), (1,12,1),
(2,10,1), (2,8,2),
(2,14,1)
-----------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------
-----1. Xem họ tên và ngày vào làm theo mã nhân viên
CREATE PROC SP_NHANVIEN @MANV INT
AS
BEGIN
	IF EXISTS (SELECT * FROM NHANVIEN WHERE @MANV = MANV)
	BEGIN
		SELECT TENNV, NGAYVAOLAM
		FROM NHANVIEN
		WHERE MANV = @MANV
	END
END
-----------------------------------------------------------------------------------------------------
-----2. Không cho phép xoá những sản phẩm đã được đặt hàng
CREATE TRIGGER TR_XOASANPHAM ON SANPHAM FOR DELETE 
AS
BEGIN
	DECLARE @MASP INT, @COUNT INT
	SELECT @COUNT = COUNT(*) FROM deleted D, CHITIETDH CTDH
	WHERE D.MASP = CTDH.MASP
	IF (@COUNT > 0)
		BEGIN
			PRINT N'Không thể xoá sản phẩm'
			ROLLBACK TRAN
		END
END

-----3. Cập nhật tổng tiền đặt hàng và lưu vào bảng tạm
CREATE TABLE ##TEMP_TB (MADH INT, TONGTIEN INT)
DECLARE CR_UPDTT CURSOR FOR SELECT MADH FROM DATHANG
OPEN CR_UPDTT
DECLARE @MADH INT, @TONGTIEN INT, @MAKM INT, @NGAYDAT DATE, @NGAYBD DATE, @NGAYKT DATE
FETCH NEXT FROM CR_UPDTT INTO @MADH
WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT @MADH = DH.MADH, @TONGTIEN = SUM(GIA*CT.SL)
		FROM SANPHAM SP, CHITIETDH CT, DATHANG DH, KHUYENMAI KM
		WHERE SP.MASP = CT.MASP AND DH.MADH = CT.MADH AND DH.MADH = @MADH
		GROUP BY DH.MADH

		SELECT @NGAYDAT =  NGAYDAT, @MAKM = DH.MAKM
		FROM KHUYENMAI KM, DATHANG DH
		WHERE DH.MADH = @MADH AND KM.MAKM = DH.MAKM

		SELECT @NGAYBD = NGAYBD, @NGAYKT = NGAYKT
		FROM KHUYENMAI
		WHERE MAKM = @MAKM

		IF(@NGAYDAT BETWEEN @NGAYBD AND @NGAYKT)
		BEGIN
			SELECT @TONGTIEN = @TONGTIEN - TRIGIA
			FROM KHUYENMAI
			WHERE MAKM = @MAKM
		END

		INSERT INTO ##TEMP_TB VALUES (@MADH, @TONGTIEN)
		FETCH NEXT FROM CR_UPDTT INTO @MADH
	END
CLOSE CR_UPDTT
DEALLOCATE CR_UPDTT

SELECT * FROM ##TEMP_TB
------------------------------------------------------------------------
-----4. Đọc danh sách khách hàng
CREATE FUNCTION FUNC_DSKHACHHANG()
RETURNS TABLE
AS RETURN
	SELECT *
	FROM KHACHHANG  
GO
select * from FUNC_DSKHACHHANG()
-----------------------------------------------------------------------------------------------------
-----5. Tự động cập nhật lại ngày hoàn thành khi đơn đặt hàng ở trạng thái đã thanh toán
DECLARE CR_UPDPAY CURSOR FOR SELECT MAGH FROM GIAOHANG
OPEN CR_UPDPAY
DECLARE @MAGH INT, @DATHANHTOAN BIT, @NGAYHOANTHANH DATE, @SOTHE CHAR(12)
FETCH NEXT FROM CR_UPDPAY INTO @MAGH
WHILE @@FETCH_STATUS =0
	BEGIN
		SELECT @DATHANHTOAN = DATHANHTOAN, @NGAYHOANTHANH = NGAYHOANTHANH, @SOTHE = SOTHE
		FROM GIAOHANG G, DATHANG H
		WHERE H.MAGH = G.MAGH AND G.MAGH = @MAGH
		IF(@DATHANHTOAN = 1 AND @SOTHE IS NULL) 
			BEGIN
				UPDATE GIAOHANG SET NGAYHOANTHANH = GETDATE() WHERE MAGH = @MAGH
			END
		IF(@DATHANHTOAN = 0 OR @DATHANHTOAN IS NULL) 
			BEGIN
				UPDATE GIAOHANG SET NGAYHOANTHANH = NULL WHERE MAGH = @MAGH
			END
		FETCH NEXT FROM CR_UPDPAY INTO @MAGH
	END
CLOSE CR_UPDPAY
DEALLOCATE CR_UPDPAY

SELECT * FROM GIAOHANG
-----------------------------------------------------------------------------------------------------
-----6. Kiểm tra tính hợp lệ của ngày hoàn thành giao hàng 
CREATE TRIGGER TRG_GIAOHANG ON GIAOHANG
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @NGAYGIAO DATE, @NGAYHOANTHANH DATE
	SELECT @NGAYGIAO = G.NGAYGIAO, @NGAYHOANTHANH = I.NGAYHOANTHANH
	FROM inserted I, GIAOHANG G 
	WHERE I.MAGH = G.MAGH
	IF (@NGAYGIAO > @NGAYHOANTHANH)
		PRINT N'Ngày hoàn thành không được nhỏ hơn ngày giao'
	ROLLBACK TRAN
END
-----------------------------------------------------------------------------------------------------
-----7. Giá tiền sản phẩm phải luôn dương
CREATE TRIGGER TRG_GIATIEN ON SANPHAM
FOR INSERT
AS
BEGIN
	DECLARE @GIATIEN INT
	SELECT @GIATIEN = GIA
	FROM inserted I
	IF (@GIATIEN < 0)
		PRINT N'Giá tiền của sản phẩm không hợp lệ'
	ROLLBACK TRAN
END 
-----------------------------------------------------------------------------------------------------
-----8. Trị giá của khuyến mãi phải luôn dương
CREATE TRIGGER TRG_TRIGIA ON KHUYENMAI
FOR INSERT
AS
BEGIN
	DECLARE @TRIGIA INT
	SELECT @TRIGIA = TRIGIA
	FROM inserted I
	IF (@TRIGIA < 0)
		PRINT N'Trị giá khuyến mãi không hợp lệ'
	ROLLBACK TRAN
END
