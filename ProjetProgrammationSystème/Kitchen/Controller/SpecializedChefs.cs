using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    class SpecializedChefs : SpecializedChefsInterface
    {
        private int Time;
        private int order;
        

        public int time
        {
            get {return this.Time;}
            set { this.Time = value;}
        }

        public int Order { get => order; set => order = value; }

        /*public int idCommisChef
        {
            get;
            set;
        }*/
        

        private static List<CommisChefInterface> _CommisChefList;
        public static List<CommisChefInterface> CommisChefList
        {
            get { return _CommisChefList;}
            set { _CommisChefList = value;}
        }


        public List<CommisChefInterface> CommisChefsList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CallType()
            {
                Console.WriteLine();
            }

        public int UseOven(int time)
        {
            throw new NotImplementedException();
        }

        public int UseHotPlate(int time)
        {
            throw new NotImplementedException();
        }

        public int GiveOrders(int Order, int idCommisChef)
        {
            throw new NotImplementedException();
        }

        public int Preparation()
        {
            throw new NotImplementedException();
        }
    }
}
