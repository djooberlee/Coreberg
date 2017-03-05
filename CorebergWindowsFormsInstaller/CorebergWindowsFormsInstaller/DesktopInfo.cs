using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CorebergWindowsFormsInstaller
{
    internal class DesktopInfo
    {
        public static void Install()
        {
            try
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.ToLower() == "desktopinfo")
                    {
                        process.WaitForInputIdle();
                        process.CloseMainWindow();

                        process.Kill();
                        process.WaitForExit();
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

        public static void Uninstall()
        {
            try
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.ToLower() == "desktopinfo")
                    {
                        process.WaitForInputIdle();
                        process.CloseMainWindow();
                        process.Kill();
                        process.WaitForExit();
                    }
                }
                if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + "\\DI\\"))
                {
                    Directory.Delete(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + "\\DI\\", true);
                    Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    key.DeleteValue("Desktopinfo");
                    key.Close();
                }
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