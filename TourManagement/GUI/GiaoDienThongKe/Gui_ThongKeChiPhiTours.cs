using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienThongKe
{
    public partial class Gui_ThongKeChiPhiTours : Form
    {
        

        List<Dto_Tour> dsTour;
        List<Dto_ThongKeChiPhiTour> dsThongKeChiPhiTour;

        public Gui_ThongKeChiPhiTours()
        {
            InitializeComponent();
            LayDanhSachTour();
            DieuChinhNgay();

        }

        private void LayDanhSachTour()
        {
            Bus_ThongKe bus = new Bus_ThongKe();
            dsTour = bus.LayDanhSachTour();
            foreach (var item in dsTour)
            {
                cbxTour.Items.Add(item.TenTour);
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
            dsThongKeChiPhiTour = bus.LayKetQuaThongKeChiPhi(dsTour[cbxTour.SelectedIndex].Id, dtTuNgay.Value, dtDenNgay.Value);
            Dto_ThongKeChiPhiTour cpCaoNhat = bus.ChiPhiCaoNhat(dsThongKeChiPhiTour);
            Dto_ThongKeChiPhiTour cpThapNhat = bus.ChiPhiThapNhat(dsThongKeChiPhiTour);
            decimal tongCacChiPhi = bus.TinhTongChiPhi(dsThongKeChiPhiTour);
           
            txtChiPhiThapNhat.Text = cpThapNhat.LoaiChiPhi.ToString();
            txtSoTienThapNhat.Text = cpThapNhat.TongSoTien.ToString();
            txtChiPhiCaoNhat.Text = cpCaoNhat.LoaiChiPhi.ToString();
            txtSoTienCaoNhat.Text = cpCaoNhat.TongSoTien.ToString();
            txtTongCacChiPhi.Text = tongCacChiPhi.ToString();

            thongKeDoanGridView.DataSource = dsThongKeChiPhiTour;
            DatTenDauDanhSach();
        }

        private void DatTenDauDanhSach()
        {
            thongKeDoanGridView.Columns["LoaiChiPhi"].HeaderText = "Loại chi phí";
            thongKeDoanGridView.Columns["TongSoTien"].HeaderText = "Tổng số tiền";
        }
    }
}
