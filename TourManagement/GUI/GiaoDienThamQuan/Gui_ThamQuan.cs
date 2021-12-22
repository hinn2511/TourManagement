using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienThamQuan
{
    public partial class Gui_ThamQuan : Form
    {
        List<Dto_ThamQuan> dsThamQuan;
        int currentIndex;
        Dto_Tour currentTour;

        public Gui_ThamQuan(Dto_Tour tour)
        {
            InitializeComponent();
            currentTour = tour;
            CapNhatDanhSachThamQuan();
            txtTenTour.Text = tour.TenTour;
            currentIndex = -1;
        }
        private void CapNhatDanhSachThamQuan()
        {
            Bus_ThamQuan bus = new Bus_ThamQuan();
            dsThamQuan = bus.LayDanhSachThamQuan(currentTour.Id);
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


        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemThamQuan themThamQuanForm = new Gui_ThemThamQuan(currentTour);
            themThamQuanForm.ShowDialog();
            CapNhatDanhSachThamQuan();
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
            dsThamQuan = bus.LayDanhSachThamQuan(currentTour.Id);
            if (bus.XoaThamQuan(dsThamQuan[currentIndex].Tour_Id, dsThamQuan[currentIndex].DiaDiem_Id))
            {
                MessageBox.Show("Xóa lịch trình tham quan thành công", "Thành công", MessageBoxButtons.OK);
                CapNhatDanhSachThamQuan();
            }
            else
                MessageBox.Show("Xóa lịch trình tham quan thất bại", "Lỗi", MessageBoxButtons.OK);

        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn lịch trình cần sửa", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            Gui_SuaThamQuan suaThamQuanForm = new Gui_SuaThamQuan(dsThamQuan[currentIndex]);

            suaThamQuanForm.ShowDialog();

            CapNhatDanhSachThamQuan();

        }

    }
}
