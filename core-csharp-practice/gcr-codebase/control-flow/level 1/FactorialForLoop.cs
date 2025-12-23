using System;

class FactorialForLoop
{
    static void Main()
    {
        int number;
        long factorial = 1;

        Console.Write("Enter a natural number: ");
        number = int.Parse(Console.ReadLine());

        if (number <= 0)
        {
            Console.WriteLine("Please enter a positive natural number.");
        }
        else
        {
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            Console.WriteLine("The factorial of " + number + " is " + factorial);
        }
    }
}

