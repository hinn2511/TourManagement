using System.Collections.Generic;
using System.Linq;
using TourManagement.DAL;
using TourManagement.DTO;

namespace TourManagement.BUS
{
    public class Bus_ThamQuan
    {

        public string LayTenTour(int tourId)
        {
            Dal_Tour dal_tour = new Dal_Tour();

            var result = dal_tour.ChiTietTour(tourId).TenTour;

            return result;
        }

        public Dto_ThamQuan ChiTietThamQuan(int tourId, int diadiemId)
        {
            Dal_ThamQuan dal_ThamQuan = new Dal_ThamQuan();

            var result = dal_ThamQuan.ChiTietThamQuanTheoDiaDiem(tourId, diadiemId);

            return convertToDto(result);
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

        public bool SuaLichTrinhThamQuan(Dto_ThamQuan thamQuan)
        {
            Dal_ThamQuan dal_ThamQuan = new Dal_ThamQuan();

            var thamQuanHienTai = dal_ThamQuan.ChiTietThamQuanTheoDiaDiem(thamQuan.Tour_Id, thamQuan.DiaDiem_Id);
            int thuTuCu = thamQuanHienTai.ThuTu;
            var thamQuanCanDoi = dal_ThamQuan.ChiTietThamQuanTheoThuTu(thamQuan.Tour_Id, thamQuan.ThuTu);

            if (thamQuanHienTai != null && thamQuanCanDoi != null)
            {
                thamQuanHienTai.ThuTu = thamQuan.ThuTu;
                if (dal_ThamQuan.CapNhatThamQuan(thamQuanHienTai))
                {

                    thamQuanCanDoi.ThuTu = thuTuCu;
                    if (dal_ThamQuan.CapNhatThamQuan(thamQuanCanDoi))
                        return true;
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

        public bool ThemThamQuan(Dto_ThamQuan thamQuan)
        {
            Dal_ThamQuan dal_ThamQuan = new Dal_ThamQuan();

            int soLuongHienTai = dal_ThamQuan.SoLuongDiaDiemThamQuan(thamQuan.Tour_Id);

            thamQuan.ThuTu = soLuongHienTai + 1;

            if (dal_ThamQuan.ThemThamQuan(convertToEntity(thamQuan)))
                return true;

            return false;

        }

        public bool XoaThamQuan(int tourId, int diaDiemId)
        {
            Dal_ThamQuan dal_ThamQuan = new Dal_ThamQuan();

            var chiTietThamQuan = ChiTietThamQuan(tourId, diaDiemId);

            int soLuongHienTai = dal_ThamQuan.SoLuongDiaDiemThamQuan(chiTietThamQuan.Tour_Id);

            List<Dto_ThamQuan> dsThamQuan = dal_ThamQuan.LayDanhSachThamQuan(chiTietThamQuan.Tour_Id);

            if (chiTietThamQuan.ThuTu != soLuongHienTai)
            {
                for (int i = chiTietThamQuan.ThuTu - 1; i < soLuongHienTai; i++)
                {
                    ThamQuan tq = new ThamQuan();
                    tq.Tour_Id = dsThamQuan[i].Tour_Id;
                    tq.DiaDiem_Id = dsThamQuan[i].DiaDiem_Id;
                    tq.ThuTu = i;
                    if (dal_ThamQuan.CapNhatThamQuan(tq))
                        continue;
                }
            }

            if (dal_ThamQuan.XoaThamQuan(chiTietThamQuan.Tour_Id, chiTietThamQuan.DiaDiem_Id))
                return true;

            return false;

        }

        public ThamQuan convertToEntity(Dto_ThamQuan dto)
        {
            ThamQuan tq = new ThamQuan();
            tq.Tour_Id = dto.Tour_Id;
            tq.DiaDiem_Id = dto.DiaDiem_Id;
            tq.ThuTu = dto.ThuTu;
            return tq;
        }

        public Dto_ThamQuan convertToDto(ThamQuan thamQuan)
        {
            Dto_ThamQuan dto = new Dto_ThamQuan();
            dto.Tour_Id = thamQuan.Tour_Id;
            dto.DiaDiem_Id = thamQuan.DiaDiem_Id;
            dto.ThuTu = thamQuan.ThuTu;
            dto.TenTour = thamQuan.Tour.TenTour;
            dto.TenDiaDiem = thamQuan.DiaDiem.TenDiaDiem;
            return dto;
        }
    }
}
