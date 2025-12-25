using System;

class SumOfNaturalNumbersComparison
{
    static int SumUsingRecursion(int n)
    {
        if (n == 1)
            return 1;
        return n + SumUsingRecursion(n - 1);
    }

    static int SumUsingFormula(int n)
    {
        return n * (n + 1) / 2;
    }

    static void Main()
    {
        Console.Write("Enter a natural number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n <= 0)
        {
            Console.WriteLine("Not a natural number. Program terminated.");
            return;
        }

        int recursiveSum = SumUsingRecursion(n);
        int formulaSum = SumUsingFormula(n);

        Console.WriteLine("Sum using recursion: " + recursiveSum);
        Console.WriteLine("Sum using formula: " + formulaSum);

        if (recursiveSum == formulaSum)
            Console.WriteLine("Both computations give the same result. Result is correct.");
        else
            Console.WriteLine("Results do not match.");
    }
}
