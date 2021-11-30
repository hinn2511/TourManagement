using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TourManagement.DAL;
using TourManagement.DTO;

namespace TourManagement.BUS
{
    public class Bus_ChiTietDoan
    {
        public List<Dto_ChiTietDoan> LayDanhSachChiTietDoan(int doanId)
        {
            Dal_ChiTietDoan dal = new Dal_ChiTietDoan();
            return dal.LayDanhSachChiTietDoan(doanId);
        }

        public bool XoaChiTietDoan(Dto_ChiTietDoan chiTietDoan)
        {
            Dal_ChiTietDoan dal_ChiTietDoan = new Dal_ChiTietDoan();
            return dal_ChiTietDoan.XoaChiTietDoan(chiTietDoan.DoanDuLich_Id, chiTietDoan.KhachHang_Id);
        }

        public bool ThemChiTietDoan(Dto_ChiTietDoan chiTietDoan)
        {
            Dal_ChiTietDoan dal_chiTietDoan = new Dal_ChiTietDoan();
            ChiTietDoan ctd = new ChiTietDoan();
            ctd.KhachHang_Id = chiTietDoan.KhachHang_Id;
            ctd.DoanDuLich_Id = chiTietDoan.DoanDuLich_Id;
            if (dal_chiTietDoan.ThemChiTietDoan(ctd))
            {
                Dal_DoanDuLich dal_doanDuLich = new Dal_DoanDuLich();
                var doan = dal_doanDuLich.ChiTietDoanDuLich(chiTietDoan.DoanDuLich_Id);
                Dal_GiaTour dal_GiaTour = new Dal_GiaTour();
                decimal gia = dal_GiaTour.GiaTourDangApDung(doan.Tour_Id).Gia;
                Debug.WriteLine(gia);
                doan.DoanhThu = doan.DoanhThu + gia;
                Debug.WriteLine(gia);
                if (dal_doanDuLich.CapNhatDoanDuLich(doan))
                    return true;
            }
            return false;
        }

        public List<KhachHang> LayDanhSachKhachHangChuaThamGia(int doanId)
        {
            Dal_ChiTietDoan dal_chiTietDoan = new Dal_ChiTietDoan();
            var dsDaThamGia = dal_chiTietDoan.LayDanhSachChiTietDoan(doanId);
            Dal_KH dal_KH = new Dal_KH();
            var dsKhachHang = dal_KH.LayDanhSachKH();
            List<KhachHang> dsChuaThamGia = new List<KhachHang>();
            foreach (var item in dsKhachHang)
            {
                if (dsDaThamGia.FirstOrDefault(dtg => dtg.KhachHang_Id == item.Id) == null)
                    dsChuaThamGia.Add(item);
            }
            return dsChuaThamGia;
        }
    }
}
