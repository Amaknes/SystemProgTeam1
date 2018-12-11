using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model;

namespace TestUnitairesProjetSystème.ModelSalle
{
    [TestClass]
    public class TestTable
    {
        [TestMethod]
        public void TestGetIdTable()
        {
            Table testTable1 = new Table(2,6);
            Assert.AreEqual(testTable1.IdTable, 2);
        }

        [TestMethod]
        public void TestSetIdTable()
        {
            Table testTable1 = new Table(1, 6);
            testTable1.IdTable = 254;
            Assert.AreEqual(testTable1.IdTable, 254);
        }

        [TestMethod]
        public void TestGetClients()
        {
            Table testTable1 = new Table(1, 6);
            Assert.AreEqual(testTable1.Clients, null);
        }

        [TestMethod]
        public void TestSetClients()
        {
            Table testTable1 = new Table(1, 6);

            Clients clientsAssert = new Clients(1, false, false, 2);
            testTable1.Clients = clientsAssert;

            Assert.AreEqual(testTable1.Clients, clientsAssert);
        }

        [TestMethod]
        public void TestGetNbPlace()
        {
            Table testTable1 = new Table(1, 6);
            Assert.AreEqual(testTable1.NbPlace, 6);
        }

        [TestMethod]
        public void TestSetNbPlace()
        {
            Table testTable1 = new Table(1, 6);
            testTable1.NbPlace = 4;
            Assert.AreEqual(testTable1.NbPlace, 4);
        }
    }
}
