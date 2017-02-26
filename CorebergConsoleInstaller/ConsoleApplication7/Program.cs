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
            string idc = "j3ybf6m";
            string apitoken = "1896401-MFly66TCw962nl8qdCP4";
            string tag_company = "Coreberg";
            int tag_number = 200001;

            if (!InstalledSoftware.NameContain("OCS Inventory"))  OCS.Install(tag_company, tag_number); 
            
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Teamviewer\\"))
            {
                Console.WriteLine("в инсталяторе не найден каталог Teamviwer");
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
                TeamViewer.Install(tag_company, idc);
                if (InstalledSoftware.NameContain("Teamviewer"))
                    TeamViewer.Assign(apitoken, tag_company, tag_number);
                TeamViewer.DisplayInfo();
                Console.WriteLine(" press any key...");
                Console.ReadKey();
                Console.WriteLine();
            }
            else
            {
                TeamViewer.Install(tag_company, idc);
                if (InstalledSoftware.NameContain("Teamviewer"))
                    TeamViewer.Assign(apitoken, tag_company, tag_number);
                TeamViewer.DisplayInfo();
                Console.WriteLine(" press any key...");
                Console.ReadKey();
                Console.WriteLine();
            }
        }
    }
}