using Salle.Controller;
using Salle.Model;
using Salle.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Salle.Sockets
{
    public class OrderDesk : InterfaceOrderDesk
    {
        private static OrderDesk OrderDeskInstance;
        private Thread _thEcoute;
        private Affichage afficher;

        private int _nbDishesWaiting;
        public int nbDishesWaiting
        {
            get => this._nbDishesWaiting;
            set
            {
                if (value >= 0)
                {
                    this._nbDishesWaiting = value;
                }
            }
        }
        private byte[] _bytes;
        public byte[] bytes
        {
            get => this._bytes;
            set => this._bytes = value;
        }

        private List<OrderInterface> _listOrders;
        public List<OrderInterface> listOrders
        {
            get => this._listOrders;
            set => this._listOrders = value;
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
            afficher = new Affichage();
            this.listOrders = new List<OrderInterface>();
            _thEcoute = new Thread(new ThreadStart(EcouterOrderDesk));
            new Pause().AddThread(_thEcoute);
            _thEcoute.Start();
        }



        public void EcouterOrderDesk()
        { 

            //On crée le serveur en lui spécifiant le port sur lequel il devra écouter.
            UdpClient serveur = new UdpClient(5035);

            //Création d'une boucle infinie qui aura pour tâche d'écouter.
            while (true)
            {
                //Création d'un objet IPEndPoint qui recevra les données du Socket distant.
                IPEndPoint client = null;
                afficher.afficherLine("OrderDesk's Socket Listening....");

                //On écoute jusqu'à recevoir un message.
                byte[] data = serveur.Receive(ref client);
                //afficher.afficherLine("Données reçues en provenance de " + client.Address + ":" + client.Port + ".");
                afficher.afficherLine("Dishes received from the Commis Chef");

                //Décryptage et affichage du message.
                string message = Encoding.Default.GetString(data);
                //récupère une préparation avec l'id de la table : id de la préparation : id entree/plat/dessert : nb de plats actuels
                afficher.afficherLine("Dish " + message + " is now waiting on the OrderDesk\n");

                ReceptMessage(message);

            }

        }

        public void ReceptMessage(string message)
        {
            String[] listMessage = Regex.Split(message, ":");
            String[] IdTables = Regex.Split(listMessage[0], @"\D+");
            int idTable = Int32.Parse(IdTables[0] + IdTables[1]);

            Clients leClient = (Clients)Hall.hallInstance().FindTableById(idTable).Clients;
            int i = 0;
            bool idFound = false;

            while (i < listOrders.Count && !idFound)
            {
                if (listOrders[i].IdTable == idTable)
                {
                    idFound = true;
                }
                else
                {
                    i++;
                }
            }

            if (!idFound)
            {
                i = listOrders.Count;
                listOrders.Add(new Order(idTable));
            }



            String[] IdPreparation = Regex.Split(listMessage[2], @"\D+");
            int Preparation = Int32.Parse(IdPreparation[0] + IdPreparation[1]);

            String[] IdEntreePlatDessert = Regex.Split(listMessage[2], @"\D+");
            int EntreePlatDessert = Int32.Parse(IdEntreePlatDessert[0] + IdEntreePlatDessert[1]);

            String[] NbPlatsStr = Regex.Split(listMessage[3], @"\D+");
            int NbPlats = Int32.Parse(NbPlatsStr[0] + NbPlatsStr[1]);


            if (EntreePlatDessert == 1)
            {
                listOrders[i].ListEntries.Add(Preparation);
                if (this.nbDishesWaiting + 1 <= 15)
                {
                    this.nbDishesWaiting += 1;
                }
                else
                {
                    throw new Exception();
                }
            }
            else if (EntreePlatDessert == 2)
            {
                listOrders[i].ListPlats.Add(Preparation);
                if (this.nbDishesWaiting + 1 <= 15)
                {
                    this.nbDishesWaiting += 1;
                }
                else
                {
                    throw new Exception();
                }
            }
            else if (EntreePlatDessert == 3)
            {

                listOrders[i].ListDesserts.Add(Preparation);
                if (this.nbDishesWaiting + 1 <= 15)
                {
                    this.nbDishesWaiting += 1;
                }
                else
                {
                    throw new Exception();
                }

            }

            afficher.afficherLine("---------------");
            afficher.afficherLine("Current number of entries available in the Client's order : " + listOrders[i].ListEntries.Count);
            afficher.afficherLine("Current number of Main dishes available in the Client's order : " + listOrders[i].ListPlats.Count);
            afficher.afficherLine("Current number of Desserts available in the Client's order : " + listOrders[i].ListDesserts.Count);
            afficher.afficherLine("---------------\n");
            //if(leClient.CurrentDishe != 0)
            //{

            if (leClient.CurrentDishe == 0)
            {
                if (listOrders[i].ListEntries.Count == NbPlats)
                {
                    //alertWaiter recup entries
                    this.nbDishesWaiting -= listOrders[i].ListEntries.Count;
                    Hall.hallInstance().FindSquareByTableId(idTable).GetFreeWaiter().Serve(idTable, 1);
                }
            }
            else if (leClient.CurrentDishe == 1)
            {
                if (listOrders[i].ListPlats.Count == NbPlats)
                {
                    //alertWaiter recup plats
                    this.nbDishesWaiting -= listOrders[i].ListPlats.Count;
                    Hall.hallInstance().FindSquareByTableId(idTable).GetFreeWaiter().Serve(idTable, 2);
                }
            }
            else if (leClient.CurrentDishe == 2)
            {
                if (listOrders[i].ListDesserts.Count == NbPlats)
                {
                    //alertWaiter recup Desserts
                    this.nbDishesWaiting -= listOrders[i].ListDesserts.Count;
                    Hall.hallInstance().FindSquareByTableId(idTable).GetFreeWaiter().Serve(idTable, 3);
                }
            }

            //}
        }

        public void verifCommands(int IdTable, Clients leClient)
        {
            int i = 0;
            bool idFound = false;

            while (i < listOrders.Count && !idFound)
            {
                if (listOrders[i].IdTable == IdTable)
                {
                    idFound = true;
                }
                else
                {
                    i++;
                }
            }

            if (idFound)
            {
                if (leClient.CurrentDishe == 2)
                {
                    if (listOrders[i].ListDesserts.Count > 0)
                    {
                        //alertWaiter recup Desserts
                        this.nbDishesWaiting -= listOrders[i].ListDesserts.Count;
                        Hall.hallInstance().FindSquareByTableId(IdTable).GetFreeWaiter().Serve(IdTable, 3);
                    }
                }
            }

        }

        public void throwDishes(int IdTable)
        {
            int i = 0;
            bool idFound = false;

            while (i < listOrders.Count && !idFound)
            {
                if (listOrders[i].IdTable == IdTable)
                {
                    idFound = true;
                }
                else
                {
                    i++;
                }
            }
            if (idFound)
            {
                listOrders.RemoveAt(i);
            }
        }

        public void SendData(OrderInterface ord)
        {
            try
            {
                // Sending message 
                //<Client Quit> is the sign for end of data 
                string theMessageToSend = ord.IdTable + ":";

                for (int i = 0; i < ord.ListEntries.Count; i++)
                {
                    if (i != 0)
                    {
                        theMessageToSend += ",";
                    }
                    theMessageToSend += ord.ListEntries[i];
                }

                theMessageToSend += ":";
                for (int i = 0; i < ord.ListPlats.Count; i++)
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

                afficher.afficherLine("The HeadWaiter gives the order " + theMessageToSend+" to the Chef\n" );

                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend);

                UdpClient udpClient = new UdpClient();
                udpClient.Send(msg, msg.Length, "127.0.0.1", 5036);
                // udpClient.Send(msg, msg.Length, "10.144.50.44", 5036); 
                udpClient.Close();

            }
            catch (Exception exc)
            {
                afficher.afficherLine(exc.ToString());
            }

        }
    }
}
