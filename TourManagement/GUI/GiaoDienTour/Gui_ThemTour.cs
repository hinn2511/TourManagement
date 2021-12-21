using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienTour
{
    public partial class Gui_ThemTour : Form
    {


        public Gui_ThemTour()
        {
            InitializeComponent();
            CapNhatDanhSachLoaiTour();
        }

  

        private void CapNhatDanhSachLoaiTour()
        {
            Bus_Tour bus_Tour = new Bus_Tour();
            List<LoaiTour> loaiTours = new List<LoaiTour>();
            loaiTours = bus_Tour.LayDanhSachLoaiTour();
            foreach (var l in loaiTours)
            {
                cbxLoaiTour.Items.Add(l.TenLoai);
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            GiaTour giaTour = new GiaTour();
            Dto_Tour tour = new Dto_Tour();
            tour.Loai_Id = cbxLoaiTour.SelectedIndex;
            tour.TenTour = txtTenTour.Text;
            tour.DacDiem = txtDacDiem.Text;
 
            Bus_Tour bus_Tour = new Bus_Tour();
            if (bus_Tour.ThemTourMoi(tour))
            {
                MessageBox.Show("Đã thêm tour thành công", "Thành công", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;

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
