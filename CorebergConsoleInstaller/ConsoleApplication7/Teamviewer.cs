using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace CorebergConsoleInstaller
{
    class TeamViewer
    {
        static int tvid;
        static string tvistallpath;
        static string tvversion;
        // static string tvservicename;
        static string msi_packege_name;

        static public int ID
        {
            get
            {
                GetTVID();
                return tvid;
            }
            private set
            {
            }
        }

        static public string Path
        {
            get
            {
                GetTVpath();
                return tvistallpath;
            }
            private set
            {
            }
        }

        static public string Version
        {
            get
            {
                GetTVversion();
                return tvversion;
            }
            private set
            {
            }
        }


        static public void DisplayInfo()
        {
            if (InstalledSoftware.NameContain("teamviewer"))
            {
                GetTVID();
                Console.WriteLine("Teamviewer ID: {0}", ID);
                Console.WriteLine("Каталог установки: {0}", Path);
                if (Services.Check("teamviewer"))
                {
                    Console.Write("Имя сервиса: ");
                    Services.DisplayList("teamviewer");
                }
                else { Console.WriteLine("Как сервис не установлен."); }
            }
            else
            {
                Console.WriteLine("В системе не найдено установленного Teamviewer.");
            }
        }

        static void GetTVID()
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

        static void GetTVpath()
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
            }catch (Exception) { Console.WriteLine("не сработал GetTVpath()"); }
        }

        static void GetTVversion()
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
                    Console.WriteLine("Удаляем \"" + InstalledSoftware.GetNameContain("teamviewer", "msi")+ "\"");
                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = TeamViewer.Path; //sets the working directory in which the exe file resides.
                    process.StartInfo.FileName = string.Format(TeamViewer.Path + "\\uninstall.exe");
                    process.StartInfo.Arguments = " /S";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = false;
                    Console.WriteLine("Запуск: "+ process.StartInfo.FileName + process.StartInfo.Arguments);
                    process.Start();
                    process.WaitForExit();
                    Console.WriteLine("Удаление завершено.");
                    Console.WriteLine();
                }
                if (InstalledSoftware.NameContain2("teamviewer","msi"))
                {
                    Console.WriteLine("Удаляем \"" + InstalledSoftware.GetNameContain2("teamviewer", "msi")+ "\"");
                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\TeamViewer";
                    process.StartInfo.FileName = "msiexec.exe";
                    process.StartInfo.Arguments = " /x \"" + Directory.GetCurrentDirectory() + "\\TeamViewer\\" + TeamViewer.GetMSIPackegeName() + "\" /norestart /qn";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = false;
                    Console.WriteLine("Запуск: " + process.StartInfo.FileName + process.StartInfo.Arguments);
                    process.Start();
                    process.WaitForExit();
                    Console.WriteLine("Удаление завершено.");
                    Console.WriteLine();
                }

            }
            catch (Exception)
            {
                Console.WriteLine("что-то пошло не так :( и метод Teamviewer.Uninstall() не отработал как положено");
            }
        }

        public static void Install(string idc)
        {
            try
            {
                File.Move(Directory.GetCurrentDirectory() + "\\Teamviewer\\"+ GetMSIPackegeName(), Directory.GetCurrentDirectory() + "\\TeamViewer\\TeamViewer_Host-idc" + idc + ".msi");
            
            Console.WriteLine("Установка \"Teamviewer\".");
            Process process = new Process();
            process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\TeamViewer"; //sets the working directory in which the exe file resides.
            process.StartInfo.FileName = "msiexec.exe";
            process.StartInfo.Arguments = " /package \"" + Directory.GetCurrentDirectory() + "\\Teamviewer\\" + GetMSIPackegeName() +  "\" /norestart /qn";
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

        public static void Assign(string apitoken, string tag_company, int tag_number)
        {
            Process process = new Process();
            process.StartInfo.WorkingDirectory = string.Format(Directory.GetCurrentDirectory() + "\\TeamViewer"); //sets the working directory in which the exe file resides.
            process.StartInfo.FileName = "tv_assignement.exe";
            process.StartInfo.Arguments = string.Format("-apitoken " + apitoken + " -allowEasyAccess -devicealias " + tag_company + "-" + tag_number + " -wait \"30\" -datafile \"" + Path + "\\AssignmentData.json\" -verbose"); //Pass the number of arguments.
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = false;
            process.Start();
            process.WaitForExit();
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
            catch (Exception) { Console.WriteLine("Видимо MSI-пакета Teamviewer, в каталоге инсталятора нет"); }
            return msi_packege_name;
        }
    }
}
