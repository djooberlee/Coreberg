using System;
using System.IO;
using System.Diagnostics;


namespace OCSInventoryAgentRemover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Process process = new Process();
                if (File.Exists("C:\\Program files\\OCS Inventory Agent\\uninst.exe"))
                {
                    process.StartInfo.FileName = "C:\\Program files\\OCS Inventory Agent\\uninst.exe";
                    process.StartInfo.Arguments = " /S";
                    //process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.WaitForExit();
                }
                else
                {
                    process.StartInfo.FileName = "C:\\Program Files (x86)\\OCS Inventory Agent\\uninst.exe";
                    process.StartInfo.Arguments = " /S";
                    //process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.WaitForExit();
                }
            }
            catch (Exception) { }
        }
    }
}
