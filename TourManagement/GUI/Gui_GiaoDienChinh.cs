using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using TourManagement.GUI.GiaoDienChiPhi;
using TourManagement.GUI.GiaoDienDiaDiem;
using TourManagement.GUI.GiaoDienDoanDuLich;
using TourManagement.GUI.GiaoDienKhachHang;
using TourManagement.GUI.GiaoDienNhanVien;
using TourManagement.GUI.GiaoDienTour;

namespace TourManagement.GUI
{
    public partial class Gui_GiaoDienChinh : Form
    {
        public IconButton currentBtn;
        public Panel leftBorderBtn;
        public Form currentChildForm;
        public Gui_GiaoDienChinh()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 70);
            panelMenu.Controls.Add(leftBorderBtn);
            Reset();

        }

        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.Chocolate;
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = Color.White;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.Transparent;
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            OpenChildForm(new Gui_TrangChu());
            iconCurrentChildForm.IconChar = IconChar.Home;
            lblTitleChildForm.Text = "TRANG CHỦ";
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
            panelForm.Controls.Add(childForm);
            panelForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Gui_KhachHang());
            lblTitleChildForm.Text = "KHÁCH HÀNG";
        }

        private void btnTour_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Gui_Tour());
            lblTitleChildForm.Text = "TOUR";

        }

        private void btnDiaDiem_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Gui_DiaDiem());
            lblTitleChildForm.Text = "ĐỊA ĐIỂM";
        }

        private void btnDoanDuLich_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Gui_DoanDuLich());
            lblTitleChildForm.Text = "ĐOÀN DU LỊCH";
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Gui_NhanVien());
            lblTitleChildForm.Text = "NHÂN VIÊN";
        }

        private void btnChiPhi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Gui_ChiPhi());
            lblTitleChildForm.Text = "CHI PHÍ";
        }


        private void imgLogo_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
