using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Socket
{
    class SocketCuisine
    {
        public System.Net.Sockets.Socket GetConnection(string server, int port)
        {
            System.Net.Sockets.Socket s = null;
            IPHostEntry hostEntry = null;

            hostEntry = Dns.GetHostEntry(server);

            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                System.Net.Sockets.Socket tempSocket =
                    new System.Net.Sockets.Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return s;
        }

    }
}
