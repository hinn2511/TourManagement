using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienGiaTour
{
    public partial class Gui_GiaTour : Form
    {
        List<Dto_GiaTour> dsGiaTour;
        int currentIndex;
        Dto_Tour currentTour;

        public Gui_GiaTour(Dto_Tour tour)
        {
            InitializeComponent();
            currentTour = tour;
            txtTenTour.Text = currentTour.TenTour;
            CapNhatDanhSachGiaTour();
            currentIndex = -1;
        }

        private void DatTenDauDanhSach()
        {
            giaTourGridView.Columns["Tour_Id"].Visible = false;
            giaTourGridView.Columns["Id"].HeaderText = "Mã giá";
            giaTourGridView.Columns["Gia"].HeaderText = "Giá (VNĐ)";
            giaTourGridView.Columns["DangApDung"].HeaderText = "Đang áp dụng";
            giaTourGridView.Columns["NgayBatDau"].HeaderText = "Ngày bắt đầu";
            giaTourGridView.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";
            giaTourGridView.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
            giaTourGridView.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void CapNhatDanhSachGiaTour()
        {
            Bus_GiaTour bus = new Bus_GiaTour();
            dsGiaTour = bus.LayDanhSachGiaTour(currentTour.Id);
            giaTourGridView.DataSource = dsGiaTour;
            DatTenDauDanhSach();
        }


        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemGiaTour themGiaTourForm = new Gui_ThemGiaTour(currentTour);
            themGiaTourForm.ShowDialog();
            CapNhatDanhSachGiaTour();
        }


        private void giaTourGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (giaTourGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
            }
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {

            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tour cần xóa", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            DateTime now = DateTime.Now;

            if (dsGiaTour[currentIndex].NgayKetThuc < now)
            {
                MessageBox.Show("Không thể xóa giá tour đã áp dụng", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            if (dsGiaTour[currentIndex].DangApDung)
            {
                MessageBox.Show("Không thể xóa giá tour đang áp dụng", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            Bus_GiaTour bus = new Bus_GiaTour();
            var result = bus.XoaGiaTour(dsGiaTour[currentIndex].Id);

            if (result)
            {
                MessageBox.Show("Đã giá xóa tour thành công", "Xóa thành công", MessageBoxButtons.OK);
                dsGiaTour.RemoveAt(currentIndex);
                giaTourGridView.DataSource = null;
                giaTourGridView.DataSource = dsGiaTour;
                DatTenDauDanhSach();
            }

        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giá tour cần sửa", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            DateTime now = DateTime.Now;
            if (dsGiaTour[currentIndex].NgayKetThuc < now)
            {
                MessageBox.Show("Không thể sửa giá tour đã áp dụng", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Gui_SuaGiaTour suaGiaTourForm = new Gui_SuaGiaTour(dsGiaTour[currentIndex], currentTour);
            suaGiaTourForm.ShowDialog();
            CapNhatDanhSachGiaTour();

        }

    
    }
}
