using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public class FactoryClients : Factory
    {
        public override ClientsInterface CreateClientsInterface(int idClients, bool Order, bool Booking, int ClientsNumber)
        {
            return (ClientsInterface)new Clients(idClients, Order, Booking, ClientsNumber);
        }

        public override IndividualClientInterface CreateIndividualClientInterface(int Taste, int TimeSpend, int Choice, bool WaiterRequest)
        {
            return (IndividualClientInterface) new IndividualClient(Taste, TimeSpend, Choice, WaiterRequest);
        }
    }
}
