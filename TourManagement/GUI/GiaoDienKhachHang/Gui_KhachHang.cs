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
            khGridView.Columns[0].HeaderText = "Mã Khách Hàng";
            khGridView.Columns[1].HeaderText = "Họ Tên ";
            khGridView.Columns[2].HeaderText = "CMND";
            khGridView.Columns[3].HeaderText = "Địa Chỉ";
            khGridView.Columns[4].HeaderText = "Giới tính";
            khGridView.Columns[5].HeaderText = "Số điện thoại";
            khGridView.Columns[6].HeaderText = "Quốc tịch";
        }
        private void CapNhatDanhSachKH()
        {
            Bus_KH bus = new Bus_KH();
            dsKH = bus.LayDanhSachKH();
            khGridView.DataSource = dsKH;
        }
        private void actionThemKH(object sender, System.EventArgs e)
        {
            Gui_ThemKH themKHForm = new Gui_ThemKH();
            var result = themKHForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                CapNhatDanhSachKH();
            }
        }
        private void actionXoaKH(object sender, System.EventArgs e)
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
    }
}
