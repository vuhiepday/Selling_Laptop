CREATE DATABASE QL_CUAHANG;
USE QL_CUAHANG;
-- Tạo bảng NSX (Nhà sản xuất)
CREATE TABLE NSX (
    MaNSX VARCHAR(50) PRIMARY KEY,
    TenNSX NVARCHAR(50)
);

-- Tạo bảng SANPHAM (Sản phẩm)
CREATE TABLE SANPHAM (
    MaSP VARCHAR(50) PRIMARY KEY,
    TenSP NVARCHAR(50),
    SoLuong INT,
    ChiTiet TEXT,
    Anh VARCHAR(50),
    GiaBan DECIMAL(15, 2),
	MaNSX VARCHAR(50),
	FOREIGN KEY (MaNSX) REFERENCES NSX(MaNSX)
);

-- Tạo bảng NHANVIEN (Nhân viên)
CREATE TABLE NHANVIEN (
    MaNV VARCHAR(50) PRIMARY KEY,
    TenNV NVARCHAR(50),
    GioiTinh NVARCHAR(10),
    DiaChi NVARCHAR(100),
    SDT VARCHAR(15)
);

-- Tạo bảng KHACH (Khách hàng)
CREATE TABLE KHACH (
    MaKhach VARCHAR(50) PRIMARY KEY,
    TenKhach NVARCHAR(50) NOT NULL,
    TENDN VARCHAR(100) NOT NULL,
    MATKHAU VARCHAR(30) NOT NULL,
	SDT VARCHAR(15),
    NGAYSINH DATE,
    EMAIL VARCHAR(50),
    DIACHI NVARCHAR(100)
);

-- Tạo bảng HOADON (Hóa đơn)
CREATE TABLE HOADON (
    MaHoaDon VARCHAR(50) PRIMARY KEY,
    MaKhach VARCHAR(50),
    TongTien DECIMAL(15, 2),
    FOREIGN KEY (MaKhach) REFERENCES KHACH(MaKhach)
);

-- Tạo bảng CHITIETHOADON (Chi tiết hóa đơn)
CREATE TABLE CHITIETHOADON (
    MaHoaDon VARCHAR(50),
    MaSP VARCHAR(50),
    SoLuong INT,
    DonGia DECIMAL(15, 2),
    ThanhTien DECIMAL(15, 2),
    PRIMARY KEY (MaHoaDon, MaSP),
    FOREIGN KEY (MaHoaDon) REFERENCES HOADON(MaHoaDon),
    FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
);
CREATE TABLE TK_ADMIN(
	MaNV VARCHAR(50),
	TAIKHOAN VARCHAR(50),
	MATKHAU VARCHAR(50),
	PRIMARY KEY (MaNV, TAIKHOAN),
	FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);
-- Nạp dữ liệu vào bảng NSX (Nhà sản xuất)
INSERT INTO NSX (MaNSX, TenNSX)
VALUES
    ('NSX001', 'Samsung'),
    ('NSX002', 'Apple'),
    ('NSX003', 'Sony'),
	('NSX004', 'LG'),
    ('NSX005', 'Huawei'),
	('NSX006', 'Google'),
    ('NSX007', 'OnePlus'),
    ('NSX008', 'Xiaomi'),
    ('NSX009', 'Asus'),
    ('NSX010', 'Motorola');

