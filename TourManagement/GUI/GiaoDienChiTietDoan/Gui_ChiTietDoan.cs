using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TourManagement.BUS;
using TourManagement.DTO;

namespace TourManagement.GUI.GiaoDienChiTietDoan
{
    public partial class Gui_ChiTietDoan : Form
    {
        List<Dto_ChiTietDoan> dsChiTietDoan;
        int currentIndex;
        Dto_DoanDuLich currentDoanDuLich;

        public Gui_ChiTietDoan(Dto_DoanDuLich doanDuLich)
        {
            InitializeComponent();
            currentDoanDuLich = doanDuLich;
            //txtTenTour.Text = currentTour.TenTour;
            CapNhatDanhSachChiTietDoan();
            currentIndex = -1;
        }

        private void DatTenDauDanhSach()
        {
            chiTietDoanGridView.Columns["DoanDuLich_Id"].Visible = false;
            chiTietDoanGridView.Columns["KhachHang_Id"].HeaderText = "Mã khách hàng";
            chiTietDoanGridView.Columns["TenKhachHang"].HeaderText = "Tên khách hàng";
        }

        private void CapNhatDanhSachChiTietDoan()
        {
            Bus_ChiTietDoan bus = new Bus_ChiTietDoan();
            dsChiTietDoan = bus.LayDanhSachChiTietDoan(currentDoanDuLich.Id);
            chiTietDoanGridView.DataSource = dsChiTietDoan;
            DatTenDauDanhSach();
        }


        private void btnThem_Click(object sender, System.EventArgs e)
        {
            Gui_ThemChiTietDoan themDanhSachThamGiaForm = new Gui_ThemChiTietDoan(currentDoanDuLich);
            Debug.WriteLine(currentIndex);
            themDanhSachThamGiaForm.ShowDialog();
            CapNhatDanhSachChiTietDoan();
        }


        private void giaTourGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (chiTietDoanGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                currentIndex = e.RowIndex;
            }
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {

            if (currentIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng tham gia cần xóa", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            Bus_ChiTietDoan bus = new Bus_ChiTietDoan();
            var result = bus.XoaChiTietDoan(dsChiTietDoan[currentIndex]);

            if (result)
            {
                MessageBox.Show("Đã giá xóa khách hàng tham gia thành công", "Xóa thành công", MessageBoxButtons.OK);
                dsChiTietDoan.RemoveAt(currentIndex);
                chiTietDoanGridView.DataSource = null;
                chiTietDoanGridView.DataSource = dsChiTietDoan;
                DatTenDauDanhSach();
            }

        }

    }
}
