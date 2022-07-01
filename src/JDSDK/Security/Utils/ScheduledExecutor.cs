using System;
using System.Timers;

namespace Jd.ACES.Utils
{
    public delegate void ScheduleTask(Object obj, ElapsedEventArgs e);

    public class ScheduledExecutor : Timer
    {
        /// <summary>
        /// Constructor of ScheduledExecutor with given interval and given task.
        /// </summary>
        /// <param name="interval">The given interval, unit is second.</param>
        /// <param name="task">The given task to execute repeatedly.</param>
        public ScheduledExecutor(double interval, ScheduleTask task)
        {
            this.Interval = interval * 1000;
            this.Elapsed += new ElapsedEventHandler(task);
            this.AutoReset = true;
            this.Enabled = true;
        }

        /// <summary>
        /// Sets the interval, in seconds, for repeated execution.
        /// </summary>
        /// <param name="interval">The given interval, unit is second.</param>
        public void SetExecuteInterval(long interval)
        {
            this.Interval = interval * 1000;
        }
    }
}