-- Nạp dữ liệu vào bảng SANPHAM (Sản phẩm)
-- Nạp dữ liệu vào bảng SANPHAM (cửa hàng bán laptop)
INSERT INTO SANPHAM (MaSP, TenSP, SoLuong, ChiTiet, Anh, GiaBan, MaNSX)
VALUES
    ('SP001', 'Laptop Gaming Asus ROG Strix G15', 10, N'Laptop siêu mỏng và nhẹ, màn hình 13 inch', 'SanPham5.jpg', 1499.99, 'NSX009'),
    ('SP002', 'Laptop HP Spectre x360', 15, N'Laptop 2 trong 1 với màn hình cảm ứng xoay 360 độ', 'SanPham2.jpg', 1299.99, 'NSX009'),
    ('SP003', 'Laptop Apple MacBook Air', 20, N'Laptop siêu mỏng, hiệu suất cao', 'SanPham3.jpg', 999.99, 'NSX002'),
    ('SP004', 'Laptop Lenovo ThinkPad X1 Carbon', 8, N'Laptop doanh nhân chất lượng cao', 'SanPham4.jpg', 1599.99, 'NSX006'),
    ('SP005', 'Laptop Asus ROG Zephyrus G14', 12, N'Laptop gaming mỏng nhẹ và mạnh mẽ', 'SanPham5.jpg', 1299.99, 'NSX009'),
	('SP006', 'Laptop Lenovo ThinkPad X1 Carbon', 10, N'Laptop siêu nhẹ với màn hình 14 inch', 'SanPham6.jpg', 899.99, 'NSX009'),
    ('SP007', 'Laptop Gaming HP VICTUS 15-fa1086TX 8C5M3PA', 12, N'Laptop mỏng nhẹ với hiệu suất cao', 'SanPham7.jpg', 1099.99, 'NSX009'),
    ('SP008', 'Laptop Gaming Asus ROG Strix G15 G513RC-HN038W', 18, N'Laptop giá trị với màn hình lớn', 'SanPham8.jpg', 799.99, 'NSX001'),
    ('SP009', 'Laptop Gaming Acer Nitro 5 Eagle AN515-57-54MV', 15, N'Laptop sang trọng và mỏng nhẹ', 'SanPham9.jpg', 1199.99, 'NSX002'),
    ('SP010', 'Laptop Lenovo Yoga C930', 10, N'Laptop 2 trong 1 với màn hình cảm ứng 4K', 'SanPham10.png', 1299.99, 'NSX006'),
    ('SP011', 'Laptop Microsoft Surface Laptop 4', 10, N'Laptop cao cấp với màn hình PixelSense', 'SanPham11.jpg', 1399.99, 'NSX006'),
    ('SP012', 'Laptop ASUS ROG Strix Scar 17', 5, N'Laptop gaming mạnh mẽ với màn hình 17 inch', 'SanPham12.jpg', 1799.99, 'NSX008'),
    ('SP013', 'Laptop Acer Predator Helios 300', 8, N'Laptop gaming với hiệu suất tốt', 'SanPham13.jpg', 1299.99, 'NSX009'),
    ('SP014', 'Laptop MSI GS66 Stealth', 7, N'Laptop gaming siêu mỏng và siêu nhẹ', 'SanPham14.jpg', 1599.99, 'NSX003'),
    ('SP015', 'Laptop Acer Predator Helios 300', 9, N'Laptop gaming với thiết kế mạnh mẽ', 'SanPham5.jpg', 1699.99, 'NSX006'),
    ('SP016', 'Laptop ASUS ROG Strix Scar 17', 6, N'Laptop siêu nhẹ với màn hình 17 inch', 'SanPham2.jpg', 1199.99, 'NSX004'),
    ('SP017', 'Laptop Huawei MateBook X Pro', 11, N'Laptop mỏng nhẹ với màn hình tái tạo 3K', 'SanPham3.jpg', 1399.99, 'NSX005'),
    ('SP018', 'Laptop Google Pixelbook Go', 14, N'Laptop Chromebook mỏng nhẹ', 'SanPham4.jpg', 899.99, 'NSX006'),
    ('SP019', 'Laptop Huawei MateBook X Pro', 10, N'Laptop cao cấp với hiệu suất cao', 'SanPham5.jpg', 1299.99, 'NSX007'),
    ('SP020', 'Laptop Xiaomi Mi Notebook Pro', 8, N'Laptop giá trị với hiệu suất cao', 'SanPham6.jpg', 999.99, 'NSX008'),
	('SP021', 'Laptop Huawei MateBook X Pro', 6, N'Laptop cao cấp với thiết kế sang trọng', 'SanPham7.jpg', 1299.99, 'NSX003');



