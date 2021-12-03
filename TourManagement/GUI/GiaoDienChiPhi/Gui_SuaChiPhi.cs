using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienChiPhi
{
    public partial class Gui_SuaChiPhi : Form
    {

        List<LoaiChiPhi> dsLoaiChiPhi;
        Dto_ChiPhi currentChiPhi;

        public Gui_SuaChiPhi(Dto_ChiPhi chiPhi)
        {
            InitializeComponent();
            currentChiPhi = chiPhi;
            cbxLoaiChiPhi.Text = chiPhi.TenLoaiChiPhi;
            txtSoTien.Text = chiPhi.SoTien.ToString();
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

        private void btnSua_Click(object sender, EventArgs e)
        {

            decimal soTien;
            if (!decimal.TryParse(txtSoTien.Text, out soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return;

            }

            Dto_ChiPhi ChiPhi = new Dto_ChiPhi();
            ChiPhi.Id = currentChiPhi.Id;
            ChiPhi.DoanDuLich_Id = currentChiPhi.DoanDuLich_Id;
            ChiPhi.SoTien = soTien;

            if (cbxLoaiChiPhi.SelectedItem != null)
                ChiPhi.LoaiChiPhi_id = dsLoaiChiPhi[cbxLoaiChiPhi.SelectedIndex].Id;
            else
                ChiPhi.LoaiChiPhi_id = currentChiPhi.LoaiChiPhi_id;

            Bus_ChiPhi bus = new Bus_ChiPhi();
            if (bus.CapNhatChiPhi(ChiPhi))
            {
                MessageBox.Show("Đã cập nhật chi phí thành công", "Thành công", MessageBoxButtons.OK);
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
