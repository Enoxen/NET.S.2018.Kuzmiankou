using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nod.TestsMsUnit
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
        public void NodEuclidDDTTest()
        {
            
        }
    }
}
