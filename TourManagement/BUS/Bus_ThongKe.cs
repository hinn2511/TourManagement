using System.Collections.Generic;
using TourManagement.DAL;
using TourManagement.DTO;

namespace TourManagement.BUS
{
    public class Bus_ThongKe
    {
        public List<NhanVien> LayDsNhanVien()
        {
            Dal_NV dal_NhanVien = new Dal_NV();
            return dal_NhanVien.LayDanhSachNV();
        }

        public List<Dto_DoanDuLich> LayDsDoanDuLich()
        {
            Dal_DoanDuLich dal_DoanDuLich = new Dal_DoanDuLich();
            return dal_DoanDuLich.LayDanhSachDoanDuLich();
        }

        public List<Dto_Tour> LayDsTour()
        {
            Dal_Tour dal_Tour = new Dal_Tour();
            return dal_Tour.LayDanhSachTour();
        }
    }
}
