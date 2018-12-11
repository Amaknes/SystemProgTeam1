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
    public class OrderDesk : InterfaceOrderDesk
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
        public Socket s
        {
            get => this._s;
            set => this._s = value;
        }


        public static OrderDesk orderDeskInstance()
        {
            if (OrderDeskInstance == null)
            {
                OrderDeskInstance = new OrderDesk();
            }
            return OrderDeskInstance;
        }

        private OrderDesk()
        {
            _thEcoute = new Thread(new ThreadStart(Ecouter));
            _thEcoute.Start();
        }



        private void Ecouter()
        {
            Console.WriteLine("Préparation à l'écoute...");

            //On crée le serveur en lui spécifiant le port sur lequel il devra écouter.
            UdpClient serveur = new UdpClient(5035);

            //Création d'une boucle infinie qui aura pour tâche d'écouter.
            while (true)
            {
                //Création d'un objet IPEndPoint qui recevra les données du Socket distant.
                IPEndPoint client = null;
                Console.WriteLine("ÉCOUTE...");

                //On écoute jusqu'à recevoir un message.
                byte[] data = serveur.Receive(ref client);
                Console.WriteLine("Données reçues en provenance de {0}:{1}.", client.Address, client.Port);

                //Décryptage et affichage du message.
                string message = Encoding.Default.GetString(data);
                Console.WriteLine("CONTENU DU MESSAGE : {0}\n", message);
            }

        }

        public void SendData(OrderInterface ord)
        {
            try
            {
                // Sending message 
                //<Client Quit> is the sign for end of data 
                string theMessageToSend = ord.IdTable + ":";

                for(int i = 0; i < ord.ListEntries.Count;i++)
                {
                    if(i != 0)
                    {
                        theMessageToSend += ",";
                    }
                    theMessageToSend += ord.ListEntries[i];
                }

                theMessageToSend += ":";
                for (int i = 0; i < ord.ListPlats.Count;i++)
                {
                    if (i != 0)
                    {
                        theMessageToSend += ",";
                    }
                    theMessageToSend += ord.ListPlats[i];
                }

                theMessageToSend += ":";
                for (int i = 0; i < ord.ListDesserts.Count; i++)
                {
                    if (i != 0)
                    {
                        theMessageToSend += ",";
                    }
                    theMessageToSend += ord.ListDesserts[i];
                }

                Console.WriteLine("Message  {0} ", theMessageToSend);

                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend);

                UdpClient udpClient = new UdpClient();
                udpClient.Send(msg, msg.Length, "127.0.0.1", 5036);
               // udpClient.Send(msg, msg.Length, "10.144.50.44", 5036); 
                udpClient.Close();

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

        }
    }
}
