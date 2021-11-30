using System;
using System.Windows.Forms;
using TourManagement.BUS;
namespace TourManagement.GUI
{
    public partial class Gui_ThemDiaDiem : Form
    {


        public Gui_ThemDiaDiem()
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
            Bus_DiaDiem bus = new Bus_DiaDiem();
            DiaDiem diaDiem = new DiaDiem();
            diaDiem.TenDiaDiem = txtTenDiaDiem.Text;
            if (bus.ThemDiaDiem(diaDiem))
            {
                MessageBox.Show("Đã thêm địa điểm thành công", "Thành công", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
