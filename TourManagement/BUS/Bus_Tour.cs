using System.Collections.Generic;
using System.Linq;
using TourManagement.DAL;
using TourManagement.DTO;

namespace TourManagement.BUS
{

    public class Bus_Tour
    {
        public List<Dto_Tour> LayDanhSachTour()
        {
            //Goi lop dal
            Dal_Tour dal_tour = new Dal_Tour();

            //Gan result = ket qua tra ve tu dal
            var result = dal_tour.LayDanhSachTour();

            //Tra ve result
            return result;
        }

        public List<Dto_Tour> TimKiemTour(List<Dto_Tour> dsTour, string tukhoa)
        {

            //Gan result = ket qua tra ve tu 
            //dsTour.Where(t => t.TenTour.Contains(tukhoa)) => Tim trong list co ten tour nao co chua tu khoa can tim kiem
            var result = dsTour.Where(t => t.TenTour.Contains(tukhoa)).ToList();
            //Tra ve result
            return result;
        }


        public bool ThemTourMoi(Tour tour, GiaTour gia)
        {
            //Goi lop dal
            Dal_Tour dal_tour = new Dal_Tour();

            Dal_GiaTour dal_giaTour = new Dal_GiaTour();

            //Tao gia tour moi
            if (dal_giaTour.ThemGiaTour(gia))

            //Neu thanh cong 
            {
                //Neu them thanh cong tim gia tour da tao
                var giaTourMoi = dal_giaTour.LayGiaTourMoiNhat();

                //Them gia tour id vao tour
                tour.GiaTour_Id = giaTourMoi.Id;

                //Them tour
                if (dal_tour.ThemTour(tour))
                {
                    //Cap nhat tour id trong gia tour
                    //Ap dung gia tour
                    if (giaTourMoi != null)
                    {
                        giaTourMoi.Tour_Id = tour.Id;
                        giaTourMoi.DangApDung = true;
                        dal_giaTour.CapNhatGiaTour(giaTourMoi);
                    }
                    return true;
                }

                //Neu them that bai tra ve false
                return false;
            }
            return false;

        }

        public bool XoaTour(int id)
        {
            Dal_Tour dal_tour = new Dal_Tour();
            if (dal_tour.XoaTour(id))
                return true;
            return false;
        }

        public List<LoaiTour> LayDanhSachLoaiTour()
        {
            Dal_LoaiTour dal_loaiTour = new Dal_LoaiTour();
            var result = dal_loaiTour.getAllTourType();
            return result;
        }
    }
}
