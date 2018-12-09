using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    public class HeadWaiter : HeadWaiterInterface
    {
        private int _IdHeadWaiter;
        public int IdHeadWaiter {
            get => this._IdHeadWaiter;
            set
            {
                if(value > 0)
                {
                    this._IdHeadWaiter = value;
                }
            }
        }

        private bool _Busy;
        public bool Busy {
            get => this._Busy;
            set => this._Busy = value;
        }

        public void DistributeCards(int IdTable)
        {
            throw new NotImplementedException();
        }

        public void DrowUpTable(int IdTable)
        {
            throw new NotImplementedException();
        }

        public int getOrder(int IdTable)
        {
            throw new NotImplementedException();
        }

        public void GiveOrder(int Order)
        {
            throw new NotImplementedException();
        }

        public int Position(int IdSquare)
        {
            throw new NotImplementedException();
        }

        public void SitClient(int IdTable)
        {
            this.Busy = true;
            System.Threading.Thread.Sleep(1200);
            this.Busy = false;
        }

        public HeadWaiter(int idHeadWaiter)
        {
            this.IdHeadWaiter = idHeadWaiter;
            this.Busy = false;
        }
    }
}
