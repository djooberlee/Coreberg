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
            //string apitoken = "1896401-MFly66TCw962nl8qdCP4";
            //string tag_company = "Coreberg";
            //int tag_number = 200001;
            // if (InstalledSoftware.NameEquals("TeamViewer 12")) { Console.WriteLine("Ща запуститься удаляшка"); TeamViewer.Uninstall("silent"); }
            /*if (InstalledSoftware.NameEquals("TeamViewer 12"))
            {
             TeamViewer.Install(idc);
               
                TeamViewer.DisplayInfo();
            }*/
            //TeamViewer.Install(idc);
            //TeamViewer.Assign(apitoken, tag_company, tag_number);
            TeamViewer.Uninstall("silent");
            Console.ReadKey();
        }
    }
}