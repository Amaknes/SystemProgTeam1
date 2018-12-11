using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    public interface DishWasherInterface
    {
        int ListLaundry { get; set; }
        int ListCutlery { get; set; }
        bool Busy { get; set; }
        long Timer { get; set; }
        int ListWashMachine { get; set; }
        int ListDishWasher { get; set; }

        void GetCutlery(string nb);
        void StockLaundry(bool Dirty);
        void StockCutlery(bool Dirty, int Cutlery);
        void LaunchWashingMachine();
        void LaunchDishWasher();


    }
}
