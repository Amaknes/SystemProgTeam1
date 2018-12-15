using Kitchen.Sockets;
using Salle.View;
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
        private Affichage afficher;

        private List<int> _ingredients;
        public List<int> ingredients { get => this._ingredients; set => this._ingredients = value; }



        public CommisChef(int id)
        {
            this.ingredients = new List<int>();
            this.afficher = new Affichage();
        }




        public void PeelVegetables()
        {
            afficher.afficherLine("The Commis is peeling vegetables...");
            Thread.Sleep(500);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SearchIngredients(string NameIngredient, int TypeIngredient, int nbSameDish)
        {
            //liste des endroits ou le commis ira chercher les ingrédients (0,1,2)
            if (TypeIngredient == 0)
            {
                afficher.afficherLine("The Commis Chef took " + nbSameDish + " " + NameIngredient + " from the Reserve");
            }
            else if (TypeIngredient == 1)
            {
                afficher.afficherLine("The Commis Chef took " + nbSameDish + " " + NameIngredient + " from the Cold Chamber");
            }
            else if (TypeIngredient == 2)
            {
                afficher.afficherLine("The Commis Chef took " + nbSameDish + " " + NameIngredient + " from the Freezer");
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
