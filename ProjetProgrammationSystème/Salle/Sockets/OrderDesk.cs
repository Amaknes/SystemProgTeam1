﻿using Salle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Sockets
{
    public class OrderDesk: InterfaceOrderDesk
    {
        private static OrderDesk OrderDeskInstance;

        private byte[] _bytes;
        public byte[] bytes
        {
            get => this._bytes;
            set => this._bytes = value;
        }


        private Socket _s;
        public Socket s {
            get => this._s;
            set => this._s = value;
        }


        public static OrderDesk orderDeskInstance()
        {
            if(OrderDeskInstance == null)
            {
                OrderDeskInstance = new OrderDesk();
            }
            return OrderDeskInstance;
        }

        private OrderDesk()
        {

            bytes = new byte[1024];
            try
            {
                SocketPermission permission = new SocketPermission(NetworkAccess.Accept, TransportType.Tcp, "", SocketPermission.AllPorts);

                permission.Demand();
                IPHostEntry ipHost = Dns.GetHostEntry("");
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 4510);

                this.s = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                s.NoDelay = false;
                s.Connect(ipEndPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }




        
        public void SendData(OrderInterface ord)
        {
            try
            {
                // Sending message 
                //<Client Quit> is the sign for end of data 
                string theMessageToSend = ord.IdTable + ":";
                foreach (int idEntry in ord.ListEntries)
                {
                    theMessageToSend += " " + idEntry;
                }
                theMessageToSend += ":";
                foreach (int idPlat in ord.ListPlats)
                {
                    theMessageToSend += " " + idPlat;
                }
                theMessageToSend += ":";
                foreach (int idDessert in ord.ListDesserts)
                {
                    theMessageToSend += " " + idDessert;
                }

                Console.WriteLine("Message  {0} ",theMessageToSend);

                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend + "<Client Quit>");

                // Sends data to a connected Socket. 
                int bytesSend = s.Send(msg);

                ReceiveDataFromServer();

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

        private void ReceiveDataFromServer()
        {
            try
            {
                // Receives data from a bound Socket. 
                int bytesRec = s.Receive(bytes);

                // Converts byte array to string 
                String theMessageToReceive = Encoding.Unicode.GetString(bytes, 0, bytesRec);

                // Continues to read the data till data isn't available 
                while (s.Available > 0)
                {
                    bytesRec = s.Receive(bytes);
                    theMessageToReceive += Encoding.Unicode.GetString(bytes, 0, bytesRec);
                }

                Console.WriteLine(theMessageToReceive);
                

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }
    }
}
