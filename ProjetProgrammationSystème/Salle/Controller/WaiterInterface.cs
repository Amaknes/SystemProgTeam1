using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Controller
{
    public interface WaiterInterface
    {

        int IdWaiter { get; set; } 
        bool Busy { get; set; }

        void CleanTable(int idTable, int nbClients);
        void Serve(int idTable, int stepDishes);
        void ServeBreadDrinks(int idTable);
    }
}
