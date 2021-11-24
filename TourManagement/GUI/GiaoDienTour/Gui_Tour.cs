using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;
using TourManagement.GUI.GiaoDienLoaiTour;

namespace TourManagement.GUI.GiaoDienTour
{
    public partial class Gui_Tour : Form
    {

        List<Dto_Tour> dsTour = new List<Dto_Tour>();

        int currentIndex;
        int currentId;

        public Gui_Tour()
        {
            InitializeComponent();
            CapNhatDanhSachTour();
            DatTenDauDanhSach();
            currentIndex = -1;
        }

        public void CapNhatDanhSachTour()
        {
            Bus_Tour bus = new Bus_Tour();
            dsTour = bus.LayDanhSachTour();
            tourGridView.DataSource = dsTour;
        }

        private void tourGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Gui_ThemTour themTourForm = new Gui_ThemTour();
            var result = themTourForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                CapNhatDanhSachTour();
            }
        }

        private void DatTenDauDanhSach()
        {
            tourGridView.Columns[0].HeaderText = "Mã tour";
            tourGridView.Columns[1].HeaderText = "Tên tour";
            tourGridView.Columns[2].HeaderText = "Đặc điểm";
            tourGridView.Columns[3].HeaderText = "Loại";
            tourGridView.Columns[4].HeaderText = "Giá (VNĐ)";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Bus_Tour bus = new Bus_Tour();
            var result = bus.TimKiemTour(dsTour, txtTimKiem.Text);
            tourGridView.DataSource = result;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            tourGridView.DataSource = dsTour;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentIndex < 0)
                MessageBox.Show("Vui lòng chọn tour cần xóa", "Lỗi", MessageBoxButtons.OK);
            else
            {
                Bus_Tour bus = new Bus_Tour();
                var result = bus.XoaTour(dsTour[currentIndex].Id);
                if (result)
                {
                    MessageBox.Show("Đã xóa tour thành công", "Xóa thành công", MessageBoxButtons.OK);
                    dsTour.RemoveAt(currentIndex);
                    tourGridView.DataSource = null;
                    tourGridView.DataSource = dsTour;
                }
            }

        }

        private void tourGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (tourGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
                currentId = int.Parse(tourGridView.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());

            }
        }

        private void btnLoaiTour_Click(object sender, EventArgs e)
        {
            Gui_LoaiTour loaiTourForm = new Gui_LoaiTour();
            loaiTourForm.ShowDialog();
        }
    }
}
