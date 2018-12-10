using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    class DishWasher : DishWasherInterface
    {
        private bool _Dirty;
        bool Dirty
        {
            get => this._Dirty;
            set => this._Dirty = value;
        }

        public void GetCutlery()
        {
            throw new NotImplementedException();
        }

        public void GetDirtyUstensil()
        {
            throw new NotImplementedException();
        }

        public void GetLaundry()
        {
            throw new NotImplementedException();
        }

        public void HandWashing()
        {
            throw new NotImplementedException();
        }

        public void LaunchDishWasher()
        {
            throw new NotImplementedException();
        }

        public void LaunchWashingMachine()
        {
            throw new NotImplementedException();
        }

        public void StockCutlery(bool Dirty)
        {
            throw new NotImplementedException();
        }

        public void StockLaundry(bool Dirty)
        {
            throw new NotImplementedException();
        }

        public void TidyUstensils()
        {
            throw new NotImplementedException();
        }
    }
}
