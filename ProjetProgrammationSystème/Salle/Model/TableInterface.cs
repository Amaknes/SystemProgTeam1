using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public interface TableInterface
    {
        int IdTable { set; get; }
        int NbPlace { set; get; }
        ClientsInterface Clients { set; get; }

    }
}
