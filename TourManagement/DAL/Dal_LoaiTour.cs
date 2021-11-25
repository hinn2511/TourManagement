using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TourManagement.DAL
{

    public class Dal_LoaiTour
    {
        TourManagementDataContext context = new TourManagementDataContext();

        public List<LoaiTour> LayDanhSachLoaiTour()
        {
            List<LoaiTour> loaiTour = context.LoaiTours.ToList();
            return loaiTour;
        }

        public bool ThemLoaiTour(LoaiTour loaiTour)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            context.LoaiTours.InsertOnSubmit(loaiTour);

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

        public LoaiTour LayThongTinLoaiTour(int id)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var loaiTour = context.LoaiTours.FirstOrDefault(t => t.Id == id);

            return loaiTour;
        }

        public bool CapNhatLoaiTour(LoaiTour loaiTour)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var loaiTourUpdate = context.LoaiTours.First(t => t.Id == loaiTour.Id);

            if (loaiTourUpdate != null)
            {
                loaiTourUpdate.TenLoai = loaiTour.TenLoai;
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

        public bool XoaLoaiTour(int loaiTourId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var loaiTourDelete = context.LoaiTours.FirstOrDefault(t => t.Id == loaiTourId);

            if (loaiTourDelete != null)
            {
                context.LoaiTours.DeleteOnSubmit(loaiTourDelete);

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
            return false;

        }
    }
}
