using System;
using System.Windows.Forms;

namespace TourManagement.GUI
{
    public partial class Gui_Mau_3 : Form
    {


        public Gui_Mau_3()
        {
            InitializeComponent();
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
