using System;
using System.Collections.Generic;

namespace Terminal_Sessions_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Data
            //List<string> servers = new List<string>();
            //servers.Add("SVAAODCWTS135");
            //servers.Add("SVAARTWWTS175");
            //servers.Add("HPSSTEST");
                        
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(new string('*', 80));
            Console.WriteLine("\t\tTerminal and RDP Session Extractor v1.1");            
            Console.WriteLine("\t\t\tCreated by Harpal Singh");
            Console.WriteLine(new string('*', 80));

            try
            {
                ServersCollectionInitializer serv = new ServersCollectionInitializer();
                List<string> servers = serv.GetCitrixServers();

                //Test Display
                //servers.ForEach(x => Console.WriteLine(x.Substring(3)));
                string path = FileNameConstructor.GetPath();
                Logger.log(servers, path);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write(new string('*', 80));
            Console.WriteLine("END of Logging");
            Console.WriteLine(new string('*', 80));
        }
    }
}





