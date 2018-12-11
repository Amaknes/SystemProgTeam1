using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Controller;
using Kitchen.Sockets;

namespace Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            CutleryDesk cutleryDesk = CutleryDesk.cutleryDeskInstance();
            OrderDesk orderDesk = OrderDesk.orderDeskInstance();

            Console.Read();
        }

    }
}
