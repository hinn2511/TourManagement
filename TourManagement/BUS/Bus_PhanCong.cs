using System.Collections.Generic;
using System.Linq;
using TourManagement.DAL;
using TourManagement.DTO;

namespace TourManagement.BUS
{
    public class Bus_PhanCong
    {
        public List<NhanVien> LayDanhSachNV()
        {
            Dal_NV dal_nv = new Dal_NV();

            var result = dal_nv.LayDanhSachNV();

            return result;
        }

        public List<Dto_PhanCong> LayDanhSachPhanCong(int NvId)
        {
            Dal_PhanCong dal_PC = new Dal_PhanCong();

            var result = dal_PC.LayDanhSachPhanCong(NvId);

            return result;
        }

        public int LaySoLuongNV(int NvId)
        {
            Dal_PhanCong dal_PC = new Dal_PhanCong();

            var result = dal_PC.SoLuongNvPhanCong(NvId);

            return result;
        }

        public bool SuaLichPhanCong(Dto_PhanCong pC, string nhiemVuMoi)
        {

            Dal_PhanCong dal_pc = new Dal_PhanCong();

            var pC1 = dal_pc.ChiTietPhanCongTheoNhiemVu(pC.NV_Id, nhiemVuMoi);

            if (pC1 != null)
            {
                pC1.NhiemVu = pC.NhiemVu;
                if (dal_pc.CapNhatPC(pC1))
                {
                    var pC2 = dal_pc.ChiTietPhanCongTheoDoanDuLich(pC.NV_Id, pC.DoanDuLich_Id);
                    if (pC2 != null)
                    {
                        pC2.NhiemVu = nhiemVuMoi;
                        if (dal_pc.CapNhatPC(pC2))
                            return true;
                    }
                }
            }
            return false;
        }

        /*public List<DoanDuLich> LayDanhSachDoanDuLich(int NvId)
        {
            Dal_PhanCong dal_pc = new Dal_PhanCong();

            List<DoanDuLich> dsDoanDuLich = dal_pc.DanhSachDoanDuLich();

            List<Dto_PhanCong> dsPhanCong = dal_pc.LayDanhSachPhanCong(NvId);

            List<DiaDiem> dsConLai = new List<DiaDiem>();

            foreach (var dd in dsDiaDiem)
            {
                if (dsDiaDiemThamQuan.FirstOrDefault(ddtq => ddtq.DiaDiem_Id == dd.Id) == null)
                    dsConLai.Add(dd);
            }
            return dsConLai;
    }*/

        public bool ThemPC(PhanCong pC)
        {
            Dal_PhanCong dal_pc = new Dal_PhanCong();

            int soLuongHienTai = dal_pc.SoLuongNvPhanCong(pC.NhanVien_Id);


            if (dal_pc.ThemPC(pC))
                return true;

            return false;

        }

        public bool XoaPC(Dto_PhanCong pC)
        {
            Dal_PhanCong dal_pc = new Dal_PhanCong();

            int soLuongHienTai = dal_pc.SoLuongNvPhanCong(pC.NV_Id);

            List<Dto_PhanCong> dsPC = dal_pc.LayDanhSachPhanCong(pC.NV_Id);
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
