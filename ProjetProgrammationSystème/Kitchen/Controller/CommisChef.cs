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

        private int _ingredients;
        public int ingredients
        {
            get => this._ingredients;
            set
            {
                if(value >= 0)
                {
                    this._ingredients = value;
                }
            }
        }

        private int _IdVegetables;
        public int IdVegetables
        {
            get => this._IdVegetables;
            set
            {
                if(value >= 0)
                {
                    this._IdVegetables = value;
                }
            }
        }

        public void GiveIngredients()
        {


        }

        public int PeelVegetables()
        {
            //threadsleep(500);
        }

        public int SearchIngredients(int ingredients)
        {
            //search in BDD
        }

        public int SendDishes()
        {
            //connecter au passe plat avec le socket + sémaphore
        }
    }
}
