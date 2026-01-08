using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    public sealed class EmployeeMenu
    {
        public void ShowMenu()
        {
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
            Console.WriteLine("1. UC-1 Attendance");
            Console.WriteLine("2. UC-2 Daily Wage");
            Console.WriteLine("3. UC-3 Part-Time Wage");
            Console.WriteLine("4. UC-4 Switch Case Wage");
            Console.WriteLine("5. UC-5 Monthly Wage");
            Console.WriteLine("6. UC-6 Wage Till Condition");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: empUtility.CheckAttendance(); break;
                case 2: empUtility.CalculateDailyWage(); break;
                case 3: empUtility.CalculatePartTimeWage(); break;
                case 4: empUtility.CalculateWageUsingSwitch(); break;
                case 5: empUtility.CalculateMonthlyWage(); break;
                case 6: empUtility.CalculateWageTillCondition(); break;
                default: Console.WriteLine("Invalid Choice"); break;
            }
        }
    }
}
