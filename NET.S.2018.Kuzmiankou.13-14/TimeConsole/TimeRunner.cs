using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerEvents;
using TimerEvents.Listeners;
using Fibonacci;
using System.Numerics;
using BinarySearch;
namespace ConsoleApp1
{
    class TimeRunner
    {
        static void Main(string[] args)
        {
            /*StringBuilder bi = new StringBuilder();
            int a = 0;
            Console.WriteLine(ReferenceEquals(bi, null));
            Console.WriteLine(ReferenceEquals(a, null));

            TimerManager manager = new TimerManager();
            FirstListener l1 = new FirstListener();
            SecondListener l2 = new SecondListener();

            l1.Register(manager);
            l2.Register(manager);

            manager.SimulateEndTime(5);

            l2.Unregister(manager);

            manager.SimulateEndTime(5);*/

            foreach (var t in FibonacciNumbers.GenerateFibonacci(10))
            {
                Console.WriteLine(t);
            }

        }
    }
}
