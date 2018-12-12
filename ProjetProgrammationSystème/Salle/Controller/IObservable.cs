using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    interface IObservable
    {
        List<IObserver> Observers
        {
            get;
            set;
        }

        int StateType
        {
            get;
            set;
        }

        void NotifyObserver(int idTable, bool ft);
        bool SuppObserver(IObserver Obs);
        void AddObserver(IObserver Obs);

    }
}
