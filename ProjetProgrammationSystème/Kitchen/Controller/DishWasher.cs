using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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

        private int _ListCutlery;
        public int ListCutlery
        {
            get => this._ListCutlery;
            set => this._ListCutlery = value;
        }

        private int _ListLaundry;
        public int ListLaundry
        {
            get => this._ListLaundry;
            set => this._ListLaundry = value;
        }

        private int _ListDishWasher;
        public int ListDishWasher
        {
            get => this._ListDishWasher;
            set => this._ListDishWasher = value;
        }

        private int _ListWashMachine;
        public int ListWashMachine
        {
            get => this._ListWashMachine;
            set => this._ListWashMachine = value;
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
            this.ListCutlery = 0;
            this.ListLaundry = 0;
            this.ListWashMachine = 0;
            this.ListDishWasher = 0;
            this.Timer = DateTime.Now.Ticks;


            Thread threadDishWashingMachine = new Thread(() => TimingDishWasher());
            threadDishWashingMachine.Start();
        }





        public void GetCutlery(string nbCutlery)
        {
            string[] Lists = Regex.Split(nbCutlery, @"\D+");
            int nb = 0;

            nb = Int32.Parse(Lists[0]+Lists[1]);
            

            StockCutlery(true, nb);
            
            StockLaundry(true);
        }

        public void StockCutlery(bool Dirty, int Cutlery)
        {
            if (Dirty)
            {
                ListCutlery += Cutlery;
            }
            else
            {
                Thread.Sleep(1000);
                //ranger ListDIshwasher dans le socket
                Thread.Sleep(1000);
            }
        }

        public void TimingDishWasher()
        {
            while(Timer != 0)
            {
                while ((DateTime.Now.Ticks - Timer) < 10000)
                {
                    Thread.Sleep(500);
                }
                if (this.ListCutlery > 0)
                {
                    this.ListCutlery = 0;
                    this.Timer = DateTime.Now.Ticks;

                    Thread threadDishWashingMachine = new Thread(() => LaunchDishWasher());
                    threadDishWashingMachine.Start();
                }

            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void LaunchDishWasher()
        {
            Console.WriteLine("The DishWasher is launching the DishWashing Machine");

            ListDishWasher = ListCutlery;

            Thread.Sleep(8000);

            Console.WriteLine("DishWashing Machine Stopped");

            StockCutlery(false, this.ListDishWasher);
        }




        [MethodImpl(MethodImplOptions.Synchronized)]
        public void LaunchWashingMachine()
        {
            Console.WriteLine("The DishWasher is launching the Washing Machine");

            this.ListLaundry -= 10;
            ListWashMachine += 10;

            Thread.Sleep(15000);
            StockLaundry(false);
        }
        
        public void StockLaundry(bool Dirty)
        {
            if (Dirty)
            {
                ListLaundry += 1;

                if (ListLaundry >= 10)
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
        
    }
}
