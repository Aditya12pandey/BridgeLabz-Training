using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    internal class EmployeeUtility: IEmployee
    {
        Employee employee;
        Random random = new Random();

        // Accept employee from menu
        public EmployeeUtility(Employee emp)
        {
            employee = emp;
        }

        // UC-1 Logic
        public void CheckAttendance()
        {
            Console.WriteLine("Employee ID   : " + employee.EmpId);
            Console.WriteLine("Employee Name : " + employee.EmpName);

            int attendance = random.Next(0, 2);

            Console.WriteLine("\n Attendance Status");
            if (attendance == 1)
                Console.WriteLine("✅ Employee is Present");
            else
                Console.WriteLine("❌ Employee is Absent");
        }

    }
}
