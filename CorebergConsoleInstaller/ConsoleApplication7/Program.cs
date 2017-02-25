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

            TeamViewer.DisplayInfo();
            TeamViewer.Uninstall();
            TeamViewer.DisplayInfo();
            Console.WriteLine(" press any key...");
            Console.ReadKey();
            Console.WriteLine();

            TeamViewer.Install(idc);
            TeamViewer.DisplayInfo();
            Console.WriteLine(" press any key...");
            Console.ReadKey();
            Console.WriteLine();

            TeamViewer.Uninstall();
            TeamViewer.DisplayInfo();
            Console.WriteLine(" press any key...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}