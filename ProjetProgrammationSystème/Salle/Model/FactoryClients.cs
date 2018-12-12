using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public class FactoryClients : Factory
    {
        public override ClientsInterface CreateClientsInterface(int idClients, bool Order, bool Booking, int ClientsNumber, int TimeSpend)
        {
            return (ClientsInterface)new Clients(idClients, Order, Booking, ClientsNumber, TimeSpend);
        }

        public override IndividualClientInterface CreateIndividualClientInterface(int Taste, int Choice, bool WaiterRequest)
        {
            return (IndividualClientInterface) new IndividualClient(Taste, Choice, WaiterRequest);
        }
    }
}
