using System;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;

namespace Project_WinForms_for_Tests
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static KeyValuePair<string, string> GetOSVersionAndCaption()
        {
            KeyValuePair<string, string> kvpOSSpecs = new KeyValuePair<string, string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption, Version FROM Win32_OperatingSystem");

            try
            {
                foreach (var os in searcher.Get())
                {
                    var version = os["Version"].ToString();
                    var productName = os["Caption"].ToString();
                    kvpOSSpecs = new KeyValuePair<string, string>(productName, version);
                }
            }
            catch { }
            return kvpOSSpecs;
        }
    }
}