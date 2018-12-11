using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Salle.Controller;

namespace Salle.Model
{
    public class Clients : ClientsInterface, IObservable
    {
        private int _IdClients;
        public int IdClients
        {
            get => this._IdClients;
            set
            {
                if (value >= 0)
                {
                    this._IdClients = value;
                }
            }
        }

        private bool _Order;
        public bool Order
        {
            get => this._Order;
            set => this._Order = value;
        }

        private int _CurrentDishe;
        public int CurrentDishe
        {
            get => this._CurrentDishe;
            set
            {
                if(value >= 0 && value < 4)
                {
                    this._CurrentDishe = value;
                }
            }
        }

        private bool _Booking;
        public bool Booking
        {
            get => this._Booking;
            set => this._Booking = value;
        }

        private int _ClientsNumber;
        public int ClientsNumber
        {
            get => this._ClientsNumber;
            set
            {
                if (value >= 0)
                {
                    this._ClientsNumber = value;
                }
            }
        }

        private List<IndividualClientInterface> _ClientsList;
        public List<IndividualClientInterface> ClientsList
        {
            get => this._ClientsList;
            set => this._ClientsList = value;
        }

        private int _Bill;
        public int Bill {
            get => this._Bill;
            set
            {
                if (value >= 0)
                {
                    this._Bill = value;
                }
            }
        }

        private List<IObserver> _Observers;
        public List<IObserver> Observers {
            get => this._Observers;
            set => this._Observers = value;
        }

        private int _StateType;
        public int StateType {
            get => this._StateType;
            set => this._StateType = value;
        }

        private int _idTable;
        public int idTable {
            get => this._idTable;
            set
            {
                if (value >= 0)
                {
                    this._idTable = value;
                }
            }
        }

        private int _TimeSpend;
        public int TimeSpend
        {
            get => this._TimeSpend;
            set
            {
                if (value >= 30 && value <= 120)
                {
                    this._TimeSpend = value;
                }
            }
        }

        private long _TimeOfArrival;
        public long TimeOfArrival
        {
            get => this._TimeOfArrival;
            set => this._TimeOfArrival = value;
        }


        public Clients(int IdClients, bool Order, bool Booking, int ClientsNumber, int TimeSpend)
        {

            this.IdClients = IdClients;
            this.Order = Order;
            this.Booking = Booking;
            this.ClientsNumber = ClientsNumber;
            this.CurrentDishe = 0;
            this.TimeSpend = TimeSpend;

            this.Observers = new List<IObserver>();
            AddObserver(CommisWaiter.commisWaiterInstance());
            this.ClientsList = new List<IndividualClientInterface>();

            Random rnd = new Random();
            bool WaiterRequest;

            for (int i = 0; i < ClientsNumber; i++)
            {
                if(rnd.Next(2) == 0)
                {
                    WaiterRequest = false;
                }
                else
                {
                    WaiterRequest = true;
                }

                this.ClientsList.Add(new FactoryClients().CreateIndividualClientInterface(rnd.Next(5), rnd.Next(5), WaiterRequest));
            }
        }




        public void AddObserver(IObserver Obs)
        {
            this.Observers.Add(Obs);
        }

        public bool SuppObserver(IObserver Obs)
        {
            return this.Observers.Remove(Obs);
        }

        public void NotifyObserver(int idTable)
        {
            foreach (IObserver o in Observers)
            {
                o.Update(idTable);
            }
        }


        

        public OrderInterface ChoiceOrder(bool SecondOrder)
        {
            Console.WriteLine("Client Choosing......");
            Order resOrder = new Order(idTable);
            Random rnd = new Random();

            int plat = -1;

            


            foreach (IndividualClient IndCl in ClientsList)
            {
                int TimeSpent = 0;
                if (!SecondOrder)
                {
                    plat = IndCl.ChooseEntry(rnd);
                    if (plat != -1)
                    {
                        resOrder.ListEntries.Add(plat);
                        plat = -1;
                        TimeSpent += 15;
                    }
                    
                    plat = IndCl.ChoosePlat(rnd);
                    if (plat != -1)
                    {
                        resOrder.ListPlats.Add(plat);
                        plat = -1;
                        TimeSpent += 25;
                    }
                }

                if (!Order || (Order && SecondOrder))
                {
                    plat = IndCl.ChooseDessert(rnd);
                    if (plat != -1)
                    {
                        resOrder.ListDesserts.Add(plat);
                        plat = -1;
                        TimeSpent += 10;
                    }
                    
                }
            }

            return resOrder;
        }

        public void Payment()
        {
            Console.WriteLine("Clients Pay");
            Thread threadWaiterCleaning = new Thread(() => Hall.hallInstance().FindSquareByTableId(idTable).GetFreeWaiter().CleanTable(idTable));
            threadWaiterCleaning.Start();

            MaîtreHôtel MH = MaîtreHôtel.maîtreHôtelInstance();
            bool paid = false;
            while (!paid)
            {
                if (MH.Busy)
                {
                    Thread.Sleep(70);
                }
                else
                {
                    MH.GetMoney(Bill, this);
                }
            }

        }

        public void Eat()
        {
            this.TimeOfArrival = DateTime.Now.Ticks;
            Console.WriteLine("Clients Starts to eat");
            WaitForNextDishe(0);

            Thread.Sleep(15000);

            WaitForNextDishe(1);

            Thread.Sleep(25000);

            if (Order)
            {
                MaîtreHôtel.maîtreHôtelInstance().SecondOrderFromClient(idTable);
            }

            WaitForNextDishe(2);

            Thread.Sleep(10000);

            Payment();
        }

        public void WaitForNextDishe(int NbDishe)
        {
            Random rnd = new Random();
            int Bread = Hall.hallInstance().FindTableById(this.idTable).Bread;
            int Drinks = Hall.hallInstance().FindTableById(this.idTable).Drinks;
            bool request = false;

            foreach (IndividualClient Cl in ClientsList)
            {
                if (Cl.WaiterRequest == true)
                {
                    request = true;
                }
            }

            Console.WriteLine("Request : {0}, WaitTime : {1} ", request, TimeSpend);
            
            while (CurrentDishe == NbDishe)
            {
                if ((DateTime.Now.Ticks - TimeOfArrival) >= (TimeSpend * (1000  * 10000)))
                {
                    leave();
                }

                if (rnd.Next(80) < 2)
                {
                    if (Bread <= 0 && request)
                    {
                        NotifyObserver(this.idTable);
                        Bread = Hall.hallInstance().FindTableById(this.idTable).Bread;
                        Drinks = Hall.hallInstance().FindTableById(this.idTable).Drinks;
                    }
                    else
                    {
                        Bread -= 1;
                        Console.WriteLine("Eats Bread : {0}", Bread);
                    }
                }

                if (rnd.Next(80) < 2)
                {
                    if (Drinks <= 0 && request)
                    {
                        NotifyObserver(this.idTable);
                        Bread = Hall.hallInstance().FindTableById(this.idTable).Bread;
                        Drinks = Hall.hallInstance().FindTableById(this.idTable).Drinks;
                    }
                    else
                    {
                        Drinks -= 1;
                        Console.WriteLine(".....Drinking : {0}", Drinks);
                    }
                }

                Thread.Sleep(200);
            }
        }

        public void leave()
        {
            Console.WriteLine("Client is leaving");
            //detruire le client
        }
    }
}
