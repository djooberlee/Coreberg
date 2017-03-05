using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CorebergWindowsFormsInstaller
{
    internal class TeamViewer
    {
        private static int tvid;
        private static string tvistallpath;
        private static string tvversion;
        private static string msi_packege_name;
        private static string apitoken;
        private static string idc;

        static public int ID
        {
            get
            {
                GetTVID();
                return tvid;
            }
        }

        static public string Path
        {
            get
            {
                GetTVpath();
                return tvistallpath;
            }
        }

        static public string Version
        {
            get
            {
                GetTVversion();
                return tvversion;
            }
        }

        private static void GetTVID()
        {
            string key_value = "NOT FOUND";

            try
            {
                Microsoft.Win32.RegistryKey registryKey64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\TeamViewer");
                RegistryKey registryKey32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\TeamViewer");
                if (!Environment.Is64BitOperatingSystem)
                {
                    key_value = Registry.GetValue(registryKey32.Name, "ClientID", "NOT FOUND").ToString();
                }
                else
                {
                    key_value = Registry.GetValue(registryKey64.Name, "ClientID", "NOT FOUND").ToString();
                }
            }
            catch (System.Exception) { tvid = 000000000; }
            tvid = Int32.Parse(key_value);
        }

        private static void GetTVpath()
        {
            try
            {
                string key_value = "NOT FOUND";

                try
                {
                    Microsoft.Win32.RegistryKey registryKey64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\TeamViewer");
                    RegistryKey registryKey32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\TeamViewer");
                    if (!Environment.Is64BitOperatingSystem)
                    {
                        key_value = Registry.GetValue(registryKey32.Name, "InstallationDirectory", "NOT FOUND").ToString();
                    }
                    else
                    {
                        key_value = Registry.GetValue(registryKey64.Name, "InstallationDirectory", "NOT FOUND").ToString();
                    }
                }
                catch (System.Exception) { tvistallpath = "notinstalled"; }
                tvistallpath = key_value;
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

        private static void GetTVversion()
        {
            string key_value = "NOT FOUND";

            try
            {
                Microsoft.Win32.RegistryKey registryKey64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\TeamViewer");
                RegistryKey registryKey32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\TeamViewer");
                if (!Environment.Is64BitOperatingSystem)
                {
                    key_value = Registry.GetValue(registryKey32.Name, "Version", "NOT FOUND").ToString();
                }
                else
                {
                    key_value = Registry.GetValue(registryKey64.Name, "Version", "NOT FOUND").ToString();
                }
            }
            catch (System.Exception) { tvistallpath = "notinstalled"; }
            tvversion = key_value;
        }

        static public void Uninstall()
        {
            try
            {
                if (InstalledSoftware.NameContain("teamviewer", "msi"))
                {
                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = TeamViewer.Path;
                    process.StartInfo.FileName = string.Format(TeamViewer.Path + "\\uninstall.exe");
                    process.StartInfo.Arguments = " /S";
                    process.Start();
                    process.WaitForExit();
                }
                if (InstalledSoftware.NameContain2("teamviewer", "msi"))
                {
                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\TeamViewer";
                    process.StartInfo.FileName = "msiexec.exe";
                    process.StartInfo.Arguments = " /x \"" + Directory.GetCurrentDirectory() + "\\TeamViewer\\" + TeamViewer.GetMSIPackegeName() + "\" /norestart /qn";
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

        public static void Install(string tag_company, int tag_number, bool corp)
        {
            if (corp == true)
            {
                try
                {
                    GetAPITOKENandIDC(tag_company);
                    File.Move(Directory.GetCurrentDirectory() + "\\Teamviewer\\" + GetMSIPackegeName(), Directory.GetCurrentDirectory() + "\\TeamViewer\\TeamViewer_Host-idc" + idc + ".msi");

                    foreach (string i in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Teamviewer", "*.reg"))
                    {
                        File.Delete(i);
                    }

                    File.Copy(Directory.GetCurrentDirectory() + "\\Teamviewer\\REG\\TeamViewer_Settings_" + tag_company + ".REG", Directory.GetCurrentDirectory() + "\\TeamViewer\\TeamViewer_Settings_" + tag_company + ".REG", true);
                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\TeamViewer";
                    process.StartInfo.FileName = "msiexec.exe";
                    process.StartInfo.Arguments = " /package \"" + Directory.GetCurrentDirectory() + "\\Teamviewer\\" + GetMSIPackegeName() + "\" /norestart /qn";
                    process.Start();
                    process.WaitForExit();
                    Assign(tag_company, tag_number);
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
            else
            {
                try
                {
                    GetAPITOKENandIDC(tag_company);
                    File.Move(Directory.GetCurrentDirectory() + "\\Teamviewer\\" + GetMSIPackegeName(), Directory.GetCurrentDirectory() + "\\TeamViewer\\TeamViewer_Host.msi");

                    foreach (string i in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Teamviewer", "*.reg"))
                    {
                        File.Delete(i);
                    }

                    File.Copy(Directory.GetCurrentDirectory() + "\\Teamviewer\\REG\\TeamViewer_Settings_" + tag_company + ".REG", Directory.GetCurrentDirectory() + "\\TeamViewer\\TeamViewer_Settings_" + tag_company + ".REG", true);
                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\TeamViewer";
                    process.StartInfo.FileName = "msiexec.exe";
                    process.StartInfo.Arguments = " /package \"" + Directory.GetCurrentDirectory() + "\\Teamviewer\\" + GetMSIPackegeName() + "\" /norestart /qn";
                    process.Start();
                    process.WaitForExit();
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

        private static void Assign(string tag_company, int tag_number)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.WorkingDirectory = string.Format(Directory.GetCurrentDirectory() + "\\TeamViewer");
                process.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\Teamviewer\\tv_assignement.exe";
                process.StartInfo.Arguments = string.Format("-apitoken " + apitoken + " -allowEasyAccess -devicealias " + tag_company + "-" + tag_number + " -wait \"30\" -datafile \"" + Path + "\\AssignmentData.json\"");
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();
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

        public static string GetMSIPackegeName()
        {
            try
            {
                foreach (string i in Directory.GetFiles(string.Format(Directory.GetCurrentDirectory() + "\\Teamviewer"), "*.msi"))
                {
                    msi_packege_name = i.Split('\\')[(i.Split('\\').Length) - 1];
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
            return msi_packege_name;
        }

        private static void GetAPITOKENandIDC(string tag_company)
        {
            try
            {
                string[] clients_params = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Teamviewer\\clients.txt");
                foreach (string i in clients_params)
                {
                    if (i.Split(';')[0] == tag_company)
                    {
                        idc = i.Split(';')[1];
                        apitoken = i.Split(';')[2];
                    }
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