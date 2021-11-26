using System;
using System.Windows.Forms;
using TourManagement.BUS;
namespace TourManagement.GUI
{
    public partial class Gui_ThemLoaiChiPhi : Form
    {


        public Gui_ThemLoaiChiPhi()
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
            Bus_LoaiChiPhi bus = new Bus_LoaiChiPhi();
            LoaiChiPhi loaiChiPhi = new LoaiChiPhi();
            loaiChiPhi.TenLoai = txtTenDiaDiem.Text;
            if (bus.ThemLoaiChiPhi(loaiChiPhi))
            {
                MessageBox.Show("Đã thêm loại tour thành công", "Thành công", MessageBoxButtons.OK);
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
