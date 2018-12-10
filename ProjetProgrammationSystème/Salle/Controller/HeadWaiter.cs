using Salle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Salle.Sockets;

namespace Salle.Controller
{
    public class HeadWaiter : HeadWaiterInterface
    {
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

        private OrderDesk _orderDesk;
        public OrderDesk orderDesk
        {
            get => this._orderDesk;
            set => this._orderDesk = value;
        }

        public HeadWaiter(int idHeadWaiter)
        {
            this.IdHeadWaiter = idHeadWaiter;
            this.IdSquare = idHeadWaiter;
            this.Busy = false;
            this.orderDesk = OrderDesk.orderDeskInstance();
        }



        public void DistributeCards(int IdTable,int nbClients)
        {
            //va chercher les cartes et les donnes aux clients (VIEW)

            Thread threadWaitForCommand = new Thread(() => WaitOrder(IdTable, nbClients));
            threadWaitForCommand.Start();
        }

        public void DrowUpTable(int IdTable)
        {
            throw new NotImplementedException();
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
            Console.WriteLine("Headwaiter taking order");
            
            return (Order)Hall.hallInstance().FindTableById(IdTable).Clients.ChoiceOrder(SecondOrder);
        }

        public void GiveOrder(OrderInterface Order)
        {
            Thread threadWaiterServeBreadDrinks = new Thread(() => OrderWaiters(Order.IdTable));
            threadWaiterServeBreadDrinks.Start();

            //HeadWaiter give Order to the CommandDesk
            //orderDesk.SendData(Order);
            this.Busy = false;
        }

        public void OrderWaiters(int IdTable)
        {
            bool served = false;
            Square sqr = (Square)Hall.hallInstance().SquareList[IdSquare];

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

        public int Position(int IdSquare)
        {
            throw new NotImplementedException();
        }

        public void SitClient(int IdTable, int nbClients)
        {
            this.Busy = true;
            //Move the client to the table
            DistributeCards(IdTable, nbClients);
            this.Busy = false;
        }
    }
}
