using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TourManagement.DAL
{
    internal class Dal_GiaTour
    {
        //public List<GiaTour> LayDanhSachGiaTour()
        //{
        //    TourManagementDataContext context = new TourManagementDataContext();

        //    List<GiaTour> dsGiaTour = context.GiaTours.Select(gt => gt).ToList();

        //    return dsGiaTour;
        //}

        public List<GiaTour> LayDanhSachGiaTourTheoMaTour(int tourId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            List<GiaTour> dsGiaTour = context.GiaTours.Where(gt => gt.Tour_Id == tourId).ToList();

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

            var giatour = context.GiaTours.FirstOrDefault(gt => gt.Tour_Id == tourId && gt.DangApDung);

            return giatour;
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
