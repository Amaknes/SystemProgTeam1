using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Socket
{
    interface InterfaceOrderDesk
    {
        List<int> OrderTable { get; set; }
        List<int> FinishedOrder { get; set; }
        void DeliverOrder(int OrderDone);
    }
}
