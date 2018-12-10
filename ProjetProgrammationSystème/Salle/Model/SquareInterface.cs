using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Controller;

namespace Salle.Model
{
    public interface SquareInterface
    {

        int IdSquare { get; set; }
        int NbClients { get; set; }
        List<LineInterface> LineList { get; set; }
        HeadWaiterInterface headWaiter { get; set; }
        List<WaiterInterface> WaiterList { get; set; }


        WaiterInterface GetFreeWaiter();
    }
}
