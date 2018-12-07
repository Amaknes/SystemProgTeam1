using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Socket
{
    class OrderDesk : InterfaceOrderDesk
    {
        int[,] _OrderTable;
        int[,] _FinishedOrder;

        public int[,] OrderTable {
            get { return _OrderTable; }
            set { _OrderTable = value; }
        }
        public int[,] FinishedOrder {
            get { return _FinishedOrder; }
            set { _FinishedOrder = value; }
        }

        public void DeliverOrder(int foo, int fooo)
        {
            throw new NotImplementedException();
        }
    }
}
