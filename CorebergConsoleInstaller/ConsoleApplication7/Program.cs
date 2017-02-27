using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CorebergConsoleInstaller
{
    class Program
    {
        static void Main(string[] args)
        {

            string tag_company = "Coreberg";
            int tag_number = 200001;
            
            if (!InstalledSoftware.NameContain("OCS Inventory"))  OCS.Install(tag_company, tag_number); // Ставим OCS если он не установлен
            
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Teamviewer\\")) //проверяем наличие 
            {
                Console.WriteLine("в инсталяторе не найден каталог Teamviwer");
                Console.WriteLine();
                Console.WriteLine(" press any key...");
                Console.ReadKey();
                return;
            }
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\OCSi\\"))
            {
                Console.WriteLine("в инсталяторе не найден каталог OCSi");
                Console.WriteLine();
                Console.WriteLine(" press any key...");
                Console.ReadKey();
                return;
            }
            if (InstalledSoftware.NameContain("Teamviewer"))
            {
                TeamViewer.DisplayInfo();
                TeamViewer.Uninstall();
                Console.WriteLine(" press any key...");
                Console.ReadKey();
                Console.WriteLine();
                TeamViewer.Install(tag_company, tag_number);
                TeamViewer.DisplayInfo();
                Console.WriteLine(" press any key...");
                Console.ReadKey();
                Console.WriteLine();
            }
            else
            {
                TeamViewer.Install(tag_company, tag_number);

                TeamViewer.DisplayInfo();
                Console.WriteLine(" press any key...");
                Console.ReadKey();
                Console.WriteLine();
            }
        }
    }
}