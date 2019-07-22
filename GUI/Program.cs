using System;
using System.Windows.Forms;
using GUI.Custom;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());
            //Run Program once time
            Application.Run(new frmSplash());
            SingleInstance.SingleApplication.Run(new frmLogin());
        }
    }
}
