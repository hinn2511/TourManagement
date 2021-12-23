using System.Collections.Generic;
using TourManagement.DAL;
using TourManagement.DTO;
using System.Linq;
namespace TourManagement.BUS
{
    public class Bus_NV
    {
        Dal_NV dal = new Dal_NV();
        public List<NhanVien> LayDanhSachNV()
        {
            
            return dal.LayDanhSachNV();
        }

        public bool ThemNV(NhanVien Nv)
        {
            
            return dal.ThemNV(Nv);
        }

        public bool CapNhatNV(NhanVien Nv)
        {
            
            return dal.CapNhatNhanVien(Nv);
        }

        public bool XoaNV(int id)
        {
            
            return dal.XoaNV(id);
        }
        public List<NhanVien> TimKiemNV(List<NhanVien> dsNV, string key)
        {
            var res = dsNV.Where(t => t.HoTen.Contains(key)).ToList();
            return res;
        }
        public NhanVien LayThongTinNV(int id)
        {
            return dal.LayThongTinNV(id);
        }
    }
}
