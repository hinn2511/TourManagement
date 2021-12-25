using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;
namespace TourManagement.GUI.GiaoDienPhanCong
{
    public partial class Gui_PhanCong : Form
    {
        List<Dto_PhanCong> dsPC;
        int currentIndex;
        NhanVien currentNvPc;
        
        public Gui_PhanCong(NhanVien NvPc)
        {   
            InitializeComponent();
            currentNvPc = NvPc;
            CapNhatDanhSachPC();
            currentIndex = -1;
           
        }
        private void CapNhatDanhSachPC()
        {
            Bus_PhanCong bus = new Bus_PhanCong();
            dsPC = bus.LayDanhSachPhanCong(currentNvPc.Id);
            pcGridView.DataSource = dsPC;
            DatTenDauDanhSach();
        }
        private void DatTenDauDanhSach()
        {
            pcGridView.Columns["NV_Id"].HeaderText = "Mã Nhân Viên";
            pcGridView.Columns["HoTen"].HeaderText = "Họ tên";
            pcGridView.Columns["DoanDuLich_Id"].Visible = false; 
            pcGridView.Columns["TenDoan"].HeaderText = "Tên Đoàn Du Lịch ";
            pcGridView.Columns["NhiemVu"].HeaderText = "Nhiệm Vụ";
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemPC themPCForm = new Gui_ThemPC(currentNvPc);
            themPCForm.ShowDialog();
            CapNhatDanhSachPC();
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            Gui_SuaPhanCong suaPCForm = new Gui_SuaPhanCong(dsPC[currentIndex]);
            suaPCForm.ShowDialog();
            CapNhatDanhSachPC();
        }
    }
}
