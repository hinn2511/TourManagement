using System.Collections.Generic;
using System.Linq;

namespace TourManagement.DAL
{
    public class Dal_DiaDiem
    {
        TourManagementDataContext context = new TourManagementDataContext();

        public List<DiaDiem> DanhSachDiaDiem()
        {
            List<DiaDiem> diaDiem = context.DiaDiems.ToList();
            return diaDiem;
        }

        public DiaDiem LayThongTinDiaDiem(int id)
        {
            var diaDiem = context.DiaDiems.FirstOrDefault(t => t.Id == id);

            return diaDiem;
        }

        public bool ThemDiaDiem(DiaDiem diaDiem)
        {
            context.DiaDiems.InsertOnSubmit(diaDiem);
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch { return false; }

        }

        public bool CapNhatDiaDiem(DiaDiem diaDiem)
        {
            var diaDiemUpdate = context.DiaDiems.First(t => t.Id == diaDiem.Id);
            if (diaDiemUpdate != null)
            {
                diaDiemUpdate.TenDiaDiem = diaDiem.TenDiaDiem;
            }
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public bool XoaDiaDiem(int diaDiemId)
        {
            var diaDiemDel = context.DiaDiems.FirstOrDefault(t => t.Id == diaDiemId);
            if (diaDiemDel != null)
            {
                context.DiaDiems.DeleteOnSubmit(diaDiemDel);

                try
                {
                    context.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }
    }
}
