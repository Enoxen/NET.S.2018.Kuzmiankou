using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Root;

namespace Root.Test
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { set; get; }
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\RootTestData.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("Root\\RootTestData.xml")]
        [TestMethod]
        public void TestMethod1()
        {
            double number = Convert.ToDouble(TestContext.DataRow["number"]);
            double degree = Convert.ToDouble(TestContext.DataRow["degree"]);
            double precision = Convert.ToDouble(TestContext.DataRow["precision"]);
            double expected = Convert.ToDouble(TestContext.DataRow["expected"]);

            Assert.AreEqual(expected, RootFinder.FindNthRoot(number, degree, precision));
        }
    }
}
