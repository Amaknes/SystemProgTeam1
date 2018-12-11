using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    public interface DishWasherInterface
    {
        List<bool> ListLaundry { get; set; }
        List<bool> ListCutlery { get; set; }
        bool Busy { get; set; }
        long Timer { get; set; }
        List<bool> ListWashMachine { get; set; }
        List<bool> ListDishWasher { get; set; }

        void GetCutlery();
        void GetLaundry();
        void StockLaundry(bool Dirty, List<bool> Laundry);
        void StockCutlery(bool Dirty, List<bool> Cutlery);
        void LaunchWashingMachine();
        void LaunchDishWasher();


    }
}
