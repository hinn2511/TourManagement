using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienGiaTour
{
    public partial class Gui_GiaTour : Form
    {
        List<Dto_Tour> dsTour;
        List<GiaTour> dsGiaTour;
        int currentIndex;
        int currentTourPriceId;
        int currentTourId;

        public Gui_GiaTour()
        {
            InitializeComponent();
            LayDanhSachTour();
            currentIndex = -1;
        }

        private void DatTenDauDanhSach()
        {
            giaTourGridView.Columns["Tour"].Visible = false;
            giaTourGridView.Columns["Tour_Id"].Visible = false;
            giaTourGridView.Columns["Id"].HeaderText = "Mã giá";
            giaTourGridView.Columns["Gia"].HeaderText = "Giá (VNĐ)";
            giaTourGridView.Columns["DangApDung"].HeaderText = "Đang áp dụng";
            giaTourGridView.Columns["NgayBatDau"].HeaderText = "Ngày bắt đầu";
            giaTourGridView.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";
            giaTourGridView.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
            giaTourGridView.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void LayDanhSachTour()
        {
            Bus_GiaTour bus = new Bus_GiaTour();
            dsTour = bus.LayDanhSachTour();
            foreach (var item in dsTour)
            {
                cbxTour.Items.Add(item.TenTour);
            }

        }

        private void CapNhatDanhSachGiaTour()
        {
            Bus_GiaTour bus = new Bus_GiaTour();
            dsGiaTour = bus.LayDanhSachGiaTour(currentTourId);
            giaTourGridView.DataSource = dsGiaTour;

        }


        private void btnThem_Click(object sender, System.EventArgs e)
        {
            if (cbxTour.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tour cần thêm giá", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Tour tour = new Tour();
            Gui_ThemGiaTour themGiaTourForm = new Gui_ThemGiaTour(dsTour[cbxTour.SelectedIndex]);
            var result = themGiaTourForm.ShowDialog();
            if (result == DialogResult.OK)
                CapNhatDanhSachGiaTour();
        }

        private void cbxTour_DropDownClosed(object sender, System.EventArgs e)
        {
            if (cbxTour.SelectedItem != null)
            {
                currentTourId = dsTour[cbxTour.SelectedIndex].Id;
                CapNhatDanhSachGiaTour();
                DatTenDauDanhSach();
            }

        }

        private void giaTourGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (giaTourGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;

                currentTourPriceId = int.Parse(giaTourGridView.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());

            }
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {

            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tour cần xóa", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            if (dsGiaTour[currentIndex].DangApDung)
            {
                MessageBox.Show("Không thể xóa giá tour đang chọn. Vui lòng áp dụng giá tour khác trước khi xóa", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            Bus_GiaTour bus = new Bus_GiaTour();
            var result = bus.XoaGiaTour(currentTourPriceId);

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
            if (cbxTour.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tour cần sửa giá", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giá tour cần sửa", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Tour tour = new Tour();
            tour.Id = dsTour[cbxTour.SelectedIndex].Id;
            tour.TenTour = dsTour[cbxTour.SelectedIndex].TenTour;
            Gui_SuaGiaTour suaGiaTourForm = new Gui_SuaGiaTour(dsGiaTour[currentIndex], dsTour[cbxTour.SelectedIndex]);
            var result = suaGiaTourForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                CapNhatDanhSachGiaTour();
            }

        }

        private void btnApDung_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tour cần xóa", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (dsGiaTour[currentIndex].DangApDung)
            {
                MessageBox.Show("Giá tour chọn đã áp dụng. Vui lòng chọn giá tour khác", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Bus_GiaTour bus = new Bus_GiaTour();
            var result = bus.ApDungGiaTour(dsTour[cbxTour.SelectedIndex].Id, currentTourPriceId);
            if (!result)
                MessageBox.Show("Không thể áp dụng giá tour", "Lỗi", MessageBoxButtons.OK);
            else
                MessageBox.Show("Đã áp dụng giá tour thành công", "Thành công", MessageBoxButtons.OK);
            CapNhatDanhSachGiaTour();
        }
    }
}
