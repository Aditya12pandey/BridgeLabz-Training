using System;

public class EmployeeBonusCalculator
{
    static Random random = new Random();

    public static double[,] GenerateEmployeeData(int employees)
    {
        double[,] data = new double[employees, 2];

        for (int i = 0; i < employees; i++)
        {
            // 5-digit salary (10000 – 99999)
            data[i, 0] = random.Next(10000, 100000);

            // Years of service (1 – 10)
            data[i, 1] = random.Next(1, 11);
        }
        return data;
    }

   
    public static double[,] CalculateBonus(double[,] oldData)
    {
        int employees = oldData.GetLength(0);
        double[,] newData = new double[employees, 2];

        for (int i = 0; i < employees; i++)
        {
            double salary = oldData[i, 0];
            double years = oldData[i, 1];

            double bonusRate = (years > 5) ? 0.05 : 0.02;
            double bonus = salary * bonusRate;
            double newSalary = salary + bonus;

            newData[i, 0] = newSalary;
            newData[i, 1] = bonus;
        }
        return newData;
    }

    public static void DisplayReport(double[,] oldData, double[,] newData)
    {
        double totalOldSalary = 0;
        double totalNewSalary = 0;
        double totalBonus = 0;

        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine("Emp\tOld Salary\tYears\tBonus\t\tNew Salary");
        Console.WriteLine("------------------------------------------------------------------------------------");

        for (int i = 0; i < oldData.GetLength(0); i++)
        {
            totalOldSalary += oldData[i, 0];
            totalNewSalary += newData[i, 0];
            totalBonus += newData[i, 1];

            Console.WriteLine(
                $"{i + 1}\t{oldData[i, 0],10:F2}\t{oldData[i, 1],5}\t{newData[i, 1],10:F2}\t{newData[i, 0],10:F2}"
            );
        }

        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine($"TOTAL\t{totalOldSalary,10:F2}\t\t{totalBonus,10:F2}\t{totalNewSalary,10:F2}");
        Console.WriteLine("------------------------------------------------------------------------------------");
    }

    public static void Main(string[] args)
    {
        int employees = 10;

        double[,] employeeData = GenerateEmployeeData(employees);
        double[,] updatedData = CalculateBonus(employeeData);

        DisplayReport(employeeData, updatedData);
    }
}
