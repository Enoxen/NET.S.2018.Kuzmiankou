using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alg_task_Variant1;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "перелом", "открытый", "подвывих", "закрытый" };
            Crossword cross = new Crossword(words);
            cross.FillCrossword();
            char[,] f = cross.GetField();

            for (int i = 0; i < f.GetLength(0); i++)
            {
                for (int j = 0; j < f.GetLength(1); j++)
                {
                    Console.Write(f[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
