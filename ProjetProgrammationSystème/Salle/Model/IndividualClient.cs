using System;
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

    }
}
