using System;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienGiaTour
{
    public partial class Gui_ThemGiaTour : Form
    {
        Dto_Tour tourThemGia;

        public Gui_ThemGiaTour(Dto_Tour tour)
        {
            InitializeComponent();
            DieuChinhNgayGiaTour();
            tourThemGia = tour;
            txtTenTour.Text = tour.TenTour;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dtNgayBatDau.Value > dtNgayKetThuc.Value)
            {
                MessageBox.Show("Thòi gian áp dụng không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return;

            }

            decimal gia;
            if (!decimal.TryParse(txtGiaTour.Text, out gia))
            {
                MessageBox.Show("Giá tour không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return;

            }
            Bus_GiaTour bus_giaTour = new Bus_GiaTour();
            if(!bus_giaTour.KiemTraNgayGiaTour(tourThemGia.Id, dtNgayBatDau.Value, dtNgayKetThuc.Value))
            {
                MessageBox.Show("Thời gian áp dụng giá tour trùng nhau", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Dto_GiaTour giaTour = new Dto_GiaTour();
            giaTour.Tour_Id = tourThemGia.Id;
            giaTour.NgayBatDau = dtNgayBatDau.Value;
            giaTour.NgayKetThuc = dtNgayKetThuc.Value;
            giaTour.Gia = gia;
            if (bus_giaTour.ThemGiaTour(giaTour))
            {
                MessageBox.Show("Đã thêm giá tour thành công", "Thành công", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
