using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Salle.Model;

namespace Salle.Controller
{
    public interface MaîtreHôtelInterface
    {
        List<HeadWaiterInterface> ListHeadWaiter
        {
            get;
            set;
        }

        List<ClientsInterface> ListClientsInterfaces
        {
            get;
            set;
        }

        void AssignTable(ClientsInterface clients);
        void CallHeadWaiter(int idTable);
        HeadWaiterInterface GetHeadWaiterDisposable();
        void ClientsReception();
    }
}
