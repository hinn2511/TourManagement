using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienDoanDuLich
{
    public partial class Gui_SuaDoanDuLich : Form
    {
        Dto_DoanDuLich currentDoanDuLich;
        List<Dto_Tour> dsTour;

        public Gui_SuaDoanDuLich(Dto_DoanDuLich doanDuLich)
        {
            InitializeComponent();
            currentDoanDuLich = doanDuLich;
            cbxTour.Text = doanDuLich.TenTour;
            txtTenDoan.Text = doanDuLich.TenDoan;
            dtNgayKhoiHanh.Value = currentDoanDuLich.NgayKhoiHanh;
            dtNgayKetThuc.Value = currentDoanDuLich.NgayKetThuc;
            LayDanhSachTour();
            DieuChinhNgayDoanDuLich();
        }

        private void LayDanhSachTour()
        {
            Bus_DoanDuLich bus = new Bus_DoanDuLich();
            dsTour = bus.LayDanhSachTour();
            foreach (var item in dsTour)
            {
                cbxTour.Items.Add(item.TenTour);
            }
        }

        private void DieuChinhNgayDoanDuLich()
        {
            dtNgayKhoiHanh.Format = DateTimePickerFormat.Custom;
            dtNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtNgayKhoiHanh.CustomFormat = "dd/MM/yyyy";
            dtNgayKetThuc.CustomFormat = "dd/MM/yyyy";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            currentDoanDuLich.NgayKhoiHanh = dtNgayKhoiHanh.Value;
            currentDoanDuLich.NgayKetThuc = dtNgayKetThuc.Value;
            currentDoanDuLich.TenDoan = txtTenDoan.Text;
            if (currentDoanDuLich.NgayKhoiHanh > currentDoanDuLich.NgayKetThuc)
            {
                MessageBox.Show("Ngày khởi hành hoặc ngày kết thúc không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (cbxTour.SelectedIndex > 0)
            {
                currentDoanDuLich.Tour_Id = dsTour[cbxTour.SelectedIndex].Id;
            }

            Bus_DoanDuLich bus = new Bus_DoanDuLich();
            if (bus.CapNhatDoanDuLich(currentDoanDuLich))
            {
                MessageBox.Show("Đã sửa đoàn du lịch thành công", "Thành công", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


    }
}
