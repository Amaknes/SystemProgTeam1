using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kitchen.Controller;

namespace TestUnitairesProjetSystème.TestCusine.TestControllerCuisine
{

    [TestClass]
    public class TestStaff
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
