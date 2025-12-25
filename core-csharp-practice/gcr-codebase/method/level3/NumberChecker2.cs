using System;

public static class NumberChecker2
{
    public static int CountDigits(int number)
    {
        number = Math.Abs(number);
        return number.ToString().Length;
    }

    public static int[] StoreDigits(int number)
    {
        number = Math.Abs(number);
        int count = CountDigits(number);
        int[] digits = new int[count];

        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = number % 10;
            number /= 10;
        }
        return digits;
    }

    public static int SumOfDigits(int[] digits)
    {
        int sum = 0;
        foreach (int d in digits)
        {
            sum += d;
        }
        return sum;
    }

    public static int SumOfSquaresOfDigits(int[] digits)
    {
        int sum = 0;
        foreach (int d in digits)
        {
            sum += (int)Math.Pow(d, 2);
        }
        return sum;
    }

    public static bool IsHarshadNumber(int number, int[] digits)
    {
        int sum = SumOfDigits(digits);
        return sum != 0 && number % sum == 0;
    }

    public static int[,] FindDigitFrequency(int[] digits)
    {
        int[,] frequency = new int[10, 2];

        for (int i = 0; i < 10; i++)
        {
            frequency[i, 0] = i;   // digit
            frequency[i, 1] = 0;   // frequency
        }

        foreach (int d in digits)
        {
            frequency[d, 1]++;
        }

        return frequency;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int count = NumberChecker.CountDigits(number);
        Console.WriteLine("Digit Count: " + count);

        int[] digits = NumberChecker.StoreDigits(number);
        Console.WriteLine("Digits: " + string.Join(", ", digits));

        int sum = NumberChecker.SumOfDigits(digits);
        Console.WriteLine("Sum of Digits: " + sum);

        int squareSum = NumberChecker.SumOfSquaresOfDigits(digits);
        Console.WriteLine("Sum of Squares of Digits: " + squareSum);

        bool isHarshad = NumberChecker.IsHarshadNumber(number, digits);
        Console.WriteLine("Is Harshad Number: " + isHarshad);

        int[,] frequency = NumberChecker.FindDigitFrequency(digits);

        Console.WriteLine("\nDigit Frequency:");
        Console.WriteLine("Digit\tFrequency");
        for (int i = 0; i < 10; i++)
        {
            if (frequency[i, 1] > 0)
            {
                Console.WriteLine($"{frequency[i, 0]}\t{frequency[i, 1]}");
            }
        }
    }
}
