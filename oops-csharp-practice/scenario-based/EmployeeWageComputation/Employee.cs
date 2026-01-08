using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        public int WagePerHour { get; set; }
        public int WorkingHours { get; set; }
        public int DailyWage { get; set; }
        public int MonthlyWage { get; set; }
    }
}
