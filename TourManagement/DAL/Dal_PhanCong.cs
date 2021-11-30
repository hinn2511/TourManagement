using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TourManagement.DTO;

namespace TourManagement.DAL
{

    public class Dal_PhanCong
    {
        public List<DoanDuLich> DanhSachDoanDuLich()
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var dsDoanDuLich = context.DoanDuLiches.ToList();

            return dsDoanDuLich;
        }

        public List<Dto_PhanCong> LayDanhSachPhanCong(int NvId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            List<Dto_PhanCong> dsPhanCong = (from phancong in context.PhanCongs
                                             join nhanvien in context.NhanViens on phancong.NhanVien_Id equals nhanvien.Id
                                             join doandulich in context.DoanDuLiches on phancong.DoanDuLich_Id equals doandulich.Id
                                             where phancong.NhanVien_Id == NvId
                                             select new Dto_PhanCong
                                             {
                                                 NV_Id = phancong.NhanVien_Id,
                                                 HoTen = nhanvien.HoTen,
                                                 DoanDuLich_Id = phancong.DoanDuLich_Id,
                                                 NhiemVu = phancong.NhiemVu
                                             }).ToList();
            return dsPhanCong;
        }

        public PhanCong ChiTietPhanCongTheoDoanDuLich(int NvId, int DoanDuLichId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var PhanCong = context.PhanCongs.FirstOrDefault(pc => pc.NhanVien_Id == NvId && pc.DoanDuLich_Id == DoanDuLichId);

            return PhanCong;
        }

        public PhanCong ChiTietPhanCongTheoNhiemVu(int NvId, string Nhiemvu)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var PhanCong = context.PhanCongs.FirstOrDefault(pc => pc.NhanVien_Id == NvId && pc.NhiemVu == Nhiemvu);

            return PhanCong;
        }

        public int SoLuongNvPhanCong(int NvId)
        {
            TourManagementDataContext context = new TourManagementDataContext();

            var soLuong = context.PhanCongs.Where(pc => pc.NhanVien_Id == NvId).Count();

            return soLuong;
        }

        public bool ThemPC(PhanCong phanCong)
        {
            TourManagementDataContext context = new TourManagementDataContext();
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
            TourManagementDataContext context = new TourManagementDataContext();

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
            TourManagementDataContext context = new TourManagementDataContext();

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
    }
}
