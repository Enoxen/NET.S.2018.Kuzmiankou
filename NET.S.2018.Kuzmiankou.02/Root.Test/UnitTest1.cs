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
            double number = Convert.ToDouble(Convert.ToString(TestContext.DataRow["number"]));
            //double num = Convert.ToDouble(number);
            double degree = Convert.ToDouble(Convert.ToString(TestContext.DataRow["degree"]));
            double precision = Convert.ToDouble(Convert.ToString(TestContext.DataRow["precision"]));
            
            double expected = Convert.ToDouble(Convert.ToString(TestContext.DataRow["expected"]));

            if (precision <= 0)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => RootFinder.FindNthRoot(number, degree, precision));
            }
            else
            {
                Assert.AreEqual(expected, RootFinder.FindNthRoot(number, degree, precision));
            }
        }
    }
}
