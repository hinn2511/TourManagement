using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienDoanDuLich
{
    public partial class Gui_ChiTietDoanDuLich : Form
    {


        public Gui_ChiTietDoanDuLich(Dto_DoanDuLich doanDuLich)
        {
            InitializeComponent();
            txtChiPhi.Text = doanDuLich.ChiPhi.ToString();
            txtDoanhThu.Text = doanDuLich.DoanhThu.ToString();
            txtHanhTrinh.Text = doanDuLich.HanhTrinh;
            txtKhachSan.Text = doanDuLich.KhachSan;
            txtNgayKhoiHanh.Text = doanDuLich.NgayKhoiHanh.ToString();
            txtNgayKetThuc.Text = doanDuLich.NgayKetThuc.ToString();
            txtTenDoan.Text = doanDuLich.TenDoan;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
