using System;
using System.Windows.Forms;
using TourManagement.BUS;
namespace TourManagement.GUI
{
    public partial class Gui_ThemKH : Form
    {


        public Gui_ThemKH()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            Bus_KH bus = new Bus_KH();
            kh.HoTen = txtHoTen.Text;
            kh.CMND = txtCMND.Text;
            kh.SDT = txtSDT.Text;
            kh.GioiTinh = txtGioiTinh.Text;
            kh.QuocTich = txtQT.Text;
            kh.DiaChi = txtDiaChi.Text;
            if (bus.ThemKH(kh))
            {
                MessageBox.Show("Đã thêm khách hàng mới thành công", "Thành công", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);

        }
    }
}
