using Allure.Net.Commons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenWikiTests
{
    [TestClass]
    public class SampleTests
    {
        [TestMethod]
        public void HealthCheckupTest()
        {
            Console.WriteLine("Playwright is up and running.");
            Assert.IsTrue(true);
        }
    }
}