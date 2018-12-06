using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public class FactoryClients : Factory
    {
        public override IndividualClientInterface CreateClientInterface()
        {
            return (IndividualClientInterface) new Clients();
        }
    }
}
