using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model
{
    public class IndividualClient : IndividualClientInterface
    {

        private int _Taste;
        public int Taste
        {
            get => this._Taste;
            set
            {
                if (value >= 0)
                {
                    this._Taste = value;
                }
            }
        }

        private int _Choice;
        public int Choice
        {
            get => this._Choice;
            set
            {
                if (value >= 0)
                {
                    this._Choice = value;
                }
            }
        }

        private bool _WaiterRequest;
        public bool WaiterRequest
        {
            get => this._WaiterRequest;
            set => this._WaiterRequest = value;
        }




        public IndividualClient(int Taste, int Choice, bool WaiterRequest)
        {

            //Console.WriteLine("Taste: {0}, TimeSpend: {1}, Choice: {2}, WaiterRequest: {3}", Taste, TimeSpend, Choice, WaiterRequest);

            this.Taste = Taste;

            this.Choice = Choice;
            this.WaiterRequest = WaiterRequest;
        }




        public int ChooseEntry(Random rnd)
        {
            int idEntry = -1;
            int pass = 0;

            if (Choice < 2 || Choice > 3)
            {
                if (Taste == 0)
                {
                    pass = rnd.Next(11);
                }
                else if (Taste == 1)
                {
                    pass = rnd.Next(6);
                }
                else
                {
                    pass = rnd.Next(8);
                }

                if (pass > 3)
                {
                    idEntry = rnd.Next(10);
                }
            }
            return idEntry;
        }

        public int ChoosePlat(Random rnd)
        {
            return rnd.Next(10);
        }

        public int ChooseDessert(Random rnd)
        {
            int idDessert = -1;
            int pass = 0;

            if (Choice > 2)
            {
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
                    idDessert = rnd.Next(10);
                }
            }
            return idDessert;
        }
    }
}
