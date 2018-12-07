using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    interface DishWasherInterface
    {
        bool Dirty
        {
            get;
            set;
        }


        void GetCutlery();

        void GetDirtyUstensil();

        void GetLaundry();

        void HandWashing();

        void StockLaundry();

        void StockCutlery();

        void LaunchWashingMachine();

        void LaunchDishWasher();

        void TidyUstensils();









    }
}
