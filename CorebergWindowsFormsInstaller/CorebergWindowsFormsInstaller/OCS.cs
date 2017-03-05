using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CorebergWindowsFormsInstaller
{
    internal class OCS
    {
        private static string user = "coreberg";
        private static string pwd = "CoreAgent098";

        public static void Install(string tag_company, int tag_number)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\OCSi"; //sets the working directory in which the exe file resides.
                process.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\OCSi\\OCS-NG-Windows-Agent-Setup.exe";
                process.StartInfo.Arguments = " /S /SERVER=https://inv.coreberg.com/ocsinventory /USER=" + user + " /SSL=0 /PWD=" + pwd + " /DEBUG=1 /TAG=" + tag_company + "-" + tag_number + " /NOW /NOSPLASH /NO_SYSTRAY";
                process.Start();
                process.WaitForExit();
                File.WriteAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows) + "\\tag.txt", tag_company + "-" + tag_number, Encoding.Default);
                foreach (string i in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\OCSi\\plugins", "*.vbs"))
                {
                    if (OS.Is64Bit()) File.Copy(i, System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFilesX86) + "\\OCS Inventory Agent\\Plugins\\" + i.Split('\\')[(i.Split('\\').Length) - 1], true);
                    else File.Copy(i, System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + "\\OCS Inventory Agent\\Plugins\\" + i.Split('\\')[(i.Split('\\').Length) - 1], true);
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

        public static void Uninstall()
        {
            try
            {
                Process process = new Process();
                if (OS.Is64Bit())
                {
                    process.StartInfo.FileName = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFilesX86) + "\\OCS Inventory Agent\\uninst.exe";
                    process.StartInfo.Arguments = " /S";
                    process.Start();
                    process.WaitForExit();
                }
                else
                {
                    process.StartInfo.FileName = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + "\\OCS Inventory Agent\\uninst.exe";
                    process.StartInfo.Arguments = " /S";
                    process.Start();
                    process.WaitForExit();
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