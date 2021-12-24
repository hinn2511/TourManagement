using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TourManagement.DTO;

namespace TourManagement.DAL
{

    public class Dal_PhanCong
    {
        TourManagementDataContext context = new TourManagementDataContext();
        public List<Dto_PhanCong> LayDanhSachPhanCong(int NvId)
        {
            List<Dto_PhanCong> dsPhanCong = context.PhanCongs.Where(pc => pc.NhanVien_Id == NvId).Select(pc => new Dto_PhanCong
            {
                NV_Id = pc.NhanVien_Id,
                HoTen = pc.NhanVien.HoTen,
                DoanDuLich_Id = pc.DoanDuLich_Id,
                TenDoan = pc.DoanDuLich.TenDoanDuLich,
                NhiemVu = pc.NhiemVu
            }).ToList();
            return dsPhanCong;
        }

        public PhanCong ChiTietPhanCongTheoDoanDuLich(int NvId, int DoanDuLichId)
        {
            var PhanCong = context.PhanCongs.FirstOrDefault(pc => pc.NhanVien_Id == NvId && pc.DoanDuLich_Id == DoanDuLichId);

            return PhanCong;
        }

        public PhanCong ChiTietPhanCongTheoNhiemVu(int NvId, string Nhiemvu)
        {
            var PhanCong = context.PhanCongs.FirstOrDefault(pc => pc.NhanVien_Id == NvId && pc.NhiemVu == Nhiemvu);

            return PhanCong;
        }

        public int SoLuongNvPhanCong(int NvId)
        {
            var soLuong = context.PhanCongs.Where(pc => pc.NhanVien_Id == NvId).Count();

            return soLuong;
        }

        public bool ThemPC(PhanCong phanCong)
        {
            context.PhanCongs.InsertOnSubmit(phanCong);

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

        public bool CapNhatPC(PhanCong phanCong)
        {
            var PcUpdate = context.PhanCongs.FirstOrDefault(pc => pc.NhanVien_Id == phanCong.NhanVien_Id && pc.DoanDuLich_Id == phanCong.DoanDuLich_Id);

            if (PcUpdate != null)
            {
                PcUpdate.NhiemVu = phanCong.NhiemVu;
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

        public bool XoaPC(int NvId, int doanDuLichId)
        {
            var PcDelete = context.PhanCongs.FirstOrDefault(pc => pc.NhanVien_Id == NvId && pc.DoanDuLich_Id == doanDuLichId);

            if (PcDelete != null)
            {
                context.PhanCongs.DeleteOnSubmit(PcDelete);

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
        public List<DoanDuLich> DanhSachDDL()
        {
            var dsDDL = context.DoanDuLiches.ToList();

            return dsDDL;
        }
    }
}
