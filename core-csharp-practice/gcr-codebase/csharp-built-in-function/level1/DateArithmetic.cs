using System;

class DateArithmetic
{
    static void Main()
    {
        Console.Write("Enter a date (yyyy-MM-dd): ");
        DateTime inputDate = DateTime.Parse(Console.ReadLine());

        DateTime resultDate = inputDate.AddDays(7);

        resultDate = resultDate.AddMonths(1);

        resultDate = resultDate.AddYears(2);

        resultDate = resultDate.AddDays(-21);

        Console.WriteLine("\nFinal Date after calculations:");
        Console.WriteLine(resultDate.ToString("yyyy-MM-dd"));
    }
}
