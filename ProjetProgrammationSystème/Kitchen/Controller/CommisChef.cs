using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    class CommisChef : CommisChefInterface
    {
        private int _IdCommisChef;
        public int IdCommisChef
        {
            get => this._IdCommisChef;
            set
            {
                if (value >= 0)
                {
                    this._IdCommisChef = value;
                }
            }
        }

        private list<int>_ingredients;
        public list<int>ingredients
        {
            get => this._ingredients;
            set => this._ingredients = value;
        }

        private list<int>_IdVegetables;
        public list<int>IdVegetables
        {
            get => this._IdVegetables;
            set => this._IdVegetables = value;
        }

        public void GiveIngredients()
        {
            //bouge jusq'au chef pour lui donner les ingrédients
        }

        public int PeelVegetables()
        {
            //threadsleep(500);
        }

        public int SearchIngredients(int ingredients)
        {
            //liste des endroits ou le commis ira chercher les ingrédients (0,1,2)
            return 0;
        }

        public int SendDishes()
        {
            //connecter au passe plat avec le socket + sémaphore
        }
    }
}
