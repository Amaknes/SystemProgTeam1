using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Salle.Model;
using Salle.Controller;
using Salle.Sockets;

namespace Salle
{
    class Program
    {
        static private MaîtreHôtel MHotel;

        static void Main(string[] args)
        {
            HallInterface salle = Hall.hallInstance();
            MHotel = MaîtreHôtel.maîtreHôtelInstance();
            
            CutleryDesk.cutleryDeskInstance();
            OrderDesk.orderDeskInstance();

            ThreadStart jobArriverClient = new ThreadStart(ArriverClient);
            Thread threadClient = new Thread(jobArriverClient);
            threadClient.Start();

            ThreadStart jobAccueilMaitreHotel = new ThreadStart(AccueilMaitreHotel);
            Thread threadAccueilMaitreHotel = new Thread(jobAccueilMaitreHotel);
            threadAccueilMaitreHotel.Start();


            Console.Read();
        }

        static void ArriverClient()
        {
            Random rnd = new Random();
            int IdClients = 0;
            bool Order;
            bool Book;

            //while (true) {

            FactoryClients factClients = new FactoryClients();

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

            //MHotel.ListClients.Add(factClients.CreateClientsInterface(IdClients, Order, Book, rnd.Next(1, 11), 30));

            MHotel.ListClients.Add(factClients.CreateClientsInterface(IdClients, Order, Book, 10, 30));
            //MHotel.ListClients.Add(factClients.CreateClientsInterface(IdClients, Order, Book, rnd.Next(1, 11), 60));

            Thread.Sleep(1500);
               IdClients++;
            //}
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
