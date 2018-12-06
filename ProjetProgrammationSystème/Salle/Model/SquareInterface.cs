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

        int idSquare { get; set; }
        List<LineInterface> LineList { get; set; }
        HeadWaiterInterface HeadWaiter { get; set; }
        List<WaiterInterface> WaiterList { get; set; }

    }
}
