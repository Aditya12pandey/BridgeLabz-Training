using System;

class SumUntilZero
{
    static void Main()
    {
        double total = 0.0;
        double number;

        Console.Write("Enter a number (0 to stop): ");
        number = double.Parse(Console.ReadLine());

        while (number != 0)
        {
            total += number;

            Console.Write("Enter a number (0 to stop): ");
            number = double.Parse(Console.ReadLine());
        }

        Console.WriteLine("The total sum is " + total);
    }
}
