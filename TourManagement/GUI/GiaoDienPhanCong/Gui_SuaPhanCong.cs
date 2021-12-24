using System;
using System.Diagnostics;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienPhanCong
{
    public partial class Gui_SuaPhanCong : Form
    {
        Dto_PhanCong pc;

        public Gui_SuaPhanCong(Dto_PhanCong phanCongCanSua)
        {
            InitializeComponent();
            pc = phanCongCanSua;
            txtTenDoan.Text = pc.TenDoan;
            txtTenNV.Text = pc.HoTen;
            txtNhiemVu.Text = pc.NhiemVu;
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
          
            Bus_PhanCong bus = new Bus_PhanCong();
            if (bus.SuaPhanCong(pc))
            {
                MessageBox.Show("Đã cập nhật lịch trình thành công", "Thành công", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


    }
}
