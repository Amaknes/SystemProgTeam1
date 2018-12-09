using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Socket
{
    class OrderDesk : InterfaceOrderDesk
    {
        private static OrderDesk OrderDeskInstance;
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

        private OrderDesk()
        {
            _OrderTable = new List<int>();
            _FinishedOrder = new List<int>();
        }

        public static OrderDesk getInstance()
        {
            if (OrderDeskInstance == null)
            {
                OrderDeskInstance = new OrderDesk();
                return OrderDeskInstance;
            } else return OrderDeskInstance;
        }

        public void DeliverOrder(int OrderDone)
        {
            foreach (int Order in FinishedOrder) {
                //Needs to call the DB and change the status of the order
            }
            throw new NotImplementedException();
        }
    }
}
