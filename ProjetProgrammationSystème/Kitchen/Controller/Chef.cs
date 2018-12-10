using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    public class Chef : ChefInterface
    {
        private static Chef ChefInstance;

        private List<SpecializedChefsInterface> _SpecializedChefsList;
        public List<SpecializedChefsInterface> SpecializedChefsList
        {
            get => this._SpecializedChefsList; 
            set => this._SpecializedChefsList = value;
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



        public void GetOrder()
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public void Dispatch(int Order, int IdSpecializedChefs)
        {
            throw new NotImplementedException();
        }
    }
}
