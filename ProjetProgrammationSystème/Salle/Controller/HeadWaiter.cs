using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    public class HeadWaiter : HeadWaiterInterface
    {
        public int IdHeadWaiter {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public bool Busy {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public HeadWaiter(int idHeadWaiter)
        {
            this.IdHeadWaiter = idHeadWaiter;
            this.Busy = false;
        }
    }
}
