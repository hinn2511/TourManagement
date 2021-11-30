using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TourManagement.DTO;

namespace TourManagement.DAL
{
    public class Dal_Tour
    {
        public List<Dto_Tour> LayDanhSachTour()
        {
            TourManagementDataContext context = new TourManagementDataContext();
            List<Dto_Tour> dsTour = context.Tours.Select(t => new Dto_Tour
            {
                Id = t.Id,
                TenTour = t.TenTour,
                DacDiem = t.DacDiem,
                Loai = t.LoaiTour.TenLoai,
                Loai_Id = t.LoaiTour.Id,
                Gia = t.GiaTours.FirstOrDefault(x => x.DangApDung).Gia,
                Gia_Id = (int)t.GiaTour_Id,
            }).ToList();
            return dsTour;
        }

        public Tour ChiTietTour(int id)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var tour = context.Tours.FirstOrDefault(t => t.Id == id);

            return tour;
        }


        public bool ThemTour(Tour tour)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            context.Tours.InsertOnSubmit(tour);

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

        public bool CapNhatTour(Tour tour)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            // Tim dong tour can update trong database
            var tourUpdate = context.Tours.First(t => t.Id == tour.Id);

            //Neu tim thay
            if (tourUpdate != null)
            {
                //Gan gia tri moi
                tourUpdate.TenTour = tour.TenTour;
                tourUpdate.DacDiem = tour.DacDiem;
                tourUpdate.GiaTour_Id = tour.GiaTour_Id;
                tourUpdate.LoaiTour_Id = tour.LoaiTour_Id;
            }
            try
            {
                //Luu xuong database
                context.SubmitChanges();

                //Tra ve true khi thanh cong
                return true;
            }
            catch (SqlException e)
            {
                //Tra ve false khi thanh cong
                return false;
            }
        }

        public bool XoaTour(int tourId)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            // Tim dong tour can update trong database
            var tourDelete = context.Tours.FirstOrDefault(t => t.Id == tourId);

            //Neu tim thay
            if (tourDelete != null)
            {
                //Xoa tour
                context.Tours.DeleteOnSubmit(tourDelete);

                try
                {
                    //Luu xuong database
                    context.SubmitChanges();

                    //Tra ve true khi thanh cong
                    return true;
                }
                catch (SqlException e)
                {
                    //Tra ve false khi thanh cong
                    return false;
                }
            }
            return false;

        }
    }
}
