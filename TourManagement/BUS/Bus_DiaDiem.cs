using System.Collections.Generic;
using System.Linq;
using TourManagement.DAL;

namespace TourManagement.BUS
{
    public class Bus_DiaDiem
    {
        Dal_DiaDiem dal = new Dal_DiaDiem();

        public List<DiaDiem> LayDanhSachDiaDiem()
        {
            return dal.DanhSachDiaDiem();
        }

        public bool ThemDiaDiem(DiaDiem diaDiem)
        {
            return dal.ThemDiaDiem(diaDiem);
        }

        public bool CapNhatDiaDiem(DiaDiem diaDiem)
        {
            return dal.CapNhatDiaDiem(diaDiem);
        }

        public bool XoaDiaDiem(int diaDiemId)
        {
            if (dal.XoaDiaDiem(diaDiemId))
                return true;
            return false;
        }

        public DiaDiem LayThongTinDiaDiem(int id)
        {
            return dal.LayThongTinDiaDiem(id);
        }

        public List<DiaDiem> TimKiemDiaDiem(List<DiaDiem> dsDiaDiem, string key)
        {
            var res = dsDiaDiem.Where(t => t.TenDiaDiem.Contains(key)).ToList();
            return res;
        }
    }
}
