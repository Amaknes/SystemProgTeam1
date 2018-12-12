using Salle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Sockets;
using System.Threading;

namespace Salle.Controller
{
    public class Waiter : WaiterInterface, IObservable
    {
        private int _IdWaiter;
        public int IdWaiter {
            get => this._IdWaiter;
            set
            {
                if(value > 0){
                    this._IdWaiter = value;
                }
            }
        }

        private bool _Busy;
        public bool Busy {
            get => this._Busy;
            set => this._Busy = value;
        }

        private int _StateType;
        public int StateType {
            get => this._StateType;
            set => this._StateType = value;
        }
        
        private List<IObserver> _Observers;
        public List<IObserver> Observers {
            get => this._Observers;
            set => this._Observers = value;
        }



        public Waiter(int idWaiter)
        {
            this.IdWaiter = idWaiter;
            this.Busy = false;
            this.StateType = 0;
            this.Observers =  new List<IObserver>();
        }



        public void AddObserver(IObserver Obs)
        {
            this.Observers.Add(Obs);
        }

        public bool SuppObserver(IObserver Obs)
        {
            return this.Observers.Remove(Obs);
        }

        public void NotifyObserver(int idTable,bool ft)
        {
            foreach(IObserver o in Observers)
            {
                o.Update(idTable, ft);
            }
        }



        public void CleanTable(int idTable, int nbCouverts)
        {
            Console.WriteLine("Waiter Cleans");
            Busy = true;
            Hall.hallInstance().FindTableById(idTable).Cutlery = false;
            //take cutlery to the Dishes desk

            CutleryDesk.cutleryDeskInstance().SendDataCutleryDesk(nbCouverts);
            

            Busy = false;
        }

        public void Serve(int idTable, int stepDishes)
        {
            Busy = true;

            Clients leClient = (Clients) Hall.hallInstance().FindTableById(idTable).Clients;
            leClient.CurrentDishe = stepDishes;

            Busy = false;
        }

        public void ServeBreadDrinks(int idTable)
        {
            if (Busy)
            {
                NotifyObserver(idTable,true);
            }
            else
            {
                Busy = true;
                Console.WriteLine("Waiter giving Bread and Drinks");
                Table table = (Table)Hall.hallInstance().FindTableById(idTable);
                if(table.Clients.ClientsNumber > 6)
                {
                    table.Bread = 2;
                    table.Drinks = 2;
                }
                else
                {
                    table.Bread = 1;
                    table.Drinks = 1;
                }
                table.Clients.Eat();
                Busy = false;
            }
        }
    }
}
