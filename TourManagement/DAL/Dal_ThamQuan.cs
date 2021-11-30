using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TourManagement.DTO;

namespace TourManagement.DAL
{

    public class Dal_ThamQuan
    {
        public List<DiaDiem> DanhSachDiaDiem()
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var dsDiaDiem = context.DiaDiems.ToList();

            return dsDiaDiem;
        }

        public List<Dto_ThamQuan> LayDanhSachThamQuan(int tourId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            List<Dto_ThamQuan> dsThamQuan = (from thamquan in context.ThamQuans
                                             join diadiem in context.DiaDiems on thamquan.DiaDiem_Id equals diadiem.Id
                                             join tour in context.Tours on thamquan.Tour_Id equals tour.Id
                                             where thamquan.Tour_Id == tourId
                                             orderby thamquan.ThuTu
                                             select new Dto_ThamQuan
                                             {
                                                 Tour_Id = thamquan.Tour_Id,
                                                 TenTour = tour.TenTour,
                                                 DiaDiem_Id = thamquan.DiaDiem_Id,
                                                 TenDiaDiem = diadiem.TenDiaDiem,
                                                 ThuTu = thamquan.ThuTu
                                             }).ToList();
            return dsThamQuan;
        }

        public ThamQuan ChiTietThamQuanTheoDiaDiem(int tourId, int diaDiemId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var ThamQuan = context.ThamQuans.FirstOrDefault(tq => tq.Tour_Id == tourId && tq.DiaDiem_Id == diaDiemId);

            return ThamQuan;
        }

        public ThamQuan ChiTietThamQuanTheoThuTu(int tourId, int thuTu)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var ThamQuan = context.ThamQuans.FirstOrDefault(tq => tq.Tour_Id == tourId && tq.ThuTu == thuTu);

            return ThamQuan;
        }

        public int SoLuongDiaDiemThamQuan(int tourId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var soLuong = context.ThamQuans.Where(tq => tq.Tour_Id == tourId).Count();

            return soLuong;
        }

        public bool ThemThamQuan(ThamQuan thamQuan)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            context.ThamQuans.InsertOnSubmit(thamQuan);

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

        public bool CapNhatThamQuan(ThamQuan thamQuan)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var ThamQuanUpdate = context.ThamQuans.FirstOrDefault(tq => tq.Tour_Id == thamQuan.Tour_Id && tq.DiaDiem_Id == thamQuan.DiaDiem_Id);

            if (ThamQuanUpdate != null)
            {
                ThamQuanUpdate.ThuTu = thamQuan.ThuTu;
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

        public bool XoaThamQuan(int tourId, int diaDiemId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var ThamQuanDelete = context.ThamQuans.FirstOrDefault(t => t.Tour_Id == tourId && t.DiaDiem_Id == diaDiemId);

            if (ThamQuanDelete != null)
            {
                context.ThamQuans.DeleteOnSubmit(ThamQuanDelete);

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
