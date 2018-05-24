using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Terminal_Sessions_Logger
{
    internal class RDPConnectivity
    {
        public bool TestConnection(string server)
        {
            bool result;
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, 3389);
                if(client.Connected)
                {
                    client.Close();
                    result = true;                    
                }
                else
                {
                    client.Close();
                    result = false;
                }
                                
            }
            catch(Exception Ex)
            {
                throw Ex;
            }

            return result;
        }
    }
}
