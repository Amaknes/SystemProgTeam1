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
        public List<IObservable> ListObservable = new List<IObservable>();

        public static CommisWaiter commisWaiterInstance()
        {
            if (CommisWaiterInstance == null)
            { 
            CommisWaiterInstance = new CommisWaiter();
            }
            return CommisWaiterInstance;
        }

        public void ServeBreadDrinks(int idTable)
        {
            //donner du pain et ou à boire aux clients qui le demandent
            return;
        }
    
        public void Update(int id)
        {
            this.ServeBreadDrinks();
        }

        private void ServeBreadDrinks()
        {
            throw new NotImplementedException();
        }

        private CommisWaiter()
        {
         //   Waiter.Busy = new Waiter.NotifyObserver();           
        }


    }
}
