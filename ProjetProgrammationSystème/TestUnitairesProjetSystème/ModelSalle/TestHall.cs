using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model;

namespace TestUnitairesProjetSystème.ModelSalle.testHall
{
    /// <summary>
    /// Description résumée pour UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSingletonHall()
        {
            HallInterface testHall1 = Hall.hallInstance();
            HallInterface testHall2 = Hall.hallInstance();

            Assert.AreSame(testHall1, testHall2);
        }
    }
}
