using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    interface IObservable
    {
        int StateType
        {
            get;
            set;
        }

        void NotifyObserver();
        bool SuppObserver();
        void AddObserver();

    }
}
