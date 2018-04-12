using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ToDecimal;

namespace ToDecimalTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase("0110111101100001100001010111111", 2, 934331071)]
        [TestCase("01101111011001100001010111111", 2, 233620159)]
        [TestCase("11101101111011001100001010", 2, 62370570)]
        [TestCase("1AeF101", 16, 28242177)]
        [TestCase("1ACB67", 16, 1756007)]
        [TestCase("764241", 8, 256161)]
        [TestCase("10", 5, 5)]
        public void ToDecimalConverterTests(string numberString, int radix, int expected)
        {
            Notation notation = new Notation(radix);

            Assert.AreEqual(expected, numberString.ToDecimalConverter(notation));
        }
    }
}
