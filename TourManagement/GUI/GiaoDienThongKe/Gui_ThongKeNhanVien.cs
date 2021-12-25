using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienThongKe
{
    public partial class Gui_ThongKeNhanVien : Form
    {
        

        List<NhanVien> dsNhanVien;
        List<Dto_ThongKePhanCongNV> dsThongKeNhanVien;

        public Gui_ThongKeNhanVien()
        {
            InitializeComponent();
            LayDanhSachNhanVien();
            DieuChinhNgay();

        }

        private void LayDanhSachNhanVien()
        {
            Bus_ThongKe bus = new Bus_ThongKe();
            dsNhanVien = bus.LayDanhSachNhanVien();
            foreach (var item in dsNhanVien)
            {
                cbxTour.Items.Add(item.HoTen);
            }
        }

        private void DieuChinhNgay()
        {
            dtTuNgay.Format = DateTimePickerFormat.Custom;
            dtDenNgay.Format = DateTimePickerFormat.Custom;
            dtTuNgay.CustomFormat = "dd/MM/yyyy";
            dtDenNgay.CustomFormat = "dd/MM/yyyy";
            dtTuNgay.Value = DateTime.Now;
            dtDenNgay.Value = DateTime.Now;
        }
        private void btnThongKeTour_Click(object sender, System.EventArgs e)
        {
            Bus_ThongKe bus = new Bus_ThongKe();
            dsThongKeNhanVien = bus.LayKetQuaThongKeNhanVien(dsNhanVien[cbxTour.SelectedIndex].Id, dtTuNgay.Value, dtDenNgay.Value);
            if(dsThongKeNhanVien != null)
            {
                txtSoLanPhanCong.Text = bus.TinhTongSoLanPhanCong(dsThongKeNhanVien).ToString();
                thongKeDoanGridView.DataSource = dsThongKeNhanVien;
                DatTenDauDanhSach();
            }
            
        }

        private void DatTenDauDanhSach()
        {
            thongKeDoanGridView.Columns["TenTour"].HeaderText = "Tên tour";
            thongKeDoanGridView.Columns["SoLanPhanCong"].HeaderText = "Số lần phân công";
        }
    }
}
