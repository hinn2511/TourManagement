using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TourManagement.DTO;
namespace TourManagement.DAL
{
    public class Dal_NV
    {
        TourManagementDataContext context = new TourManagementDataContext();
        public List<NhanVien> LayDanhSachNV()
        {
            List<NhanVien> Nv = context.NhanViens.ToList();
            return Nv;
        }
        public bool ThemNV(NhanVien nhanVien)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            context.NhanViens.InsertOnSubmit(nhanVien);

            try
            {
                context.SubmitChanges();

                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }
        public bool CapNhatNhanVien(NhanVien nhanVien)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var UpdateNv = context.NhanViens.First(nv => nv.HoTen == nhanVien.HoTen);

            if (UpdateNv != null)
            {
                UpdateNv.HoTen = nhanVien.HoTen;
            }
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }
        public bool XoaNV(int NvId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var DeleteNv = context.NhanViens.FirstOrDefault(nv => nv.Id == NvId);

            if (DeleteNv != null)
            {
                context.NhanViens.DeleteOnSubmit(DeleteNv);

                try
                {
                    context.SubmitChanges();
                    return true;
                }
                catch (SqlException e)
                {
                    return false;
                }
            }
            return false;

        }
        public NhanVien LayThongTinNV(int id)
        {
            var nv = context.NhanViens.FirstOrDefault(t => t.Id == id);

            return nv;
        }
    }
}
