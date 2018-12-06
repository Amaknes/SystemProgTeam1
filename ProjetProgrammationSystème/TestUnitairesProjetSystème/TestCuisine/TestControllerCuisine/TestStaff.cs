using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitairesProjetSystème.TestCuisine.TestControllerCuisine
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
