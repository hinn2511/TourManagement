using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourManagement.BUS;

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
