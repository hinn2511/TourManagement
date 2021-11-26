using System;
using System.Windows.Forms;
using TourManagement.BUS;

namespace TourManagement.GUI
{
    public partial class Gui_SuaChiPhi : Form
    {
        int diaDiemd;
        string tenDiaDiem;

        public Gui_SuaChiPhi(int id, string tenDd)
        {
            InitializeComponent();
            diaDiemd = id;
            tenDiaDiem = tenDd;
            txtDiaDiem.Text = tenDd;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Bus_DiaDiem bus = new Bus_DiaDiem();
            DiaDiem diadiem = new DiaDiem();
            diadiem.Id = diaDiemd;
            diadiem.TenDiaDiem = txtDiaDiem.Text;
            if (tenDiaDiem.Equals(txtDiaDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin mới", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (bus.CapNhatDiaDiem(diadiem))
            {
                MessageBox.Show("Đã cập nhật loại tour thành công", "Thành công", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
        }

        private void LayThongTinDiaDiem()
        {
            Bus_DiaDiem bus = new Bus_DiaDiem();
            var diadiem = bus.LayThongTinDiaDiem(diaDiemd);
            if (diadiem != null)
                txtDiaDiem.Text = diadiem.TenDiaDiem;

        }


    }
}
