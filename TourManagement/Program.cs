using System;
using System.Windows.Forms;
using TourManagement.GUI;

namespace TourManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Gui_GiaoDienChinh());
        }
    }
}
