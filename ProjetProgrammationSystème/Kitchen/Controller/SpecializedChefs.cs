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
        private bool Activity;
        

        public int time
        {
            get {return this.Time;}
            set { this.Time = value;}
        }

        public bool Activity1 { get => Activity; set => Activity = value; }

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

        public void UseOven(int duration)
        {
            int StartTime = time;
            while(time < StartTime + duration)
            {

            }
        }

        public int UseHotPlate(int duration)
        {
            int StartTime = time;
            while (time < StartTime + duration)
            {

            }
            return 0;
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
