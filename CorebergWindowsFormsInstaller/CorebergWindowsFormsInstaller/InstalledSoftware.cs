using Microsoft.Win32;
using System;
using System.Linq;

namespace CorebergWindowsFormsInstaller
{
    internal class InstalledSoftware
    {
        private static RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"); // Сохраняем ветку со списком ПО x32
        private static RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"); // Сохраняем ветку со списком ПО x64
        private static string[] skeys32 = key32.GetSubKeyNames(); // Сохраняем в массив названия каталогов из этой ветки реестра
        private static string[] skeys64 = key64.GetSubKeyNames(); // Сохраняем в массив названия каталогов из этой ветки реестра
        private static string[] swnames = new string[skeys32.Concat(skeys64).ToArray().Length];

        private static void MakeList()
        {
            int swnames_count = 0;
            string name;
            RegistryKey appKey;
            for (int i = 0; i < skeys32.Length; i++)
            {
                appKey = key32.OpenSubKey(skeys32[i]);

                try
                {
                    name = appKey.GetValue("DisplayName").ToString();
                    swnames[swnames_count] = name;
                    swnames_count++;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            for (int i = 0; i < skeys64.Length; i++)
            {
                appKey = key64.OpenSubKey(skeys64[i]);
                try
                {
                    name = appKey.GetValue("DisplayName").ToString();

                    swnames[swnames_count] = name;
                    swnames_count++;
                }
                catch (Exception)
                {
                    continue;
                }
                //appKey.Close();
            }
            //key64.Close();
            swnames = swnames.Where(n => !string.IsNullOrEmpty(n)).ToArray();
            Array.Sort(swnames);
        }

        static public void Show()
        {
            MakeList();
            for (int i = 0; i < swnames.Length; i++)
            { Console.WriteLine("{0}. {1}", i + 1, swnames[i]); }
        }

        static public void Show(string str)
        {
            MakeList();
            Console.WriteLine("Список установленных программ, содержаших в соем названии: {0}", str);
            Console.WriteLine();
            for (int i = 0; i < swnames.Length; i++)
            {
                if (swnames[i].ToLower().Contains(str.ToLower()))
                    Console.WriteLine("{0}. {1}", i + 1, swnames[i]);
            }
            Console.WriteLine();
        }

        static public bool NameContain(string contain)
        {
            MakeList();
            bool flag = false;
            for (int i = 0; i < swnames.Length; i++)
            {
                if (swnames[i].ToLower().Contains(contain.ToLower()))
                {
                    flag = true;
                }
            }
            return flag;
        }

        static public bool NameContain(string contain, string not_contain)
        {
            MakeList();
            bool flag = false;
            for (int i = 0; i < swnames.Length; i++)
            {
                if ((swnames[i].ToLower().Contains(contain.ToLower())) && !(swnames[i].ToLower().Contains(not_contain.ToLower())))
                {
                    flag = true;
                }
            }
            return flag;
        }

        static public bool NameContain2(string contain1, string contain2)
        {
            MakeList();
            bool flag = false;
            for (int i = 0; i < swnames.Length; i++)
            {
                if ((swnames[i].ToLower().Contains(contain1.ToLower())) && (swnames[i].ToLower().Contains(contain2.ToLower())))
                {
                    flag = true;
                }
            }
            return flag;
        }

        static public string GetNameContain(string contain, string not_contain)
        {
            string name = $"Not found in installed software, with \"{contain}\" and without \"{not_contain}\" in name";
            for (int i = 0; i < swnames.Length; i++)
            {
                if ((swnames[i].ToLower().Contains(contain.ToLower())) && (!swnames[i].ToLower().Contains(not_contain.ToLower())))
                {
                    name = swnames[i];
                    break;
                }
            }
            return name;
        }

        static public string GetNameContain2(string contain1, string contain2)
        {
            string name = $"Not found in installed software, with \"{contain1}\" and with \"{contain2}\" in name";
            for (int i = 0; i < swnames.Length; i++)
            {
                if ((swnames[i].ToLower().Contains(contain1.ToLower())) && (swnames[i].ToLower().Contains(contain2.ToLower())))
                {
                    name = swnames[i];
                    break;
                }
            }
            return name;
        }

        static public bool NameEquals(string str1)
        {
            MakeList();
            bool flag = false;
            for (int i = 0; i < swnames.Length; i++)
            {
                if (swnames[i].ToLower() == str1.ToLower())
                {
                    Console.WriteLine("программа с точным названием \"{0}\" найдена", str1);
                    flag = true;
                }
            }
            if (!flag) Console.WriteLine("программа с точным названием \"{0}\" НЕ найдена", str1);
            return flag;
        }
    }
}