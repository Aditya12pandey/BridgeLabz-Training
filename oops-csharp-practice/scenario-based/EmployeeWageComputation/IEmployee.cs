using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    internal interface IEmployee
    {
        void CheckAttendance();      // UC-1
        void CalculateDailyWage();   // UC-2
    }
}
