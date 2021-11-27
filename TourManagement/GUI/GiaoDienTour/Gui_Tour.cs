using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;
using TourManagement.GUI.GiaoDienGiaTour;
using TourManagement.GUI.GiaoDienLoaiTour;
using TourManagement.GUI.GiaoDienThamQuan;

namespace TourManagement.GUI.GiaoDienTour
{
    public partial class Gui_Tour : Form
    {

        List<Dto_Tour> dsTour = new List<Dto_Tour>();

        //Luu tru vi tri tour nguoi dung chon
        int currentIndex;

        public Gui_Tour()
        {
            InitializeComponent();
            CapNhatDanhSachTour();

            //Gan bang -1 de kiem tra nguoi dung da chon tour hay chua
            currentIndex = -1;
        }

        public void CapNhatDanhSachTour()
        {
            Bus_Tour bus = new Bus_Tour();
            dsTour = bus.LayDanhSachTour();
            tourGridView.DataSource = dsTour;
            DatTenDauDanhSach();
        }

        private void DatTenDauDanhSach()
        {
            tourGridView.Columns["Id"].HeaderText = "Mã tour";
            tourGridView.Columns["TenTour"].HeaderText = "Tên tour";
            tourGridView.Columns["DacDiem"].Visible = false;
            tourGridView.Columns["Loai_Id"].Visible = false;
            tourGridView.Columns["Gia_Id"].Visible = false;
            tourGridView.Columns["Loai"].HeaderText = "Loại";
            tourGridView.Columns["Gia"].HeaderText = "Giá (VNĐ)";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Gui_ThemTour themTourForm = new Gui_ThemTour();
            themTourForm.ShowDialog();
            CapNhatDanhSachTour();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tour cần xóa", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            Bus_Tour bus = new Bus_Tour();
            var result = bus.XoaTour(dsTour[currentIndex].Id);
            if (result)
            {
                MessageBox.Show("Đã xóa tour thành công", "Thành công", MessageBoxButtons.OK);
                dsTour.RemoveAt(currentIndex);
                tourGridView.DataSource = null;
                tourGridView.DataSource = dsTour;
            }

            CapNhatDanhSachTour();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tour cần xem chi tiết", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            Gui_SuaTour suaTourForm = new Gui_SuaTour(dsTour[currentIndex]);
            suaTourForm.ShowDialog();
            CapNhatDanhSachTour();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tour cần xem chi tiết", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            Gui_ChiTietTour chiTietTourForm = new Gui_ChiTietTour(dsTour[currentIndex]);
            chiTietTourForm.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Bus_Tour bus = new Bus_Tour();
            var result = bus.TimKiemTour(dsTour, txtTimKiem.Text);
            tourGridView.DataSource = null;
            tourGridView.DataSource = result;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            DatTenDauDanhSach();
            tourGridView.DataSource = dsTour;
        }

        private void btnLoaiTour_Click(object sender, EventArgs e)
        {
            Gui_LoaiTour loaiTourForm = new Gui_LoaiTour();
            loaiTourForm.ShowDialog();
            CapNhatDanhSachTour();
        }

        private void btnGiaTour_Click(object sender, EventArgs e)
        {
            Gui_GiaTour giaTourForm = new Gui_GiaTour();
            giaTourForm.ShowDialog();
            CapNhatDanhSachTour();
        }

        private void btnLichTrinh_Click(object sender, EventArgs e)
        {
            Gui_ThamQuan thamQuanForm = new Gui_ThamQuan();
            thamQuanForm.ShowDialog();
            CapNhatDanhSachTour();
        }

        private void tourGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Neu nguoi dung chon vao ten thuoc tinh tren bang thi khong co gi xay ra
            if (e.RowIndex < 0)
                return;

            //Neu chon vao tour thi luu vi tri cua tour tren bang
            if (tourGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
            }
        }

        //Khi nguoi dung nhan enter khi search
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Bus_Tour bus = new Bus_Tour();
                var result = bus.TimKiemTour(dsTour, txtTimKiem.Text);

                tourGridView.DataSource = null;
                tourGridView.DataSource = result;
            }
        }


    }
}
