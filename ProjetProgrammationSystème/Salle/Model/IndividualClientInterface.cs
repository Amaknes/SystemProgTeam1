using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    interface IndividualClientInterface
    {
        int TimeSpend { get; set; }
        int Taste { get; set; }
        int Choice { get; set; }
        bool WaiterRequest { get; set; }

    }
}
