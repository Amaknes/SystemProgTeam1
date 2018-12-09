using Kitchen.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    class Chef : ChefInterface
    {
        private static Chef ChefInstance;

        private List<SpecializedChefsInterface> _SpecializedChefsList;
        public List<SpecializedChefsInterface> SpecializedChefsList
        {
            get { return this._SpecializedChefsList; }
            set { this._SpecializedChefsList = value; }
        }


        private Chef()
        {
            List<SpecializedChefsInterface> newSpecializedChefsList = new List<SpecializedChefsInterface>();

            newSpecializedChefsList.Add((SpecializedChefsInterface)new SpecializedChefs());
            newSpecializedChefsList.Add((SpecializedChefsInterface)new SpecializedChefs());

            SpecializedChefsList = newSpecializedChefsList;
        }

        public Chef chefInstance()
        {
            if(ChefInstance == null)
            {
                ChefInstance = new Chef();
            }
            return ChefInstance;
        }

        public List<int> GetNewOrders()
        {
           return OrderDesk.getInstance().OrderTable;
        }

        public void Sort()
        {
            foreach(int order in this.GetNewOrders())
            {
                Dispatch(order);
            }
        }

        public void Dispatch(int Order)
        {
            throw new NotImplementedException();
        }
    }
}
