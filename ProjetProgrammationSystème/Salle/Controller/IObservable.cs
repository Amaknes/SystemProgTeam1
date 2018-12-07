using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    interface IObservable : IObserver
    {
        int StateType
        {
            get;
            set;
        }

        int NotifyObserver();
        bool SuppObserver();
        int AddObserver();

    }
}
