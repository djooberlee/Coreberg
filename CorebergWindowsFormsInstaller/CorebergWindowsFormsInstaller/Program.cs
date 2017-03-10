using System;
using System.Windows.Forms;

namespace CorebergWindowsFormsInstaller
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                if (args[0] == "--tv-uninstall") TeamViewer.Uninstall();
                if (args[0] == "--ocs-uninstall") OCS.Uninstall();
                if (args[0] == "--di-uninstall") DesktopInfo.Uninstall();
                return;
            }
            Application.Run(new Form1());
        }
    }
}