using System;
using System.Windows.Forms;
using TourManagement.BUS;
namespace TourManagement.GUI.GiaoDienKhachHang
{
    public partial class Gui_SuaKH : Form
    {


        public Gui_SuaKH(KhachHang khCanSua)
        {
            InitializeComponent();
            txtHoTen.Text = khCanSua.HoTen;
            txtCMND.Text = khCanSua.CMND;
            txtDiaChi.Text = khCanSua.DiaChi;
            txtGioiTinh.Text = khCanSua.GioiTinh;
            txtSDT.Text = khCanSua.SDT;
            txtQT.Text = khCanSua.QuocTich;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            Bus_KH bus = new Bus_KH();
            kh.HoTen = txtHoTen.Text;
            kh.CMND = txtCMND.Text;
            kh.SDT = txtSDT.Text;
            kh.GioiTinh = txtGioiTinh.Text;
            kh.QuocTich = txtQT.Text;
            kh.DiaChi = txtDiaChi.Text;
            if (bus.CapNhatKH(kh))
            {
                MessageBox.Show("Đã cập nhật khách hàng thành công", "Thành công", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);

        }
    }
}
