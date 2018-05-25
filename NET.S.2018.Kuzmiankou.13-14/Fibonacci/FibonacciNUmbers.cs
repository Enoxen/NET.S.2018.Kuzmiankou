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
        public static IEnumerable<BigInteger> GenerateFibonacci(int amount)
        {
            BigInteger a = 0, b = 1, c = 0;
            yield return 0;
            yield return 1;
            for (int i = 2; i < amount; i++)
            {
                c = a + b;
                a = b;
                b = c;
                yield return c;
            }
        }
    }
}
