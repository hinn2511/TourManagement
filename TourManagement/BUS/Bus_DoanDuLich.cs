using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TourManagement.DAL;
using TourManagement.DTO;

namespace TourManagement.BUS
{
    public class Bus_DoanDuLich
    {
        public List<Dto_DoanDuLich> LayDanhSachDoanDuLich()
        {
            Dal_DoanDuLich dal = new Dal_DoanDuLich();
            return dal.LayDanhSachDoanDuLich();
        }

        public List<Dto_Tour> LayDanhSachTour()
        {
            Dal_Tour dal = new Dal_Tour();
            return dal.LayDanhSachTour();
        }

        public bool ThemDoanDuLich(Dto_DoanDuLich doanDuLich)
        {
            Dal_DoanDuLich dal = new Dal_DoanDuLich();
            return dal.ThemDoanDuLich(dtoToEntity(doanDuLich));
        }

        public bool CapNhatDoanDuLich(Dto_DoanDuLich doanDuLich)
        {
            Dal_DoanDuLich dal = new Dal_DoanDuLich();
            return dal.CapNhatDoanDuLich(dtoToEntity(doanDuLich));
        }

        public DoanDuLich dtoToEntity(Dto_DoanDuLich dto)
        {
            DoanDuLich doan = new DoanDuLich();
            doan.Id = dto.Id;
            doan.TenDoanDuLich = dto.TenDoan;
            doan.NgayKetThuc = dto.NgayKetThuc;
            doan.NgayKhoiHanh = dto.NgayKhoiHanh;
            doan.Tour_Id = dto.Tour_Id;
            doan.HanhTrinh = dto.HanhTrinh;
            doan.KhachSan = dto.KhachSan;
            return doan;
        }


        public bool XoaDoanDuLich(int id)
        {
            Dal_DoanDuLich dal = new Dal_DoanDuLich();
            return dal.XoaDoanDuLich(id);
        }

        public DoanDuLich LayThongTinDoanDuLich(int id)
        {
            Dal_DoanDuLich dal = new Dal_DoanDuLich();
            return dal.LayThongTinDoanDuLich(id);
        }

        public List<Dto_DoanDuLich> TimKiemDoanDuLich(List<Dto_DoanDuLich> dsDoanDuLich, string tukhoa)
        {
            var result = dsDoanDuLich.Where(t => t.TenDoan.Contains(tukhoa)).ToList();
            return result;
        }
    }
}
