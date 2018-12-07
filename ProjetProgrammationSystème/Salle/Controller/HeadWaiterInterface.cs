using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    interface HeadWaiterInterface
    {

        int IdHeadWaiter
        {
            get;
            set;
        }

        bool Busy
        {
            get;
            set;
        }

        int Position(int IdSquare);
        int getOrder(int IdTable);
        void GiveOrder(int Order);
        void SitClient(int IdTable);
        void DistributeCards(int IdTable);
        void DrowUpTable(int IdTable);



    }
}
