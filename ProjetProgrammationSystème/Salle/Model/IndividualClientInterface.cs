using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public interface IndividualClientInterface
    {
        int TimeSpend { get; set; }
        int Taste { get; set; }
        int Choice { get; set; }
        bool WaiterRequest { get; set; }

        int ChooseEntry(Random rnd);
        int ChoosePlat(Random rnd);
        int ChooseDessert(Random rnd);
    }
}
