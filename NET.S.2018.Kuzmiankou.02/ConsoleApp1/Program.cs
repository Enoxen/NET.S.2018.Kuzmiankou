using System;
using insert;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int var = 9;
            Console.WriteLine(BitInsert.InsertNumber(ref var, 1, 10, 11));
        }
    }
}
