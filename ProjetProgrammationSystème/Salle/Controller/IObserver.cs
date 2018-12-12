using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    public interface IObserver
    {
        void Update(int idTable, bool FirstTime);
    }
}
