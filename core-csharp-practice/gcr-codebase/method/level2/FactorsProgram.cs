using System;

class FactorsProgram
{
    static int[] FindFactors(int number)
    {
        int count = 0;

        // First loop to count factors
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                count++;
        }

        int[] factors = new int[count];
        int index = 0;

        // Second loop to store factors
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                factors[index] = i;
                index++;
            }
        }

        return factors;
    }
    static int FindSum(int[] factors)
    {
        int sum = 0;
        foreach (int factor in factors)
        {
            sum += factor;
        }
        return sum;
    }

    static long FindProduct(int[] factors)
    {
        long product = 1;
        foreach (int factor in factors)
        {
            product *= factor;
        }
        return product;
    }

    static double FindSumOfSquares(int[] factors)
    {
        double sumOfSquares = 0;
        foreach (int factor in factors)
        {
            sumOfSquares += Math.Pow(factor, 2);
        }
        return sumOfSquares;
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] factors = FindFactors(number);

        Console.WriteLine("Factors of " + number + " are:");
        foreach (int factor in factors)
        {
            Console.Write(factor + " ");
        }
        Console.WriteLine();

        int sum = FindSum(factors);
        long product = FindProduct(factors);
        double sumOfSquares = FindSumOfSquares(factors);

        Console.WriteLine("Sum of factors: " + sum);
        Console.WriteLine("Product of factors: " + product);
        Console.WriteLine("Sum of squares of factors: " + sumOfSquares);
    }
}
