using System.Collections.Generic;
using System.Linq;
using TourManagement.DAL;
using TourManagement.DTO;

namespace TourManagement.BUS
{
    public class Bus_ThamQuan
    {
        public List<Dto_Tour> LayDanhSachTour()
        {
            Dal_Tour dal_tour = new Dal_Tour();

            var result = dal_tour.LayDanhSachTour();

            return result;
        }

        public List<Dto_ThamQuan> LayDanhSachThamQuan(int tourId)
        {
            Dal_ThamQuan dal_ThamQuan = new Dal_ThamQuan();

            var result = dal_ThamQuan.LayDanhSachThamQuan(tourId);

            return result;
        }

        public int LaySoLuongDiaDiem(int tourId)
        {
            Dal_ThamQuan dal_ThamQuan = new Dal_ThamQuan();

            var result = dal_ThamQuan.SoLuongDiaDiemThamQuan(tourId);

            return result;
        }

        public bool SuaLichTrinhThamQuan(Dto_ThamQuan thamQuan, int thuTuMoi)
        {

            Dal_ThamQuan dal_ThamQuan = new Dal_ThamQuan();

            var thamQuan1 = dal_ThamQuan.ChiTietThamQuanTheoThuTu(thamQuan.Tour_Id, thuTuMoi);

            if (thamQuan1 != null)
            {
                thamQuan1.ThuTu = thamQuan.ThuTu;
                if (dal_ThamQuan.CapNhatThamQuan(thamQuan1))
                {
                    var thamQuan2 = dal_ThamQuan.ChiTietThamQuanTheoDiaDiem(thamQuan.Tour_Id, thamQuan.DiaDiem_Id);
                    if (thamQuan2 != null)
                    {
                        thamQuan2.ThuTu = thuTuMoi;
                        if (dal_ThamQuan.CapNhatThamQuan(thamQuan2))
                            return true;
                    }
                }
            }
            return false;
        }

        public List<DiaDiem> LayDanhSachDiaDiem(int tourId)
        {
            Dal_ThamQuan dal_ThamQuan = new Dal_ThamQuan();

            List<DiaDiem> dsDiaDiem = dal_ThamQuan.DanhSachDiaDiem();

            List<Dto_ThamQuan> dsDiaDiemThamQuan = dal_ThamQuan.LayDanhSachThamQuan(tourId);

            List<DiaDiem> dsConLai = new List<DiaDiem>();

            foreach (var dd in dsDiaDiem)
            {
                if (dsDiaDiemThamQuan.FirstOrDefault(ddtq => ddtq.DiaDiem_Id == dd.Id) == null)
                    dsConLai.Add(dd);
            }
            return dsConLai;
        }

        public bool ThemThamQuan(ThamQuan thamQuan)
        {
            Dal_ThamQuan dal_ThamQuan = new Dal_ThamQuan();

            int soLuongHienTai = dal_ThamQuan.SoLuongDiaDiemThamQuan(thamQuan.Tour_Id);

            thamQuan.ThuTu = soLuongHienTai + 1;

            if (dal_ThamQuan.ThemThamQuan(thamQuan))
                return true;

            return false;

        }

        public bool XoaThamQuan(Dto_ThamQuan thamQuan)
        {
            Dal_ThamQuan dal_ThamQuan = new Dal_ThamQuan();

            int soLuongHienTai = dal_ThamQuan.SoLuongDiaDiemThamQuan(thamQuan.Tour_Id);

            List<Dto_ThamQuan> dsThamQuan = dal_ThamQuan.LayDanhSachThamQuan(thamQuan.Tour_Id);

            if (thamQuan.ThuTu != soLuongHienTai)
            {
                for (int i = thamQuan.ThuTu - 1; i < soLuongHienTai; i++)
                {
                    ThamQuan tq = new ThamQuan();
                    tq.Tour_Id = dsThamQuan[i].Tour_Id;
                    tq.DiaDiem_Id = dsThamQuan[i].DiaDiem_Id;
                    tq.ThuTu = i;
                    if (dal_ThamQuan.CapNhatThamQuan(tq))
                        continue;
                }
            }

            if (dal_ThamQuan.XoaThamQuan(thamQuan.Tour_Id, thamQuan.DiaDiem_Id))
                return true;

            return false;

        }
    }
}
