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

            while (true)
            {
                char key = Console.ReadKey().KeyChar;
                if (key.Equals('w'))
                {
                    new Pause().PauseThreads();
                }
                else if (key.Equals('x'))
                {
                    new Pause().Resume();
                }
            }
        }

    }
}
