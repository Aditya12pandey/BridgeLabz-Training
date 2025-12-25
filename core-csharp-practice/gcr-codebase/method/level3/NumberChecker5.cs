using System;

public static class NumberChecker5
{
    public static int[] FindFactors(int number)
    {
        int count = 0;

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                count++;
        }

        int[] factors = new int[count];
        int index = 0;

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                factors[index++] = i;
        }

        return factors;
    }

    public static int FindGreatestFactor(int[] factors)
    {
        int max = factors[0];
        foreach (int f in factors)
        {
            if (f > max)
                max = f;
        }
        return max;
    }

    public static int SumOfFactors(int[] factors)
    {
        int sum = 0;
        foreach (int f in factors)
        {
            sum += f;
        }
        return sum;
    }

    public static long ProductOfFactors(int[] factors)
    {
        long product = 1;
        foreach (int f in factors)
        {
            product *= f;
        }
        return product;
    }
    public static double ProductOfCubeOfFactors(int[] factors)
    {
        double product = 1;
        foreach (int f in factors)
        {
            product *= Math.Pow(f, 3);
        }
        return product;
    }
    public static bool IsPerfectNumber(int number, int[] factors)
    {
        int sum = 0;
        foreach (int f in factors)
        {
            if (f != number)
                sum += f;
        }
        return sum == number;
    }

    public static bool IsAbundantNumber(int number, int[] factors)
    {
        int sum = 0;
        foreach (int f in factors)
        {
            if (f != number)
                sum += f;
        }
        return sum > number;
    }

    public static bool IsDeficientNumber(int number, int[] factors)
    {
        int sum = 0;
        foreach (int f in factors)
        {
            if (f != number)
                sum += f;
        }
        return sum < number;
    }

    public static bool IsStrongNumber(int number)
    {
        int temp = number;
        int sum = 0;

        while (temp > 0)
        {
            int digit = temp % 10;
            sum += Factorial(digit);
            temp /= 10;
        }
        return sum == number;
    }

    private static int Factorial(int n)
    {
        int fact = 1;
        for (int i = 1; i <= n; i++)
        {
            fact *= i;
        }
        return fact;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int[] factors = NumberChecker.FindFactors(number);
        Console.WriteLine("Factors: " + string.Join(", ", factors));

        Console.WriteLine("Greatest Factor: " + NumberChecker.FindGreatestFactor(factors));
        Console.WriteLine("Sum of Factors: " + NumberChecker.SumOfFactors(factors));
        Console.WriteLine("Product of Factors: " + NumberChecker.ProductOfFactors(factors));
        Console.WriteLine("Product of Cube of Factors: " + NumberChecker.ProductOfCubeOfFactors(factors));

        Console.WriteLine("Is Perfect Number: " + NumberChecker.IsPerfectNumber(number, factors));
        Console.WriteLine("Is Abundant Number: " + NumberChecker.IsAbundantNumber(number, factors));
        Console.WriteLine("Is Deficient Number: " + NumberChecker.IsDeficientNumber(number, factors));
        Console.WriteLine("Is Strong Number: " + NumberChecker.IsStrongNumber(number));
    }
}
