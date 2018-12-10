using Salle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Salle.Sockets
{
    public class OrderDesk: InterfaceOrderDesk
    {
        private static OrderDesk OrderDeskInstance;
        private Thread _thEcoute;
       

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
            bool continuer = true;

            while (continuer)
            {
                Console.Write("\nEntrez un message : ");
                string message = Console.ReadLine();

                //Sérialisation du message en tableau de bytes.
                byte[] msg = Encoding.Default.GetBytes(message);

                UdpClient udpClient = new UdpClient();

                //La méthode Send envoie un message UDP.
                udpClient.Send(msg, msg.Length, "127.0.0.1", 5035);

                udpClient.Close();

                Console.Write("\nContinuer ? (O/N)");
                continuer = (Console.ReadKey().Key == ConsoleKey.O);
            }
        }


        
    }
}

        
        /*public void SendData(OrderInterface ord)
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
        }*/  
