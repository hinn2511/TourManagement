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
            pcGridView.Columns["DoanDuLich_Id"].Visible = false; 
            pcGridView.Columns["TenDoan"].HeaderText = "Tên Đoàn Du Lịch ";
            pcGridView.Columns["NhiemVu"].HeaderText = "Nhiệm Vụ";
        }
        private void pcGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (pcGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
            }
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemPC themPCForm = new Gui_ThemPC(currentNvPc);
            themPCForm.ShowDialog();
            CapNhatDanhSachPC();
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phân công cần sửa", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Gui_SuaPhanCong suaPCForm = new Gui_SuaPhanCong(dsPC[currentIndex]);
            suaPCForm.ShowDialog();
            CapNhatDanhSachPC();
        }
        private void btnXoa_Click(object sender, System.EventArgs e)
        {

            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phân công cần xóa", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Bus_PhanCong bus = new Bus_PhanCong();
            dsPC = bus.LayDanhSachPhanCong(currentNvPc.Id);
            if (bus.XoaPC(dsPC[currentIndex].NV_Id, dsPC[currentIndex].DoanDuLich_Id))
            {
                MessageBox.Show("Xóa pah6n công thành công", "Thành công", MessageBoxButtons.OK);
                CapNhatDanhSachPC();
            }
            else
                MessageBox.Show("Xóa phân công thất bại", "Lỗi", MessageBoxButtons.OK);

        }

      
    }
}
