using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    class CommisWaiter : HallOfCommisWaiterInterface 
    {
        private CommisWaiter CommisWaiterInstance;

        public CommisWaiter commisWaiterInstance()
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


    }
}
