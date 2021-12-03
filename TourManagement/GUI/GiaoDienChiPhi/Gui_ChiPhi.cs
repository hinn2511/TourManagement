using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienChiPhi
{
    public partial class Gui_ChiPhi : Form
    {
        int currentIndex;
        List<Dto_ChiPhi> dsChiPhi;
        Dto_DoanDuLich currentDoanDuLich;

        public Gui_ChiPhi(Dto_DoanDuLich doanDuLich)
        {
            InitializeComponent();
            currentDoanDuLich = doanDuLich;
            currentIndex = -1;
            CapNhatDanhSachChiPhi();
        }
        public void CapNhatDanhSachChiPhi()
        {
            Bus_ChiPhi bus = new Bus_ChiPhi();
            dsChiPhi = bus.LayDanhSachChiPhi(currentDoanDuLich.Id);
            chiPhiGridView.DataSource = dsChiPhi;
            DatTenDauDanhSach();
        }

        private void DatTenDauDanhSach()
        {
            chiPhiGridView.Columns["Id"].HeaderText = "Mã chi phí";
            chiPhiGridView.Columns["TenLoaiChiPhi"].HeaderText = "Loại chi phí";
            chiPhiGridView.Columns["SoTien"].HeaderText = "Số tiền (VNĐ)";
            chiPhiGridView.Columns["TenDoan"].Visible = false;
            chiPhiGridView.Columns["LoaiChiPhi_id"].Visible = false;
            chiPhiGridView.Columns["DoanDuLich_Id"].Visible = false;
        }
        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemChiPhi themChiPhiForm = new Gui_ThemChiPhi(currentDoanDuLich.Id);
            themChiPhiForm.ShowDialog();
            CapNhatDanhSachChiPhi();
        }


        private void chiPhiGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (chiPhiGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
            }
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn chi phí cần sửa", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Gui_SuaChiPhi suaChiPhiForm = new Gui_SuaChiPhi(dsChiPhi[currentIndex]);
            suaChiPhiForm.ShowDialog();
            CapNhatDanhSachChiPhi();
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn chi phí cần xóa", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Bus_ChiPhi bus = new Bus_ChiPhi();
            if (bus.XoaChiPhi(dsChiPhi[currentIndex].Id))
            {
                MessageBox.Show("Xóa chi phí thành công", "Thành công", MessageBoxButtons.OK);
                CapNhatDanhSachChiPhi();
            }
            else
                MessageBox.Show("Xóa chi phí thất bại", "Lỗi", MessageBoxButtons.OK);
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            Bus_ChiPhi bus = new Bus_ChiPhi();
            var result = bus.TimKiem(dsChiPhi, txtTimKiem.Text);
            chiPhiGridView.DataSource = null;
            chiPhiGridView.DataSource = result;
            DatTenDauDanhSach();
        }

        private void btnLamMoi_Click(object sender, System.EventArgs e)
        {
            chiPhiGridView.DataSource = null;
            chiPhiGridView.DataSource = dsChiPhi;
            DatTenDauDanhSach();
        }
    }
}
