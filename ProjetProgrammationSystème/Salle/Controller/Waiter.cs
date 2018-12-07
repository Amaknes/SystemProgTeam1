using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    public class Waiter : WaiterInterface, IObservable
    {
        private int _IdWaiter;
        public int IdWaiter {
            get => this._IdWaiter;
            set
            {
                if(value > 0){
                    this._IdWaiter = value;
                }
            }
        }

        private bool _Busy;
        public bool Busy {
            get => this._Busy;
            set => this._Busy = value;
        }

        private bool _StateType;
        public bool StateType {
            get => this._StateType;
            set => this._StateType = value;
        }
        int IObservable.StateType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddObserver()
        {
            throw new NotImplementedException();
        }

        public void NotifyObserver()
        {
            if (Busy == true)
            {
               CommisWaiter.commisWaiterInstance().Update(); //ne pas oublier de changer le 1 en vrai idTable
            }
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
