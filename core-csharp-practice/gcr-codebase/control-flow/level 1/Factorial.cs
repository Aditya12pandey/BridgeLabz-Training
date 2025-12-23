using System;

class Factorial
{
    static void Main()
    {
        int number;
        long factorial = 1;
        int i = 1;

        Console.Write("Enter a positive integer: ");
        number = int.Parse(Console.ReadLine());

        // Check if the number is positive
        if (number < 0)
        {
            Console.WriteLine("Please enter a positive integer.");
        }
        else
        {
            while (i <= number)
            {
                factorial = factorial * i;
                i++;
            }

            Console.WriteLine("The factorial of " + number + " is " + factorial);
        }
    }
}
