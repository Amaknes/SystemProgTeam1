using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    class CommisWaiter : CommisWaiterInterface 
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

        public int ServeBreadDrinks(int idTable)
        {
            throw new NotImplementedException();
        }

        public int VerifyClients()
        {
            throw new NotImplementedException();
        }

        public int VerifyWaiter()
        {
            if (Busy = true)
            {

            }
        }

        private CommisWaiter()
        {
             
        }


    }
}
