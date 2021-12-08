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
            Dal_Tour dal_tour = new Dal_Tour();

            var result = dal_tour.LayDanhSachTour();

            return result;
        }

        public Tour LayThongTinTour(int tourId)
        {
            Dal_Tour dal_tour = new Dal_Tour();
            var result = dal_tour.ChiTietTour(tourId);
            return result;
        }

        public GiaTour LayGiaTour(int tourId)
        {
            Dal_GiaTour dal_GiaTour = new Dal_GiaTour();
            var result = dal_GiaTour.GiaTourDangApDung(tourId);
            return result;
        }

        public List<Dto_ThamQuan> LayLichTrinhThamQuan(int tourId)
        {
            Dal_ThamQuan dal_thamQuan = new Dal_ThamQuan();
            var result = dal_thamQuan.LayDanhSachThamQuan(tourId);
            return result;
        }

        public List<Dto_Tour> TimKiemTour(List<Dto_Tour> dsTour, string tukhoa)
        {

            var result = dsTour.Where(t => t.TenTour.Contains(tukhoa)).ToList();
            return result;
        }


        public bool ThemTourMoi(Tour tour, GiaTour gia)
        {
            Dal_Tour dal_tour = new Dal_Tour();

            Dal_GiaTour dal_giaTour = new Dal_GiaTour();

            if (dal_giaTour.ThemGiaTour(gia))
            {

                var giaTourMoiNhat = dal_giaTour.LayGiaTourMoiNhat();
                if (giaTourMoiNhat != null)
                {
                    tour.GiaTour_Id = giaTourMoiNhat.Id;

                    if (dal_tour.ThemTour(tour))
                    {
                        giaTourMoiNhat.Tour_Id = tour.Id;
                        giaTourMoiNhat.DangApDung = true;
                        dal_giaTour.CapNhatGiaTour(giaTourMoiNhat);
                        return true;
                    }
                }

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

        public bool SuaThongTinTour(Dto_Tour tourDaSua)
        {
            Dal_Tour dal_tour = new Dal_Tour();

            if (dal_tour.CapNhatTour(DtoToEntity(tourDaSua)))
                return true;
            return false;
        }

        public Tour DtoToEntity(Dto_Tour dto)
        {
            Tour t = new Tour();    
            t.Id = dto.Id;
            t.LoaiTour_Id = dto.Loai_Id;
            t.GiaTour_Id = dto.Gia_Id;
            t.TenTour = dto.TenTour;
            return t;
        }

        public List<LoaiTour> LayDanhSachLoaiTour()
        {
            Dal_LoaiTour dal_loaiTour = new Dal_LoaiTour();
            var result = dal_loaiTour.LayDanhSachLoaiTour();
            return result;
        }
    }
}
