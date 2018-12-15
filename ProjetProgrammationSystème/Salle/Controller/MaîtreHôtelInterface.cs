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
        List<HeadWaiterInterface> ListHeadWaiter { get; set; }
        List<ClientsInterface> ListClients { get; set; }
        List<SquareInterface> ListSquare { get; set; }
        bool Busy { get; set; }

        bool AssignTable(ClientsInterface clients);
        int VerifTables(int idSquare, int idLine, ClientsInterface groupe);
        void CallHeadWaiter(int idTable, int nbClients);
        HeadWaiterInterface GetHeadWaiterDisposable();
        void ClientsReception();
        bool GetMoney(int Bill, ClientsInterface groupe);
        void SecondOrderFromClient(int IdTable);
    }
}
