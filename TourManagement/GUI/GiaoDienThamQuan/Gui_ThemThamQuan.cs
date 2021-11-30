using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienThamQuan
{
    public partial class Gui_ThemThamQuan : Form
    {
        Dto_Tour tourThemLichTrinh;
        List<DiaDiem> dsDiaDiem;

        public Gui_ThemThamQuan(Dto_Tour tour)
        {
            InitializeComponent();
            tourThemLichTrinh = tour;
            txtTenTour.Text = tour.TenTour;
            LayDanhSachDiaDiem();
        }


        private void LayDanhSachDiaDiem()
        {
            Bus_ThamQuan bus = new Bus_ThamQuan();
            dsDiaDiem = bus.LayDanhSachDiaDiem(tourThemLichTrinh.Id);
            foreach (var item in dsDiaDiem)
            {
                cbxDiaDiem.Items.Add(item.TenDiaDiem);
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbxDiaDiem.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn địa điểm", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            ThamQuan thamQuan = new ThamQuan();
            thamQuan.Tour_Id = tourThemLichTrinh.Id;
            thamQuan.DiaDiem_Id = dsDiaDiem[cbxDiaDiem.SelectedIndex].Id;

            Bus_ThamQuan bus = new Bus_ThamQuan();
            if (bus.ThemThamQuan(thamQuan))
            {
                MessageBox.Show("Đã thêm lịch trình tham quan thành công", "Thành công", MessageBoxButtons.OK);
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
