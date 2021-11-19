using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;

namespace TourManagement.GUI.GiaoDienLoaiTour
{
    public partial class Gui_SuaLoaiTour : Form
    {
        int loaiTourId;
        string tenLoaiTour;

        public Gui_SuaLoaiTour(int id, string tenLoai)
        {
            InitializeComponent();
            loaiTourId = id;
            tenLoaiTour = tenLoai;
            txtTenLoaiTour.Text = tenLoai;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LayThongTinLoaiTour()
        {
            Bus_LoaiTour bus = new Bus_LoaiTour();
            var loaiTour = bus.LayThongTinLoaiTour(loaiTourId);
            if (loaiTour != null)
                txtTenLoaiTour.Text = loaiTour.TenLoai;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Bus_LoaiTour bus = new Bus_LoaiTour();
            LoaiTour loaiTour = new LoaiTour();
            loaiTour.Id = loaiTourId;
            loaiTour.TenLoai = txtTenLoaiTour.Text;
            if (tenLoaiTour.Equals(txtTenLoaiTour.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin mới", "Lỗi", MessageBoxButtons.OK);
                return;
            }    
            if (bus.CapNhatLoaiTour(loaiTour))
            {
                MessageBox.Show("Đã cập nhật loại tour thành công", "Thành công", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
        }
    }
}
