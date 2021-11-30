using System;
using System.Windows.Forms;
using TourManagement.BUS;
namespace TourManagement.GUI.GiaoDienNhanVien
{
    public partial class Gui_ThemNV : Form
    {


        public Gui_ThemNV()
        {
            InitializeComponent();
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Gui_ThemNV_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Bus_NV bus = new Bus_NV();
            NhanVien nv = new NhanVien();
            nv.HoTen = txtHoTen.Text;
            if (bus.ThemNV(nv))
            {
                MessageBox.Show("Đã thêm nhân viên mới thành công", "Thành công", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
        }
    }
}
