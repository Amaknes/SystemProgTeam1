using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    interface CommisChefInterface
    {
        int IdCommisChef
        {
            get;
            set;
        }

        int IdVegetables
        {
            get;
            set;
        }


        int SearchIngredients();


        int GiveIngredients();

        int PeelVegetables();

        int SendDishes();









    }
}
