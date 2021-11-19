using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;

namespace TourManagement.GUI.GiaoDienLoaiTour
{
    public partial class Gui_ThemLoaiTour : Form
    {


        public Gui_ThemLoaiTour()
        {
            InitializeComponent();
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Bus_LoaiTour bus = new Bus_LoaiTour();
            LoaiTour loaiTour = new LoaiTour();
            loaiTour.TenLoai = txtTenLoaiTour.Text;
            if (bus.ThemLoaiTour(loaiTour))
            {
                MessageBox.Show("Đã thêm loại tour thành công", "Thành công", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
        }
    }
}
