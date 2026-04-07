using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWageComputation
{
    internal class EmployeeMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to Employee Wage Program ");

            EmployeeMenu menu = new EmployeeMenu();
            menu.ShowMenu();

            Console.WriteLine("\nThank you for using the application!");
        }

    }
}
