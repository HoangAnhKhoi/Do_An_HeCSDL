﻿create database QLSuaChuaXe3
go
USE QLSuaChuaXe3
GO
----------------------------------------------
-------- ĐẶC TẢ ĐỀ TÀI QUẢN LÝ GARAGE --------
----------------------------------------------
CREATE TABLE USERS
(
	Username VARCHAR(20) CONSTRAINT PK_USERS PRIMARY KEY,
	Pass VARCHAR(20) NOT NULL,
	ChucVu NVARCHAR(30) NOT NULL,
)
go
CREATE TABLE TT_NGUOI
(
	NguoiID CHAR(6) CONSTRAINT PK_TT_NGUOI PRIMARY KEY,
	Hoten NVARCHAR(30) NOT NULL,
	DiaChi NVARCHAR(30),
	DienThoai CHAR(11) NOT NULL,
	NgaySinh DATE NOT NULL,
	CCCD CHAR(11) NOT NULL,
	GioiTinh BIT NOT NULL,
)
go
CREATE TABLE CHUCVU
(
	MaCV CHAR(6) CONSTRAINT PK_CHUCVU PRIMARY KEY,
	TenCV NVARCHAR(20) NOT NULL,
)
go
CREATE TABLE NHANVIEN
(
	NV_NguoiID CHAR(6) CONSTRAINT PK_NHANVIEN PRIMARY KEY FOREIGN KEY REFERENCES TT_NGUOI(NguoiID) ON DELETE CASCADE,
	MaCV CHAR(6) NOT NULL FOREIGN KEY REFERENCES CHUCVU(MaCV),
	Luong DECIMAL NOT NULL CHECK(Luong>0),
)
go
CREATE TABLE KHACHHANG
(
	KH_NguoiID CHAR(6) CONSTRAINT PK_KHACHHANG PRIMARY KEY FOREIGN KEY REFERENCES TT_NGUOI(NguoiID) ON DELETE CASCADE,
)
go
CREATE TABLE VATLIEU
(
	MaVL CHAR(6) CONSTRAINT PK_VATLIEU PRIMARY KEY,
	TenVL NVARCHAR(20) NOT NULL,
	SoLuong int NOT NULL
)
go
CREATE TABLE CONGVIEC
(
	MaCViec CHAR(6) CONSTRAINT PK_CONGVIEC PRIMARY KEY,
	NoiDungCV NVARCHAR(40) NOT NULL,
	TienCong DECIMAL NOT NULL CHECK(TienCong>0),
	VatLieu char(6) FOREIGN KEY REFERENCES VATLIEU(MaVL)
)
go
CREATE TABLE HOPDONG
(
	SoHD CHAR(15) CONSTRAINT PK_HOPDONG PRIMARY KEY,
	NgayHD DATE DEFAULT(GETDATE()),
	KH_NguoiID CHAR(6) NOT NULL FOREIGN KEY REFERENCES KHACHHANG(KH_NguoiID),
	SoXE CHAR(10) NOT NULL,
	TriGiaHD INT DEFAULT(0),
	NgayGiaoDuKien DATE, 
	NgayNghiemThu DATE

)
GO

CREATE TABLE HOPDONG_BACKUP
(
	SoHD CHAR(15) CONSTRAINT PK_HOPDONG_BU PRIMARY KEY,
	NgayHD DATE,
	KH_NguoiID CHAR(6),
	SoXE CHAR(10) NOT NULL,
	TriGiaHD INT,
	NgayGiaoDuKien DATE, 
	NgayNghiemThu DATE
)
go

CREATE TABLE HOADON
(
	MaHoaDon CHAR(15) CONSTRAINT PK_HOADON PRIMARY KEY,
	NgayLapHoaDon DATE DEFAULT(GETDATE()),
	MaHopDong CHAR(15) NOT NULL FOREIGN KEY REFERENCES HOPDONG(SoHD),
	KH_NguoiID CHAR(6) NOT NULL FOREIGN KEY REFERENCES KHACHHANG(KH_NguoiID),
	HoTen NVARCHAR(40) NOT NULL, 
	SoTienThu INT NOT NULL CHECK(SoTienThu>0),
	CONSTRAINT fk_HDon_SoHD FOREIGN KEY (MaHopDong)  REFERENCES HOPDONG (SoHD)ON DELETE CASCADE
)
go
CREATE TABLE CHITIET_HD
(
	SoHD CHAR(15) FOREIGN KEY REFERENCES HOPDONG(SoHD),
	MaCV CHAR(6) NOT NULL FOREIGN KEY REFERENCES CONGVIEC(MaCViec),
	TriGiaCV INT NOT NULL CHECK(TriGiaCV>0),
	MaNV CHAR(6) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(NV_NguoiID),
	CONSTRAINT PK_CHITIET_HD PRIMARY KEY(SoHD,MaCV),
	CONSTRAINT fk_CTHD_SoHD FOREIGN KEY (SoHD)  REFERENCES HOPDONG (SoHD)ON DELETE CASCADE
)
GO
CREATE TABLE CHITIET_HD_BACKUP
(
	SoHD CHAR(15) FOREIGN KEY REFERENCES HOPDONG_BACKUP(SoHD),
	MaCV CHAR(6) NOT NULL,
	TriGiaCV INT NOT NULL,
	MaNV CHAR(6) NOT NULL,
	CONSTRAINT PK_CHITIET_HD_BU PRIMARY KEY(SoHD,MaCV)
)
go
CREATE TABLE NHACUNGCAP
(
	MaNhaCC CHAR(6) CONSTRAINT PK_NHACUNGCAP PRIMARY KEY,
	TenNhaCC NVARCHAR(30) NOT NULL,
	DienThoai CHAR(11),
	DiaChi NVARCHAR(30),
)
go
CREATE TABLE NHAPKHO
(
	MaNKho CHAR(15) CONSTRAINT PK_NHAPKHO PRIMARY KEY,
	MaVL CHAR(6) FOREIGN KEY REFERENCES VATLIEU(MaVL),
	MaNhaCC CHAR(6) NOT NULL FOREIGN KEY REFERENCES NHACUNGCAP(MaNhaCC),
	SoLuong INT,
	GiaTri DECIMAL,
	NgayNhap DATE DEFAULT(GETDATE()),
	MaNV CHAR(6) FOREIGN KEY REFERENCES NHANVIEN(NV_NguoiID)
)