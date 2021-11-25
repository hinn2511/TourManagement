using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TourManagement.DAL
{
    internal class Dal_NV
    {
        TourManagementDataContext context = new TourManagementDataContext();
        public List<NhanVien> LayDanhSachNV()
        {
            List<NhanVien> Nv = context.NhanViens.Select(nv => nv).ToList();
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

            var UpdateNv = context.NhanViens.First(nv => nv.Id == nhanVien.Id);

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
    }
}
