using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    public interface OrderInterface
    {
        int IdTable { get; set; }
        List<int> ListEntries { get; set; }
        List<int> ListPlats { get; set; }
        List<int> ListDesserts { get; set; }
    }
}
