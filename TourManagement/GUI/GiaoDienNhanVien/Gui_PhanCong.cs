using System;
using System.Windows.Forms;
using TourManagement.BUS;
namespace TourManagement.GUI
{
    public partial class Gui_PhanCong : Form
    {

        public Gui_PhanCong()
        {
            InitializeComponent();
            DatTenDauDanhSach();
        }
        private void DatTenDauDanhSach()
        {
            pcGridView.Columns["NhanVien_Id"].HeaderText = "Mã Nhân Viên";
            pcGridView.Columns["DoanDuLich_Id"].HeaderText = "Mã Đoàn Du Lịch ";
            pcGridView.Columns["NhiemVu"].HeaderText = "Nhiệm Vụ";
        }
        private void CapNhatDanhSachPC()
        {
            Bus_PhanCong bus = new Bus_PhanCong();
            /*dsPC = bus.LayDanhSachPhanCong();
            pcGridView.DataSource = dsPC;*/
        }
    }
}
