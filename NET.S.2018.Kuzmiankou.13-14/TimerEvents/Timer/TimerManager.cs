using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerEvents.EventArgs;
namespace TimerEvents
{
    /// <summary>
    /// Observer timer countdown class.
    /// </summary>
    public class TimerManager
    {
        /// <summary>
        /// Event delegate.
        /// </summary>
        public event EventHandler<EndTimeEventArgs> EndTime = delegate { };

        /// <summary>
        /// Notifies all subscribers about event.
        /// </summary>
        /// <param name="eventArgs">Contains information about event</param>
        protected virtual void OnEndTime(EndTimeEventArgs eventArgs)
        {
            EndTime?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Simulates timer countdown. On zero invokes OnEndTime method to notify subscribers.
        /// </summary>
        /// <param name="waitSeconds">Amount of seconds to wait.</param>
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
