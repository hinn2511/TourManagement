using System;
using System.Windows.Forms;

namespace TourManagement.GUI
{
    public partial class Gui_ThemKH : Form
    {


        public Gui_ThemKH()
        {
            InitializeComponent();
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lbCMND_Click(object sender, EventArgs e)
        {

        }
    }
}
