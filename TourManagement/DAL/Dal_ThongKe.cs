using System;
using System.Collections.Generic;
using System.Linq;
using TourManagement.DTO;

namespace TourManagement.DAL
{
    public class Dal_ThongKe
    {
        public List<Dto_ThongKeLoiNhuanTour> LayDsThongKeLoiNhuanTour(int tourId, DateTime tuNgay, DateTime denNgay)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            var ttk = context.DoanDuLiches.Where(dll => dll.Tour_Id == tourId && dll.NgayKhoiHanh >= tuNgay && dll.NgayKetThuc <= denNgay)
                    .Select(dll => new Dto_ThongKeLoiNhuanTour
                    {
                        TenDoanDuLich = dll.TenDoanDuLich,
                        DoanhThu = decimal.Round(context.ChiTietDoans.Where(ctd => ctd.DoanDuLich_Id == dll.Id).Count() *
                                                context.GiaTours.FirstOrDefault(gt => gt.Tour_Id == dll.Tour_Id && gt.DangApDung).Gia,
                                                0,
                                                MidpointRounding.AwayFromZero),
                        ChiPhi = context.ChiPhis.Where(cp => cp.DoanDuLich_Id == dll.Id).Any() ?
                            context.ChiPhis.Where(cp => cp.DoanDuLich_Id == dll.Id).Select(cp => cp.SoTien).Sum() : 0,
                        SoLuongKhach = context.ChiTietDoans.Where(ctd => ctd.DoanDuLich_Id == dll.Id).Count()

                    })
                    .ToList();
            return ttk;
        }

        public List<Dto_ThongKeChiPhiTour> LayDsThongKeChiPhiTour(int tourId, DateTime tuNgay, DateTime denNgay)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            var cpt = context.ChiPhis.Where(cp => cp.DoanDuLich.Tour_Id == tourId && cp.DoanDuLich.NgayKhoiHanh >= tuNgay && cp.DoanDuLich.NgayKetThuc <= denNgay)
                    .GroupBy(cp => cp.LoaiChiPhi_Id)
                    .Select(cp => new Dto_ThongKeChiPhiTour
                    {
                        LoaiChiPhi = cp.First().LoaiChiPhi.TenLoai,
                        TongSoTien = cp.Sum(c => c.SoTien)

                    })
                    .ToList();
            return cpt;
        }

        public List<Dto_ThongKePhanCongNV> LayDsThongKePhanCongNV(int nhanVienid, DateTime tuNgay, DateTime denNgay)
        {
            TourManagementDataContext context = new TourManagementDataContext();
            var pcnv = context.PhanCongs.Where(pc => pc.NhanVien_Id == nhanVienid && pc.DoanDuLich.NgayKhoiHanh >= tuNgay && pc.DoanDuLich.NgayKetThuc <= denNgay)
                    .GroupBy(pc => pc.DoanDuLich.Tour_Id)
                    .Select(pc => new Dto_ThongKePhanCongNV
                    {
                        TenTour = pc.First().DoanDuLich.Tour.TenTour,
                        SoLanPhanCong = pc.Sum(c => c.NhanVien_Id)

                    })
                    .ToList();
            return pcnv;
        }
    }
}
