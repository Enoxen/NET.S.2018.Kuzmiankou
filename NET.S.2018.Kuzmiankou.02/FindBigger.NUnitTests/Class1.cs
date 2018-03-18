using System;
using NUnit.Framework;
using FindBigger;

namespace FindBigger.NUnitTests
{
    [TestFixture]
    public class FingBiggerNUnit
    {
        [Test]
        [TestCase(12,  21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(414, 441)]
        [TestCase(144, 414)]
        [TestCase(1234321, 1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        [TestCase(10, -1)]
        [TestCase(20, -1)]
        public void FindBiggerIntTestCasese(int number, int expected)
        {
            Assert.AreEqual(expected, BiggerInteger.FindNextBiggerNumber(number));
        }
    }
}
