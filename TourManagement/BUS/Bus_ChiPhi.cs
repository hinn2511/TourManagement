using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DAL;
using TourManagement.DTO;

namespace TourManagement.BUS
{
    public class Bus_ChiPhi
    {
        Dal_ChiPhi dal = new Dal_ChiPhi();
        public List<Dto_ChiPhi> LayDsChiPhi()
        {
            return dal.LayDsChiPhi();
        }

        public ChiPhi LayThongTinChiPhi(int id)
        {
            return dal.ChiTietChiPhi(id);
        }

        public List<Dto_ChiPhi> TimKiem (List<Dto_ChiPhi> dsChiPhi, string key)
        {
            return dsChiPhi.Where(t=>t.TenLoaiChiPhi.Contains(key)).ToList();
        }

        public bool Them(ChiPhi chiphi)
        {

            return false;
        }
    }
}
