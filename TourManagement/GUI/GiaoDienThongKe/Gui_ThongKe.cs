using System.Drawing;
using System.Windows.Forms;

namespace TourManagement.GUI.GiaoDienThongKe
{
    public partial class Gui_ThongKe : Form
    {
        public Form currentChildForm;

        public Gui_ThongKe()
        {
            InitializeComponent();
            btnThongKeTour.BackColor = Color.LightSalmon;
            btnThongKeTour.ForeColor = Color.White;
            btnThongKeTour.ForeColor = Color.White;
            OpenChildForm(new Gui_ThongKeTour());
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childThongKePanel.Controls.Add(childForm);
            childThongKePanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Reset()
        {
           btnThongKeDoan.BackColor = Color.Transparent;
           btnThongKeDoan.ForeColor = Color.Black;
            btnThongKeDoan.IconColor = Color.Black;
            btnThongKeNhanVien.BackColor = Color.Transparent;
           btnThongKeNhanVien.ForeColor = Color.Black;
            btnThongKeNhanVien.IconColor = Color.Black;
            btnThongKeTour.BackColor = Color.Transparent;
            btnThongKeTour.IconColor = Color.Black;
            btnThongKeTour.ForeColor = Color.Black;
        }

        private void btnThongKeTour_Click(object sender, System.EventArgs e)
        {
            OpenChildForm(new Gui_ThongKeTour());
            Reset();
            btnThongKeTour.BackColor = Color.LightSalmon;
            btnThongKeTour.ForeColor = Color.White;
            btnThongKeTour.ForeColor = Color.White;
        }

        private void btnThongKeDoan_Click(object sender, System.EventArgs e)
        {
            OpenChildForm(new Gui_ThongKeDoan());
            Reset();
            btnThongKeDoan.BackColor = Color.LightSalmon;
            btnThongKeDoan.ForeColor = Color.White;
            btnThongKeDoan.IconColor = Color.White;
        }

        private void btnThongKeNhanVien_Click(object sender, System.EventArgs e)
        {
            OpenChildForm(new Gui_ThongKeNhanVien());
            Reset();
            btnThongKeNhanVien.BackColor = Color.LightSalmon;
            btnThongKeNhanVien.ForeColor = Color.White;
            btnThongKeNhanVien.IconColor = Color.White;
        }
    }
}
