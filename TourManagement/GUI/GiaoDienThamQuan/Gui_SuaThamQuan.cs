using System;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienThamQuan
{
    public partial class Gui_SuaThamQuan : Form
    {
        Dto_ThamQuan thamQuan;

        public Gui_SuaThamQuan(Dto_ThamQuan thamQuanCanSua)
        {
            InitializeComponent();
            thamQuan = thamQuanCanSua;
            txtTenTour.Text = thamQuanCanSua.TenTour;
            txtDiaDiem.Text = thamQuanCanSua.TenDiaDiem;
            cbxThuTu.Text = thamQuan.ThuTu.ToString();
            CapNhatThuTu();
        }

        public void CapNhatThuTu()
        {
            Bus_ThamQuan bus = new Bus_ThamQuan();
            int soLuongHienTai = bus.LaySoLuongDiaDiem(thamQuan.Tour_Id);
            for (int i = 1; i <= soLuongHienTai; i++)
            {
                if (i != thamQuan.ThuTu)
                    cbxThuTu.Items.Add(i);
            }

        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cbxThuTu.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn thứ tự mới", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Bus_ThamQuan bus = new Bus_ThamQuan();
            if (bus.SuaLichTrinhThamQuan(thamQuan, (int)cbxThuTu.SelectedItem))
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
