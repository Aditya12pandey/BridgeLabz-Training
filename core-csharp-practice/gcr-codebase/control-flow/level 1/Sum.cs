using System;

class Sum
{
    static void Main()
    {
        double total = 0.0;
        double number;

        while (true)
        {
            Console.Write("Enter a number (0 or negative to stop): ");
            number = double.Parse(Console.ReadLine());

            if (number <= 0)
            {
                break;
            }

            total += number;
        }

        Console.WriteLine("The total sum is " + total);
    }
}
