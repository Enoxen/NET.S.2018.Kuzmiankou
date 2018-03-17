using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayFilter;


namespace DDTArrayFilterTest
{
    [TestClass]
    public class ArrayFilterTest
    {   
        /// <summary>
        /// I don't know, but DDT launches onlu for one test case from xml file.
        /// And tests launch only when xml file is inside the debug folder.
        /// </summary>
        public TestContext TestContext { set; get; }
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\DigitFilterTestData.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("DDTArrayFilterTest\\DigitFilterTestData.xml")]
        [TestMethod]
        public void ArrayFilterTestMethod()
        {
            string temp = (string)TestContext.DataRow["array"];
            string[] tempArray = temp.Split(',');
            List<int> array = new List<int>();

            foreach (string element in tempArray)
            {
                array.Add(int.Parse(element.Trim()));
            }

            int digit = Convert.ToInt32((string)TestContext.DataRow["digit"]);

            temp = (string) TestContext.DataRow["result"];
            tempArray = temp.Split(',');
            List<int> result = new List<int>();

            foreach (string element in tempArray)
            {
                result.Add(int.Parse(element.Trim()));
            }
            
            CollectionAssert.AreEquivalent(Filter.DigitFilter(array.ToArray(),digit), result.ToArray() );

        }
    }
}
