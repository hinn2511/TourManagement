using System.Collections.Generic;
using System.Linq;

namespace TourManagement.DAL
{
    public class Dal_LoaiChiPhi
    {
        TourManagementDataContext context = new TourManagementDataContext();

        public List<LoaiChiPhi> LayDsLoaiChiPhi()
        {
            List<LoaiChiPhi> loaiChiPhi = context.LoaiChiPhis.ToList();
            return loaiChiPhi;
        }

        public bool Them(LoaiChiPhi loaiChiPhi)
        {
            context.LoaiChiPhis.InsertOnSubmit(loaiChiPhi);
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool CapNhat(LoaiChiPhi loaiChiPhi)
        {
            var loaiChiPhiUpdate = context.LoaiChiPhis.First(t => t.Id == loaiChiPhi.Id);
            if (loaiChiPhiUpdate != null)
            {
                loaiChiPhiUpdate.TenLoai = loaiChiPhi.TenLoai;
            }
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Xoa(int loaiChiPhiId)
        {
            var loaiChiPhiDel = context.LoaiChiPhis.FirstOrDefault(t => t.Id == loaiChiPhiId);
            if (loaiChiPhiDel != null)
            {
                context.LoaiChiPhis.DeleteOnSubmit(loaiChiPhiDel);
            }
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch { return false; }
            return false;
        }

        public LoaiChiPhi LayThongTinLoaiChiPhi(int id)
        {
            var loaiChiPhi = context.LoaiChiPhis.FirstOrDefault(t => t.Id == id);
            return loaiChiPhi;
        }
    }

}
