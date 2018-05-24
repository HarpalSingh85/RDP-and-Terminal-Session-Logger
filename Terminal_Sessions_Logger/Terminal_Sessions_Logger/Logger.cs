using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Terminal_Sessions_Logger
{
    internal class Logger
    {
        public static void log(List<string> servers, string path)
        {
            RDPConnectivity rdpconn = new RDPConnectivity();

            if (File.Exists(path))
            {
                StringBuilder builder = new StringBuilder();
                
                using (StreamReader reader = new StreamReader(path))
                {                    
                    builder.Append(reader.ReadToEnd());
                    reader.Close();
                }

                foreach (var item in servers)
                {
                    try
                    {
                        if (rdpconn.TestConnection(item.Substring(3)))
                        {                                                 


                            var task = Task.Factory.StartNew(() => {
                                var results = RDPSessionExtractor.ListUsers(item.Substring(3));
                                return results;
                            });
                            if (task.Wait(TimeSpan.FromSeconds(60))) { }
                             else  continue;


                            Console.WriteLine($"Succeeded on : {item}");
                            foreach (var result in task.Result)
                            {
                                // Test Display
                                // Console.WriteLine($"{result.UserID} {result.SessionID} {result.ClientName}");

                                var contents = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"",
                                                result.Server,
                                                result.UserID,
                                                result.SessionID,
                                                result.ClientName,
                                                result.CurrentHour
                                                );
                                builder.AppendLine(contents);

                            }
                        }
                        else
                        {
                            Console.WriteLine($"Failed on : {item}");
                        }


                        //TEST Data Simulation
                        //var results = RDPSessionExtractor.ListUsers(item);

                        //Console.WriteLine(item);




                        using (StreamWriter writer = new StreamWriter(path))
                        {
                            writer.WriteLine(builder.ToString());
                            writer.Flush();
                            
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed on : {item}");
                        continue;
                        throw ex;
                    }
                }

            }
                   
                    
            else
            {
                StringBuilder builder = new StringBuilder();
                var header = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"",
                                        "Server Name",
                                        "User ID",
                                        "Session ID",
                                        "Client Name",
                                        "Hour"
                                        );
                builder.AppendLine(header);
                foreach (var item in servers)
                {                    
                    
                    try
                    {
                        if (rdpconn.TestConnection(item.Substring(3)))
                        {
                            var task = Task.Factory.StartNew(() => {
                                var results = RDPSessionExtractor.ListUsers(item.Substring(3));
                                return results;
                            });
                            if (task.Wait(TimeSpan.FromSeconds(60))) { }
                            else continue;
                            Console.WriteLine($"Succeeded on : {item}");
                            foreach (var result in task.Result)
                            {
                                // Test Display
                                // Console.WriteLine($"{result.UserID} {result.SessionID} {result.ClientName}");

                                var contents = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"",
                                                result.Server,
                                                result.UserID,
                                                result.SessionID,
                                                result.ClientName,
                                                result.CurrentHour
                                                );
                                builder.AppendLine(contents);

                            }
                        }
                        else
                        {
                            Console.WriteLine($"Failed on : {item}");
                        }
                                           
                        //TEST Data Simulation
                        //var results = RDPSessionExtractor.ListUsers(item);                      

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed on : {item}");
                        continue;
                        throw ex;
                    }

                }

                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(builder.ToString().TrimEnd('\r', '\n'));
                    writer.Flush();
                }
            }

        }

    }
}
                      











              



                                         

                

         
