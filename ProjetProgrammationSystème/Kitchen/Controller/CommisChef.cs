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

        public int SearchIngredients(int ingredients)
        {
            
            return GiveIngredients();
        }

        public void GiveIngredients()
        {
            return this.ingredients;
        }

        public int PeelVegetables()
        {
            //threadsleep(500);
        }


        public int SendDishes()
        {
            //connecter au passe plat avec le socket + sémaphore
        }
    }
}
