using System.IO;

namespace CorebergWindowsFormsInstaller
{
    class Clients
    {
        static string[] clients;
        static public string[] GetList
        {
            get
            {
                string[] clients_params = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Teamviewer\\clients.txt");
                clients = new string[clients_params.Length];
                for (int i = 0; i < clients_params.Length; i++)
                {
                    clients[i] = clients_params[i].Split(';')[0];
                }
                return clients;
            }
        }
    }
}
