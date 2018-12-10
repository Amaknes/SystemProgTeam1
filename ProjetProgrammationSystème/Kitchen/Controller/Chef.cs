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

        public bool DefineStrategy()
        {
            //Check if list is odd or even
            if (Chef.chefInstance().SpecializedChefsList.Count() % 2 == 0)
            {
                return true;
            }
            else return false;

        }

        public void AddSpecializedChef()
        {
            if (this.DefineStrategy())
            {
                SpecializedChefsList.Add((SpecializedChefsInterface)new Pastry());

            }else
            {
                SpecializedChefsList.Add((SpecializedChefsInterface)new Cookers());
            }
        }

        private Chef()
        {
            List<SpecializedChefsInterface> SpecializedChefsList = new List<SpecializedChefsInterface>();
            this.AddSpecializedChef();
            this.AddSpecializedChef();

        }

        public static Chef chefInstance()
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
