using System;
using System.Collections.Generic;
using TourManagement.DAL;
using TourManagement.DTO;

namespace TourManagement.BUS
{
    public class Bus_GiaTour
    {
        public string LayTenTour(int tourId)
        {
            Dal_Tour dal_tour = new Dal_Tour();

            var result = dal_tour.ChiTietTour(tourId).TenTour;

            return result;
        }

        public List<Dto_GiaTour> LayDanhSachGiaTour(int tourId)
        {
            Dal_GiaTour dal_giaTour = new Dal_GiaTour();

            var result = dal_giaTour.LayDanhSachGiaTourTheoMaTour(tourId);

            return result;
        }

        public Dto_GiaTour ChiTietGiaTour(int giatourId)
        {
            Dal_GiaTour dal = new Dal_GiaTour();
            return convertToDto(dal.ChiTietGiaTour(giatourId));
        }

        public bool ThemGiaTour(Dto_GiaTour giaTour)
        {
            Dal_GiaTour dal = new Dal_GiaTour();
            return dal.ThemGiaTour(convertToEntity(giaTour));
        }
        public bool SuaGiaTour(Dto_GiaTour giaTour)
        {
            Dal_GiaTour dal = new Dal_GiaTour();
            return dal.CapNhatGiaTour(convertToEntity(giaTour));
        }


        public bool XoaGiaTour(int id)
        {
            Dal_GiaTour dal = new Dal_GiaTour();
            return dal.XoaGiaTour(id);
        }

        public bool KiemTraNgayGiaTour(int tourId, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            Dal_GiaTour dal = new Dal_GiaTour();
            if (dal.KiemTraNgayGiaTour(tourId, ngayBatDau, ngayKetThuc) != null)
                return false;
            return true;
        }

        public GiaTour convertToEntity (Dto_GiaTour dto)
        {
            GiaTour gt = new GiaTour();
            gt.Id = dto.Id;
            gt.NgayBatDau = dto.NgayBatDau;
            gt.NgayKetThuc = dto.NgayKetThuc;
            gt.Gia = dto.Gia;
            gt.Tour_Id = dto.Tour_Id;
            return gt;
        }

        public Dto_GiaTour convertToDto(GiaTour giaTour)
        {
            Dto_GiaTour dto = new Dto_GiaTour();
            dto.Id = giaTour.Id;
            dto.NgayBatDau = giaTour.NgayBatDau;
            dto.NgayKetThuc = giaTour.NgayKetThuc;
            dto.Gia = giaTour.Gia;
            dto.Tour_Id = (int)giaTour.Tour_Id;
            return dto;
        }

        
    }
}