-- Nạp dữ liệu vào bảng NHANVIEN (Nhân viên)
INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, DiaChi, SDT)
VALUES
    ('NV001', N'Nguyễn Văn A', N'Nam',N'123 Đường ABC, TP.HCM', '0901234567'),
    ('NV002', N'Trần Thị B', N'Nữ', N'456 Đường XYZ, TP.HCM', '0909876543'),
	('NV003', N'Phạm Thị E', N'Nữ', N'789 Đường MNO, TP.HCM', '0901111222')

INSERT INTO TK_ADMIN(MaNV, TAIKHOAN, MATKHAU)
VALUES
	('NV001','admin1','admin1'),
	('NV002','admin2','admin2')

-- Nạp dữ liệu vào bảng KHACH (Khách hàng)
INSERT INTO KHACH (MaKhach, TenKhach, TENDN, MATKHAU, SDT, NGAYSINH, EMAIL, DIACHI) VALUES
    ('KH001', N'Lê Minh C', 'leminhc', 'password1', '0912345678', '1990-01-15', 'leminhc@example.com', N'123 Đường A, Quận X, Thành phố Y'),
    ('KH002', N'Nguyễn Thanh D', 'nguyenthanhd', 'password2', '0987654321', '1985-05-20', 'nguyenthanhd@example.com', N'456 Đường B, Quận Y, Thành phố Z'),
    ('KH003', N'Vũ Minh M', 'vuminhm', 'password3', '0913456789', '1995-09-10', 'vuminhm@example.com', N'789 Đường C, Quận Z, Thành phố X'),
    ('KH004', N'Phan Thanh N', 'phanthanhn', 'password4', '0988765432', '1980-03-25', 'phanthanhn@example.com', N'101 Đường D, Quận X, Thành phố Y'),
    ('KH005', N'Trần Văn O', 'tranvano', 'password5', '0911111222', '1992-12-03', 'tranvano@example.com', N'202 Đường E, Quận Z, Thành phố Y'),
    ('KH006', N'Nguyễn Thị P', 'nguyenthip', 'password6', '0988888777', '1998-06-18', 'nguyenthip@example.com', N'303 Đường F, Quận Y, Thành phố Z'),
    ('KH007', N'Lê Văn Q', 'levanq', 'password7', '0912345678', '1988-08-08', 'levanq@example.com', N'404 Đường G, Quận Z, Thành phố X');

-- Nạp dữ liệu vào bảng HOADON (Hóa đơn)
INSERT INTO HOADON (MaHoaDon, MaKhach, TongTien)
VALUES
    ('HD001', 'KH001', 1999.99),
    ('HD002', 'KH002', 1599.99),
	('HD003', 'KH003', 1799.99),
    ('HD004', 'KH004', 2099.99),
    ('HD005','KH005', 1399.99),
    ('HD006',  'KH006', 999.99),
    ('HD007', 'KH007', 1899.99);

-- Nạp dữ liệu vào bảng CHITIETHOADON (Chi tiết hóa đơn)
INSERT INTO CHITIETHOADON (MaHoaDon, MaSP, SoLuong, DonGia, ThanhTien)
VALUES
    ('HD001', 'SP001', 2, 999.99, 2000.00),
    ('HD002', 'SP002', 1, 1099.99, 1099.99),
	('HD003', 'SP003', 3, 799.99, 2399.97),
    ('HD004', 'SP004', 2, 699.99, 1399.98),
    ('HD005', 'SP005', 1, 799.99, 799.99),
    ('HD006', 'SP006', 1, 799.99, 799.99),
    ('HD007', 'SP007', 2, 899.99, 1799.98)

select * from NSX;
select * from NHANVIEN;
select * from SANPHAM;
select * from HOADON;
select * from CHITIETHOADON;
select * from KHACH;
select * from TK_ADMIN;
    