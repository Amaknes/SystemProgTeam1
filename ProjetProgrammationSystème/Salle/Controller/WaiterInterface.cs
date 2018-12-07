using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    interface WaiterInterface
    {

       int IdWaiter
        {
            get;
            set;
        }

        bool Busy
        {
            get;
            set;
        }
    }
}
