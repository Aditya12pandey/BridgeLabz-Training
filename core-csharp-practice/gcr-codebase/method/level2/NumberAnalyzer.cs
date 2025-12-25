using System;

public class NumberAnalyzer
{
    public static bool IsPositive(int number)
    {
        return number >= 0;
    }

    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public static int Compare(int number1, int number2)
    {
        if (number1 > number2) return 1;
        else if (number1 == number2) return 0;
        else return -1;
    }

    public static void Main(string[] args)
    {
        int[] numbers = new int[5];

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter number {i + 1}: ");
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nAnalysis of numbers:");
        for (int i = 0; i < numbers.Length; i++)
        {
            int num = numbers[i];
            if (IsPositive(num))
            {
                if (IsEven(num))
                {
                    Console.WriteLine($"{num} is positive and even");
                }
                else
                {
                    Console.WriteLine($"{num} is positive and odd");
                }
            }
            else
            {
                Console.WriteLine($"{num} is negative");
            }
        }

        int comparisonResult = Compare(numbers[0], numbers[4]);
        Console.WriteLine("\nComparison of first and last numbers:");
        if (comparisonResult == 1)
        {
            Console.WriteLine($"First number ({numbers[0]}) is greater than last number ({numbers[4]})");
        }
        else if (comparisonResult == 0)
        {
            Console.WriteLine($"First number ({numbers[0]}) is equal to last number ({numbers[4]})");
        }
        else
        {
            Console.WriteLine($"First number ({numbers[0]}) is less than last number ({numbers[4]})");
        }
    }
}
