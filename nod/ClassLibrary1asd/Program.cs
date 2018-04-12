using System;
using FloatToBinary;
using System.Runtime.InteropServices;
using ToDecimal;
using Polynomial;

namespace ClassLibrary1asd
{
    class Program
    { 
        static void Main(string[] args)
        {
            Polynom p1 = new Polynom(1, 2, 3);
            Polynom p2 = new Polynom(1, 2, 2);
            Polynom p3 = p1 - p2;

            /* for(int i = 0; i <= p3.Degree; i++)
             {
                 Console.WriteLine(p3[i]);
             }
             */
            Console.WriteLine(p1 != p2);

        }
    }
}
