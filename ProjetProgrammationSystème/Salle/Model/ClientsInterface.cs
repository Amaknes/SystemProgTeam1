using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public interface ClientsInterface
    {
        int IdClients { get; set; }
        bool Order { get; set; }
        bool Booking { get; set; }
        int ClientsNumber { get; set; }
        List<IndividualClientInterface> ClientsList { get; set; }
        int Bill { get; set; }


        int[] ChoiceOrder();
        int Payment();
        void AlertCommisWaiter();

    }
}
