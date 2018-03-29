using System;
using NUnit.Framework;
using nod;

namespace NodTests
{
    [TestFixture]
    public class NodTests
    {
        [Test]
        [TestCase(5, new int[] { 10, 15, 25 })]
        [TestCase(1, new int[] { 1, 3, 5, 100})]
        [TestCase(int.MaxValue, new int[] { int.MaxValue, int.MaxValue })]
        [TestCase(-1, new int[] { int.MinValue, int.MaxValue })]
        public void FindNodEuclid_Tests(int expected, int[] numbers)
        {
            int actual = Nod.FindNodEuclid(numbers);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1)]
        public void FindNodEuclid_Exception_Test(int number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Nod.FindNodEuclid(number));
        }

        [Test]
        [TestCase(5, new int[] { 10, 15, 25 })]
        [TestCase(1, new int[] { 1, 3, 5, 100 })]
        [TestCase(int.MaxValue, new int[] { int.MaxValue, int.MaxValue})]
        [TestCase(-1, new int[] { int.MinValue, int.MaxValue })]
        public void FindSteinsNod_Tests(int expected, int[] numbers)
        {
            int actual = Nod.FindSteinsNod(numbers);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1)]
        public void FindSteinsNod_Exception_Test(int number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Nod.FindSteinsNod(number));
        }
    }
}
