using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;
using System.Collections.Generic;
namespace TourManagement.GUI.GiaoDienChiPhi
{
    public partial class Gui_ChiPhi : Form
    {
        List<Dto_ChiPhi> dsChiPhi = new List<Dto_ChiPhi>();
        int currentIndex;
        public Gui_ChiPhi()
        {
            InitializeComponent();
            CapNhatDanhSachTour();
        }
        private void DatTenDauDanhSach()
        {
            GridView.Columns["Id"].HeaderText = "Mã chi phí";
            GridView.Columns["DoanDuLichId"].HeaderText = "Mã Đoàn";
            GridView.Columns["LoaiChiPhiId"].Visible = false;
            GridView.Columns["TenLoaiChiPhi"].HeaderText = "Loại";
            GridView.Columns["SoTien"].HeaderText = "Số tiền (VNĐ)";
        }

        public void CapNhatDanhSachTour()
        {
            Bus_ChiPhi bus = new Bus_ChiPhi();
            dsChiPhi = bus.LayDsChiPhi(); 
            GridView.DataSource = dsChiPhi;
            DatTenDauDanhSach();
        }


        private void btnLoaiChiPhi_Click(object sender, System.EventArgs e)
        {
            Gui_LoaiChiPhi formLoaiChiPhi = new Gui_LoaiChiPhi();
            formLoaiChiPhi.ShowDialog();
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {

        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {

        }

        private void btnChiTiet_Click(object sender, System.EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, System.EventArgs e)
        {

        }
    }
}
