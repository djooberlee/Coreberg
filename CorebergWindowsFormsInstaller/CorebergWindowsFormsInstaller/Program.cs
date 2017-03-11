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
                if (args[0] == "--tv-uninstall-9") TeamViewer.Uninstall(9);
                if (args[0] == "--tv-uninstall-11") TeamViewer.Uninstall(11);
                if (args[0] == "--tv-uninstall-12") TeamViewer.Uninstall(12);
                if (args[0] == "--ocs-uninstall") OCS.Uninstall();
                if (args[0] == "--di-uninstall") DesktopInfo.Uninstall();
                return;
            }
            Application.Run(new Form1());
        }
    }
}