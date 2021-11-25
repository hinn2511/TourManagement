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
            GiaTour giaTour = new GiaTour();
            giaTour.DangApDung = false;
            giaTour.Tour_Id = tourThemGia.Id;
            giaTour.NgayBatDau = dtNgayBatDau.Value;
            giaTour.NgayKetThuc = dtNgayKetThuc.Value;
            decimal gia;
            if (!decimal.TryParse(txtGiaTour.Text, out gia))
            {
                MessageBox.Show("Giá tour không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return;

            }
            giaTour.Gia = gia;
            Bus_GiaTour bus_giaTour = new Bus_GiaTour();
            if (bus_giaTour.ThemGiaTour(giaTour))
            {
                MessageBox.Show("Đã thêm giá tour thành công", "Thành công", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
            Close();
            return;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
