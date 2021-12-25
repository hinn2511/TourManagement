using System.Collections.Generic;
using System.Linq;
using TourManagement.DAL;
using TourManagement.DTO;

namespace TourManagement.BUS
{
    public class Bus_PhanCong
    {
        Dal_PhanCong dal_PC = new Dal_PhanCong();
        public List<Dto_PhanCong> LayDanhSachPhanCong(int NvId)
        {
            return dal_PC.LayDanhSachPhanCong(NvId);
        }
        public List<DoanDuLich> LayDanhSachDDL(int NvId)
        {
            Dal_PhanCong dal_PC = new Dal_PhanCong();

            List<DoanDuLich> dsDDL = dal_PC.DanhSachDDL();

            List<Dto_PhanCong> dsDDLPhanCong = dal_PC.LayDanhSachPhanCong(NvId);

            List<DoanDuLich> dsDDLConLai = new List<DoanDuLich>();

            foreach (var dd in dsDDL)
            {
                if (dsDDLPhanCong.FirstOrDefault(ddlpc => ddlpc.DoanDuLich_Id == dd.Id) == null)
                    dsDDLConLai.Add(dd);
            }
            return dsDDLConLai;
        }
        public bool SuaPhanCong(Dto_PhanCong pcCanSua)
        {
            if (dal_PC.CapNhatPC(ConvertToEntity(pcCanSua)))
                return true;
            return false;
        }
    
        public PhanCong ConvertToEntity(Dto_PhanCong dto)
        {
            PhanCong pc = new PhanCong();
            pc.NhanVien_Id = dto.NV_Id;
            pc.DoanDuLich_Id = dto.DoanDuLich_Id;
            pc.NhiemVu = dto.NhiemVu;
            return pc;
        }

        public bool ThemPC(Dto_PhanCong PC)
        {
            if (dal_PC.ThemPC(ConvertToEntity(PC)))
                return true;
            return false;
        }

        public bool XoaPC(int NvId, int ddlID)
        {
            return dal_PC.XoaPC(NvId, ddlID);

        }
        public Dto_PhanCong ChiTietPhanCong(int NvId, int doandulichId)
        {
            var result = dal_PC.ChiTietPhanCongTheoDoanDuLich(NvId, doandulichId);
            return convertToDto(result);
        }
        public Dto_PhanCong convertToDto(PhanCong phanCong)
        {
            Dto_PhanCong dto = new Dto_PhanCong();
            dto.NV_Id = phanCong.NhanVien_Id;
            dto.DoanDuLich_Id = phanCong.DoanDuLich_Id;
            dto.NhiemVu = phanCong.NhiemVu;
            dto.HoTen = phanCong.NhanVien.HoTen;
            dto.TenDoan = phanCong.DoanDuLich.TenDoanDuLich;
            return dto;
        }
        public string LayTenDoan(int ddlId)
        {
            Dal_DoanDuLich dal_ddl = new Dal_DoanDuLich();

            var result = dal_ddl.ChiTietDoanDuLich(ddlId).TenDoanDuLich;

            return result;
        }
    }
}
