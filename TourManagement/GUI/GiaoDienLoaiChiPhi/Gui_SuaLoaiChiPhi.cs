using System;
using System.Windows.Forms;
using TourManagement.BUS;

namespace TourManagement.GUI
{
    public partial class Gui_SuaLoaiChiPhi : Form
    {
        int loaiChiPhiId;
        string tenLoaiChiPhi;

        public Gui_SuaLoaiChiPhi(int id, string tenCp)
        {
            InitializeComponent();
            loaiChiPhiId = id;
            tenLoaiChiPhi = tenCp;
            txtLoaiChiPhi.Text = tenCp;
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
            loaiChiPhi.Id = loaiChiPhiId;
            loaiChiPhi.TenLoai = txtLoaiChiPhi.Text;
            if (tenLoaiChiPhi.Equals(txtLoaiChiPhi.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin mới", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (bus.CapNhatLoaiChiPhi(loaiChiPhi))
            {
                MessageBox.Show("Đã cập nhật loại tour thành công", "Thành công", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
        }

        //private void LayThongTinDiaDiem()
        //{
        //    Bus_DiaDiem bus = new Bus_DiaDiem();
        //    var diadiem = bus.LayThongTinDiaDiem(diaDiemd);
        //    if (diadiem != null)
        //        txtLoaiChiPhi.Text = diadiem.TenDiaDiem;

        //}


    }
}
