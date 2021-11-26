using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.DTO;

namespace TourManagement.DAL
{
   
    public class Dal_ChiPhi
    {
        TourManagementDataContext context = new TourManagementDataContext();
        public List<Dto_ChiPhi> LayDsChiPhi()
        {
           
            List<Dto_ChiPhi> chiPhi = (from ChiPhi in context.ChiPhis
                                       join DoanDuLich in context.DoanDuLiches on ChiPhi.DoanDuLich_Id equals DoanDuLich.Id
                                       join LoaiChiPhi in context.LoaiChiPhis on ChiPhi.LoaiChiPhi_Id equals LoaiChiPhi.Id
                                       select new Dto_ChiPhi
                                       {
                                           Id = ChiPhi.Id,
                                           SoTien = ChiPhi.SoTien,
                                           DoanDuLichId = DoanDuLich.Id,
                                           LoaiChiPhiId = LoaiChiPhi.Id,
                                           TenLoaiChiPhi =  LoaiChiPhi.TenLoai,
                                       }).ToList();
            return chiPhi;
        }

        public ChiPhi ChiTietChiPhi(int id)
        {
            return context.ChiPhis.FirstOrDefault(t => t.Id == id);
        }

        public bool Them(ChiPhi chiPhi)
        {
            context.ChiPhis.InsertOnSubmit(chiPhi);
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch {return false;}
        }

        public bool Xoa (int id)
        {
            var chiPhiDel = context.ChiPhis.FirstOrDefault(t => t.Id == id);
            if (chiPhiDel != null)
            {
                context.ChiPhis.DeleteOnSubmit(chiPhiDel);
                try
                {
                    context.SubmitChanges();
                    return true;
                }
                catch { return false;}
            }
            return false;
        }

        public bool CapNhatChiPhi (ChiPhi chiPhi)
        {
            var chiPhiUpdate = context.ChiPhis.First(t=> t.Id == chiPhi.Id);
            if (chiPhiUpdate != null)
            {
                chiPhiUpdate.SoTien = chiPhi.SoTien;
                chiPhiUpdate.LoaiChiPhi_Id = chiPhi.LoaiChiPhi_Id;
                chiPhiUpdate.DoanDuLich_Id = chiPhi.DoanDuLich_Id;
            }
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch { return false; }
            return false;
        }
    }
}
