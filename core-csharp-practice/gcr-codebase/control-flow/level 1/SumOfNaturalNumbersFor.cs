using System;

class SumOfNaturalNumbersFor
{
    static void Main()
    {
        int n;
        int sumForLoop = 0;
        int sumFormula;

        Console.Write("Enter a natural number: ");
        n = int.Parse(Console.ReadLine());

        // Check if n is a natural number
        if (n <= 0)
        {
            Console.WriteLine("Please enter a valid natural number.");
        }
        else
        {
            // Calculate sum using for loop
            for (int i = 1; i <= n; i++)
            {
                sumForLoop += i;
            }

            // Calculate sum using formula
            sumFormula = n * (n + 1) / 2;

            // Display results
            Console.WriteLine("Sum using for loop = " + sumForLoop);
            Console.WriteLine("Sum using formula = " + sumFormula);

            // Compare results
            if (sumForLoop == sumFormula)
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
