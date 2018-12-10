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
            //bouge jusq'au chef pour lui donner les ingrédients
        }

        public int PeelVegetables(int IdVegetables)
        {
            throw new NotImplementedException();
        }

        public int SearchIngredients(int ingredients)
        {
            throw new NotImplementedException();
        }

        public int SendDishes()
        {
            throw new NotImplementedException();
        }
    }
}
