using System;
using System.Collections.Generic;
using System.Numerics;

namespace Fibonacci
{
    public static class FibonacciNumbers
    {
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

        public static BigInteger[] GenerateFibonacciRecursive(int amount)
        {
            var fibb = new List<BigInteger>();
           

            FibRecursive(fibb, 0, 1, 1, amount);
            return fibb.ToArray();
        }

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
