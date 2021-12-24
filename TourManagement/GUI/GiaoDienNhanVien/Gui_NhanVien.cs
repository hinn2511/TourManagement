using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.GUI.GiaoDienPhanCong;
namespace TourManagement.GUI.GiaoDienNhanVien
{
    public partial class Gui_NhanVien : Form
    {
        private List<NhanVien> dsNV = new List<NhanVien>();

        int currentIndex;

        public Gui_NhanVien()
        {
            InitializeComponent();
            CapNhatDanhSachNV();
            DatTenDauDanhSach();

            currentIndex = -1;
        }
        private void DatTenDauDanhSach()
        {
            nvGridView.Columns["Id"].HeaderText = "Mã Nhân Viên";
            nvGridView.Columns["HoTen"].HeaderText = "Họ Tên ";
        }
        private void CapNhatDanhSachNV()
        {
            Bus_NV bus = new Bus_NV();
            dsNV = bus.LayDanhSachNV();
            nvGridView.DataSource = dsNV;
        }


        private void btnPhanCong_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xem phân công!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Gui_PhanCong gui_PhanCong = new Gui_PhanCong(dsNV[currentIndex]);
            gui_PhanCong.ShowDialog(this);
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemNV themNVForm = new Gui_ThemNV();
            themNVForm.ShowDialog();
            CapNhatDanhSachNV();
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa", "Lỗi", MessageBoxButtons.OK);
            else
            {
                Bus_NV bus = new Bus_NV();
                var result = bus.XoaNV(dsNV[currentIndex].Id);
                if (result)
                {
                    MessageBox.Show("Đã xóa thành công", "Xóa thành công", MessageBoxButtons.OK);
                    dsNV.RemoveAt(currentIndex);
                    nvGridView.DataSource = null;
                    nvGridView.DataSource = dsNV;
                }
            }
        }
        private void nvGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (nvGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
            }
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            Gui_SuaNV suaNVForm = new Gui_SuaNV();
            suaNVForm.ShowDialog();
            CapNhatDanhSachNV();
        }
    }
}
