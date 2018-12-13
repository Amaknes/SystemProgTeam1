using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Sockets
{
    interface InterfaceOrderDesk
    {
        byte[] bytes { get; set; }
        Socket s { get; set; }

        void EcouterOrderDesk(); 
        void SendDataOrderDesk(int idTable, int IdDish, int intDish, int intNbDishesList);
    }
}
