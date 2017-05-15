using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;


namespace GA            
{
    class Timing          //时间性能测试
    {
        private TimeSpan startingtime;
        private TimeSpan duration;
        public Timing()
        {
            startingtime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }

        public void StopTime()
        {
            duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startingtime);
        }
        public void startTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startingtime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
}
