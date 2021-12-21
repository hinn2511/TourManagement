using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using TourManagement.DTO;

namespace TourManagement.DAL
{
    public class Dal_GiaTour
    {
        public List<Dto_GiaTour> LayDanhSachGiaTourTheoMaTour(int tourId)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            DateTime now = DateTime.Now;
            List<Dto_GiaTour> dsGiaTour = context.GiaTours.Where(gt => gt.Tour_Id == tourId).Select(gt => new Dto_GiaTour
            {
                Id = gt.Id, 
                NgayKetThuc =  gt.NgayKetThuc,
                NgayBatDau = gt.NgayBatDau,
                Gia = gt.Gia,
                Tour_Id = (int)gt.Tour_Id,
                DangApDung = gt.NgayBatDau <= now && gt.NgayKetThuc >= now ? true : false,
            }).ToList();

            return dsGiaTour;
        }

        public GiaTour ChiTietGiaTour(int giaTourId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var giatour = context.GiaTours.FirstOrDefault(gt => gt.Id == giaTourId);

            return giatour;
        }

        public GiaTour GiaTourDangApDung(int tourId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            DateTime now = DateTime.Now;
            var giatour = context.GiaTours.FirstOrDefault(gt => gt.Tour_Id == tourId && gt.NgayBatDau <= now && gt.NgayKetThuc >= now);

            return giatour;
        }


        public GiaTour GiaTourApDungTrongThoiGian(int tourId, DateTime ngayThamGia)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var giatour = context.GiaTours.FirstOrDefault(gt => gt.Tour_Id == tourId && gt.NgayBatDau <= ngayThamGia && gt.NgayKetThuc >= ngayThamGia);

            return giatour;
        }

        public GiaTour KiemTraNgayGiaTour(int tourId, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            var giatour = context.GiaTours.FirstOrDefault(gt =>gt.Tour_Id == tourId && ((gt.NgayBatDau >= ngayBatDau && gt.NgayBatDau <= ngayKetThuc) ||
                              (gt.NgayKetThuc <= ngayKetThuc && gt.NgayKetThuc >= ngayBatDau)));

            return giatour;
        }

        public bool ThemGiaTour(GiaTour giaTour)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            context.GiaTours.InsertOnSubmit(giaTour);

            try
            {
                context.SubmitChanges();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }


        public bool CapNhatGiaTour(GiaTour giaTour)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var giaTourUpdate = context.GiaTours.FirstOrDefault(t => t.Id == giaTour.Id);

            if (giaTourUpdate != null)
            {
                giaTourUpdate.Gia = giaTour.Gia;
                giaTourUpdate.NgayBatDau = giaTour.NgayBatDau;
                giaTourUpdate.NgayKetThuc = giaTour.NgayKetThuc;
                giaTourUpdate.Tour_Id = giaTour.Tour_Id;
            }
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        public bool XoaGiaTour(int giaTourId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var giaTourDelete = context.GiaTours.FirstOrDefault(gt => gt.Id == giaTourId);

            if (giaTourDelete != null)

                context.GiaTours.DeleteOnSubmit(giaTourDelete);

            try
            {
                context.SubmitChanges();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }
    }
}
