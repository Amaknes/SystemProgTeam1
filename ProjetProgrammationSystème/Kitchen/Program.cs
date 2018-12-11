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
            OrderDesk test = OrderDesk.orderDeskInstance();
            /*DishWasher dish = new DishWasher();

            List<bool> test = new List<bool>();
            for (int i = 0; i < 15; i++)
            {
                test.Add(true);
            }
            dish.StockLaundry(true, test);*/
            Console.Read();
        }

    }
}
