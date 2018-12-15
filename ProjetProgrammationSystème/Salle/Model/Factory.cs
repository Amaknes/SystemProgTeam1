using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public abstract class Factory
    {
        public abstract IndividualClientInterface CreateIndividualClientInterface(int Taste, int Choice, bool WaiterRequest);
        public abstract ClientsInterface CreateClientsInterface(int idClients, bool Order, bool Booking, int ClientsNumber, int TimeSpend, Order newOrd);
    }
}
