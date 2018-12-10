using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    public interface DishWasherInterface
    {


        void GetCutlery();

        void GetDirtyUstensil();

        void GetLaundry();

        void HandWashing();

        void StockLaundry(bool Dirty);

        void StockCutlery(bool Dirty);

        void LaunchWashingMachine();

        void LaunchDishWasher();

        void TidyUstensils();









    }
}
