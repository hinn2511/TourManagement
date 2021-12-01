using System.Collections.Generic;
using System.Linq;
using TourManagement.DTO;

namespace TourManagement.DAL
{
    public class Dal_ChiPhi
    {
        TourManagementDataContext context = new TourManagementDataContext();

        public List<Dto_ChiPhi> LayDsChiPhi()
        {
            List<Dto_ChiPhi> chiPhi = context.ChiPhis.Select(cp => new Dto_ChiPhi
            {
                Id = cp.Id,
                TenDoan = cp.DoanDuLich.TenDoanDuLich,
                DoanDuLich_Id  = cp.DoanDuLich_Id,
                TenLoai = cp.LoaiChiPhi.TenLoai,
                LoaiChiPhi_id   = cp.LoaiChiPhi_Id,
                SoTien = cp.SoTien
            }).ToList();
            return chiPhi;
        }

        public bool Them(ChiPhi chiPhi)
        {
            context.ChiPhis.InsertOnSubmit(chiPhi);
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool CapNhat(ChiPhi chiPhi)
        {
            var chiPhiUpdate = context.ChiPhis.First(t => t.Id == chiPhi.Id);
            if (chiPhiUpdate != null)
            {
                chiPhiUpdate.LoaiChiPhi_Id = chiPhi.LoaiChiPhi_Id;
                chiPhiUpdate.DoanDuLich_Id = chiPhi.DoanDuLich_Id;
                chiPhiUpdate.SoTien = chiPhi.SoTien;
            }
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Xoa(int chiPhiId)
        {
            var chiPhiDel = context.ChiPhis.FirstOrDefault(t => t.Id == chiPhiId);
            if (chiPhiDel != null)
            {
                context.ChiPhis.DeleteOnSubmit(chiPhiDel);
            }
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public ChiPhi LayThongTinChiPhi(int id)
        {
            var chiPhi = context.ChiPhis.FirstOrDefault(t => t.Id == id);
            return chiPhi;
        }
    }

}
