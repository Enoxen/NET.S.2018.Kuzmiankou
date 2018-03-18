using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindBigger;

namespace FindBigger.Test
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { set; get; }
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\FindIntTestData.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("FindBigger\\FindIntTestData.xml")]
        [TestMethod]
        public void DDT_Test_FindInteger()
        {
            int number = Convert.ToInt32(TestContext.DataRow["number"]);

            int result = BiggerInteger.FindNextBiggerNumber(number);

            int expected = Convert.ToInt32(TestContext.DataRow["expected"]);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionTest_ArgumentOutOfRange()
        {
            int number = -1;

            BiggerInteger.FindNextBiggerNumber(number);
        }


    }
}
