using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Salle.Model;

namespace Salle.Controller
{
    public class MaîtreHôtel : MaîtreHôtelInterface
    {

        private static Semaphore _semOccuper;
        private static MaîtreHôtel MaîtreHôtelInstance;

        private List<ClientsInterface> _ListClientsInterface;
        public List<ClientsInterface> ListClientsInterfaces
        {
            get => this._ListClientsInterface;
            set => this._ListClientsInterface = value;
        }

        private static List<HeadWaiterInterface> _ListHeadWaiter;
        public List<HeadWaiterInterface> ListHeadWaiter
        {
            get => _ListHeadWaiter;
            set => _ListHeadWaiter = value;
        }



        public static MaîtreHôtel maîtreHôtelInstance()
        {

            if (MaîtreHôtelInstance == null)
            {
                MaîtreHôtelInstance = new MaîtreHôtel();
            }

            return MaîtreHôtelInstance;
        }

        private MaîtreHôtel()
        {
            _semOccuper = new Semaphore(0,1);

            List<ClientsInterface> newListClient = new List<ClientsInterface>();
            this.ListClientsInterfaces = (List<ClientsInterface>) newListClient;

            List<HeadWaiterInterface> newListHeadWaiter = new List<HeadWaiterInterface>
            {
                new HeadWaiter(1),
                new HeadWaiter(2)
            };

            ListHeadWaiter = newListHeadWaiter;
        }



        public void AssignTable(ClientsInterface clients)
        {
            throw new NotImplementedException();
        }

        public void CallHeadWaiter(int idTable)
        {
            throw new NotImplementedException();
        }

        public HeadWaiterInterface GetHeadWaiterDisposable()
        {
            HeadWaiterInterface repHeadWaiter = null;

            if (!ListHeadWaiter[0].Busy)
            {
                repHeadWaiter = ListHeadWaiter[0];
            }else if (!ListHeadWaiter[0].Busy)
            {
                repHeadWaiter = ListHeadWaiter[1];
            }
            else
            {
                System.Threading.Thread.Sleep(700);
                repHeadWaiter = GetHeadWaiterDisposable();
            }

            return repHeadWaiter;
        }

        public void ClientsReception()
        {
            
            if(this.ListClientsInterfaces.Count > 0)
            {
                ClientsInterface premierGroupe = this.ListClientsInterfaces[0];
                AssignTable(premierGroupe);
                this.ListClientsInterfaces.Remove(premierGroupe);
            }
        }
    }
}
