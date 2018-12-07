using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Socket
{
    interface InterfaceOrderDesk
    {
        int[,] OrderTable { get; set; }
        int[,] FinishedOrder { get; set; }
        void DeliverOrder(int foo, int fooo);
    }
}
