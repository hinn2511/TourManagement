using System;
using System.Collections.Generic;
using TourManagement.DAL;
using TourManagement.DTO;

namespace TourManagement.BUS
{
    public class Bus_ThongKe
    {
        public List<Dto_Tour> LayDanhSachTour()
        {
            Dal_Tour dal_Tour = new Dal_Tour(); 
            return dal_Tour.LayDanhSachTour();
        }

        public List<Dto_DoanDuLich> LayDanhSachDoan()
        {
            Dal_DoanDuLich dal_DoanDuLich = new Dal_DoanDuLich();
            return dal_DoanDuLich.LayDanhSachDoanDuLich();
        }

        public List<NhanVien> LayDanhSachNhanVien()
        {
            Dal_NV dal_NV = new Dal_NV();
            return dal_NV.LayDanhSachNV();
        }

        public List<Dto_ThongKeLoiNhuanTour> LayKetQuaThongKeLoiNhuan(int tourId, DateTime tuNgay, DateTime denNgay)
        {
            Dal_ThongKe dal_ThongKe = new Dal_ThongKe();
            return dal_ThongKe.LayDsThongKeLoiNhuanTour(tourId, tuNgay, denNgay);
        }

        public List<Dto_ThongKeChiPhiTour> LayKetQuaThongKeChiPhi(int tourId, DateTime tuNgay, DateTime denNgay)
        {
            Dal_ThongKe dal_ThongKe = new Dal_ThongKe();
            return dal_ThongKe.LayDsThongKeChiPhiTour(tourId, tuNgay, denNgay);
        }

        public List<Dto_ThongKePhanCongNV> LayKetQuaThongKeNhanVien(int nvId, DateTime tuNgay, DateTime denNgay)
        {
            Dal_ThongKe dal_ThongKe = new Dal_ThongKe();
            return dal_ThongKe.LayDsThongKePhanCongNV(nvId, tuNgay, denNgay);
        }

        public decimal TinhTongDoanhThu(List<Dto_ThongKeLoiNhuanTour> dsLoiNhuan)
        {
            decimal tongDoanhThu = 0;
            foreach (var item in dsLoiNhuan)
            {
                tongDoanhThu += item.DoanhThu;
            }
            return tongDoanhThu;
        }

        public decimal TinhTongChiPhi(List<Dto_ThongKeLoiNhuanTour> dsLoiNhuan)
        {
            decimal tongChiPhi = 0;
            foreach (var item in dsLoiNhuan)
            {
                tongChiPhi += item.ChiPhi;
            }
            return tongChiPhi;
        }

        public decimal TinhTongLoiNhuan(decimal tongDoanhThu, decimal tongChiPhi)
        {
            return tongDoanhThu - tongChiPhi;
        }

        public Dto_ThongKeChiPhiTour ChiPhiCaoNhat(List<Dto_ThongKeChiPhiTour> dsChiPhi)
        {
            Dto_ThongKeChiPhiTour cp = dsChiPhi[0];
            foreach (var item in dsChiPhi)
            {
                if(item.TongSoTien > cp.TongSoTien)
                    cp = item;
            }
            return cp;
        }

        public Dto_ThongKeChiPhiTour ChiPhiThapNhat(List<Dto_ThongKeChiPhiTour> dsChiPhi)
        {
            Dto_ThongKeChiPhiTour cp = dsChiPhi[0];
            foreach (var item in dsChiPhi)
            {
                if (item.TongSoTien< cp.TongSoTien)
                    cp = item;
            }
            return cp;
        }

        public decimal TinhTongChiPhi(List<Dto_ThongKeChiPhiTour> dsChiPhi)
        {
            decimal tongSoTienTatCa = 0;
            foreach (var item in dsChiPhi)
            {
                tongSoTienTatCa += item.TongSoTien;
            }
            return tongSoTienTatCa;
        }

        public int TinhTongSoLanPhanCong(List<Dto_ThongKePhanCongNV> dsPhanCong)
        {
            int soLan = 0;
            foreach (var item in dsPhanCong)
            {
                soLan += item.SoLanPhanCong;
            }
            return soLan;
        }
    }
}
