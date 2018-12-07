using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    interface CommisChefInterface
    {


        int SearchIngredients(int ingredients);


        int GiveIngredients();

        int PeelVegetables(int IdVegetables);

        int SendDishes();









    }
}
