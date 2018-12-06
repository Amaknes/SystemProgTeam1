using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    interface ChefInterface
    {
        List<SpecializedChefsInterface> SpecializedChefsList { get; set; }

        public void GetOrder()
        {

        }

        public void Sort()
        {

        }

        public void Dispatch()
        {

        }
    }
}
