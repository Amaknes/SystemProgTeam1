using Salle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Sockets
{
    public interface InterfaceOrderDesk
    {
        Socket s { get; set; }
        byte[] bytes { get; set; }

        void SendData(OrderInterface ord);
    }
}
