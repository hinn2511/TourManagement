using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using TourManagement.DTO;

namespace TourManagement.DAL
{

    public class Dal_DoanDuLich
    {


        public List<Dto_DoanDuLich> LayDanhSachDoanDuLich()
        {
            TourManagementDataContext context = new TourManagementDataContext();
            List<Dto_DoanDuLich> DoanDuLich = context.DoanDuLiches.Select(dll => new Dto_DoanDuLich
            {
                Id = dll.Id,
                Tour_Id = dll.Tour_Id,
                TenDoan = dll.TenDoanDuLich,
                TenTour = dll.Tour.TenTour,
                NgayKhoiHanh = dll.NgayKhoiHanh,
                NgayKetThuc = dll.NgayKetThuc,
                DoanhThu = decimal.Round(context.ChiTietDoans.Where(ctd => ctd.DoanDuLich_Id == dll.Id).Count() *
                                                context.GiaTours.FirstOrDefault(gt => gt.Tour_Id == dll.Tour_Id && gt.DangApDung).Gia,
                                                0,
                                                MidpointRounding.AwayFromZero),
                ChiPhi = context.ChiPhis.Where(cp => cp.DoanDuLich_Id == dll.Id).Any() ?
                            context.ChiPhis.Where(cp => cp.DoanDuLich_Id == dll.Id).Select(cp => cp.SoTien).Sum() : 0
            }).ToList();
            return DoanDuLich;
        }

        public DoanDuLich ChiTietDoanDuLich(int doanDuLichId)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            return context.DoanDuLiches.FirstOrDefault(ddl => ddl.Id == doanDuLichId);
        }

        public bool ThemDoanDuLich(DoanDuLich DoanDuLich)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            context.DoanDuLiches.InsertOnSubmit(DoanDuLich);

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

        public DoanDuLich LayThongTinDoanDuLich(int id)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var DoanDuLich = context.DoanDuLiches.FirstOrDefault(t => t.Id == id);

            return DoanDuLich;
        }

        public bool CapNhatDoanDuLich(DoanDuLich DoanDuLich)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var DoanDuLichUpdate = context.DoanDuLiches.First(t => t.Id == DoanDuLich.Id);

            if (DoanDuLichUpdate != null)
            {
                DoanDuLichUpdate.Tour_Id = DoanDuLich.Tour_Id;
                DoanDuLichUpdate.NgayKhoiHanh = DoanDuLich.NgayKhoiHanh;
                DoanDuLichUpdate.NgayKetThuc = DoanDuLich.NgayKetThuc;
                DoanDuLichUpdate.DoanhThu = DoanDuLich.DoanhThu;
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

        public bool XoaDoanDuLich(int DoanDuLichId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var DoanDuLichDelete = context.DoanDuLiches.FirstOrDefault(t => t.Id == DoanDuLichId);

            if (DoanDuLichDelete != null)
            {
                context.DoanDuLiches.DeleteOnSubmit(DoanDuLichDelete);

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
