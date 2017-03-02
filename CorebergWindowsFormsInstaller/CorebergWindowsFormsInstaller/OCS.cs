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
    class OCS
    {
        static string user = "coreberg";
        static string pwd = "CoreAgent098";

        public static void Install(string tag_company, int tag_number)
        {
            try
            {
                //Console.WriteLine("Установка \"OCS Inventory\".");
                Process process = new Process();
                process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\OCSi"; //sets the working directory in which the exe file resides.
                process.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\OCSi\\OCS-NG-Windows-Agent-Setup.exe";
                process.StartInfo.Arguments = " /S /SERVER=https://inv.coreberg.com/ocsinventory /USER=" + user + " /SSL=0 /PWD=" + pwd + " /DEBUG=1 /TAG=" + tag_company + "-" + tag_number + " /NOW /NOSPLASH /NO_SYSTRAY";
               // process.StartInfo.UseShellExecute = false;
                //process.StartInfo.CreateNoWindow = true;
                //Console.WriteLine("Запуск: " + process.StartInfo.FileName + process.StartInfo.Arguments);
                process.Start();
                process.WaitForExit();
                //Console.WriteLine("Установка \"OCS Inventory\" завершена.");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Стандартное сообщение таково: ");
                MessageBox.Show(exc.ToString()); // вызвать метод ToString()
                MessageBox.Show("Свойство StackTrace: " + exc.StackTrace);
                MessageBox.Show("Свойство Message: " + exc.Message);
                MessageBox.Show("Свойство TargetSite: " + exc.TargetSite);
            }
        }
    }
}
