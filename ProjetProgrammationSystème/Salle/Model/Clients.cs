using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Salle.Controller;
using Salle.View;

namespace Salle.Model
{
    public class Clients : ClientsInterface, IObservable
    {
        private Affichage afficher;

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

        private bool SkipEntry, SkipPlate, SkipDessert = false;

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
            this.afficher = new Affichage();
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

        public void NotifyObserver(int idTable, bool ft)
        {
            foreach (IObserver o in Observers)
            {
                o.Update(idTable, false);
            }
        }


        

        public OrderInterface ChoiceOrder(bool SecondOrder)
        {
            afficher.afficherLine("Client Choosing......");
            Order resOrder = new Order(idTable);
            Random rnd = new Random();

            int plat = -1;

            


            foreach (IndividualClient IndCl in ClientsList)
            {
                //          int TimeSpent = 0;
                if (!SecondOrder)
                {
                    plat = IndCl.ChooseEntry(rnd);
                    if (plat != -1)
                    {
                        resOrder.ListEntries.Add(plat);
                        plat = -1;
                        //                      TimeSpent += 15;
                    }

                    plat = IndCl.ChoosePlat(rnd);
                    if (plat != -1)
                    {
                        resOrder.ListPlats.Add(plat);
                        plat = -1;
                        //                        TimeSpent += 25;
                    }
                }

                if (!Order || (Order && SecondOrder))
                {
                    plat = IndCl.ChooseDessert(rnd);
                    if (plat != -1)
                    {
                        resOrder.ListDesserts.Add(plat);
                        plat = -1;
 //                       TimeSpent += 10;
                    }
                    
                }
            }


            if(resOrder.ListEntries.Count == 0)
            {
                this.SkipEntry = true;
            }
            else
            {
                this.SkipEntry = false;
            }
            if (resOrder.ListPlats.Count == 0)
            {
                this.SkipPlate = true;
            }
            else
            {
                this.SkipPlate = false;
            }
            if (resOrder.ListDesserts.Count == 0)
            {
                this.SkipDessert = true;
            }
            else
            {
                this.SkipDessert = false;
            }

            return resOrder;
        }

        public void Payment()
        {
            afficher.afficherLine("Clients Pay");
            
            MaîtreHôtel.maîtreHôtelInstance().GetMoney(Bill, this);
            

        }

        public void Eat()
        {
            this.TimeOfArrival = DateTime.Now.Ticks;
            afficher.afficherLine("Clients Starts to eat");
            bool leaving = false;

            if (!SkipEntry)
            {
                leaving = WaitForNextDishe(0);
            }

            if (!leaving)
            {
                if (!SkipPlate)
                {
                    Thread.Sleep(15000);
                    afficher.afficherLine("Client ate an entry");
                    leaving = WaitForNextDishe(1);
                }

                if (!leaving)
                {
                    Thread.Sleep(25000);
                    afficher.afficherLine("Client ate a Plat");
                    if (Order && !leaving)
                    {
                        MaîtreHôtel.maîtreHôtelInstance().SecondOrderFromClient(idTable);
                    }


                    if (!SkipDessert)
                    {
                        leaving = WaitForNextDishe(2);

                        if (!leaving)
                        {
                            Thread.Sleep(10000);
                            afficher.afficherLine("Client ate a Dessert");
                        }
                    }
                }

                
            }

            if (!leaving)
            {
                Payment();
            }
        }

        public bool WaitForNextDishe(int NbDishe)
        {
            Random rnd = new Random();
            int Bread = Hall.hallInstance().FindTableById(this.idTable).Bread;
            int Drinks = Hall.hallInstance().FindTableById(this.idTable).Drinks;
            bool request = false;
            bool leaving = false;

            foreach (IndividualClient Cl in ClientsList)
            {
                if (Cl.WaiterRequest == true)
                {
                    request = true;
                }
            }

            afficher.afficherLine("Request : "+request+", WaitTime : "+TimeSpend);
            
            while (this.CurrentDishe == NbDishe && !leaving)
            {
                afficher.afficherLine(""+this.CurrentDishe);
                if ((DateTime.Now.Ticks - TimeOfArrival) >= (TimeSpend * (1000  * 10000)))
                {
                    leaving = leave();
                }

                if (!leaving)
                {
                    if (rnd.Next(80) < 2)
                    {
                        if (Bread <= 0 && request)
                        {
                            NotifyObserver(this.idTable, false);
                            Bread = Hall.hallInstance().FindTableById(this.idTable).Bread;
                            Drinks = Hall.hallInstance().FindTableById(this.idTable).Drinks;
                        }
                        else if (Bread > 0)
                        {
                            Bread -= 1;
                            afficher.afficherLine("Eats Bread at Table "+idTable+" : "+Bread);
                        }
                    }

                    if (rnd.Next(80) < 2)
                    {
                        if (Drinks <= 0 && request)
                        {
                            NotifyObserver(this.idTable, false);
                            Bread = Hall.hallInstance().FindTableById(this.idTable).Bread;
                            Drinks = Hall.hallInstance().FindTableById(this.idTable).Drinks;
                        }
                        else if (Drinks > 0)
                        {
                            Drinks -= 1;
                            afficher.afficherLine(".....Drinking at Table "+idTable+" : "+Drinks);
                        }
                    }

                    Thread.Sleep(200);
                }

                
            }
            return leaving;
        }

        public bool leave()
        {
            afficher.afficherLine("Client is leaving");
            //detruire le client
            Hall.hallInstance().FindTableById(idTable).Clients = null;

            Thread threadWaiterCleaning = new Thread(() => Hall.hallInstance().FindSquareByTableId(idTable).GetFreeWaiter().CleanTable(this.idTable,this.ClientsNumber));
            new Pause().AddThread(threadWaiterCleaning);
            threadWaiterCleaning.Start();

            return true;
        }
    }
}
