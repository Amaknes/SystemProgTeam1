using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model;
using Salle.Controller;
using System.Collections.Generic;

namespace TestUnitairesProjetSystème.ModelSalle
{
    [TestClass]
    public class TestSquare
    {
        [TestMethod]
        public void TestGetIdSquare()
        {
            Square testSquare1 = new Square(1);
            Assert.Equals(testSquare1.IdSquare, 1);
        }

        [TestMethod]
        public void TestSetIdSquare()
        {
            Square testSquare1 = new Square(1);
            testSquare1.IdSquare = 2;
            Assert.Equals(testSquare1.IdSquare, 2);
        }

        [TestMethod]
        public void TestGetHeadWaiter()
        {
            Square testSquare1 = new Square(1);
            Assert.Equals(testSquare1.headWaiter, null);
            //
        }

        [TestMethod]
        public void TestSetHeadWaiter()
        {
            Square testSquare1 = new Square(1);
            HeadWaiter headWaiterTest = new HeadWaiter(2);
            testSquare1.headWaiter = (HeadWaiterInterface)headWaiterTest;
            Assert.Equals(testSquare1.headWaiter, headWaiterTest);
        }

        [TestMethod]
        public void TestGetListLine()
        {
            Square testSquare1 = new Square(1);
            Assert.Equals(testSquare1.LineList.Count, 2);
        }

        [TestMethod]
        public void TestSetListLine()
        {
            Square testSquare1 = new Square(1);
            List<LineInterface> LineList = new List<LineInterface>();
            testSquare1.LineList = LineList;
            Assert.Equals(testSquare1.LineList, LineList);
        }

        [TestMethod]
        public void TestGetListWaiter()
        {
            Square testSquare1 = new Square(1);
            Assert.Equals(testSquare1.WaiterList.Count, 2);
        }

        [TestMethod]
        public void TestSetListWaiter()
        {
            Square testSquare1 = new Square(1);
            List<WaiterInterface> WaiterList = new List<WaiterInterface>();
            testSquare1.WaiterList = WaiterList;
            Assert.Equals(testSquare1.WaiterList, WaiterList);
        }
    }
}
