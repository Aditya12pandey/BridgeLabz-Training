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

        public EmployeeUtility(Employee emp)
        {
            employee = emp;
        }

        // UC-1
        public void CheckAttendance()
        {
            Console.WriteLine("\n Employee Details ");
            Console.WriteLine("Employee ID   : " + employee.EmpId);
            Console.WriteLine("Employee Name : " + employee.EmpName);

            int attendance = random.Next(0, 2);

            Console.WriteLine("\n Attendance Status ");
            if (attendance == 1)
                Console.WriteLine(" Employee is Present");
            else
                Console.WriteLine(" Employee is Absent");
        }

        // UC-2
        public void CalculateDailyWage()
        {
            Console.WriteLine("\n Employee Details ");
            Console.WriteLine("Employee ID   : " + employee.EmpId);
            Console.WriteLine("Employee Name : " + employee.EmpName);

            int attendance = random.Next(0, 2);

            if (attendance == 1)
            {
                employee.WorkingHours = 8;
                employee.DailyWage = employee.WorkingHours * employee.WagePerHour;

                Console.WriteLine("\n Employee is Present");
                Console.WriteLine("Working Hours : " + employee.WorkingHours);
                Console.WriteLine("Daily Wage    : " + employee.DailyWage);
            }
            else
            {
                employee.DailyWage = 0;
                Console.WriteLine("\n Employee is Absent");
                Console.WriteLine("Daily Wage    : 0");
            }
        }


    }
}
