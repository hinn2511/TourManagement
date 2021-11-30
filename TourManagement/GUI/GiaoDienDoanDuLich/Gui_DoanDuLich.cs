using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;
using TourManagement.GUI.GiaoDienChiTietDoan;

namespace TourManagement.GUI.GiaoDienDoanDuLich
{
    public partial class Gui_DoanDuLich : Form
    {
        List<Dto_DoanDuLich> dsDoanDuLich = new List<Dto_DoanDuLich>();

        int currentIndex;

        public Gui_DoanDuLich()
        {
            InitializeComponent();
            CapNhatDanhSachDoanDuLich();
            currentIndex = -1;
        }


        public void CapNhatDanhSachDoanDuLich()
        {
            Bus_DoanDuLich bus = new Bus_DoanDuLich();
            dsDoanDuLich = bus.LayDanhSachDoanDuLich();
            doanDuLichGridView.DataSource = dsDoanDuLich;
            DatTenDauDanhSach();
        }

        private void DatTenDauDanhSach()
        {
            doanDuLichGridView.Columns["Id"].HeaderText = "Mã đoàn";
            doanDuLichGridView.Columns["TenDoan"].HeaderText = "Tên đoàn du lịch";
            doanDuLichGridView.Columns["TenTour"].HeaderText = "Tên tour";
            doanDuLichGridView.Columns["Tour_Id"].Visible = false;
            doanDuLichGridView.Columns["DoanhThu"].HeaderText = "Doanh thu (VNĐ)";
            doanDuLichGridView.Columns["NgayKhoiHanh"].HeaderText = "Ngày khởi hành";
            doanDuLichGridView.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";
            doanDuLichGridView.Columns["NgayKhoiHanh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            doanDuLichGridView.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemDoanDuLich themDoanDuLichForm = new Gui_ThemDoanDuLich();
            themDoanDuLichForm.ShowDialog();
            CapNhatDanhSachDoanDuLich();
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đoàn du lịch cần sửa", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Gui_SuaDoanDuLich suaDoanDuLichForm = new Gui_SuaDoanDuLich(dsDoanDuLich[currentIndex]);
            suaDoanDuLichForm.ShowDialog();
            CapNhatDanhSachDoanDuLich();
        }

        private void doanDuLichGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (doanDuLichGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
            }
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đoàn du lịch cần xóa", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Bus_DoanDuLich bus = new Bus_DoanDuLich();
            if (bus.XoaDoanDuLich(dsDoanDuLich[currentIndex].Id))
            {
                MessageBox.Show("Xóa đoàn du lịch thành công", "Thành công", MessageBoxButtons.OK);
                CapNhatDanhSachDoanDuLich();
            }
            else
                MessageBox.Show("Xóa đoàn du lịch thất bại", "Lỗi", MessageBoxButtons.OK);
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            Bus_DoanDuLich bus = new Bus_DoanDuLich();
            var result = bus.TimKiemDoanDuLich(dsDoanDuLich, txtTimKiem.Text);
            doanDuLichGridView.DataSource = null;
            doanDuLichGridView.DataSource = result;
            DatTenDauDanhSach();

        }

        private void btnLamMoi_Click(object sender, System.EventArgs e)
        {
            doanDuLichGridView.DataSource = null;
            doanDuLichGridView.DataSource = dsDoanDuLich;
            DatTenDauDanhSach();
        }

        private void btnDanhSachDoan_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đoàn du lịch cần xem danh sách tham gia", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Gui_ChiTietDoan chiTietDoanForm = new Gui_ChiTietDoan(dsDoanDuLich[currentIndex]);
            chiTietDoanForm.ShowDialog();
            CapNhatDanhSachDoanDuLich();
        }

        private void btnChiPhi_Click(object sender, System.EventArgs e)
        {
            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đoàn du lịch xem chi phí", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            //Gui_ChiPhi chiTietDoanForm = new Gui_ChiTietDoan(dsDoanDuLich[currentIndex]);
            //chiTietDoanForm.ShowDialog();
            CapNhatDanhSachDoanDuLich();
        }
    }
}
