using System.Collections.Generic;
using TourManagement.DAL;

namespace TourManagement.BUS
{
    internal class Bus_GiaTour
    {
        public string LayTenTour(int tourId)
        {
            Dal_Tour dal_tour = new Dal_Tour();

            var result = dal_tour.ChiTietTour(tourId).TenTour;

            return result;
        }

        public bool ApDungGiaTour(int tourId, int giaTourMoiId)
        {
            Dal_GiaTour dal_giaTour = new Dal_GiaTour();
            Dal_Tour dal_Tour = new Dal_Tour();

            var tourThayDoiGia = dal_Tour.ChiTietTour(tourId);

            int giaTourCuId = (int)tourThayDoiGia.GiaTour_Id;

            tourThayDoiGia.GiaTour_Id = giaTourMoiId;

            if (dal_Tour.CapNhatTour(tourThayDoiGia))
            {
                var giaTourCu = dal_giaTour.ChiTietGiaTour(giaTourCuId);

                giaTourCu.DangApDung = false;

                if (dal_giaTour.CapNhatGiaTour(giaTourCu))
                {
                    var giaTourMoi = dal_giaTour.ChiTietGiaTour(giaTourMoiId);

                    giaTourMoi.DangApDung = true;

                    if (dal_giaTour.CapNhatGiaTour(giaTourMoi))
                        return true;
                }
            }

            return false;
        }

        public List<GiaTour> LayDanhSachGiaTour(int tourId)
        {
            Dal_GiaTour dal_giaTour = new Dal_GiaTour();

            var result = dal_giaTour.LayDanhSachGiaTourTheoMaTour(tourId);

            return result;
        }

        public bool XoaGiaTour(int id)
        {
            Dal_GiaTour dal = new Dal_GiaTour();
            return dal.XoaGiaTour(id);
        }

        public bool ThemGiaTour(GiaTour giaTour)
        {
            Dal_GiaTour dal = new Dal_GiaTour();
            return dal.ThemGiaTour(giaTour);
        }

        public bool SuaGiaTour(GiaTour giaTour)
        {
            Dal_GiaTour dal = new Dal_GiaTour();
            return dal.CapNhatGiaTour(giaTour);
        }
    }
}
