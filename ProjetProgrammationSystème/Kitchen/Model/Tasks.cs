using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class Tasks : TasksInterface
    {
        private string _NameTask;
        public string NameTask {
            get => this._NameTask;
            set => this._NameTask = value;
        }

        private int _TimeTask;
        public int TimeTask {
            get => this._TimeTask;
            set
            {
                if(value >= 0)
                {
                    this._TimeTask = value;
                }
                else
                {
                    this._TimeTask = 0;
                }
            }
        }

        private int _OrderStep;
        public int OrderStep
        {
            get => this._OrderStep;
            set
            {
                if (value >= 0)
                {
                    this._OrderStep = value;
                }
                else
                {
                    this._OrderStep = 0;
                }
            }
        }

        private int _Dish;
        public int Dish
        {
            get => this._Dish;
            set
            {
                if (value >= 0)
                {
                    this._Dish = value;
                }
                else
                {
                    this._Dish = 0;
                }
            }
        }

        private int _IdDish;
        public int IdDish
        {
            get => this._IdDish;
            set
            {
                if (value >= 0)
                {
                    this._IdDish = value;
                }
                else
                {
                    this._IdDish = 0;
                }
            }
        }

        private int _NbDishesList;
        public int NbDishesList
        {
            get => this._NbDishesList;
            set
            {
                if (value >= 0)
                {
                    this._NbDishesList = value;
                }
                else
                {
                    this._NbDishesList = 0;
                }
            }
        }

        private int _NbSameDish;
        public int NbSameDish
        {
            get => this._NbSameDish;
            set
            {
                if (value >= 0)
                {
                    this._NbSameDish = value;
                }
                else
                {
                    this._NbSameDish = 0;
                }
            }
        }

        public Tasks(String NameTask,int TimeTask,int OrderStep, int Dish, int nbDishesList, int NbSameDish, int idDish)
        {
            this.Dish = Dish;
            this.NameTask = NameTask;
            this.TimeTask = TimeTask;
            this.OrderStep = OrderStep;
            this.NbDishesList = nbDishesList;
            this.NbSameDish = NbSameDish;
            this.IdDish = idDish;
        }
    }
}
