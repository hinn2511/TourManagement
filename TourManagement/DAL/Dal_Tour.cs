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
            //Thuc hien cau query
            //Join 3 bang tour + gia tour + loai tour
            //Tra ve danh sach Dto_Tour
            List<Dto_Tour> tours = (from tour in context.Tours
                                    join giatour in context.GiaTours on tour.GiaTour_Id equals giatour.Id
                                    join loaitour in context.LoaiTours on tour.LoaiTour_Id equals loaitour.Id
                                    select new Dto_Tour
                                    {
                                        //Lay cac thuoc tinh can thiet
                                        //Ben trai la cac thuoc tinh trong dto
                                        //Ben phai la thuoc tinh sau khi join
                                        Id = tour.Id,
                                        TenTour = tour.TenTour,
                                        DacDiem = tour.DacDiem,
                                        Loai = loaitour.TenLoai,
                                        Gia = giatour.Gia,
                                    }).ToList();
            //Tra ve danh sach
            return tours;
        }



        public bool ThemTour(Tour tour)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            //Them dong moi trong database
            context.Tours.InsertOnSubmit(tour);

            try
            {
                //Luu xuong database
                context.SubmitChanges();

                //Tra ve true khi thanh cong
                return true;
            }
            catch (SqlException e)
            {
                //Tra ve false khi that bai
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
