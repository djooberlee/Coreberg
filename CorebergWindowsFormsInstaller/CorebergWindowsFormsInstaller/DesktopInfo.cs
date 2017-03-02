using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorebergWindowsFormsInstaller
{
    class DesktopInfo
    {
        public static void Install()
        {
            try
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.ToLower() == "desktopinfo")
                    {
                        MessageBox.Show(process.ProcessName);
                        process.Kill();
                    }
                }
                Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + "\\DI\\");
                File.Copy(Directory.GetCurrentDirectory() + "\\DI\\DesktopInfo.exe", System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + "\\DI\\DesktopInfo.exe", true);
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.SetValue("Desktopinfo", System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + "\\DI\\DesktopInfo.exe");
                key.Close();
                Process process1 = new Process();
                process1.StartInfo.WorkingDirectory =
                process1.StartInfo.FileName = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + "\\DI\\DesktopInfo.exe";
                process1.StartInfo.CreateNoWindow = true;
                process1.Start();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Стандартное сообщение таково: ");
                MessageBox.Show(exc.ToString());
                MessageBox.Show("Свойство StackTrace: " + exc.StackTrace);
                MessageBox.Show("Свойство Message: " + exc.Message);
                MessageBox.Show("Свойство TargetSite: " + exc.TargetSite);
            }
        }
    }
}
