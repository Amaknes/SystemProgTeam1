﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public class IndividualClient : IndividualClientInterface
    {
        private int _TimeSpend;
        public int TimeSpend {
            get => this._TimeSpend;
            set
            {
                if (value >= 30 && value <= 120)
                {
                    this._TimeSpend = value;
                }
            }
        }

        private int _Taste;
        public int Taste {
            get => this._Taste;
            set
            {
                if(value >= 0)
                {
                    this._Taste = value;
                }
            }
        }

        private int _Choice;
        public int Choice {
            get => this._Choice;
            set
            {
                if(value >= 0)
                {
                    this._Choice = value;
                }
            }
        }

        private bool _WaiterRequest;
        public bool WaiterRequest {
            get => this._WaiterRequest;
            set => this._WaiterRequest = value;
        }

        public IndividualClient(int Taste, int TimeSpend, int Choice, bool WaiterRequest)
        {

            //Console.WriteLine("Taste: {0}, TimeSpend: {1}, Choice: {2}, WaiterRequest: {3}", Taste, TimeSpend, Choice, WaiterRequest);

            this.TimeSpend = TimeSpend;
            this.Taste = Taste;

            this.Choice = Choice;
            this.WaiterRequest = WaiterRequest;
        }

        public int ChooseEntry()
        {
            int idEntry = -1;
            int pass = 0;

            if(Choice < 2 || Choice > 3)
            {
                Random rnd = new Random();
                if(Taste == 0)
                {
                    pass = rnd.Next(11);
                }else if(Taste == 1)
                {
                    pass = rnd.Next(6);
                }
                else
                {
                    pass = rnd.Next(8);
                }

                if(pass > 3)
                {
                    idEntry = rnd.Next(11);
                }
            }
            return idEntry;
        }

        public int ChoosePlat()
        {
            Random rnd = new Random();
            return rnd.Next(11);
        }

        public int ChooseDessert()
        {
            int idDessert = -1;
            int pass = 0;

            if(Choice > 2)
            {
                Random rnd = new Random();
                if (Taste == 1)
                {
                    pass = rnd.Next(11);
                }
                else if (Taste == 0)
                {
                    pass = rnd.Next(6);
                }
                else
                {
                    pass = rnd.Next(8);
                }

                if (pass > 3)
                {
                    idDessert = rnd.Next(11);
                }
            }
            return idDessert;
        }
    }
}
