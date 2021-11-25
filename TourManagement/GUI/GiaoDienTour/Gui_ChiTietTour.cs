using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienTour
{
    public partial class Gui_ChiTietTour : Form
    {


        public Gui_ChiTietTour(Dto_Tour tour)
        {
            InitializeComponent();
            LayThongTinTour(tour);
            LayThongTinGiaTour(tour);
            LayDanhSachThamQuanTour(tour);
        }

        private void LayThongTinTour(Dto_Tour tour)
        {
            Bus_Tour bus = new Bus_Tour();
            Tour t = bus.LayThongTinTour(tour.Id);
            txtTenTour.Text = t.TenTour;
            txtDacDiem.Text = t.DacDiem;
            txtLoaiTour.Text = t.LoaiTour.TenLoai;
            GiaTour gt = bus.LayGiaTour(tour.Id);
            txtGiaTour.Text = gt.Gia.ToString();
            txtNgayBatDau.Text = gt.NgayBatDau.ToString();
            txtNgayKetThuc.Text = gt.NgayKetThuc.ToString();
            List<Dto_ThamQuan> dsThamQuan = bus.LayLichTrinhThamQuan(tour.Id);
            thamQuanGridView.DataSource = dsThamQuan;
        }

        private void LayThongTinGiaTour(Dto_Tour tour)
        {
            Bus_Tour bus = new Bus_Tour();
            GiaTour gt = bus.LayGiaTour(tour.Id);
            txtGiaTour.Text = gt.Gia.ToString();
            txtNgayBatDau.Text = gt.NgayBatDau.ToShortDateString().ToString();
            txtNgayKetThuc.Text = gt.NgayKetThuc.ToShortDateString().ToString();
        }

        private void LayDanhSachThamQuanTour(Dto_Tour tour)
        {
            Bus_Tour bus = new Bus_Tour();
            List<Dto_ThamQuan> dsThamQuan = bus.LayLichTrinhThamQuan(tour.Id);
            thamQuanGridView.DataSource = dsThamQuan;
            thamQuanGridView.Columns["DiaDiem_Id"].HeaderText = "Mã địa điểm";
            thamQuanGridView.Columns["tenDiaDiem"].HeaderText = "Tên địa điểm";
            thamQuanGridView.Columns["ThuTu"].HeaderText = "Thứ tự";
            thamQuanGridView.Columns["Tour_Id"].Visible = false;
            thamQuanGridView.Columns["TenTour"].Visible = false;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
