using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    
    internal class EmployeeUtility : IEmployee
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
            Console.WriteLine("\nEmployee ID   : " + employee.EmpId);
            Console.WriteLine("Employee Name : " + employee.EmpName);

            int attendance = random.Next(0, 2);
            Console.WriteLine(attendance == 1
                ? "Employee is Present"
                : "Employee is Absent");
        }

        // UC-2
        public void CalculateDailyWage()
        {
            int attendance = random.Next(0, 2);

            if (attendance == 1)
            {
                employee.WorkingHours = 8;
                employee.DailyWage = employee.WorkingHours * employee.WagePerHour;
                Console.WriteLine("Employee is Present");
                Console.WriteLine("Daily Wage : " + employee.DailyWage);
            }
            else
            {
                Console.WriteLine("Employee is Absent");
                Console.WriteLine("Daily Wage : 0");
            }
        }

        // UC-3
        public void CalculatePartTimeWage()
        {
            int empType = random.Next(0, 3);

            if (empType == 1)
            {
                employee.WorkingHours = 8;
                Console.WriteLine("Full-Time Employee");
            }
            else if (empType == 2)
            {
                employee.WorkingHours = 4;
                Console.WriteLine("Part-Time Employee");
            }
            else
            {
                employee.WorkingHours = 0;
                Console.WriteLine("Employee is Absent");
            }

            employee.DailyWage = employee.WorkingHours * employee.WagePerHour;
            Console.WriteLine("Daily Wage : " + employee.DailyWage);
        }

        // UC-4 
        public void CalculateWageUsingSwitch()
        {
            int empType = random.Next(0, 3);

            switch (empType)
            {
                case 1:
                    employee.WorkingHours = 8;
                    Console.WriteLine("Employee Type : Full-Time");
                    break;

                case 2:
                    employee.WorkingHours = 4;
                    Console.WriteLine("Employee Type : Part-Time");
                    break;

                default:
                    employee.WorkingHours = 0;
                    Console.WriteLine("Employee Type : Absent");
                    break;
            }

            employee.DailyWage = employee.WorkingHours * employee.WagePerHour;
            Console.WriteLine("Daily Wage    : " + employee.DailyWage);
        }
    }
}
