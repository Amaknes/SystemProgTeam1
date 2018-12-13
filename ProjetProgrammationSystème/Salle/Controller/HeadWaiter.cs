using Salle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Salle.Sockets;
using Salle.View;

namespace Salle.Controller
{
    public class HeadWaiter : HeadWaiterInterface
    {
        private Semaphore _semHW;
        private Affichage afficher;

        private int _IdHeadWaiter;
        public int IdHeadWaiter {
            get => this._IdHeadWaiter;
            set
            {
                if(value > 0)
                {
                    this._IdHeadWaiter = value;
                }
            }
        }

        private bool _Busy;
        public bool Busy {
            get => this._Busy;
            set => this._Busy = value;
        }

        private int _IdSquare;
        public int IdSquare
        {
            get => this._IdSquare;
            set
            {
                if(value > 0)
                {
                    this._IdSquare = value;
                }
            }
        }
        



        public HeadWaiter(int idHeadWaiter)
        {
            this.IdHeadWaiter = idHeadWaiter;
            this.IdSquare = idHeadWaiter;
            this.Busy = false;
            this._semHW = new Semaphore(1, 1);
            this.afficher = new Affichage();
        }



        public void DistributeCards(int IdTable,int nbClients)
        {
            //va chercher les cartes et les donnes aux clients (VIEW)

            Thread threadWaitForCommand = new Thread(() => WaitOrder(IdTable, nbClients));
            new Pause().AddThread(threadWaitForCommand);
            threadWaitForCommand.Start();
        }

        public void DrowUpTable(int IdTable, int ClientsNumber)
        {
            _semHW.WaitOne();

            Table tb = (Table) Hall.hallInstance().FindTableById(IdTable);
            CutleryDesk.cutleryDeskInstance().getCutlery(ClientsNumber);
            tb.Cutlery = true;
            afficher.afficherLine("--"+tb.IdTable+"---Headwaiter dressing the table---"+IdTable+"--");

            _semHW.Release();
        }

        public void WaitOrder(int IdTable, int nbClients)
        {
            Thread.Sleep(nbClients * 300);
            while (this.Busy) { Thread.Sleep(70);}

            this.Busy = true;
            GiveOrder(getOrder(IdTable,false));
        }

        public OrderInterface getOrder(int IdTable, bool SecondOrder)
        {
            afficher.afficherLine("Headwaiter taking order");

            Table tabl1 = (Table) Hall.hallInstance().FindTableById(IdTable);
            Clients Cl1 = (Clients)tabl1.Clients;

            return (Order)Cl1.ChoiceOrder(SecondOrder);
        }

        public void GiveOrder(OrderInterface Order)
        {
            Thread threadWaiterServeBreadDrinks = new Thread(() => OrderWaiters(Order.IdTable));
            new Pause().AddThread(threadWaiterServeBreadDrinks);
            threadWaiterServeBreadDrinks.Start();

            //HeadWaiter give Order to the CommandDesk
            OrderDesk.orderDeskInstance().SendData(Order);
            this.Busy = false;
        }

        public void OrderWaiters(int IdTable)
        {
            bool served = false;
            Square sqr = (Square)Hall.hallInstance().SquareList[IdSquare-1];

            while (!served)
            { 
                if (!sqr.WaiterList[0].Busy)
                {
                    sqr.WaiterList[0].ServeBreadDrinks(IdTable);
                    served = true;
                }
                else if(!sqr.WaiterList[1].Busy)
                {
                    sqr.WaiterList[1].ServeBreadDrinks(IdTable);
                    served = true;
                }
                else
                {
                    Thread.Sleep(70);
                }
                    
            }
        }
        
        public void SitClient(int IdTable, int nbClients)
        {
            this._semHW.WaitOne();

            //Move the client to the table
            DistributeCards(IdTable, nbClients);

            this._semHW.Release();
        }
    }
}
