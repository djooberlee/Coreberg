using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CorebergConsoleInstaller
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
                        //Console.WriteLine(process.ProcessName);
                        process.Kill();
                    }
                }
                Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + "\\DI\\");
                File.Copy(Directory.GetCurrentDirectory() + "\\DI\\DesktopInfo.exe", System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + "\\DI\\DesktopInfo.exe", true);
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.SetValue("Desktopinfo", System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + "\\DI\\DesktopInfo.exe");
                key.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Стандартное сообщение таково: ");
                Console.WriteLine(exc); // вызвать метод ToString()
                Console.WriteLine("Свойство StackTrace: " + exc.StackTrace);
                Console.WriteLine("Свойство Message: " + exc.Message);
                Console.WriteLine("Свойство TargetSite: " + exc.TargetSite);
            }
        }
    }
}
