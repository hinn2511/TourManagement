using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;
namespace TourManagement.GUI
{
    public partial class Gui_PhanCong : Form
    {
        List<Dto_PhanCong> dsPC;
        int currentIndex;
        Dto_NV currentNvPc;

        public Gui_PhanCong(Dto_NV NvPc)
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
            pcGridView.Columns["DoanDuLich_Id"].Visible = false; 
            pcGridView.Columns["TenDoan"].HeaderText = "Tên Đoàn Du Lịch ";
            pcGridView.Columns["NhiemVu"].HeaderText = "Nhiệm Vụ";
        }
        
    }
}
