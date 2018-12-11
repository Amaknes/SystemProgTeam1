using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model;

namespace TestUnitairesProjetSystème.ModelSalle
{ 
    [TestClass]
    public class TestIndividualClients
    {
        [TestMethod]
        public void TestGetTaste()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface(1,90,1,false);
            Assert.AreEqual(client1.Taste, 1);
        }

        [TestMethod]
        public void TestSetTaste()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface(1, 90, 1, false);
            client1.Taste = 2;
            Assert.AreEqual(client1.Taste, 2);
        }

        [TestMethod]
        public void TestGetTimeSpend()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface(1, 90, 1, false);
            Assert.AreEqual(client1.TimeSpend, 90);
        }

        [TestMethod]
        public void TestSetTimeSpend()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface(1, 90, 1, false);
            client1.TimeSpend = 120;
            Assert.AreEqual(client1.TimeSpend, 120);

            client1.TimeSpend = 180;
            Assert.AreEqual(client1.TimeSpend, 120);
        }

        [TestMethod]
        public void TestGetChoice()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface(1, 90, 1, false);
            Assert.AreEqual(client1.Choice, 1);
        }

        [TestMethod]
        public void TestSetChoice()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface(1, 90, 1, false);
            client1.Choice = 2;
            Assert.AreEqual(client1.Choice, 2);
        }

        [TestMethod]
        public void TestGetWaiterRequest()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface(1, 90, 1, false);
            Assert.AreEqual(client1.WaiterRequest, false);
        }

        [TestMethod]
        public void TestSetWaiterRequest()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface(1, 90, 1, false);
            client1.WaiterRequest = true;
            Assert.AreEqual(client1.WaiterRequest, true);
        }
    }
}
