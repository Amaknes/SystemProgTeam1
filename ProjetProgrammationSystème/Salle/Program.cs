using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Salle.Model;
using Salle.Controller;
using Salle.Sockets;
using Salle.View;
using System.Data;
using Kitchen.Model;

namespace Salle
{
    class Program
    {
        static private MaîtreHôtel MHotel;

        public static Affichage afficher;

        static void Main(string[] args)
        {
            afficher = new Affichage();

            HallInterface salle = Hall.hallInstance();
            MHotel = MaîtreHôtel.maîtreHôtelInstance();

            CutleryDesk.cutleryDeskInstance();
            OrderDesk.orderDeskInstance();


            string rep = Console.ReadLine();


            Thread threadClient = new Thread(() => ArriverClient(rep));
            new Pause().AddThread(threadClient);
            threadClient.Start();


            Thread threadAccueilMaitreHotel = new Thread(() => AccueilMaitreHotel());
            new Pause().AddThread(threadAccueilMaitreHotel);
            threadAccueilMaitreHotel.Start();

            while (true)
            {
                char key = Console.ReadKey().KeyChar;
                if (key.Equals('w'))
                {
                    new Pause().PauseThreads();
                }
                else if (key.Equals('x'))
                {
                    new Pause().Resume();
                }
            }
        }

        static void ArriverClient(string str)
        {
            Random rnd = new Random();
            int IdClients = 0;
            bool Order;
            bool Book;

            if (str.Equals("non") || str.Equals(""))
            {
                FactoryClients factClients = new FactoryClients();
                afficher.afficherLine("Scénario aléatoire");
                //while (true) {

                if (rnd.Next(2) == 0)
                {
                    Book = true;
                }
                else
                {
                    Book = false;
                }

                if (rnd.Next(2) == 0)
                {
                    Order = true;
                }
                else
                {
                    Order = false;
                }


                //Création random de clients 

                //MHotel.ListClients.Add(factClients.CreateClientsInterface(IdClients, Order, Book, rnd.Next(1, 11), 30, null));

                //MHotel.ListClients.Add(factClients.CreateClientsInterface(IdClients, Order, Book, 5, 120,null));
                MHotel.ListClients.Add(factClients.CreateClientsInterface(IdClients, Order, Book, rnd.Next(1, 11), 60, null));

                Thread.Sleep(1500);
                IdClients++;
                //}
            }
            else if (str.Equals("1"))
            {
                afficher.afficherLine("Scénario n°1");
                CreateClientFromDataBase(1);
            }
            else if (str.Equals("2"))
            {
                afficher.afficherLine("Scénario n°2");
                CreateClientFromDataBase(2);
            }

        }

        static void CreateClientFromDataBase(int id)
        {
            FactoryClients factClients = new FactoryClients();
            CLprocessus process = new CLprocessus();

            //Récupération des Clients possédant le même id que le scénario
            DataSet setDataClients = process.GetListClients("Projet_Syst", id);
            //DataSet setDataCommandes = process.GetListCommand("Projet_Syst", 0);

            int IDBooking = 0;
            int NbrBookers = 0;
            int Time = 0;




            List<int> ListIdClient = new List<int>();

            foreach (DataRow drCl in setDataClients.Tables[0].Rows)
            {
                if (!ListIdClient.Contains(Int32.Parse(drCl["IDBooking"].ToString())))
                {
                    ListIdClient.Add(Int32.Parse(drCl["IDBooking"].ToString()));
                }
            }
             
            foreach (int idClient in ListIdClient)
            {
                List<int> ListIdEntries = new List<int>();
                List<int> ListIdPlats = new List<int>();
                List<int> ListIdDesserts = new List<int>();

                foreach (DataRow drCl in setDataClients.Tables[0].Rows)
                {
                    //if (CurrentIdBook != Int32.Parse(drCl["IDBooking"].ToString()))
                    //{

                    if (idClient == Int32.Parse(drCl["IDBooking"].ToString()))
                    {
                        IDBooking = Int32.Parse(drCl["IDBooking"].ToString());
                        NbrBookers = Int32.Parse(drCl["NbrBooker"].ToString());
                        Time = Int32.Parse(drCl["Time"].ToString());

                        //Récupération des commandes d'un groupe de client
                        //TypeBook, idBook, number

                        int TypeBook = 0;
                        int IDBook = 0;
                        int Number = 0;
                        TypeBook = Int32.Parse(drCl["TypeBook"].ToString());
                        IDBook = Int32.Parse(drCl["IDBook"].ToString());
                        Number = Int32.Parse(drCl["Number"].ToString());

                        for (int i = 0; i < Number; i++)
                        {
                            switch (TypeBook)
                            {
                                case 0:
                                    ListIdEntries.Add(IDBook);
                                    break;
                                case 1:
                                    ListIdPlats.Add(IDBook);
                                    break;
                                case 2:
                                    ListIdDesserts.Add(IDBook);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }



                Order newOrd = new Order(ListIdEntries, ListIdPlats, ListIdDesserts);

                Console.WriteLine("Nombre de Clients du Scénario n°"+id+" du groupe "+ idClient + " : " + NbrBookers);
                //Implémentation dans la salle
                MHotel.ListClients.Add(factClients.CreateClientsInterface(IDBooking, false, false, NbrBookers, Time, newOrd));
                Thread.Sleep(30000); 
            }
        }

        static void AccueilMaitreHotel()
        {
            while (true)
            {
                //maitre d hotel a intervalle réguilier
                MHotel.ClientsReception();

                Thread.Sleep(1000);
            }
        }

    }
}
