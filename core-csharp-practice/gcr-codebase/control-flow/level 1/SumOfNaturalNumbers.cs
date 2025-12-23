using System;

class SumOfNaturalNumbers
{
    static void Main()
    {
        int n;
        int sumWhile = 0;
        int i = 1;

        Console.Write("Enter a natural number: ");
        n = int.Parse(Console.ReadLine());

        if (n <= 0)
        {
            Console.WriteLine("Please enter a valid natural number.");
        }
        else
        {
            // Sum using while loop
            while (i <= n)
            {
                sumWhile += i;
                i++;
            }

            // Sum using formula
            int sumFormula = n * (n + 1) / 2;

            Console.WriteLine("Sum using while loop = " + sumWhile);
            Console.WriteLine("Sum using formula   = " + sumFormula);

            if (sumWhile == sumFormula)
            {
                Console.WriteLine("Both computations are correct.");
            }
            else
            {
                Console.WriteLine("The computations do not match.");
            }
        }
    }
}
