using System;
using System.Collections.Generic;
using System.Linq;

using TourManagement.DAL;

namespace TourManagement.BUS
{
    internal class Bus_NV
    {
        public List<NhanVien> LayDanhSachNV()
        {
            Dal_NV dal = new Dal_NV();
            return dal.LayDanhSachNV();
        }

        public bool ThemNV(NhanVien Nv)
        {
            Dal_NV dal = new Dal_NV();
            return dal.ThemNV(Nv);
        }

        public bool CapNhatNV(NhanVien Nv)
        {
            Dal_NV dal = new Dal_NV();
            return dal.CapNhatNhanVien(Nv);
        }

        public bool XoaNV(int id)
        {
            Dal_NV dal = new Dal_NV();
            return dal.XoaNV(id);
        }
    }
}
