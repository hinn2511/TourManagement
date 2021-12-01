using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TourManagement.BUS;
namespace TourManagement.GUI
{
    public partial class Gui_LoaiChiPhi : Form
    {
        List<LoaiChiPhi> dsLoaiPhi = new List<LoaiChiPhi>();

        int currentIndex;
        int currentId;
        Bus_LoaiChiPhi bus = new Bus_LoaiChiPhi();
        public Gui_LoaiChiPhi()
        {
            InitializeComponent();
            CapNhatDanhSach();
            DatTenDauDanhSach();
            currentIndex = -1;
        }

        private void CapNhatDanhSach()
        {
            Bus_LoaiChiPhi bus = new Bus_LoaiChiPhi();
            dsLoaiPhi = bus.LayDanhSachLoaiChiPhi();
            LoaiChiPhiGridView.DataSource = dsLoaiPhi;
        }
        private void DatTenDauDanhSach()
        {
            LoaiChiPhiGridView.Columns[0].HeaderText = "Mã loại chi phí";
            LoaiChiPhiGridView.Columns[1].HeaderText = "Tên loại chi phí";
        }
        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
                MessageBox.Show("Vui lòng chọn loại tour cần xóa", "Lỗi", MessageBoxButtons.OK);
            else
            {
                var result = bus.XoaLoaiChiPhi(dsLoaiPhi[currentIndex].Id);
                if (result)
                {
                    MessageBox.Show("Đã xóa loại tour thành công", "Xóa thành công", MessageBoxButtons.OK);
                    dsLoaiPhi.RemoveAt(currentIndex);
                    LoaiChiPhiGridView.DataSource = null;
                    LoaiChiPhiGridView.DataSource = dsLoaiPhi;
                }
            }
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
                MessageBox.Show("Vui lòng chọn loại tour cần sửa", "Lỗi", MessageBoxButtons.OK);
            else
            {
                string tenLoaiChiPhi = LoaiChiPhiGridView.Rows[currentIndex].Cells["TenLoai"].FormattedValue.ToString();
                Gui_SuaLoaiChiPhi suaLoaiChiPhiForm = new Gui_SuaLoaiChiPhi(currentId, tenLoaiChiPhi);
                var result = suaLoaiChiPhiForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CapNhatDanhSach();
                }
            }
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemLoaiChiPhi themForm = new Gui_ThemLoaiChiPhi();
            themForm.ShowDialog();
            CapNhatDanhSach();

        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            Bus_LoaiChiPhi bus = new Bus_LoaiChiPhi();
            var result = bus.TimKiem(dsLoaiPhi, txtTimKiem.Text);
            LoaiChiPhiGridView.DataSource = result;
        }

        private void btnLamMoi_Click(object sender, System.EventArgs e)
        {
            LoaiChiPhiGridView.DataSource = dsLoaiPhi;
        }

        public void LoaiChiPhiGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (LoaiChiPhiGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
                Debug.WriteLine(currentIndex);
                currentId = int.Parse(LoaiChiPhiGridView.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());

            }
        }
    }
}
