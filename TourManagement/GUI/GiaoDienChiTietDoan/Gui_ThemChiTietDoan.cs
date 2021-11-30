using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienChiTietDoan
{
    public partial class Gui_ThemChiTietDoan : Form
    {
        List<KhachHang> dsKhachHangChuaThamGia;
        Dto_DoanDuLich currentDoanDuLich;

        public Gui_ThemChiTietDoan(Dto_DoanDuLich doanDuLich)
        {
            InitializeComponent();
            currentDoanDuLich = doanDuLich;
            CapNhatDanhSachKhachHang();

            //txtTenTour.Text = tour.TenTour;
        }

        private void CapNhatDanhSachKhachHang()
        {
            Bus_ChiTietDoan bus = new Bus_ChiTietDoan();
            dsKhachHangChuaThamGia = bus.LayDanhSachKhachHangChuaThamGia(currentDoanDuLich.Id);
            foreach (var item in dsKhachHangChuaThamGia)
            {
                cbxKhachHang.Items.Add(item.HoTen);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //decimal gia;
            //if (!decimal.TryParse(txtGiaTour.Text, out gia))
            //{
            //    MessageBox.Show("Giá tour không hợp lệ", "Lỗi", MessageBoxButtons.OK);
            //    return;

            //}
            //GiaTour giaTour = new GiaTour();
            //giaTour.DangApDung = false;
            //giaTour.Tour_Id = tourThemGia.Id;
            //giaTour.NgayBatDau = dtNgayBatDau.Value;
            //giaTour.NgayKetThuc = dtNgayKetThuc.Value;
            //giaTour.Gia = gia;
            Dto_ChiTietDoan chiTietDoanMoi = new Dto_ChiTietDoan();
            chiTietDoanMoi.KhachHang_Id = dsKhachHangChuaThamGia[cbxKhachHang.SelectedIndex].Id;
            chiTietDoanMoi.DoanDuLich_Id = currentDoanDuLich.Id;
            Bus_ChiTietDoan bus = new Bus_ChiTietDoan();
            if (bus.ThemChiTietDoan(chiTietDoanMoi))
            {
                MessageBox.Show("Đã thêm khách hàng thành công", "Thành công", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
