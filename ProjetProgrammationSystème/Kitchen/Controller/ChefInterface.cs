using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    public interface ChefInterface
    {
        void GetOrder(String strOrder);
    
        void Sort();

        void Dispatch(int Order, int IdSpecializedChefs);
    }
}
