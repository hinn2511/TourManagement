using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TourManagement.DTO;

namespace TourManagement.DAL
{
    internal class Dal_GiaTour
    {
        public List<Dto_GiaTour> LayDanhSachGiaTour()
        {
            TourManagementDataContext context = new TourManagementDataContext();

            List<Dto_GiaTour> dsGiaTour = (from giaTour in context.GiaTours
                                           join tour in context.Tours on giaTour.Tour_Id equals tour.Id
                                           select new Dto_GiaTour
                                           {

                                               Id = giaTour.Id,
                                               NgayBatDau = giaTour.NgayBatDau,
                                               NgayKetThuc = giaTour.NgayKetThuc,
                                               Gia = giaTour.Gia,
                                               TenTour = tour.TenTour,
                                           }).ToList();

            return dsGiaTour;
        }

        public List<GiaTour> LayDanhSachGiaTourTheoMaTour(int tourId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            List<GiaTour> dsGiaTour = context.GiaTours.Where(gt => gt.Tour_Id == tourId).ToList();

            return dsGiaTour;
        }

        public GiaTour ChiTietGiaTour(int id)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var giatour = context.GiaTours.FirstOrDefault(gt => gt.Id == id);

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

        public GiaTour LayGiaTourMoiNhat()
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var giaTourMoiNhat = context.GiaTours.OrderByDescending(s => s.Id)
                     .FirstOrDefault();
            if (giaTourMoiNhat != null)
                return giaTourMoiNhat;

            return null;

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
                giaTourUpdate.DangApDung = giaTour.DangApDung;
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

            var giaTourDelete = context.Tours.First(t => t.Id == giaTourId);

            if (giaTourDelete != null)

                context.Tours.DeleteOnSubmit(giaTourDelete);

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
