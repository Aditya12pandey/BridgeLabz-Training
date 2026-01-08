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
            Console.WriteLine("\n Employee Details ");

            Console.Write("Enter Employee ID   : ");
            int empId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name : ");
            string empName = Console.ReadLine();

            Employee employee = new Employee
            {
                EmpId = empId,
                EmpName = empName
            };

            IEmployee empUtility = new EmployeeUtility(employee);

            Console.WriteLine("\n MENU ");
            Console.WriteLine("1. Check Employee Attendance (UC-1)");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    empUtility.CheckAttendance();
                    break;

                default:
                    Console.WriteLine("❌ Invalid choice");
                    break;
            }
        }
    }
}
