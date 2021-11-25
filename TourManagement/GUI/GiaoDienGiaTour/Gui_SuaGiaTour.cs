using System;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienGiaTour
{
    public partial class Gui_SuaGiaTour : Form
    {
        GiaTour giaTour;

        public Gui_SuaGiaTour(GiaTour giaTourCanSua, Dto_Tour tourCanSua)
        {
            InitializeComponent();
            giaTour = giaTourCanSua;
            txtTenTour.Text = tourCanSua.TenTour;
            txtGiaTour.Text = giaTourCanSua.Gia.ToString();
            dtNgayBatDau.Value = giaTourCanSua.NgayBatDau;
            dtNgayKetThuc.Value = giaTourCanSua.NgayKetThuc;
            DieuChinhNgayGiaTour();
        }

        private void DieuChinhNgayGiaTour()
        {
            dtNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtNgayBatDau.CustomFormat = "dd/MM/yyyy";
            dtNgayKetThuc.CustomFormat = "dd/MM/yyyy";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            giaTour.NgayBatDau = dtNgayBatDau.Value;
            giaTour.NgayKetThuc = dtNgayKetThuc.Value;
            if (giaTour.NgayBatDau > giaTour.NgayKetThuc)
            {
                MessageBox.Show("Ngày áp dụng hoặc ngày kết thúc giá tour không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            decimal gia;
            if (!decimal.TryParse(txtGiaTour.Text, out gia))
            {
                MessageBox.Show("Giá tour không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return;

            }
            giaTour.Gia = gia;
            Bus_GiaTour bus_giaTour = new Bus_GiaTour();
            if (bus_giaTour.SuaGiaTour(giaTour))
            {
                MessageBox.Show("Đã sửa giá tour thành công", "Thành công", MessageBoxButtons.OK);
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
