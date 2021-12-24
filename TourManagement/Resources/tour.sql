DROP DATABASE tourmanagement

--Chay dong` nay dau` tien
CREATE DATABASE tourmanagement

--Chay dong` nay tiep theo 
USE tourmanagement


--Chay het cac dong` con` lai
CREATE TABLE Tour (
    Id int IDENTITY(1,1) PRIMARY KEY,
    TenTour nvarchar(50) NOT NULL,
    DacDiem nvarchar(255),
    LoaiTour_Id int NOT NULL
);

CREATE TABLE GiaTour (
    Id int IDENTITY(1,1) PRIMARY KEY,
    NgayBatDau date NOT NULL,
    NgayKetThuc date NOT NULL,
	Gia decimal(18,0) NOT NULL,
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
	HanhTrinh nvarchar(255) NOT NULL,
	KhachSan nvarchar(255) NOT NULL,
    DoanhThu decimal(18,0) NOT NULL,
);

CREATE TABLE KhachHang (
    Id int IDENTITY(1,1) PRIMARY KEY,
    HoTen nvarchar(50) NOT NULL,
    CMND nvarchar(10),
	DiaChi nvarchar(20),
    GioiTinh nvarchar(10),
	SDT nvarchar(10),
	QuocTich nvarchar(10),
);

CREATE TABLE ChiTietDoan (
    KhachHang_Id int NOT NULL,
	DoanDuLich_Id int NOT NULL,
	NgayThamGia date NOT NULL,
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
VALUES (N'Du lịch sinh thái');
INSERT INTO LoaiTour(TenLoai)
VALUES (N'Du lịch hướng nghiệp');
INSERT INTO LoaiTour(TenLoai)
VALUES (N'Du lịch nghĩ dưỡng');
INSERT INTO LoaiTour(TenLoai)
VALUES (N'Du lịch biển');
INSERT INTO LoaiTour(TenLoai)
VALUES (N'Du lịch ẩm thực');
INSERT INTO LoaiTour(TenLoai)
VALUES (N'Teambuilding');
INSERT INTO LoaiTour(TenLoai)
VALUES (N'Tham quan di tích lịch sử');
INSERT INTO LoaiTour(TenLoai)
VALUES (N'Du lịch văn hóa');
INSERT INTO LoaiTour(TenLoai)
VALUES (N'Du lịch nội địa');
INSERT INTO LoaiTour(TenLoai)
VALUES (N'Du lịch quốc tế');

INSERT INTO Tour (TenTour, DacDiem,LoaiTour_Id)
VALUES (N'Du lịch Đà Lạt Tết Nguyên Đán 2022', N'Tour Đà Lạt nổi tiếng với nhiều địa điểm tham quan, vui chơi mang đậm bản sắc văn hóa dân tộc, thiên nhiên hùng vĩ, thơ mộng.', 9);
INSERT INTO Tour (TenTour, DacDiem,LoaiTour_Id)
VALUES (N'Du lịch Châu Âu', N'Tour Châu Âu nổi tiếng với nhiều địa điểm tham quan, khung cảnh thiên nhiên hùng vĩ, thơ mộng.', 10);
INSERT INTO Tour (TenTour, DacDiem,LoaiTour_Id)
VALUES (N'Du lịch Nhật Bản - Đài Loan', N'Tour Nhật Bản - Đài Loan nổi tiếng với nhiều địa điểm tham quan, khung cảnh thiên nhiên hùng vĩ, thơ mộng.', 10);
INSERT INTO Tour (TenTour, DacDiem,LoaiTour_Id)
VALUES (N'Du lịch Singapore - Maylaysia', N'Tour Singapore - Maylaysia nổi tiếng với nhiều địa điểm tham quan, khung cảnh thiên nhiên hùng vĩ, thơ mộng.', 10);
INSERT INTO Tour (TenTour, DacDiem,LoaiTour_Id)
VALUES (N'Du lịch Vườn quốc gia Việt Nam', N'Tham quan các vườn quốc gia nổi tiếng với nhiều địa điểm tham quan, khung cảnh thiên nhiên hùng vĩ, thơ mộng.', 1);
INSERT INTO Tour (TenTour, DacDiem,LoaiTour_Id)
VALUES (N'Du lịch Nha Trang - Đà Lạt',N'Tour nghỉ dưỡng với nhiều địa điểm tham quan, khung cảnh thiên nhiên hùng vĩ, thơ mộng.', 3);
INSERT INTO Tour (TenTour, DacDiem,LoaiTour_Id)
VALUES (N'Teambuilding Hồ Tràm', N'Team building với nhiều địa điểm tham quan, khung cảnh thiên nhiên và nhiều trò chơi vui nhộn.', 6);
INSERT INTO Tour (TenTour, DacDiem,LoaiTour_Id)
VALUES (N'Teambuilding Cà Mau', N'Team building với nhiều địa điểm tham quan, khung cảnh thiên nhiên và nhiều trò chơi vui nhộn.', 6);
INSERT INTO Tour (TenTour, DacDiem,LoaiTour_Id)
VALUES (N'Du lịch các tỉnh miền Tây', N'Tour du lịch văn hóa với nhiều địa điểm tham quan,vui chơi mang đậm bản sắc văn hóa dân tộc, khung cảnh thiên nhiên hùng vĩ, thơ mộng.', 8);
INSERT INTO Tour (TenTour, DacDiem,LoaiTour_Id)
VALUES (N'Du lịch Thái Lan', N'Tour du lịch ẩm thực với nhiều địa điểm tham quan,vui chơi mang đậm bản sắc văn hóa dân tộc, thức ăn ngon và đặc sắc.', 5);
INSERT INTO Tour (TenTour, DacDiem,LoaiTour_Id)
VALUES (N'Du lịch Đà Nẵng Tết Nguyên Đán 2022', N'Tour du lịch biển với nhiều địa điểm tham quan,vui chơi mang đậm bản sắc văn hóa dân tộc, khung cảnh thiên nhiên hùng vĩ, thơ mộng.', 4);
INSERT INTO Tour (TenTour, DacDiem,LoaiTour_Id)
VALUES (N'Tham quan Địa đạo Củ Chi', N'Tham quan di tích lịch sử Địa đạo Củ Chi tồn tại từ thời kháng chiến chống Pháp', 7);

INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2021-12-01', '2021-12-31', 3000000, 1);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-01-01', '2022-01-31', 4000000, 1);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-02-01', '2022-02-28', 5000000, 1);

INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2021-12-01', '2021-12-31', 55000000, 2);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-01-01', '2022-01-31', 52000000, 2);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-02-01', '2022-02-28', 54000000, 2);

INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2021-12-01', '2021-12-31', 30000000, 3);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-01-01', '2022-01-31', 40000000, 3);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-02-01', '2022-02-28', 50000000, 3);

INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2021-12-01', '2021-12-31', 25000000, 4);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-01-01', '2022-01-31', 26000000, 4);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-02-01', '2022-02-28', 28000000, 4);

INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2021-12-01', '2021-12-31', 3900000, 5);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-01-01', '2022-01-31', 4300000, 5);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-02-01', '2022-02-28', 6700000, 5);

INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2021-12-01', '2021-12-31', 14000000, 6);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-01-01', '2022-01-31', 25000000, 6);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-02-01', '2022-02-28', 15000000, 6);

INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2021-12-01', '2021-12-31', 33000000, 7);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-01-01', '2022-01-31', 48000000, 7);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-02-01', '2022-02-28', 52000000, 7);

INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2021-12-01', '2021-12-31', 12000000, 8);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-01-01', '2022-01-31', 14000000, 8);
INSERT INTO GiaTour(NgayBatDau, NgayKetThuc, Gia, Tour_Id)
VALUES ('2022-02-01', '2022-02-28', 15000000, 8);

INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Đà Lạt');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Đà Nẵng');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Nha Trang');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Sóc Trăng');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Kiên Giang');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Bạc Liêu');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Vườn Quốc gia Phong Nha - Kẻ Bàng');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Địa đạo Củ Chi');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Khu du lịch Hồ Tràm');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Khu du lịch Cà Mau');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Singapore');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Malaysia');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Nhật Bản');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Đài Loan');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Ý');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Pháp');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Anh');
INSERT INTO DiaDiem(TenDiaDiem)
VALUES (N'Thái Lan');

INSERT INTO ThamQuan(Tour_Id, DiaDiem_Id, ThuTu)
VALUES (1,1,1);
INSERT INTO ThamQuan(Tour_Id, DiaDiem_Id, ThuTu)
VALUES (2,15,1);
INSERT INTO ThamQuan(Tour_Id, DiaDiem_Id, ThuTu)
VALUES (2,16,2);
INSERT INTO ThamQuan(Tour_Id, DiaDiem_Id, ThuTu)
VALUES (2,17,3);
INSERT INTO ThamQuan(Tour_Id, DiaDiem_Id, ThuTu)
VALUES (3,13,1);
INSERT INTO ThamQuan(Tour_Id, DiaDiem_Id, ThuTu)
VALUES (3,14,2);
INSERT INTO ThamQuan(Tour_Id, DiaDiem_Id, ThuTu)
VALUES (4,11,1);
INSERT INTO ThamQuan(Tour_Id, DiaDiem_Id, ThuTu)
VALUES (4,12,2);
INSERT INTO ThamQuan(Tour_Id, DiaDiem_Id, ThuTu)
VALUES (5,7,1);
INSERT INTO ThamQuan(Tour_Id, DiaDiem_Id, ThuTu)
VALUES (6,3,1);
INSERT INTO ThamQuan(Tour_Id, DiaDiem_Id, ThuTu)
VALUES (6,1,2);
INSERT INTO ThamQuan(Tour_Id, DiaDiem_Id, ThuTu)
VALUES (7,9,1);

INSERT INTO DoanDuLich(Tour_Id,TenDoanDuLich, NgayKhoiHanh, NgayKetThuc, HanhTrinh, KhachSan, DoanhThu)
VALUES (1, N'Đoàn du lịch Công ty Vingroup' ,'2022-01-15', '2022-01-31', N'Đà Lạt - Lâm Đồng - Thác Dambri', N'Khách sạn Teracotta', 0);

INSERT INTO DoanDuLich(Tour_Id,TenDoanDuLich, NgayKhoiHanh, NgayKetThuc, HanhTrinh, KhachSan, DoanhThu)
VALUES (1, N'Đoàn du lịch Công ty Fintech','2022-01-15', '2022-01-31', N'Đà Lạt - Lâm Đồng - Thác Dambri', N'Khách sạn Teracotta', 0);

INSERT INTO DoanDuLich(Tour_Id,TenDoanDuLich, NgayKhoiHanh, NgayKetThuc, HanhTrinh, KhachSan, DoanhThu)
VALUES (2, N'Đoàn Châu Âu 1 - Khách đoàn','2022-01-15', '2022-01-31', N'Ý - Anh - Pháp', N'Khách sạn Guilio - Khách sạn Demetio', 0);
INSERT INTO DoanDuLich(Tour_Id,TenDoanDuLich, NgayKhoiHanh, NgayKetThuc, HanhTrinh, KhachSan, DoanhThu)
VALUES (2, N'Đoàn Châu Âu 2 - Gia đình','2022-01-15', '2022-01-31', N'Ý - Anh - Pháp', N'Khách sạn Guilio - Khách sạn Demetio', 0);
INSERT INTO DoanDuLich(Tour_Id,TenDoanDuLich, NgayKhoiHanh, NgayKetThuc, HanhTrinh, KhachSan, DoanhThu)
VALUES (2, N'Đoàn Châu Âu 3 - Khách đoàn','2022-01-15', '2022-01-31', N'Ý - Anh - Pháp', N'Khách sạn Guilio - Khách sạn Demetio', 0);

INSERT INTO DoanDuLich(Tour_Id,TenDoanDuLich, NgayKhoiHanh, NgayKetThuc, HanhTrinh, KhachSan, DoanhThu)
VALUES (3, N'Đoàn Nhật Bản - Đài Loan 1' ,'2022-01-15', '2022-01-31', N'Nhật Bản - Đài Loan', N'Khách sạn Ajinomoto', 0);
INSERT INTO DoanDuLich(Tour_Id,TenDoanDuLich, NgayKhoiHanh, NgayKetThuc, HanhTrinh, KhachSan, DoanhThu)
VALUES (3, N'Đoàn Nhật Bản - Đài Loan 2' ,'2022-01-15', '2022-01-31', N'Nhật Bản - Đài Loan', N'Khách sạn Ajinomoto', 0);

INSERT INTO DoanDuLich(Tour_Id,TenDoanDuLich, NgayKhoiHanh, NgayKetThuc, HanhTrinh, KhachSan, DoanhThu)
VALUES (7, N'Teambuilding Công ty Việt Hải' ,'2022-01-15', '2022-01-31', N'TPHCM - Hồ Tràm - TPHCM', N'Khách sạn HoTram Hotel', 0);
INSERT INTO DoanDuLich(Tour_Id,TenDoanDuLich, NgayKhoiHanh, NgayKetThuc, HanhTrinh, KhachSan, DoanhThu)
VALUES (8, N'Teambuilding Trường ĐH Sài Gòn' ,'2022-01-15', '2022-01-31', N'TPHCM - Cà Mau - TPHCM', N'Lều trại', 0);

INSERT INTO DoanDuLich(Tour_Id,TenDoanDuLich, NgayKhoiHanh, NgayKetThuc, HanhTrinh, KhachSan, DoanhThu)
VALUES (12, N'Tham quan Trường THPT Nguyễn Khuyến' ,'2022-01-15', '2022-01-31', N'TPHCM - Củ Chi - TPHCM', N'Lều trại', 0);

INSERT INTO KhachHang(HoTen, DiaChi, CMND, SDT, GioiTinh, QuocTich)
VALUES (N'Nguyễn Nghĩa Dũng', N'Quận 2', '0026476352', '08485641', N'Nam', N'Việt Nam');
INSERT INTO KhachHang(HoTen, DiaChi, CMND, SDT, GioiTinh, QuocTich)
VALUES (N'Nguyễn Ngọc Quang', N'Quận 1', '0028565178', '084029787', N'Nam', N'Việt Nam');
INSERT INTO KhachHang(HoTen, DiaChi, CMND, SDT, GioiTinh, QuocTich)
VALUES (N'Lê Tùng Châu', N'Quận 4', '002486603', '08406042', N'Nam', N'Việt Nam');
INSERT INTO KhachHang(HoTen, DiaChi, CMND, SDT, GioiTinh, QuocTich)
VALUES (N'Lê Trọng Kiên', N'Quận 3', '00214223', '084289313', N'Nam', N'Việt Nam');
INSERT INTO KhachHang(HoTen, DiaChi, CMND, SDT, GioiTinh, QuocTich)
VALUES (N'Trần Tâm Hạnh', N'Quận 2', '0029983003', '084331190', N'Nữ', N'Việt Nam');
INSERT INTO KhachHang(HoTen, DiaChi, CMND, SDT, GioiTinh, QuocTich)
VALUES (N'Trần Thùy Mi', N'Quận TB', '002697652', '08432315', N'Nữ', N'Việt Nam');
INSERT INTO KhachHang(HoTen, DiaChi, CMND, SDT, GioiTinh, QuocTich)
VALUES (N'Đỗ Hoài Thương', N'Quận 2', '00238092', '08426161', N'Nữ', N'Việt Nam');
INSERT INTO KhachHang(HoTen, DiaChi, CMND, SDT, GioiTinh, QuocTich)
VALUES (N'Nguyễn Thu Nguyệt', N'Quận 11', '0028171829', '084042351', N'Nữ', N'Việt Nam');
INSERT INTO KhachHang(HoTen, DiaChi, CMND, SDT, GioiTinh, QuocTich)
VALUES (N'Trần Tấn Phát', N'Quận 10', '00207291', '08430414', N'Nam', N'Việt Nam');
INSERT INTO KhachHang(HoTen, DiaChi, CMND, SDT, GioiTinh, QuocTich)
VALUES (N'Lê Khánh Hoàng', N'Quận 6', '002906783', '08470355', N'Nam', N'Việt Nam');
INSERT INTO KhachHang(HoTen, DiaChi, CMND, SDT, GioiTinh, QuocTich)
VALUES (N'Tom Hiddleston', N'Quận 9', '2501467', '08463880', N'Nam', N'Anh');
INSERT INTO KhachHang(HoTen, DiaChi, CMND, SDT, GioiTinh, QuocTich)
VALUES (N'Angela Daria', N'Quận 11', '0167459', '08452140', N'Nữ', N'Mỹ');

INSERT INTO NhanVien(HoTen)
VALUES (N'Bùi Minh Huy');
INSERT INTO NhanVien(HoTen)
VALUES (N'Trần Việt Trinh');
INSERT INTO NhanVien(HoTen)
VALUES (N'Lê Thiên Trí');
INSERT INTO NhanVien(HoTen)
VALUES (N'Nguyễn Quốc Ðại');
INSERT INTO NhanVien(HoTen)
VALUES (N'Nguyễn Mạnh Dũng');
INSERT INTO NhanVien(HoTen)
VALUES (N'Bùi Huyền Thanh');
INSERT INTO NhanVien(HoTen)
VALUES (N'Nguyễn Mạnh Dũng');
INSERT INTO NhanVien(HoTen)
VALUES (N'Trần Ngọc Ðiệp');
INSERT INTO NhanVien(HoTen)
VALUES (N'Trần Mai Châu');
INSERT INTO NhanVien(HoTen)
VALUES (N'Trần Phương Thảo');

INSERT INTO PhanCong(DoanDuLich_Id, NhanVien_Id, NhiemVu)
VALUES (1, 1, N'Hướng dẫn viên');
INSERT INTO PhanCong(DoanDuLich_Id, NhanVien_Id, NhiemVu)
VALUES (1, 3, N'Tài xế');
INSERT INTO PhanCong(DoanDuLich_Id, NhanVien_Id, NhiemVu)
VALUES (1, 2, N'Hướng dẫn viên');

INSERT INTO PhanCong(DoanDuLich_Id, NhanVien_Id, NhiemVu)
VALUES (2, 4, N'Hướng dẫn viên');
INSERT INTO PhanCong(DoanDuLich_Id, NhanVien_Id, NhiemVu)
VALUES (2, 7, N'Tài xế');
INSERT INTO PhanCong(DoanDuLich_Id, NhanVien_Id, NhiemVu)
VALUES (2, 3, N'Hướng dẫn viên');

INSERT INTO PhanCong(DoanDuLich_Id, NhanVien_Id, NhiemVu)
VALUES (3, 9, N'Hướng dẫn viên');
INSERT INTO PhanCong(DoanDuLich_Id, NhanVien_Id, NhiemVu)
VALUES (3, 5, N'Tài xế');
INSERT INTO PhanCong(DoanDuLich_Id, NhanVien_Id, NhiemVu)
VALUES (3, 6, N'Hướng dẫn viên');

INSERT INTO PhanCong(DoanDuLich_Id, NhanVien_Id, NhiemVu)
VALUES (4, 8, N'Hướng dẫn viên');
INSERT INTO PhanCong(DoanDuLich_Id, NhanVien_Id, NhiemVu)
VALUES (4, 10, N'Tài xế');
INSERT INTO PhanCong(DoanDuLich_Id, NhanVien_Id, NhiemVu)
VALUES (4, 3, N'Hướng dẫn viên');

INSERT INTO LoaiChiPhi(TenLoai)
VALUES (N'Xăng dầu');
INSERT INTO LoaiChiPhi(TenLoai)
VALUES (N'Ăn uống');
INSERT INTO LoaiChiPhi(TenLoai)
VALUES (N'Khách sạn');
INSERT INTO LoaiChiPhi(TenLoai)
VALUES (N'Bảo dưỡng xe');
INSERT INTO LoaiChiPhi(TenLoai)
VALUES (N'Bảo hiểm');
INSERT INTO LoaiChiPhi(TenLoai)
VALUES (N'Phí tham quan');
INSERT INTO LoaiChiPhi(TenLoai)
VALUES (N'Phí kho bãi');
INSERT INTO LoaiChiPhi(TenLoai)
VALUES (N'Vé máy bay');

INSERT INTO ChiPhi(DoanDuLich_Id, LoaiChiPhi_Id, SoTien)
VALUES (1, 1, 4000000);
INSERT INTO ChiPhi(DoanDuLich_Id, LoaiChiPhi_Id, SoTien)
VALUES (1, 2, 10000000);
INSERT INTO ChiPhi(DoanDuLich_Id, LoaiChiPhi_Id, SoTien)
VALUES (1, 3, 40000000);

INSERT INTO ChiPhi(DoanDuLich_Id, LoaiChiPhi_Id, SoTien)
VALUES (2, 8, 100000000);
INSERT INTO ChiPhi(DoanDuLich_Id, LoaiChiPhi_Id, SoTien)
VALUES (2, 2, 100000000);
INSERT INTO ChiPhi(DoanDuLich_Id, LoaiChiPhi_Id, SoTien)
VALUES (2, 3, 80000000);

INSERT INTO ChiPhi(DoanDuLich_Id, LoaiChiPhi_Id, SoTien)
VALUES (3, 8, 120000000);
INSERT INTO ChiPhi(DoanDuLich_Id, LoaiChiPhi_Id, SoTien)
VALUES (3, 2, 180000000);
INSERT INTO ChiPhi(DoanDuLich_Id, LoaiChiPhi_Id, SoTien)
VALUES (3, 3, 70000000);

INSERT INTO ChiPhi(DoanDuLich_Id, LoaiChiPhi_Id, SoTien)
VALUES (4, 8, 80000000);
INSERT INTO ChiPhi(DoanDuLich_Id, LoaiChiPhi_Id, SoTien)
VALUES (4, 2, 110000000);
INSERT INTO ChiPhi(DoanDuLich_Id, LoaiChiPhi_Id, SoTien)
VALUES (4, 3, 45000000);