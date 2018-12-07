using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    public class Waiter : WaiterInterface, IObservable
    {
        public int IdWaiter {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public bool Busy {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int StateType {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int AddObserver()
        {
            throw new NotImplementedException();
        }

        public int NotifyObserver()
        {
            throw new NotImplementedException();
        }

        public bool SuppObserver()
        {
            throw new NotImplementedException();
        }
        public Waiter(int idWaiter)
        {
            this.IdWaiter = idWaiter;
            this.Busy = false;
        }
    }
}
