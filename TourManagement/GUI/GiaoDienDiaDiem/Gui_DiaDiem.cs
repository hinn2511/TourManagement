using System.Windows.Forms;
using TourManagement.BUS;
using System.Collections.Generic;

namespace TourManagement.GUI.GiaoDienDiaDiem
{
    public partial class Gui_DiaDiem : Form
    {
        List<DiaDiem> dsDiaDiem = new List<DiaDiem>();
        int currentIndex;
        int currentId;
        public Gui_DiaDiem()
        {
            InitializeComponent();
            CapNhatDanhSachDiaDiem();
            DatTenDauDanhSach();
            currentIndex = -1;
        }

        public void CapNhatDanhSachDiaDiem()
        {
            Bus_DiaDiem bus = new Bus_DiaDiem();
            dsDiaDiem = bus.LayDanhSachDiaDiem();
            DiaDiemGridView.DataSource = dsDiaDiem;
        }
        private void DatTenDauDanhSach()
        {
            DiaDiemGridView.Columns[0].HeaderText = "Mã địa điểm";
            DiaDiemGridView.Columns[1].HeaderText = "Tên địa điểm";
        }

        public void DiaDiemGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (DiaDiemGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
                currentId = int.Parse(DiaDiemGridView.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());

            }
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn địa điểm cần xóa", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            
                Bus_DiaDiem bus = new Bus_DiaDiem();
                var res = bus.XoaDiaDiem(dsDiaDiem[currentIndex].Id);
                if (res)
                {
                    MessageBox.Show("Đã xoá địa điểm thành công", "Xoá thành công", MessageBoxButtons.OK);
                    dsDiaDiem.RemoveAt(currentIndex);
                    DiaDiemGridView.DataSource = null;
                    DiaDiemGridView.DataSource = dsDiaDiem;
                }
            CapNhatDanhSachDiaDiem();
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
                MessageBox.Show("Vui lòng chọn loại tour cần sửa", "Lỗi", MessageBoxButtons.OK);
            else
            {
                string tenDiaDiem = DiaDiemGridView.Rows[currentIndex].Cells["TenDiaDiem"].FormattedValue.ToString();
                Gui_SuaDiaDiem suaDiaDiemForm = new Gui_SuaDiaDiem(currentId, tenDiaDiem);
                var result = suaDiaDiemForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CapNhatDanhSachDiaDiem();
                }
            }
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemDiaDiem themDiaDiemForm = new Gui_ThemDiaDiem();
            themDiaDiemForm.ShowDialog();
            CapNhatDanhSachDiaDiem();
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            Bus_DiaDiem bus = new Bus_DiaDiem();
            var res = bus.TimKiemDiaDiem(dsDiaDiem, txtTimKiem.Text);
            DiaDiemGridView.DataSource = res;
        }

        private void btnLamMoi_Click(object sender, System.EventArgs e)
        {
            DiaDiemGridView.DataSource = dsDiaDiem;
        }
    }
}
