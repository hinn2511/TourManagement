using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienChiPhi
{
    public partial class Gui_ThemChiPhi : Form
    {

        List<LoaiChiPhi> dsLoaiChiPhi;
        int currentDoanDuLichId;

        public Gui_ThemChiPhi(int doanDuLichId)
        {
            InitializeComponent();
            currentDoanDuLichId = doanDuLichId;
            LayDanhSachChiPhi();
        }


        private void LayDanhSachChiPhi()
        {
            Bus_ChiPhi bus = new Bus_ChiPhi();
            dsLoaiChiPhi = bus.LayDanhSachLoaiChiPhi();
            foreach (var item in dsLoaiChiPhi)
            {
                cbxLoaiChiPhi.Items.Add(item.TenLoai);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbxLoaiChiPhi.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại chi phí", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            decimal soTien;
            if (!decimal.TryParse(txtSoTien.Text, out soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return;

            }

            Dto_ChiPhi ChiPhi = new Dto_ChiPhi();

            ChiPhi.DoanDuLich_Id = currentDoanDuLichId;
            ChiPhi.LoaiChiPhi_id = dsLoaiChiPhi[cbxLoaiChiPhi.SelectedIndex].Id;
            ChiPhi.SoTien = soTien;

            Bus_ChiPhi bus = new Bus_ChiPhi();
            if (bus.ThemChiPhi(ChiPhi))
            {
                MessageBox.Show("Đã thêm chi phí thành công", "Thành công", MessageBoxButtons.OK);
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
