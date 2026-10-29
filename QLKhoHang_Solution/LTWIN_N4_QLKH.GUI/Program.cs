using System;
using System.Windows.Forms;
using LTWIN_N4_QLKH.GUI.Forms.Auth;

namespace LTWIN_N4_QLKH.GUI
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
            Application.Run(new frmDangNhap());
        }
    }
}
