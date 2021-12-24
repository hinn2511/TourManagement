using System;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DAL;
using TourManagement.DTO;
using System.Collections.Generic;
using System.Linq;

namespace TourManagement.GUI.GiaoDienPhanCong
{
    public partial class Gui_ThemPC : Form
    {
        NhanVien nv;
        List<DoanDuLich> dsDDL;
        public Gui_ThemPC(NhanVien Nv)
        {
            InitializeComponent();
            nv = Nv;
            LayDanhSachDDL();
        }
        private void LayDanhSachDDL()
        {
            Bus_PhanCong bus = new Bus_PhanCong();
            dsDDL = bus.LayDanhSachDDL(nv.Id);
            foreach (var item in dsDDL)
            {
                cbxDDL.Items.Add(item.TenDoanDuLich);
            }
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
            if (cbxDDL.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tên đoàn du lịch", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Bus_PhanCong bus = new Bus_PhanCong();
            Dto_PhanCong pc = new Dto_PhanCong();
            pc.NV_Id = nv.Id;
            pc.DoanDuLich_Id = dsDDL[cbxDDL.SelectedIndex].Id;
            pc.NhiemVu = txtNhiemVu.Text;
            if (bus.ThemPC(pc))
            {
                MessageBox.Show("Đã thêm phân công mới thành công", "Thành công", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Đã có lỗi xảy ra", "Thất bại", MessageBoxButtons.OK);
        }
    }
}
