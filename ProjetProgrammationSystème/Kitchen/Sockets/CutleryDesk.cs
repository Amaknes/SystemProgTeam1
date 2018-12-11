using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kitchen.Controller;

namespace Kitchen.Sockets
{
    class CutleryDesk : InterfaceCutleryDesk
    {
        private Thread _thEcoute;
        private static CutleryDesk CutleryDeskInstance;
        private DishWasherInterface DWasher;

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
            this.DWasher = new DishWasher();

            _thEcoute = new Thread(new ThreadStart(EcouterCutleryDesk));
            _thEcoute.Start();
        }

        public void EcouterCutleryDesk()
        {
            Console.WriteLine("Préparation à l'écoute...");

            //On crée le serveur en lui spécifiant le port sur lequel il devra écouter.
            UdpClient serveur = new UdpClient(5038);

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



                DWasher.GetCutlery(message);

            }

        }

        public void SendDataCutleryDesk()
        {
        }
    }
}
