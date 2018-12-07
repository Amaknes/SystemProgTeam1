using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model;

namespace TestUnitairesProjetSystème.ModelSalle
{ 
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetTaste()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface();
            Assert.Equals(client1.Taste, 1);
        }

        [TestMethod]
        public void TestSetTaste()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface();
            client1.Taste = 2;
            Assert.Equals(client1.Taste, 2);
        }

        [TestMethod]
        public void TestGetTimeSpend()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface();
            Assert.Equals(client1.TimeSpend, 1);
        }

        [TestMethod]
        public void TestSetTimeSpend()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface();
            client1.TimeSpend = 2;
            Assert.Equals(client1.TimeSpend, 1);
        }

        [TestMethod]
        public void TestGetChoice()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface();
            Assert.Equals(client1.Choice, 1);
        }

        [TestMethod]
        public void TestSetChoice()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface();
            client1.Choice = 2;
            Assert.Equals(client1.Choice, 2);
        }

        [TestMethod]
        public void TestGetWaiterRequest()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface();
            Assert.Equals(client1.WaiterRequest, false);
        }

        [TestMethod]
        public void TestSetWaiterRequest()
        {
            IndividualClient client1 = (IndividualClient)new FactoryClients().CreateIndividualClientInterface();
            client1.WaiterRequest = true;
            Assert.Equals(client1.WaiterRequest, true);
        }
    }
}
