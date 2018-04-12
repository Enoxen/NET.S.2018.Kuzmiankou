using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerEvents.EventArgs;

namespace TimerEvents.Listeners
{
    public sealed class SecondListener
    {
        public SecondListener() { }

        public void Register(TimerManager manager)
        {
            manager.EndTime += SecondListenerMsg;
        }

        public void Unregister(TimerManager manager)
        {
            manager.EndTime -= SecondListenerMsg;
        }

        private void SecondListenerMsg(object sender, EndTimeEventArgs args)
        {
            Console.WriteLine("Second listener message:");
            Console.WriteLine($"Time ended on = {args.timeOfEvent.TimeOfDay} " );
        }
    }
}
