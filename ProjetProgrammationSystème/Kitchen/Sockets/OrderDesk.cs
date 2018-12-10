using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Sockets
{
    class OrderDesk : InterfaceOrderDesk
    {
        int[,] _OrderTable;
        int[,] _FinishedOrder;

        public int[,] OrderTable {
            get { return _OrderTable; }
            set { _OrderTable = value; }
        }
        public int[,] FinishedOrder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DeliverOrder(int foo, int fooo)
        {
            throw new NotImplementedException();
        }

        
    }
}