using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model;

namespace TestUnitairesProjetSystème.ModelSalle
{

    [TestClass]
    public class TestClients
    {

        [TestMethod]
        public void TestGetIdClients()
        {
            Clients testClients1 = new Clients(1,false,false,1);
            Assert.AreEqual(testClients1.IdClients, 1);

        }

        [TestMethod]
        public void TestSetIdClients()
        {
            Clients testClients1 = new Clients(1, false, false, 1);
            testClients1.IdClients = 2;
            Assert.AreEqual(testClients1.IdClients, 2);

        }

        [TestMethod]
        public void TestGetOrder()
        {
            Clients testClients1 = new Clients(1, false, false, 1);
            Assert.AreEqual(testClients1.Order, false);

        }

        [TestMethod]
        public void TestSetOrder()
        {
            Clients testClients1 = new Clients(1, false, false, 1);
            testClients1.Order = true;
            Assert.AreEqual(testClients1.Order, true);

        }

        [TestMethod]
        public void TestGetBooking()
        {
            Clients testClients1 = new Clients(1, false, false, 1);
            Assert.AreEqual(testClients1.Booking, false);

        }

        [TestMethod]
        public void TestSetBooking()
        {
            Clients testClients1 = new Clients(1, false, false, 1);
            testClients1.Order = true;
            Assert.AreEqual(testClients1.Booking, true);

        }

        [TestMethod]
        public void TestGetClientsNumber()
        {
            Clients testClients1 = new Clients(0, false, false, 0);
            testClients1.ClientsList.Add(new IndividualClient(1,1,1,false));
            Assert.AreEqual(testClients1.ClientsNumber, 1);

            testClients1.ClientsList.Add(new IndividualClient(1, 1, 1, false));
            testClients1.ClientsList.Add(new IndividualClient(1, 1, 1, false));
            Assert.AreEqual(testClients1.ClientsNumber, 3);

        }

        [TestMethod]
        public void TestSetClientsNumber()
        {
            Clients testClients1 = new Clients(1, false, false, 1);
            testClients1.ClientsNumber = 5;
            Assert.AreEqual(testClients1.ClientsNumber, 5);

        }

        [TestMethod]
        public void TestGetBill()
        {
            Clients testClients1 = new Clients(1, false, false, 1);
            Assert.AreEqual(testClients1.Bill, 0);

        }

        [TestMethod]
        public void TestSetBill()
        {
            Clients testClients1 = new Clients(1, false, false, 1);
            testClients1.Bill = 50;
            Assert.AreEqual(testClients1.Bill, 50);

        }

        [TestMethod]
        public void TestGetClientsList()
        {
            Clients testClients1 = new Clients(1, false, false, 1);
            Assert.AreEqual(testClients1.ClientsList, null);
            //
        }

        [TestMethod]
        public void TestSetClientsList()
        {
            Clients testClients1 = new Clients(1, false, false, 1);

            List<IndividualClientInterface> list = new List<IndividualClientInterface>();
            list.Add(new IndividualClient(1,1,1,false));
            testClients1.ClientsList = list;
            Assert.AreEqual(testClients1.ClientsList, list);

        }




        [TestMethod]
        public void TestHelloMaîtreHôtel()
        {
            Clients testClients1 = new Clients(1, false, false, 1);

        }

        [TestMethod]
        public void TestEat()
        {
            Clients testClients1 = new Clients(1, false, false, 1);

        }

        [TestMethod]
        public void TestPayment()
        {
            Clients testClients1 = new Clients(1, false, false, 1);

        }

        [TestMethod]
        public void TestChoiceOrder()
        {
            Clients testClients1 = new Clients(1, false, false, 1);
            List<IndividualClientInterface> list = new List<IndividualClientInterface>();
            list.Add(new IndividualClient(1, 1, 1, false));
            testClients1.ClientsList = list;

            Assert.AreEqual(testClients1.ChoiceOrder(), new int[1,5,2,4]);
            //

        }

        [TestMethod]
        public void TestAlertCommisWaiter()
        {
            Clients testClients1 = new Clients(1, false, false, 1);

        }
    }
}
