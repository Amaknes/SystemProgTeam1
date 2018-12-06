using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    class Clients : ClientsInterface
    {
        private int _IdClients;
        public int IdClients
        {
            get => this._IdClients;
            set => this._IdClients = value;
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
            set => this._ClientsNumber = value;
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
            set => this._Bill = value;
        }


        public Clients()
        {
            this.ClientsList.Add(new FactoryClients().CreateClientInterface());
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

        public void HelloMaîtreHôtel(ClientsInterface Clients)
        {
            throw new NotImplementedException();
        }

        public int Payment()
        {
            throw new NotImplementedException();
        }
    }
}
