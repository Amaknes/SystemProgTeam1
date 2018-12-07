using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model;
using System.Collections.Generic;

namespace TestUnitairesProjetSystème.ModelSalle
{
    /// <summary>
    /// Description résumée pour UnitTest1
    /// </summary>
    [TestClass]
    public class TestHall
    {
        [TestMethod]
        public void TestSingletonHall()
        {
            HallInterface testHall1 = Hall.hallInstance();
            HallInterface testHall2 = Hall.hallInstance();

            Assert.AreSame(testHall1, testHall2);
        }

        [TestMethod]
        public void TestGetListSquare()
        {
            HallInterface testHall1 = Hall.hallInstance();
            Assert.Equals(testHall1.SquareList.Count, 2);
        }

        [TestMethod]
        public void TestSetListSquare()
        {
            HallInterface testHall1 = Hall.hallInstance();
            List<SquareInterface> SquareList = new List<SquareInterface>();
            testHall1.SquareList = SquareList;
            Assert.Equals(testHall1.SquareList, SquareList);
        }
    }
}
