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
    class CutleryDesk : InterfaceCutleryDesk
    {
        private Thread _thEcoute;
        private static CutleryDesk CutleryDeskInstance;
        private Affichage afficher;

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

        private int _cutlery;
        public int cutlery
        {
            get => this._cutlery;
            set => this._cutlery = value;
        }

        private int _nappes;
        public int nappes
        {
            get => this._nappes;
            set => this._nappes = value;
        }




        public static CutleryDesk cutleryDeskInstance()
        {
            if (CutleryDeskInstance == null)
            {
                CutleryDeskInstance = new CutleryDesk();
            }
            return CutleryDeskInstance;
        }


        private CutleryDesk()
        {
            afficher = new Affichage();
            _thEcoute = new Thread(new ThreadStart(EcouterCutleryDesk));
            _thEcoute.Start();
            this.cutlery = 0;
        }

        public void EcouterCutleryDesk()
        {
            afficher.afficherLine("Préparation à l'écoute...");

            //On crée le serveur en lui spécifiant le port sur lequel il devra écouter.
            UdpClient serveur = new UdpClient(5037);

            //Création d'une boucle infinie qui aura pour tâche d'écouter.
            while (true)
            {
                //Création d'un objet IPEndPoint qui recevra les données du Socket distant.
                IPEndPoint client = null;
                afficher.afficherLine("ÉCOUTE...");

                //On écoute jusqu'à recevoir un message.
                byte[] data = serveur.Receive(ref client);
                afficher.afficherLine("Données reçues en provenance de "+ client.Address+":"+ client.Port+".");

                //Décryptage et affichage du message.
                string message = Encoding.Default.GetString(data);
                ReceptMessage(message);
                
            }

        }

        public void ReceptMessage(string message)
        {
            String[] MArriver = Regex.Split(message, ":");
            String[] IdsTables = Regex.Split(MArriver[1], @"\D+");

            if (Int32.Parse(MArriver[0]) == 0)
            {
                afficher.afficherLine("CONTENU DU MESSAGE : "+ MArriver[1]+" Couverts ont été rangé\n");
                this.cutlery += Int32.Parse(IdsTables[0] + IdsTables[1]);
            }
            else
            {
                afficher.afficherLine("CONTENU DU MESSAGE : "+ MArriver[1]+" Nappes ont été rangé\n");
                this.nappes += Int32.Parse(IdsTables[0] + IdsTables[1]);
            }
        }

        public void SendDataCutleryDesk(int data)
        {
            try
            {
                // Sending message 
                //<Client Quit> is the sign for end of data 
                string theMessageToSend = ""+data;

                afficher.afficherLine("Message "+ theMessageToSend);

                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend);

                UdpClient udpClient = new UdpClient();
                udpClient.Send(msg, msg.Length, "127.0.0.1", 5038);
                // udpClient.Send(msg, msg.Length, "10.144.50.44", 5038); 
                udpClient.Close();

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

        public void getCutlery(int nbCutlery)
        {
            if(cutlery >= nbCutlery)
            {
                cutlery -= nbCutlery;
            }
        }
    }
}
