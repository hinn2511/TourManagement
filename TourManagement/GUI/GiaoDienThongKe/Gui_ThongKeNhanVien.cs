﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienThongKe
{
    public partial class Gui_ThongKeNhanVien : Form
    {
        

        List<Dto_NV> dsNhanVien;
        List<Dto_ThongKePhanCongNV> dsThongKeNhanVien;

        public Gui_ThongKeNhanVien()
        {
            InitializeComponent();
            LayDanhSachNhanVien();

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
        private void btnThongKeTour_Click(object sender, System.EventArgs e)
        {
            Bus_ThongKe bus = new Bus_ThongKe();
            dsThongKeNhanVien = bus.LayKetQuaThongKeNhanVien(dsNhanVien[cbxTour.SelectedIndex].Id, dtTuNgay.Value, dtDenNgay.Value);
            txtSoLanPhanCong.Text = bus.TinhTongSoLanPhanCong(dsThongKeNhanVien).ToString();
            thongKeDoanGridView.DataSource = dsThongKeNhanVien;
            DatTenDauDanhSach();
        }

        private void DatTenDauDanhSach()
        {
            thongKeDoanGridView.Columns["TenTour"].HeaderText = "Tên tour";
            thongKeDoanGridView.Columns["SoLanPhanCong"].HeaderText = "Số lần phân công";
        }
    }
}
