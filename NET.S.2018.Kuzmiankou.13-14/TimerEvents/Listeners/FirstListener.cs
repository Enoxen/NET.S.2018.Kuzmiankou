using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerEvents.EventArgs;

namespace TimerEvents.Listeners
{
    public sealed class FirstListener
    {
        public FirstListener() { }

        public void Register(TimerManager manager)
        {
            manager.EndTime += FirstListenerMsg;
        }

        public void Unregister(TimerManager manager)
        {
            manager.EndTime -= FirstListenerMsg;
        }

        private void FirstListenerMsg(object sender, EndTimeEventArgs args)
        {
            Console.WriteLine("First listener message:");
            Console.WriteLine($"Time ended on = {args.timeOfEvent.TimeOfDay}");
        }
    }
}
