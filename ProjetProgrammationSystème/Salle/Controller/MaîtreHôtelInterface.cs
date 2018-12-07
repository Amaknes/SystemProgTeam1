using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    public interface MaîtreHôtelInterface
    {
        int[] ListHeadWaiter
        {
            get;
            set;
        }

        void AssignTable(int IdTable);
        void getHeadWaiterDisposable(int[] getListeHeadWaiter);
        void CallHeadWaiter(int IdHeadWaiter);
        HeadWaiterInterface GetHeadWaiterDisposable();
    }
}
