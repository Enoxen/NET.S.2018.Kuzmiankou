using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerEvents;
using TimerEvents.Listeners;
using Fibonacci;
using System.Numerics;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              TimerManager manager = new TimerManager();
              FirstListener l1 = new FirstListener();
              SecondListener l2 = new SecondListener();

              l1.Register(manager);
              l2.Register(manager);

              manager.SimulateEndTime(5);

              l2.Unregister(manager);

              manager.SimulateEndTime(5);
              */
            var a = FibonacciNumbers.GenerateFibonacciRecursive(100);
            foreach(BigInteger b in a)
            {
                Console.Write(b + " ");
            }
        }
    }
}
