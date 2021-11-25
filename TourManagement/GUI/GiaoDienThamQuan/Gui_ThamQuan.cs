using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienThamQuan
{
    public partial class Gui_ThamQuan : Form
    {
        List<Dto_Tour> dsTour;
        List<Dto_ThamQuan> dsThamQuan;
        int currentIndex;

        public Gui_ThamQuan()
        {
            InitializeComponent();
            LayDanhSachTour();
            currentIndex = -1;
        }
        private void CapNhatDanhSachThamQuan(int tourId)
        {
            Bus_ThamQuan bus = new Bus_ThamQuan();
            dsThamQuan = bus.LayDanhSachThamQuan(tourId);
            thamQuanGridView.DataSource = dsThamQuan;
            DatTenDauDanhSach();
        }

        private void DatTenDauDanhSach()
        {
            thamQuanGridView.Columns["TenTour"].Visible = false;
            thamQuanGridView.Columns["Tour_Id"].Visible = false;
            thamQuanGridView.Columns["DiaDiem_Id"].HeaderText = "Mã địa điểm";
            thamQuanGridView.Columns["TenDiaDiem"].HeaderText = "Tên địa điểm";
            thamQuanGridView.Columns["ThuTu"].HeaderText = "Thứ tự";
        }

        private void LayDanhSachTour()
        {
            Bus_ThamQuan bus = new Bus_ThamQuan();
            dsTour = bus.LayDanhSachTour();
            foreach (var item in dsTour)
            {
                cbxTour.Items.Add(item.TenTour);
            }

        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            if (cbxTour.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tour cần thêm lịch trình", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Gui_ThemThamQuan themThamQuanForm = new Gui_ThemThamQuan(dsTour[cbxTour.SelectedIndex]);
            themThamQuanForm.ShowDialog();
            CapNhatDanhSachThamQuan(dsTour[cbxTour.SelectedIndex].Id);
        }

        private void cbxTour_DropDownClosed(object sender, System.EventArgs e)
        {
            if (cbxTour.SelectedItem != null)
            {
                CapNhatDanhSachThamQuan(dsTour[cbxTour.SelectedIndex].Id);
            }

        }

        private void giaTourGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (thamQuanGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
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
            Bus_ThamQuan bus = new Bus_ThamQuan();
            dsThamQuan = bus.LayDanhSachThamQuan(dsTour[cbxTour.SelectedIndex].Id);
            if (bus.XoaThamQuan(dsThamQuan[currentIndex]))
            {
                MessageBox.Show("Xóa lịch trình tham quan thành công", "Thành công", MessageBoxButtons.OK);
                CapNhatDanhSachThamQuan(dsTour[cbxTour.SelectedIndex].Id);
            }
            else
                MessageBox.Show("Xóa lịch trình tham quan thất bại", "Lỗi", MessageBoxButtons.OK);

        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            if (cbxTour.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tour cần sửa lịch trình", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn lịch trình cần sửa", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            Gui_SuaThamQuan suaThamQuanForm = new Gui_SuaThamQuan(dsThamQuan[currentIndex]);

            suaThamQuanForm.ShowDialog();

            CapNhatDanhSachThamQuan(dsTour[cbxTour.SelectedIndex].Id);

        }

    }
}
