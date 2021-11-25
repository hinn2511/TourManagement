using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienTour
{
    public partial class Gui_SuaTour : Form
    {
        List<LoaiTour> dsLoaiTour;
        Dto_Tour tour;

        public Gui_SuaTour(Dto_Tour tourCanSua)
        {
            InitializeComponent();
            tour = tourCanSua;
            txtDacDiem.Text = tourCanSua.DacDiem;
            txtTenTour.Text = tourCanSua.TenTour;
            cbxLoaiTour.Text = tourCanSua.Loai;
            LayDanhSachLoaiTour();
        }

        private void LayDanhSachLoaiTour()
        {
            Bus_Tour bus = new Bus_Tour();
            dsLoaiTour = bus.LayDanhSachLoaiTour(tour.Loai);
            foreach (var item in dsLoaiTour)
            {
                cbxLoaiTour.Items.Add(item.TenLoai);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbxLoaiTour_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxLoaiTour.SelectedIndex > 0)
            {
                tour.Loai_Id = dsLoaiTour[cbxLoaiTour.SelectedIndex].Id;
            }

        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            tour.TenTour = txtTenTour.Text;
            tour.DacDiem = txtDacDiem.Text;
            Bus_Tour bus = new Bus_Tour();
            if (bus.SuaThongTinTour(tour))
            {
                MessageBox.Show("Sửa thông tin tour thành công", "Thành công", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("Sửa thông tin tour không thành công", "Lỗi", MessageBoxButtons.OK);
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }
    }
}
