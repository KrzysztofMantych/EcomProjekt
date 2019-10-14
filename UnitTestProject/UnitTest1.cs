using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Internet Connection Test
            bool expectedValue = true;
            bool actualResult = NetworkCheck.IsInternet();
            Assert.AreEqual(expectedValue, actualResult);
            


        }
    }
}
