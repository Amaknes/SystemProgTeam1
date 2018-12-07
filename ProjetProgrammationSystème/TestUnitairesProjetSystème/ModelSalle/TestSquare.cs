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
            List<HeadWaiterInterface> newListHeadWaiter = new List<HeadWaiterInterface>
            {
                new HeadWaiter(1),
                new HeadWaiter(2)
            };

            Square testSquare1 = new Square(1,newListHeadWaiter);
            Assert.AreEqual(testSquare1.IdSquare, 1);
        }

        [TestMethod]
        public void TestSetIdSquare()
        {
            List<HeadWaiterInterface> newListHeadWaiter = new List<HeadWaiterInterface>
            {
                new HeadWaiter(1),
                new HeadWaiter(2)
            };

            Square testSquare1 = new Square(1,newListHeadWaiter);
            testSquare1.IdSquare = 2;
            Assert.AreEqual(testSquare1.IdSquare, 2);
        }

        [TestMethod]
        public void TestGetHeadWaiter()
        {
            List<HeadWaiterInterface> newListHeadWaiter = new List<HeadWaiterInterface>
            {
                new HeadWaiter(1),
                new HeadWaiter(2)
            };

            Square testSquare1 = new Square(1,newListHeadWaiter);
            Assert.AreEqual(testSquare1.headWaiter, null);
            //
        }

        [TestMethod]
        public void TestSetHeadWaiter()
        {
            List<HeadWaiterInterface> newListHeadWaiter = new List<HeadWaiterInterface>
            {
                new HeadWaiter(1),
                new HeadWaiter(2)
            };

            Square testSquare1 = new Square(1,newListHeadWaiter);
            HeadWaiter headWaiterTest = new HeadWaiter(2);
            testSquare1.headWaiter = (HeadWaiterInterface)headWaiterTest;
            Assert.AreEqual(testSquare1.headWaiter, headWaiterTest);
        }

        [TestMethod]
        public void TestGetListLine()
        {
            List<HeadWaiterInterface> newListHeadWaiter = new List<HeadWaiterInterface>
            {
                new HeadWaiter(1),
                new HeadWaiter(2)
            };

            Square testSquare1 = new Square(1,newListHeadWaiter);
            Assert.AreEqual(testSquare1.LineList.Count, 2);
        }

        [TestMethod]
        public void TestSetListLine()
        {
            List<HeadWaiterInterface> newListHeadWaiter = new List<HeadWaiterInterface>
            {
                new HeadWaiter(1),
                new HeadWaiter(2)
            };

            Square testSquare1 = new Square(1,newListHeadWaiter);
            List<LineInterface> LineList = new List<LineInterface>();
            testSquare1.LineList = LineList;
            Assert.AreEqual(testSquare1.LineList, LineList);
        }

        [TestMethod]
        public void TestGetListWaiter()
        {
            List<HeadWaiterInterface> newListHeadWaiter = new List<HeadWaiterInterface>
            {
                new HeadWaiter(1),
                new HeadWaiter(2)
            };

            Square testSquare1 = new Square(1,newListHeadWaiter);
            Assert.AreEqual(testSquare1.WaiterList.Count, 2);
        }

        [TestMethod]
        public void TestSetListWaiter()
        {
            List<HeadWaiterInterface> newListHeadWaiter = new List<HeadWaiterInterface>
            {
                new HeadWaiter(1),
                new HeadWaiter(2)
            };

            Square testSquare1 = new Square(1,newListHeadWaiter);
            List<WaiterInterface> WaiterList = new List<WaiterInterface>();
            testSquare1.WaiterList = WaiterList;
            Assert.AreEqual(testSquare1.WaiterList, WaiterList);
        }
    }
}
