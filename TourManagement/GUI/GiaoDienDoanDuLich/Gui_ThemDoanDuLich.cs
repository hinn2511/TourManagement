using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienDoanDuLich
{
    public partial class Gui_ThemDoanDuLich : Form
    {

        List<Dto_Tour> dsTour;
        public Gui_ThemDoanDuLich()
        {
            InitializeComponent();
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
            dtNgayKhoiHanh.Value = DateTime.Now;
            dtNgayKetThuc.Value = DateTime.Now;
            dtNgayKhoiHanh.MinDate = DateTime.Now;
            dtNgayKetThuc.MinDate = DateTime.Now;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbxTour.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tour", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (dtNgayKhoiHanh.Value > dtNgayKetThuc.Value)
            {
                MessageBox.Show("Ngày khởi hành không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            if (txtHanhTrinh.Text == null || txtKhachSan == null || txtTenDoan == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            Dto_DoanDuLich doanDuLich = new Dto_DoanDuLich();

            doanDuLich.NgayKhoiHanh = dtNgayKhoiHanh.Value;
            doanDuLich.NgayKetThuc = dtNgayKetThuc.Value;
            doanDuLich.HanhTrinh = txtHanhTrinh.Text;
            doanDuLich.KhachSan = txtKhachSan.Text;
            doanDuLich.TenDoan = txtTenDoan.Text;
            doanDuLich.Tour_Id = dsTour[cbxTour.SelectedIndex].Id;

            Bus_DoanDuLich bus = new Bus_DoanDuLich();
            if (bus.ThemDoanDuLich(doanDuLich))
            {
                MessageBox.Show("Đã thêm đoàn du lịch thành công", "Thành công", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
