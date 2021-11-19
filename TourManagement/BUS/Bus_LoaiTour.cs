using System.Collections.Generic;
using TourManagement.DAL;

namespace TourManagement.BUS
{
    internal class Bus_LoaiTour
    {
        public List<LoaiTour> LayDanhSachLoaiTour()
        {
            Dal_LoaiTour dal = new Dal_LoaiTour();
            return dal.LayTatCaLoaiTour();
        }

        public bool ThemLoaiTour(LoaiTour loaiTour)
        {
            Dal_LoaiTour dal = new Dal_LoaiTour();
            return dal.ThemLoaiTour(loaiTour);
        }

        public bool CapNhatLoaiTour(LoaiTour loaiTour)
        {
            Dal_LoaiTour dal = new Dal_LoaiTour();
            return dal.CapNhatLoaiTour(loaiTour);
        }

        public bool XoaLoaiTour(int id)
        {
            Dal_LoaiTour dal = new Dal_LoaiTour();
            return dal.XoaLoaiTour(id);
        }

        public LoaiTour LayThongTinLoaiTour(int id)
        {
            Dal_LoaiTour dal = new Dal_LoaiTour();
            return dal.LayThongTinLoaiTour(id);
        }
    }
}
