using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PerformanceService
    {
        public string LongRunningTask()
        {
            Thread.Sleep(3000); // 3 seconds
            return "Completed";
        }
    }
}
