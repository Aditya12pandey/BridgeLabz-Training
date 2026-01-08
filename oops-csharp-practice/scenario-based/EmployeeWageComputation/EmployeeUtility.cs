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
            int attendance = random.Next(0, 2);
            Console.WriteLine(attendance == 1 ? "Employee is Present" : "Employee is Absent");
        }

        // UC-2
        public void CalculateDailyWage()
        {
            int attendance = random.Next(0, 2);

            if (attendance == 1)
            {
                employee.WorkingHours = 8;
                employee.DailyWage = employee.WorkingHours * employee.WagePerHour;
                Console.WriteLine("Daily Wage : " + employee.DailyWage);
            }
            else
            {
                Console.WriteLine("Daily Wage : 0");
            }
        }

        // UC-3
        public void CalculatePartTimeWage()
        {
            int empType = random.Next(0, 3);

            if (empType == 1)
                employee.WorkingHours = 8;
            else if (empType == 2)
                employee.WorkingHours = 4;
            else
                employee.WorkingHours = 0;

            employee.DailyWage = employee.WorkingHours * employee.WagePerHour;
            Console.WriteLine("Daily Wage : " + employee.DailyWage);
        }

        // UC-4
        public void CalculateWageUsingSwitch()
        {
            int empType = random.Next(0, 3);

            switch (empType)
            {
                case 1: employee.WorkingHours = 8; break;
                case 2: employee.WorkingHours = 4; break;
                default: employee.WorkingHours = 0; break;
            }

            employee.DailyWage = employee.WorkingHours * employee.WagePerHour;
            Console.WriteLine("Daily Wage : " + employee.DailyWage);
        }

        // UC-5
        public void CalculateMonthlyWage()
        {
            int TOTAL_DAYS = 20;
            employee.MonthlyWage = 0;

            for (int day = 1; day <= TOTAL_DAYS; day++)
            {
                int empType = random.Next(0, 3);

                switch (empType)
                {
                    case 1: employee.WorkingHours = 8; break;
                    case 2: employee.WorkingHours = 4; break;
                    default: employee.WorkingHours = 0; break;
                }

                employee.MonthlyWage += employee.WorkingHours * employee.WagePerHour;
            }

            Console.WriteLine("Monthly Wage : " + employee.MonthlyWage);
        }

        // UC-6 (NEW)
        public void CalculateWageTillCondition()
        {
            int MAX_DAYS = 20;
            int MAX_HOURS = 100;

            employee.TotalWorkingDays = 0;
            employee.TotalWorkingHours = 0;
            employee.MonthlyWage = 0;

            while (employee.TotalWorkingDays < MAX_DAYS &&
                   employee.TotalWorkingHours < MAX_HOURS)
            {
                employee.TotalWorkingDays++;

                int empType = random.Next(0, 3);
                switch (empType)
                {
                    case 1: employee.WorkingHours = 8; break;
                    case 2: employee.WorkingHours = 4; break;
                    default: employee.WorkingHours = 0; break;
                }

                employee.TotalWorkingHours += employee.WorkingHours;
                employee.MonthlyWage += employee.WorkingHours * employee.WagePerHour;
            }

            Console.WriteLine("Total Working Days  : " + employee.TotalWorkingDays);
            Console.WriteLine("Total Working Hours : " + employee.TotalWorkingHours);
            Console.WriteLine("Total Wage          : " + employee.MonthlyWage);
        }
    }
}
