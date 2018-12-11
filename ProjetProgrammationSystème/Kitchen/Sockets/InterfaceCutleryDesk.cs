using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Sockets
{
    interface InterfaceCutleryDesk
    {
        byte[] bytes { get; set; }
        Socket s { get; set; }

        void SendDataCutleryDesk();
        void EcouterCutleryDesk();
    }
}
