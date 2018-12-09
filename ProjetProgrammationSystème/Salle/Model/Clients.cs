using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Controller;

namespace Salle.Model
{
    public class Clients : ClientsInterface
    {
        private int _IdClients;
        public int IdClients
        {
            get => this._IdClients;
            set
            {
                if (value >= 0)
                {
                    this._IdClients = value;
                }
            }
        }

        private bool _Order;
        public bool Order
        {
            get => this._Order;
            set => this._Order = value;
        }

        private bool _Booking;
        public bool Booking
        {
            get => this._Booking;
            set => this._Booking = value;
        }

        private int _ClientsNumber;
        public int ClientsNumber
        {
            get => this._ClientsNumber;
            set
            {
                if (value >= 0)
                {
                    this._ClientsNumber = value;
                }
            }
        }

        private List<IndividualClientInterface> _ClientsList;
        public List<IndividualClientInterface> ClientsList
        {
            get => this._ClientsList;
            set => this._ClientsList = value;
        }

        private int _Bill;
        public int Bill {
            get => this._Bill;
            set
            {
                if (value >= 0)
                {
                    this._Bill = value;
                }
            }
        }




        public Clients(int IdClients, bool Order, bool Booking, int ClientsNumber)
        {

            Console.WriteLine(IdClients);

            this.IdClients = IdClients;
            this.Order = Order;
            this.Booking = Booking;
            this.ClientsNumber = ClientsNumber;

            this.ClientsList = new List<IndividualClientInterface>();

            Random rnd = new Random();
            bool WaiterRequest;

            for (int i = 0; i < ClientsNumber; i++)
            {
                if(rnd.Next(2) == 0)
                {
                    WaiterRequest = false;
                }
                else
                {
                    WaiterRequest = true;
                }

                this.ClientsList.Add(new FactoryClients().CreateIndividualClientInterface(rnd.Next(5), rnd.Next(30,121), rnd.Next(5), WaiterRequest));
            }
            //temporaire
        }




        public void AlertCommisWaiter()
        {
            throw new NotImplementedException();
        }

        public int[] ChoiceOrder()
        {
            throw new NotImplementedException();
        }

        public int Payment()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }
    }
}
