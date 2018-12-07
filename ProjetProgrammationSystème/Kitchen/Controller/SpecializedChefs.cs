using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    class SpecializedChefs : SpecializedChefsInterface
    {
        public int time
        {
            get;
            set;
        }

        public int Order
        {
            get;
            set;
        }

        public int idCommisChef
        {
            get;
            set;
        }


        private List<CommisChefInterface> _CommisChefList;
        public List<CommisChefInterface> CommisChefList
        {
            get { return this._CommisChefList; }
            set { this._CommisChefList = value; }
        }


        public SpecializedChefsInterface Strategy { get; set; }

            public void CallType()
            {
                Console.WriteLine(Strategy.TypeTestStrategy());
            }
        
    }
}
