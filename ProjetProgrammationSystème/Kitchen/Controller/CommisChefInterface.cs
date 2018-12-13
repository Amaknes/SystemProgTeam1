using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    public interface CommisChefInterface
    {
        List<int> ingredients { get; set; }
        

        void SearchIngredients(string NameIngredient, int TypeIngredient, int nbSameDish); 
        void PeelVegetables();
        void SendDishes(int idTable, int IdDish, int Dish, int NbDishesList);
    }
}
