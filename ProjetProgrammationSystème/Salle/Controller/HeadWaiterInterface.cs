﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Model;

namespace Salle.Controller
{
    public interface HeadWaiterInterface
    {

        int IdHeadWaiter { get; set; }
        int IdSquare { get; set; }
        bool Busy { get; set; }

        int Position(int IdSquare);
        OrderInterface getOrder(int IdTable, bool SecondOrder);
        void GiveOrder(OrderInterface Order);
        void SitClient(int IdTable, int nbClients);
        void DistributeCards(int IdTable, int nbClients);
        void DrowUpTable(int IdTable);
        void WaitOrder(int IdTable, int nbClients);
        void OrderWaiters(int IdTable);

    }
}
