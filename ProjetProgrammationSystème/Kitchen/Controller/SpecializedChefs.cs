using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    public class SpecializedChefs : SpecializedChefsInterface
    {
        private int _time;
        public int time
        {
            get => this._time;
            set
            {
                if (value >= 0)
                {
                    this._time = value;
                }
            }
        }

        private int _Order;
        public int Order
        {
            get => this._Order;
            set
            {
                if (value >= 0)
                {
                    this._Order = value;
                }
            }
        }

        private int _idCommisChef;
        public int idCommisChef
        {
            get => this._idCommisChef;
            set
            {
                if (value >= 0)
                {
                    this._idCommisChef = value;
                }
            }
        }


        private List<CommisChefInterface> _CommisChefsList;
        public List<CommisChefInterface> CommisChefsList
        {
            get { return this._CommisChefsList; }
            set { this._CommisChefsList = value; }
        }

        private SpecializedChefsInterface _Strategy;
        public SpecializedChefsInterface Strategy {
            get => this._Strategy;
            set => this._Strategy = value;
        }


        public void CallType()
        {
            Console.WriteLine(Strategy.TypeTestStrategy());
        }

        public string TypeTestStrategy()
        {
            throw new NotImplementedException();
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
            CommisChef.GiveIngredients();
        }
    }
}
