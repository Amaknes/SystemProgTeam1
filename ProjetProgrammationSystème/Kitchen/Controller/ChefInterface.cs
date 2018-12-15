using Kitchen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    public interface ChefInterface
    {
        List<Order> ListOrder { get; set; }
        CLprocessus process { get; set; }


        void GetOrder(String strOrder);
        void Sort();
        void Dispatch(List<int> Order, int pastry, int idTable);
    }
}
