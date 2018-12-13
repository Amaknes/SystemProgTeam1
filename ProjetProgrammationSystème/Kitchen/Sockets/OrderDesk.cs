using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kitchen.Controller;
using Salle.View;

namespace Kitchen.Sockets
{
    class OrderDesk : InterfaceOrderDesk
    {
        private Affichage afficher;
        private Thread _thEcoute;
        private static OrderDesk OrderDeskInstance;

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
            afficher = new Affichage();
            _thEcoute = new Thread(new ThreadStart(EcouterOrderDesk));
            new Pause().AddThread(_thEcoute);
            _thEcoute.Start();
        }




        public void EcouterOrderDesk()
        {
            afficher.afficherLine("Préparation à l'écoute...");

            //On crée le serveur en lui spécifiant le port sur lequel il devra écouter.
            UdpClient serveur = new UdpClient(5036);

            //Création d'une boucle infinie qui aura pour tâche d'écouter.
            while (true)
            {
                //Création d'un objet IPEndPoint qui recevra les données du Socket distant.
                IPEndPoint client = null;
                afficher.afficherLine("ÉCOUTE...");

                //On écoute jusqu'à recevoir un message.
                byte[] data = serveur.Receive(ref client);
                afficher.afficherLine("Données reçues en provenance de "+client.Address+":"+client.Port+".");

                //Décryptage et affichage du message.
                string message = Encoding.Default.GetString(data);
                afficher.afficherLine("CONTENU DU MESSAGE : "+message+"\n");

                Chef.chefInstance().GetOrder(message);
            }
        }

        public void SendDataOrderDesk(int idTable, int IdDish, int Dish, int NbDishesList)
        {
            try
            {
                // Sending message 
                //<Client Quit> is the sign for end of data 
                string theMessageToSend = idTable + ":" + IdDish + ":" + Dish + ":" + NbDishesList;

                afficher.afficherLine("Message  "+theMessageToSend);

                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend);

                UdpClient udpClient = new UdpClient();
                udpClient.Send(msg, msg.Length, "127.0.0.1", 5035);
                // udpClient.Send(msg, msg.Length, "10.144.50.44", 5035); 
                udpClient.Close();

            }
            catch (Exception exc)
            {
                afficher.afficherLine(""+exc);
            }
        }
    }
        
}