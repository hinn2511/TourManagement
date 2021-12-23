using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienThongKe
{
    public partial class Gui_ThongKeLoiNhuanTour : Form
    {
        List<Dto_Tour> dsTour;
        List<Dto_ThongKeLoiNhuanTour> dsThongKeLoiNhuanTour;

        public Gui_ThongKeLoiNhuanTour()
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
            dsThongKeLoiNhuanTour = bus.LayKetQuaThongKeLoiNhuan(dsTour[cbxTour.SelectedIndex].Id, dtTuNgay.Value, dtDenNgay.Value);

            decimal tongDoanhThu = bus.TinhTongDoanhThu(dsThongKeLoiNhuanTour);
            decimal tongChiPhi = bus.TinhTongChiPhi(dsThongKeLoiNhuanTour);
            decimal tongLoiNhuan = bus.TinhTongLoiNhuan(tongDoanhThu, tongChiPhi);

            txtDoanhThu.Text = tongDoanhThu.ToString();
            txtChiPhi.Text = tongChiPhi.ToString();
            txtLoiNhuan.Text = tongLoiNhuan.ToString();

            // Console.WriteLine(dtTuNgay.Value);


            thongKeDoanGridView.DataSource = dsThongKeLoiNhuanTour;
            DatTenDauDanhSach();

           /* if(dsThongKeLoiNhuanTour != null)
            {
                decimal tongDoanhThu = bus.TinhTongDoanhThu(dsThongKeLoiNhuanTour);
                decimal tongChiPhi = bus.TinhTongChiPhi(dsThongKeLoiNhuanTour);
                decimal tongLoiNhuan = bus.TinhTongLoiNhuan(tongDoanhThu, tongChiPhi);

                txtDoanhThu.Text = tongDoanhThu.ToString();
                txtChiPhi.Text = tongChiPhi.ToString();
                txtLoiNhuan.Text = tongLoiNhuan.ToString();

                thongKeDoanGridView.DataSource = dsThongKeLoiNhuanTour;
                DatTenDauDanhSach();
            }*/
            

        }

        private void DatTenDauDanhSach()
        {
            thongKeDoanGridView.Columns["TenDoanDuLich"].HeaderText = "Tên đoàn du lịch";
            thongKeDoanGridView.Columns["DoanhThu"].HeaderText = "Tổng doanh thu đoàn";
            thongKeDoanGridView.Columns["ChiPhi"].HeaderText = "Tổng chi phí đoàn";
            thongKeDoanGridView.Columns["SoLuongKhach"].HeaderText = "Số lượng người tham gia đoàn";
        }
    }
}
