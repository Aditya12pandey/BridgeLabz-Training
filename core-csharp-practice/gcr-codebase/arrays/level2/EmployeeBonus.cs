using System;

class EmployeeBonus
{
    static void Main()
    {
        int employeeCount = 10;

        double[] salary = new double[employeeCount];
        double[] yearsOfService = new double[employeeCount];
        double[] bonus = new double[employeeCount];
        double[] newSalary = new double[employeeCount];

        double totalBonus = 0.0;
        double totalOldSalary = 0.0;
        double totalNewSalary = 0.0;

        Console.WriteLine("Enter salary and years of service for 10 employees:");

        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine($"\nEmployee {i + 1}:");

            Console.Write("Enter Salary: ");
            salary[i] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Years of Service: ");
            yearsOfService[i] = Convert.ToDouble(Console.ReadLine());

            if (salary[i] <= 0 || yearsOfService[i] < 0)
            {
                Console.WriteLine("Invalid input! Please enter valid salary and years of service.");
                i--; // decrement index to re-enter values
                continue;
            }
        }

        for (int i = 0; i < employeeCount; i++)
        {
            if (yearsOfService[i] > 5)
            {
                bonus[i] = salary[i] * 0.05; // 5% bonus
            }
            else
            {
                bonus[i] = salary[i] * 0.02; // 2% bonus
            }

            newSalary[i] = salary[i] + bonus[i];

            totalBonus += bonus[i];
            totalOldSalary += salary[i];
            totalNewSalary += newSalary[i];
        }

        Console.WriteLine("\nEmployee Salary Details:");
        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine(
                $"Employee {i + 1}: Old Salary = {salary[i]}, Bonus = {bonus[i]}, New Salary = {newSalary[i]}"
            );
        }

        Console.WriteLine($"Total Old Salary = {totalOldSalary}");
        Console.WriteLine($"Total Bonus Paid = {totalBonus}");
        Console.WriteLine($"Total New Salary = {totalNewSalary}");
    }
}
