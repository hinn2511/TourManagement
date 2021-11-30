--Chay dong` nay dau` tien
CREATE DATABASE tourmanagement

--Chay dong` nay tiep theo 
USE tourmanagement

DROP DATABASE tourmanagement

--Chay het cac dong` con` lai
CREATE TABLE Tour (
    Id int IDENTITY(1,1) PRIMARY KEY,
    TenTour nvarchar(50) NOT NULL,
    DacDiem nvarchar(255),
	GiaTour_Id int,
    LoaiTour_Id int NOT NULL
);

CREATE TABLE GiaTour (
    Id int IDENTITY(1,1) PRIMARY KEY,
    NgayBatDau date NOT NULL,
    NgayKetThuc date NOT NULL,
	Gia decimal(18,0) NOT NULL,
	DangApDung bit NOT NULL,
	Tour_Id int
);

CREATE TABLE LoaiTour (
    Id int IDENTITY(1,1) PRIMARY KEY,
    TenLoai nvarchar(50) NOT NULL,
);

CREATE TABLE DiaDiem (
    Id int IDENTITY(1,1) PRIMARY KEY,
    TenDiaDiem nvarchar(50) NOT NULL,
);

CREATE TABLE ThamQuan (
    Tour_Id int NOT NULL,
    DiaDiem_Id int NOT NULL,
	ThuTu int NOT NULL,
	CONSTRAINT PK_ThamQuan PRIMARY KEY (Tour_Id,DiaDiem_Id)
);

CREATE TABLE DoanDuLich (
    Id int IDENTITY(1,1) PRIMARY KEY,
	TenDoanDuLich nvarchar(50) NOT NULL,
    Tour_Id int NOT NULL,
	NgayKhoiHanh date NOT NULL,
    NgayKetThuc date NOT NULL,
    DoanhThu decimal(18,0) NOT NULL,
);

CREATE TABLE NoiDungTour (
    DoanDuLich_Id int PRIMARY KEY,
    HanhTrinh nvarchar(255) NOT NULL,
	KhachSan nvarchar(255) NOT NULL,
    DiaDiem nvarchar(255) NOT NULL,
);

CREATE TABLE KhachHang (
    Id int IDENTITY(1,1) PRIMARY KEY,
    HoTen nvarchar(50) NOT NULL,
    CMND nvarchar(10),
	DiaChi nvarchar(10),
    GioiTinh nvarchar(10),
	SDT nvarchar(10),
	QuocTich nvarchar(10),
);

CREATE TABLE ChiTietDoan (
    KhachHang_Id int NOT NULL,
	DoanDuLich_Id int NOT NULL,
    CONSTRAINT PK_ChiTietDoan PRIMARY KEY (KhachHang_Id,DoanDuLich_Id)
);

CREATE TABLE NhanVien (
    Id int IDENTITY(1,1) PRIMARY KEY,
    HoTen nvarchar(50) NOT NULL,
);

CREATE TABLE PhanCong (
    NhanVien_Id int NOT NULL,
	DoanDuLich_Id int NOT NULL,
	NhiemVu nvarchar(50) NOT NULL,
    CONSTRAINT PK_PhanCong PRIMARY KEY (NhanVien_Id,DoanDuLich_Id)
);

CREATE TABLE ChiPhi (
    Id int IDENTITY(1,1) PRIMARY KEY,
    DoanDuLich_Id int NOT NULL,
    SoTien decimal(18,0) NOT NULL,
	LoaiChiPhi_Id int NOT NULL,
);

CREATE TABLE LoaiChiPhi (
    Id int IDENTITY(1,1) PRIMARY KEY,
    TenLoai nvarchar(50) NOT NULL,
);

ALTER TABLE Tour
ADD FOREIGN KEY (LoaiTour_Id) REFERENCES LoaiTour(Id) ON DELETE CASCADE;

ALTER TABLE ThamQuan
ADD FOREIGN KEY (Tour_Id) REFERENCES Tour(Id) ON DELETE CASCADE;

ALTER TABLE ThamQuan
ADD FOREIGN KEY (DiaDiem_Id) REFERENCES DiaDiem(Id) ON DELETE CASCADE;

ALTER TABLE GiaTour
ADD FOREIGN KEY (Tour_Id) REFERENCES Tour(Id) ON DELETE CASCADE;

ALTER TABLE DoanDuLich
ADD FOREIGN KEY (Tour_Id) REFERENCES Tour(Id) ON DELETE CASCADE;

ALTER TABLE NoiDungTour
ADD FOREIGN KEY (DoanDuLich_Id) REFERENCES DoanDuLich(Id) ON DELETE CASCADE;

ALTER TABLE ChiTietDoan
ADD FOREIGN KEY (DoanDuLich_Id) REFERENCES DoanDuLich(Id) ON DELETE CASCADE;

ALTER TABLE ChiTietDoan
ADD FOREIGN KEY (KhachHang_Id) REFERENCES KhachHang(Id) ON DELETE CASCADE;

ALTER TABLE PhanCong
ADD FOREIGN KEY (NhanVien_Id) REFERENCES NhanVien(Id) ON DELETE CASCADE;

ALTER TABLE PhanCong
ADD FOREIGN KEY (DoanDuLich_Id) REFERENCES DoanDuLich(Id) ON DELETE CASCADE;

ALTER TABLE ChiPhi
ADD FOREIGN KEY (DoanDuLich_Id) REFERENCES DoanDuLich(Id) ON DELETE CASCADE;

ALTER TABLE ChiPhi
ADD FOREIGN KEY (LoaiChiPhi_Id) REFERENCES LoaiChiPhi(Id);

INSERT INTO LoaiTour(TenLoai)
VALUES (N'Du lịch biển');
INSERT INTO LoaiTour(TenLoai)
VALUES (N'Du lịch núi');

--INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, DangApDung)
--VALUES ('2021-11-20', '2021-08-20', 3000000, 0);
--INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, DangApDung)
--VALUES ('2021-12-15', '2021-12-30', 2000000, 0);

--INSERT INTO Tour (TenTour, DacDiem, GiaTour_Id, LoaiTour_Id)
--VALUES (N'Vũng Tàu', N'Biển', 1, 1);
--INSERT INTO Tour (TenTour, DacDiem, GiaTour_Id, LoaiTour_Id)
--VALUES (N'Đà Lạt', N'Núi', 1, 2);
--INSERT INTO Tour (TenTour, DacDiem, GiaTour_Id, LoaiTour_Id)
--VALUES (N'Nha Trang', N'Biển', 2, 1);

INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, DangApDung)
VALUES ('2021-11-20', '2021-08-20', 45000000, 0);


--SELECT t.Id, t.TenTour, t.DacDiem, lt.TenLoai, gt.NgayBatDau, gt.NgayKetThuc, gt.Gia 
--FROM Tour t, GiaTour gt, LoaiTour lt
--WHERE t.GiaTour_Id = gt.Id AND t.LoaiTour_Id = lt.Id
