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
        public List<IObservable> ListObservable;



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
            this.ListObservable = new List<IObservable>();
            //Waiter.Busy = new Waiter.NotifiyObserver();
        }


        public void ServeBreadDrinks(int idTable)
        {
            //donner du pain et ou à boire aux clients qui le demandent
        }
    
        public void Update()
        {
            ServeBreadDrinks(1);
            //Temporaire changer id
        }

    }
}
