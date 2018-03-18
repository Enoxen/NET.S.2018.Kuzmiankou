using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using insert;

namespace BitInsert.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { set; get; }
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\BitInsertTestData.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("BitInsert.Tests\\BitInsertTestData.xml")]
        [TestMethod]
        public void DDT_BitInsert()
        {
            int firstNumber = Convert.ToInt32(TestContext.DataRow["firstNumber"]);
            int secondNumber = Convert.ToInt32(TestContext.DataRow["secondNumber"]);
            int i = Convert.ToInt32(TestContext.DataRow["i"]);
            int j = Convert.ToInt32(TestContext.DataRow["j"]);
            int expected = Convert.ToInt32(TestContext.DataRow["expected"]);

            if (i < 0 || i > 31)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => Insert.InsertNumber(ref firstNumber, secondNumber, i, j));
            }
            else
            if (j < 0 || j > 31 || j < i)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => Insert.InsertNumber(ref firstNumber, secondNumber, i, j));

            }
            else
            {

                Insert.InsertNumber(ref firstNumber, secondNumber, i, j);

                Assert.AreEqual(expected, firstNumber);
            }




        }
    }
}
