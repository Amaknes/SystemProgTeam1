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

        public static CommisWaiter commisWaiterInstance()
        {
            if (CommisWaiterInstance == null)
            { 
            CommisWaiterInstance = new CommisWaiter();
            }

            return CommisWaiterInstance;
        }

        public int ServeBreadDrainks(int idTable)
        {
            throw new NotImplementedException();
        }

        public int VerifyClients()
        {
            throw new NotImplementedException();
        }

        private CommisWaiter()
        {
             
        }


    }
}
