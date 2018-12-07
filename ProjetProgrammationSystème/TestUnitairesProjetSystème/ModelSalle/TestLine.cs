using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model;

namespace TestUnitairesProjetSystème.ModelSalle
{
    [TestClass]
    public class TestLine
    {
        [TestMethod]
        public void TestGetIdLine()
        {
            Line testLine1 = new Line(1);
            Assert.Equals(testLine1.IdLine, 1);
        }

        [TestMethod]
        public void TestSetIdLine()
        {
            Line testLine1 = new Line(1);
            testLine1.IdLine = 2;
            Assert.Equals(testLine1.IdLine, 2);
        }

        [TestMethod]
        public void TestGetListTable()
        {
            Line testLine1 = new Line(1);
            Assert.Equals(testLine1.ListTable.Count, 2);
        }

        [TestMethod]
        public void TestSetListTable()
        {
            Line testLine1 = new Line(2);
            List <TableInterface> tableList = new List<TableInterface>();
            testLine1.ListTable = tableList;
            Assert.Equals(testLine1.ListTable, tableList);
        }
    }
}
