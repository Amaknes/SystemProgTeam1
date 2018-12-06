using Kitchen.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitairesProjetSystème
{
    [TestClass]
    class TestStaff
    {
        [TestMethod]
        public void TestSingleton()
        { 
        //Arrange
        Staff TestStaff1 = Staff.StaffInstance();
        Staff TestStaff2 = Staff.StaffInstance();
        Assert.AreSame(TestStaff1, TestStaff2);
        }

    }
}
