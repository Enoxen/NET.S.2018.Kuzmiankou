using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task6.Solution;

namespace Task6.Tests
{
    [TestFixture]
    public class CustomEnumerableTests
    {
        [Test]
        public void Generator_ForSequence1()
        {
            int[] expected = {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};
            var gen = new FunctionGenerator<int>(1, 1);
            var list = new List<int>();
            foreach (var t in gen.GenerateByFirstRule(10))
            {
                list.Add(t);
            }
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [Test]
        public void Generator_ForSequence2()
        {
            int[] expected = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };
            var gen = new FunctionGenerator<int>(1, 2);
            var list = new List<int>();
            foreach (var t in gen.GenerateBySecondRule(10))
            {
                list.Add(t);
            }
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [Test]
        public void Generator_ForSequence3()
        {
            double[] expected = { 1, 2, 2.5, 3.3, 4.05757575757576, 4.87086926018965, 5.70389834408211, 6.55785277425587, 7.42763417076325, 8.31053343902137 };

            var gen = new FunctionGenerator<double>(1, 2);
            var list = new List<double>();
            foreach (var t in gen.GenerateByThirdRule(10))
            {
                list.Add(t);
            }
            CollectionAssert.AreEqual(expected, list.ToArray());
        }
    }
}
