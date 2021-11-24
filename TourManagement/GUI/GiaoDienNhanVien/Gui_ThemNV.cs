using System;
using System.Windows.Forms;

namespace TourManagement.GUI.GiaoDienNhanVien
{
    public partial class Gui_ThemNV : Form
    {


        public Gui_ThemNV()
        {
            InitializeComponent();
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Gui_ThemNV_Load(object sender, EventArgs e)
        {

        }
    }
}
