using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DAL;

namespace TourManagement.BUS
{
    public class Bus_LoaiChiPhi
    {
        Dal_LoaiChiPhi dal = new Dal_LoaiChiPhi();
        public List<LoaiChiPhi> LayDanhSachLoaiChiPhi()
        {
            return dal.LayDsLoaiChiPhi();
        }

        public bool ThemLoaiChiPhi(LoaiChiPhi loaiChiPhi)
        {
            return dal.Them(loaiChiPhi);
        }

        public bool XoaLoaiChiPhi(int id)
        {
            return dal.Xoa (id);
        }

        public bool CapNhatLoaiChiPhi(LoaiChiPhi loaiChiPhi)
        {
            return dal.CapNhat(loaiChiPhi);
        }

        public LoaiChiPhi LayThongTinLoaiChiPhi (int id)
        {
            return dal.LayThongTinLoaiChiPhi(id);
        }

        public List<LoaiChiPhi> TimKiem (List<LoaiChiPhi> dsLoaiChiPhi, string key)
        {
            return dsLoaiChiPhi.Where (t => t.TenLoai.Contains (key)).ToList();
           
        }
    }
}
