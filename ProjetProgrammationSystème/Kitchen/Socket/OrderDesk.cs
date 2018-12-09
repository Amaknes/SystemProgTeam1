using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Socket
{
    class OrderDesk : InterfaceOrderDesk
    {
        List<int> _OrderTable;
        List<int> _FinishedOrder;

        public List<int> OrderTable {
            get { return _OrderTable; }
            set { _OrderTable = value; }
        }
        public List<int> FinishedOrder {
            get { return _FinishedOrder; }
            set { _FinishedOrder = value; }
        }

        public void DeliverOrder(int OrderDone)
        {
            throw new NotImplementedException();
        }
    }
}
