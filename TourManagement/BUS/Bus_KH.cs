using System;
using System.Collections.Generic;
using System.Linq;
using TourManagement.DAL;

namespace TourManagement.BUS
{
    internal class Bus_KH
    {
        public List<KhachHang> LayDanhSachKH()
        {
            Dal_KH dal = new Dal_KH();
            return dal.LayDanhSachKH();
        }

        public bool ThemKH(KhachHang KH)
        {
            Dal_KH dal = new Dal_KH();
            return dal.ThemKH(KH);
        }

        public bool CapNhatKH(KhachHang KH)
        {
            Dal_KH dal = new Dal_KH();
            return dal.CapNhatKH(KH);
        }

        public bool XoaKH(int id)
        {
            Dal_KH dal = new Dal_KH();
            return dal.XoaKH(id);
        }
    }
}

