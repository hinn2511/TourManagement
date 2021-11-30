using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TourManagement.DTO;

namespace TourManagement.DAL
{

    public class Dal_ChiTietDoan
    {
        TourManagementDataContext context = new TourManagementDataContext();

        public List<Dto_ChiTietDoan> LayDanhSachChiTietDoan(int doanId)
        {
            List<Dto_ChiTietDoan> ChiTietDoan = context.ChiTietDoans.Where(ctd => ctd.DoanDuLich_Id == doanId).Select(ctd => new Dto_ChiTietDoan
            {
                TenKhachHang = ctd.KhachHang.HoTen,
                KhachHang_Id = ctd.KhachHang_Id,
                DoanDuLich_Id = ctd.DoanDuLich_Id
            }).ToList();
            return ChiTietDoan;
        }

        public bool ThemChiTietDoan(ChiTietDoan ChiTietDoan)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            context.ChiTietDoans.InsertOnSubmit(ChiTietDoan);

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

        public bool XoaChiTietDoan(int doanId, int khachHangId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var ChiTietDoanDelete = context.ChiTietDoans.FirstOrDefault(ctd => ctd.DoanDuLich_Id == doanId && ctd.KhachHang_Id == khachHangId);

            if (ChiTietDoanDelete != null)
            {
                context.ChiTietDoans.DeleteOnSubmit(ChiTietDoanDelete);

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
