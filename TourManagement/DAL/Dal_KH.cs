using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace TourManagement.DAL
{
    internal class Dal_KH
    {
        TourManagementDataContext context = new TourManagementDataContext();
        public List<KhachHang> LayDanhSachKH()
        {
            List<KhachHang> KH = context.KhachHangs.Select(kh => kh).ToList();
            return KH;
        }
        public bool ThemKH(KhachHang khachHang)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            context.KhachHangs.InsertOnSubmit(khachHang);

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
        public bool CapNhatKH(KhachHang khachHang)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var UpdateKH = context.KhachHangs.First(kh => kh.Id == khachHang.Id);

            if (UpdateKH != null)
            {
                UpdateKH.HoTen = khachHang.HoTen;
                UpdateKH.DiaChi = khachHang.DiaChi;
                UpdateKH.CMND = khachHang.CMND;
                UpdateKH.SDT = khachHang.SDT;
                UpdateKH.GioiTinh = khachHang.GioiTinh;
                UpdateKH.QuocTich = khachHang.QuocTich;
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
        public bool XoaKH(int KhId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var DeleteKH = context.KhachHangs.FirstOrDefault(kh => kh.Id == KhId);

            if (DeleteKH != null)
            {
                context.KhachHangs.DeleteOnSubmit(DeleteKH);

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

