using System.Collections.Generic;
using TourManagement.DAL;
using System.Linq;
namespace TourManagement.BUS
{
    public class Bus_KH
    {
        Dal_KH dal = new Dal_KH();
        public List<KhachHang> LayDanhSachKH()
        {
            
            return dal.LayDanhSachKH();
        }

        public bool ThemKH(KhachHang KH)
        {
           
            return dal.ThemKH(KH);
        }

        public bool CapNhatKH(KhachHang KH)
        {
            
            return dal.CapNhatKH(KH);
        }

        public bool XoaKH(int id)
        {
            
            return dal.XoaKH(id);
        }
        public List<KhachHang> TimKiemKH(List<KhachHang> dsKH, string key)
        {
            var res = dsKH.Where(t => t.HoTen.Contains(key)).ToList();
            return res;
        }
        public KhachHang LayThongTinKH(int id)
        {
            return dal.LayThongTinKH(id);
        }
    }
}

