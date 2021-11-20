using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;

namespace TourManagement.GUI.GiaoDienLoaiTour
{
    public partial class Gui_LoaiTour : Form
    {
        private List<LoaiTour> dsLoaiTour = new List<LoaiTour>();

        int currentIndex;
        int currentId;

        public Gui_LoaiTour()
        {
            InitializeComponent();
            CapNhatDanhSachLoaiTour();
            DatTenDauDanhSach();
            currentIndex = -1;
        }

        private void CapNhatDanhSachLoaiTour()
        {
            Bus_LoaiTour bus = new Bus_LoaiTour();
            dsLoaiTour = bus.LayDanhSachLoaiTour();
            loaiTourGridView.DataSource = dsLoaiTour;

        }

        private void DatTenDauDanhSach()
        {
            loaiTourGridView.Columns[0].HeaderText = "Mã loại";
            loaiTourGridView.Columns[1].HeaderText = "Tên loại";
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemLoaiTour themLoaiTourForm = new Gui_ThemLoaiTour();
            var result = themLoaiTourForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                CapNhatDanhSachLoaiTour();
            }
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
                MessageBox.Show("Vui lòng chọn loại tour cần xóa", "Lỗi", MessageBoxButtons.OK);
            else
            {
                Bus_LoaiTour bus = new Bus_LoaiTour();
                var result = bus.XoaLoaiTour(currentId);
                if (result)
                {
                    MessageBox.Show("Đã xóa loại tour thành công", "Xóa thành công", MessageBoxButtons.OK);
                    dsLoaiTour.RemoveAt(currentIndex);
                    loaiTourGridView.DataSource = null;
                    loaiTourGridView.DataSource = dsLoaiTour;
                }
            }
        }

        private void loaiTourGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (loaiTourGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
                currentId = int.Parse(loaiTourGridView.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());

            }
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
                MessageBox.Show("Vui lòng chọn loại tour cần sửa", "Lỗi", MessageBoxButtons.OK);
            else
            {
                string tenLoaiTour = loaiTourGridView.Rows[currentIndex].Cells["TenLoai"].FormattedValue.ToString();
                Gui_SuaLoaiTour suaLoaiTourForm = new Gui_SuaLoaiTour(currentId, tenLoaiTour);
                var result = suaLoaiTourForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CapNhatDanhSachLoaiTour();
                }
            }
            
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            Bus_LoaiTour bus = new Bus_LoaiTour();
            var result = bus.TimKiemLoaiTour(dsLoaiTour, txtTimKiem.Text);
            loaiTourGridView.DataSource = result;
        }

        private void btnLamMoi_Click(object sender, System.EventArgs e)
        {
            loaiTourGridView.DataSource = dsLoaiTour;
        }
    }
}
