using System;
using System.Configuration;
using static StreamsDemo.StreamsExtension;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //var source = ConfigurationManager.AppSettings["sourceFilePath"];
            string source = @"..\..\..\Resources\SourceFile.txt";
            string destination = @"..\..\..\Resources\DestinationFile.txt";
            //var destination = ConfigurationManager.AppSettings["destinationFiePath"];

            //Console.WriteLine($"ByteCopy() done. Total bytes: {ByByteCopy(source, destination)}");

            //Console.WriteLine($"ByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destination)}");

            //Console.WriteLine($"InMemoryByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destination)}");
            Console.WriteLine($"InMemoryByteCopy() done. Total bytes: {ByBlockCopy(source, destination)}");
            //Console.WriteLine(IsContentEquals(source, destination));

            //etc
        }
    }
}
