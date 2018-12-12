using Salle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    class CommisWaiter : CommisWaiterInterface, IObserver
    {
        private static CommisWaiter CommisWaiterInstance;
        
        public static CommisWaiter commisWaiterInstance()
        {
            if (CommisWaiterInstance == null)
            { 
                CommisWaiterInstance = new CommisWaiter();
            }

            return CommisWaiterInstance;
        }



        private CommisWaiter()
        {

        }


        public void ServeBreadDrinks(int idTable)
        {
            Console.WriteLine("Commis Serving Drinks and Bread");
            Table table = (Table)Hall.hallInstance().FindTableById(idTable);
            if (table.Clients.ClientsNumber > 6)
            {
                table.Bread = 2;
                table.Drinks = 2;
            }
            else
            {
                table.Bread = 1;
                table.Drinks = 1;
            }
        }
    
        public void Update(int idTable, bool FirstTime)
        {
            ServeBreadDrinks(idTable);
            if (FirstTime)
            {
                Hall.hallInstance().FindTableById(idTable).Clients.Eat();
            }
        }

    }
}
