using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            PrinterManager manager = new PrinterManager();
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new Epson printer");
            Console.WriteLine("2:Add new Canon printer");
            Console.WriteLine("3:Print on Canon");
            Console.WriteLine("4:Print on Epson");

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                CreateEpsonPrinter(manager);
            }

            if (key.Key == ConsoleKey.D2)
            {
                CreateCanonPrinter(manager);
            }

            if (key.Key == ConsoleKey.D3)
            {
             
            }

            if (key.Key == ConsoleKey.D4)
            {
                
            }
        }

        private static void Print(Printer printer, PrinterManager manager)
        {
            if (manager.OnStartPrinting.Invoke(printer))
            {
                manager.Print(printer);
                manager.OnEndPrinting(printer);
            }
            else
            {
                Console.WriteLine("There is no such printer");
            }
        }

        

        private static void CreateCanonPrinter(PrinterManager m)
        {
            string name = Console.ReadLine();
            string model = Console.ReadLine();

            m.Add(new CanonPrinter(name, model));
        }

        private static void CreateEpsonPrinter(PrinterManager m)
        {
            string name = Console.ReadLine();
            string model = Console.ReadLine();

            m.Add(new EpsonPrinter(name, model));
        }
    }
}
