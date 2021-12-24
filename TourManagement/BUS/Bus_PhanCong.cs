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

        public bool XoaPC(Dto_PhanCong PC)
        {
            Dal_PhanCong dal_PC = new Dal_PhanCong();

            int soLuongHienTai = dal_PC.SoLuongNvPhanCong(PC.NV_Id);

            List<Dto_PhanCong> dsPC = dal_PC.LayDanhSachPhanCong(PC.NV_Id);
            /*
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
            */
            return false;

        }
    }
}
