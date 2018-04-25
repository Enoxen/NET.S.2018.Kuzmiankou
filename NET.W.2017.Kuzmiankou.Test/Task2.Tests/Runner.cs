using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Solution;

namespace Task2.Tests
{
    static class Runner
    {
        public static void Main(string[] args)
        {
            var gen = new RandomBytesFileGenerator(@"D:\hjfgh\dir1", ".txt");
            gen.GenerateFiles(1, 100);

            var gen1 = new RandomCharsFileGenerator(@"D:\hjfgh\dir", ".txt");
            gen1.GenerateFiles(1, 100);
        }
    }
}
