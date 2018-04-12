using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerEvents.EventArgs;
namespace TimerEvents
{
    public class TimerManager
    {

        public event EventHandler<EndTimeEventArgs> EndTime = delegate { };

        protected virtual void OnEndTime(EndTimeEventArgs eventArgs)
        {
            EndTime?.Invoke(this, eventArgs);
        }

        public void SimulateEndTime(int waitSeconds)
        {
            var startTime = DateTime.Now;
    
            while(waitSeconds != 0)
            {
                if(DateTime.Now.Second - startTime.Second == 1)
                {
                    startTime = DateTime.Now;
                    waitSeconds--;
                }
            }

            EndTimeEventArgs args = new EndTimeEventArgs();

            OnEndTime(args);
        }

    }
}
