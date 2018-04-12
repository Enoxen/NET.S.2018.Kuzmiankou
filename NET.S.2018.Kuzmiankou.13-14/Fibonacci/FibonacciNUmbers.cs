using System;
using System.Collections.Generic;
using System.Numerics;

namespace Fibonacci
{
    /// <summary>
    /// Class provides methods for fibonacci serises generation.
    /// </summary>
    public static class FibonacciNumbers
    {
        /// <summary>
        /// Fibonacci series generation iterative implementation.
        /// </summary>
        /// <param name="amount">Amount of numbers to be generated.</param>
        /// <returns></returns>
        public static BigInteger[] GenerateFibonacciIter(int amount)
        {
            var fibb = new List<BigInteger>();

            BigInteger a = 0, b = 1, c = 0;

            fibb.Add(a);
            fibb.Add(b);

            for(int i = 2; i < amount; i++)
            {
                c = a + b;
                fibb.Add(c);
  
                a = b;
                b = c;
            }
            return fibb.ToArray();
        }

        /// <summary>
        /// Public method that invokes private implementation of recursive algorithm.
        /// </summary>
        /// <param name="amount">Amount of numbers to be generated.</param>
        /// <returns></returns>
        public static BigInteger[] GenerateFibonacciRecursive(int amount)
        {
            var fibb = new List<BigInteger>();
           

            FibRecursive(fibb, 0, 1, 1, amount);
            return fibb.ToArray();
        }

        /// <summary>
        /// Recursive generation
        /// </summary>
        /// <param name="fibb">List of fibonacci numbers</param>
        /// <param name="a">First parameter for recursive implementation</param>
        /// <param name="b">Second parameter for recursive implementation</param>
        /// <param name="counter">Counts iterations</param>
        /// <param name="amount">Amount of numbers to be generated.</param>
        private static void FibRecursive(List<BigInteger> fibb, BigInteger a, BigInteger b, int counter, int amount)
        {
            if(counter <= amount)
            {
                fibb.Add(a);
                FibRecursive(fibb, b, a + b, counter + 1, amount);
            }
        }
    }
}
