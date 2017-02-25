using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CorebergConsoleInstaller
{
    class OCS
    {
        static string user="Coreberg";
        static string pwd= "CoreAgent098";

        public static void Install(string tag_company, int tag_number)
        {
            try
            {
                

                Console.WriteLine("Установка \"Teamviewer\".");
                Process process = new Process();
                process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\OCSi"; //sets the working directory in which the exe file resides.
                process.StartInfo.FileName = "OCS-NG-Windows-Agent-Setup.exe";
                process.StartInfo.Arguments = "/S /SERVER=https://inv.coreberg.com/ocsinventory /USER=" + user + " /SSL=0 /PWD=" + pwd + " /DEBUG=1 /TAG=" + tag_company + "-" + tag_number + " /NOW /NOSPLASH /NO_SYSTRAY";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = false;
                Console.WriteLine("Запуск: " + process.StartInfo.FileName + process.StartInfo.Arguments);
                process.Start();
                process.WaitForExit();
                Console.WriteLine("Установка \"Teamviewer\" завершена.");
                Console.WriteLine();
            }
            catch (System.Exception) { Console.WriteLine("проблема гдето в Install()"); }
        }
    }
}
