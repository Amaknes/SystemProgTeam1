using Kitchen.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

        private List<int>_ingredients;
        public List<int>ingredients { get => this._ingredients; set => this._ingredients = value; }

        private List<int>_IdVegetables;
        public List<int>IdVegetables {  get => this._IdVegetables; set => this._IdVegetables = value; }


        public CommisChef(int id)
        {
            this.IdCommisChef = id;
            this.ingredients = new List<int>();
            this.IdVegetables = new List<int>();
        }




        public void PeelVegetables()
        {
            Console.WriteLine("The Commis is peeling vegetables...");
            Thread.Sleep(500);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SearchIngredients(string NameIngredient, int TypeIngredient, int nbSameDish)
        {
            //liste des endroits ou le commis ira chercher les ingrédients (0,1,2)
            if (TypeIngredient == 0)
            {
                Console.WriteLine("The Commis Chef took {0} {1} from the Reserve", nbSameDish, NameIngredient);
            }
            else if(TypeIngredient == 1)
            {
                Console.WriteLine("The Commis Chef took {0} {1} from the Cold Chamber", nbSameDish, NameIngredient);
            }
            else if(TypeIngredient == 2)
            {
                Console.WriteLine("The Commis Chef took {0} {1} from the Freezer", nbSameDish, NameIngredient);
            }

            if (NameIngredient.Equals("Carotte") || NameIngredient.Equals("Pomme") || NameIngredient.Equals("Concombre") || NameIngredient.Equals("Oignon"))
            {
                PeelVegetables();
            }
        }

        public void SendDishes(int idTable, int IdDish, int Dish, int NbDishesList)
        {
            //connecter au passe plat avec le socket + sémaphore
            OrderDesk.orderDeskInstance().SendDataOrderDesk(idTable, IdDish, Dish, NbDishesList);
        }
    }
}
