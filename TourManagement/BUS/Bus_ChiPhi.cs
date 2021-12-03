using System.Collections.Generic;
using System.Linq;
using TourManagement.DAL;
using TourManagement.DTO;

namespace TourManagement.BUS
{
    public class Bus_ChiPhi
    {
        Dal_ChiPhi dal = new Dal_ChiPhi();

        public List<Dto_ChiPhi> LayDanhSachChiPhi(int doanDuLichId)
        {
            return dal.LayDsChiPhiTheoDoan(doanDuLichId);
        }

        public List<LoaiChiPhi> LayDanhSachLoaiChiPhi()
        {
            Dal_LoaiChiPhi dal_loaiChiPhi = new Dal_LoaiChiPhi();
            return dal_loaiChiPhi.LayDsLoaiChiPhi();
        }

        public bool ThemChiPhi(Dto_ChiPhi chiPhi)
        {
            return dal.Them(dtoToEntity(chiPhi));
        }

        public bool XoaChiPhi(int id)
        {
            return dal.Xoa(id);
        }

        public bool CapNhatChiPhi(Dto_ChiPhi chiPhi)
        {
            return dal.CapNhat(dtoToEntity(chiPhi));
        }

        public ChiPhi LayThongTinChiPhi(int id)
        {
            return dal.LayThongTinChiPhi(id);
        }

        public List<Dto_ChiPhi> TimKiem(List<Dto_ChiPhi> dsChiPhi, string key)
        {
            return dsChiPhi.Where(cp => cp.TenLoaiChiPhi.Contains(key)).ToList();

        }

        public ChiPhi dtoToEntity(Dto_ChiPhi dto)
        {
            ChiPhi cp = new ChiPhi();
            cp.Id = dto.Id;
            cp.LoaiChiPhi_Id = dto.LoaiChiPhi_id;
            cp.DoanDuLich_Id = dto.DoanDuLich_Id;
            cp.SoTien = dto.SoTien;
            return cp;
        }
    }
}
