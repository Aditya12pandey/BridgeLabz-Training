using System;

class AbundantNumber
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int sum = 0;

        for (int i = 1; i < number; i++)
        {
            if (number % i == 0) // Check if i is a divisor
            {
                sum += i; // Add divisor to sum
            }
        }

        if (sum > number)
        {
            Console.WriteLine(number + " is an Abundant Number.");
        }
        else
        {
            Console.WriteLine(number + " is not an Abundant Number.");
        }
    }
}
