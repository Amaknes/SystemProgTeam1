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

        private int _IdBusy;
        public bool Busy {
            get => this._IdBusy;
            set => this._Busy = value;
        }

        private bool _StateType;
        public bool StateType {
            get => this._StateType;
            set => this._StateType = value;
        }

        public void AddObserver()
        {
            throw new NotImplementedException();
        }

        public void NotifyObserver()
        {
            if (Busy == true)
            {
               CommisWaiter.CommisWaiterInstance.Update(); //ne pas oublier de changer le 1 en vrai idTable
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
