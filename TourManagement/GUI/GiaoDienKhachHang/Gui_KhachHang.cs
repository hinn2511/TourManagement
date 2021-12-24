using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;

namespace TourManagement.GUI.GiaoDienKhachHang
{
    public partial class Gui_KhachHang : Form
    {
        private List<KhachHang> dsKH = new List<KhachHang>();

        int currentIndex;

        public Gui_KhachHang()
        {
            InitializeComponent();
            CapNhatDanhSachKH();
            DatTenDauDanhSach();

            currentIndex = -1;
        }
        private void DatTenDauDanhSach()
        {
            khGridView.Columns["Id"].HeaderText = "Mã Khách Hàng";
            khGridView.Columns["HoTen"].HeaderText = "Họ Tên ";
            khGridView.Columns["CMND"].HeaderText = "CMND";
            khGridView.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            khGridView.Columns["GioiTinh"].HeaderText = "Giới tính";
            khGridView.Columns["SDT"].HeaderText = "Số điện thoại";
            khGridView.Columns["QuocTich"].HeaderText = "Quốc tịch";
        }
        private void CapNhatDanhSachKH()
        {
            Bus_KH bus = new Bus_KH();
            dsKH = bus.LayDanhSachKH();
            khGridView.DataSource = dsKH;
        }
        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemKH themKHForm = new Gui_ThemKH();
            themKHForm.ShowDialog();
            CapNhatDanhSachKH();
        }
        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa", "Lỗi", MessageBoxButtons.OK);
            else
            {
                Bus_KH bus = new Bus_KH();
                var result = bus.XoaKH(dsKH[currentIndex].Id);
                if (result)
                {
                    MessageBox.Show("Đã xóa thành công", "Xóa thành công", MessageBoxButtons.OK);
                    dsKH.RemoveAt(currentIndex);
                    khGridView.DataSource = null;
                    khGridView.DataSource = dsKH;
                }
            }
        }
        private void khGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (khGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
            }
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            Gui_SuaKH suaKHForm = new Gui_SuaKH(dsKH[currentIndex]);
            suaKHForm.ShowDialog();
            CapNhatDanhSachKH();
        }
    }
}
