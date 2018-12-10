﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Controller
{
    class DishWasher : DishWasherInterface
    {
        private bool _Busy;
        public bool Busy
        {
            get => this._Busy;
            set => this._Busy = value;
        }

        private List<bool> _ListCutlery;
        public List<bool> ListCutlery
        {
            get => this._ListCutlery;
            set => this._ListCutlery = value;
        }

        private List<bool> _ListLaundry;
        public List<bool> ListLaundry
        {
            get => this._ListLaundry;
            set => this._ListLaundry = value;
        }

        private List<bool> _ListDishWasher;
        public List<bool> ListDishWasher
        {
            get => this._ListDishWasher;
            set => this._ListDishWasher = value;
        }

        private List<bool> _ListWashMachine;
        public List<bool> ListWashMachine
        {
            get => this._ListWashMachine;
            set => this._ListWashMachine = value;
        }

        private List<bool> _ListUstensile;
        public List<bool> ListUstensile
        {
            get => this._ListUstensile;
            set => this._ListUstensile = value;
        }

        private long _Timer;
        public long Timer
        {
            get => this._Timer;
            set => this._Timer = value;
        }


        public DishWasher()
        {
            this.Busy = false;
            this.ListCutlery = new List<bool>();
            this.ListLaundry = new List<bool>();
            this.ListUstensile = new List<bool>();
            this.Timer = DateTime.Now.Ticks;


            Thread threadDishWashingMachine = new Thread(() => LaunchDishWasher());
            threadDishWashingMachine.Start();
        }





        public void GetCutlery()
        {
            //take from the socket et utiliser Stock
        }

        public void StockCutlery(bool Dirty, List<bool> Cutlery)
        {
            if (Dirty)
            {
                foreach (bool Ctl in Cutlery)
                {
                    ListCutlery.Add(true);
                }
            }
            else
            {
                Thread.Sleep(1000);
                //ranger ListDIshwasher dans le socket
                Thread.Sleep(1000);

                LaunchDishWasher();
            }
        }

        public void LaunchDishWasher()
        {
            while (DateTime.Now.Ticks - Timer < 10000)
            {
                Thread.Sleep(500);
            }

            if(this.ListCutlery.Count > 0)
            {
                this.Timer = DateTime.Now.Ticks;
                Console.WriteLine("The DishWasher is launching the DishWashing Machine");
                foreach (bool Ctl in ListCutlery)
                {
                    ListCutlery.Remove(Ctl);
                    ListDishWasher.Add(true);
                }
                Thread.Sleep(8000);

                StockCutlery(false, this.ListDishWasher);

            }
            else
            {
                LaunchDishWasher();
            }
        }



        public void GetLaundry()
        {
            //take from the socket et utiliser Stock

        }

        public void LaunchWashingMachine()
        {
            Console.WriteLine("The DishWasher is launching the Washing Machine");

            foreach(bool Ldn in ListLaundry)
            {
                ListLaundry.Remove(Ldn);
                ListWashMachine.Add(true);
            }

            Thread.Sleep(15000);
            StockLaundry(false, this.ListLaundry);
        }

        public void StockLaundry(bool Dirty, List<bool> Laundry)
        {
            if (Dirty)
            {
                foreach(bool Ldr in Laundry)
                {
                    ListLaundry.Add(true);
                }

                if (ListLaundry.Count >= 10)
                {
                    Thread threadWashingMachine = new Thread(() => LaunchWashingMachine());
                    threadWashingMachine.Start();
                }
            }
            else
            {
                Thread.Sleep(1000);
                //ranger dans le socket
                Thread.Sleep(1000);
            }
        }



        public void GetDirtyUstensil()
        {
            //récupère les instruments et les rajoutent à la liste
        }

        public void HandWashing()
        {
            if(ListUstensile.Count > 0)
            {
                if(ListUstensile[0] == true)
                {
                    Thread.Sleep(500);
                }
                else
                {
                    Thread.Sleep(1000);
                }
                TidyUstensils();
            }
        }

        public void TidyUstensils()
        {
            ListUstensile.RemoveAt(0);
            //range sur la map
        }
    }
}
