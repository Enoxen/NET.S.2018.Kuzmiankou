using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerEvents.EventArgs
{   
    /// <summary>
    /// Stores system time when event occured.
    /// </summary>
    public class EndTimeEventArgs
    {
        /// <summary>
        /// Time when event occured
        /// </summary>
        public readonly DateTime timeOfEvent;

        /// <summary>
        /// Constructor for initialization.
        /// </summary>
        /// <param name="timeOfEvent"></param>
        /// <param name="mFrom"></param>
        /// <param name="mTo"></param>
        public EndTimeEventArgs()
        {
            this.timeOfEvent = DateTime.Now;

        }
        
    }
}
