using System;

public static class NumberChecker4
{
    public static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    public static bool IsNeon(int number)
    {
        int square = number * number;
        int sum = 0;

        while (square > 0)
        {
            sum += square % 10;
            square /= 10;
        }

        return sum == number;
    }

    public static bool IsSpy(int number)
    {
        int sum = 0;
        int product = 1;
        int temp = number;

        while (temp > 0)
        {
            int digit = temp % 10;
            sum += digit;
            product *= digit;
            temp /= 10;
        }

        return sum == product;
    }

    public static bool IsAutomorphic(int number)
    {
        int square = number * number;
        return square.ToString().EndsWith(number.ToString());
    }
	
    public static bool IsBuzz(int number)
    {
        return number % 7 == 0 || number % 10 == 7;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Is Prime Number: " + NumberChecker.IsPrime(number));
        Console.WriteLine("Is Neon Number: " + NumberChecker.IsNeon(number));
        Console.WriteLine("Is Spy Number: " + NumberChecker.IsSpy(number));
        Console.WriteLine("Is Automorphic Number: " + NumberChecker.IsAutomorphic(number));
        Console.WriteLine("Is Buzz Number: " + NumberChecker.IsBuzz(number));
    }
}
