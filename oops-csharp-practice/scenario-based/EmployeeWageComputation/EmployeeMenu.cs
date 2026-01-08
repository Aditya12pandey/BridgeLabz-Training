using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    sealed class EmployeeMenu
    {
        public void ShowMenu()
        {
   
             Console.WriteLine("\n Enter Employee Details ");

            Console.Write("Enter Employee ID   : ");
            int empId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name : ");
            string empName = Console.ReadLine();

            Console.Write("Enter Wage Per Hour : ");
            int wagePerHour = Convert.ToInt32(Console.ReadLine());

            Employee employee = new Employee
            {
                EmpId = empId,
                EmpName = empName,
                WagePerHour = wagePerHour
            };

            IEmployee empUtility = new EmployeeUtility(employee);

            Console.WriteLine("\n MENU ");
            Console.WriteLine("1. UC-1 Check Employee Attendance");
            Console.WriteLine("2. UC-2 Calculate Daily Wage");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    empUtility.CheckAttendance();
                break;

                case 2:
                    empUtility.CalculateDailyWage();
                break;

                default:
                    Console.WriteLine(" Invalid Choice");
                break;
            }
        }
    }
}
