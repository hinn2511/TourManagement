using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;

namespace TourManagement.GUI.GiaoDienTour
{
    public partial class Gui_ThemTour : Form
    {


        public Gui_ThemTour()
        {
            InitializeComponent();
            DieuChinhNgayGiaTour();
            CapNhatDanhSachLoaiTour();
        }

        private void DieuChinhNgayGiaTour()
        {
            dtNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtNgayBatDau.CustomFormat = "dd/MM/yyyy";
            dtNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            dtNgayBatDau.Value = DateTime.Now;
            dtNgayKetThuc.Value = DateTime.Now;
            dtNgayBatDau.MinDate = DateTime.Now;
            dtNgayKetThuc.MinDate = DateTime.Now;
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
            Tour tour = new Tour();
            tour.LoaiTour_Id = cbxLoaiTour.SelectedIndex;
            tour.TenTour = txtTenTour.Text;
            tour.DacDiem = txtDacDiem.Text;
            giaTour.DangApDung = false;

            giaTour.NgayBatDau = dtNgayBatDau.Value;
            giaTour.NgayKetThuc = dtNgayKetThuc.Value;
            decimal gia;
            if (!decimal.TryParse(txtGiaTour.Text, out gia))
                MessageBox.Show("Giá tour không hợp lệ", "Lỗi", MessageBoxButtons.OK);
            else
            {
                giaTour.Gia = gia;
                Bus_Tour bus_Tour = new Bus_Tour();
                if (bus_Tour.ThemTourMoi(tour, giaTour))
                    MessageBox.Show("Đã thêm tour thành công", "Thành công", MessageBoxButtons.OK);

                DialogResult = DialogResult.OK;
                Close();
            }



        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
