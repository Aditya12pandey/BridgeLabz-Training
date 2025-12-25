using System;

public static class NumberChecker
{
    public static int CountDigits(int number)
    {
        return number.ToString().Length;
    }

    public static int[] GetDigitsArray(int number)
    {
        int count = CountDigits(number);
        int[] digits = new int[count];
        int temp = number;

        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = temp % 10;
            temp /= 10;
        }

        return digits;
    }

    // Method to check if a number is a duck number
    // Duck number: a number that has at least one non-zero digit
    public static bool IsDuckNumber(int[] digits)
    {
        foreach (int digit in digits)
        {
            if (digit != 0) return true;
        }
        return false;
    }

    // Method to check if a number is an Armstrong number
    public static bool IsArmstrong(int[] digits)
    {
        int sum = 0;
        int n = digits.Length;
        foreach (int digit in digits)
        {
            sum += (int)Math.Pow(digit, n);
        }

        int originalNumber = 0;
        foreach (int digit in digits)
        {
            originalNumber = originalNumber * 10 + digit;
        }

        return sum == originalNumber;
    }

    // Method to find largest and second largest elements in an array
    public static int[] FindLargestAndSecondLargest(int[] digits)
    {
        int largest = Int32.MinValue;
        int secondLargest = Int32.MinValue;

        foreach (int digit in digits)
        {
            if (digit > largest)
            {
                secondLargest = largest;
                largest = digit;
            }
            else if (digit > secondLargest && digit != largest)
            {
                secondLargest = digit;
            }
        }

        return new int[] { largest, secondLargest };
    }

    // Method to find smallest and second smallest elements in an array
    public static int[] FindSmallestAndSecondSmallest(int[] digits)
    {
        int smallest = Int32.MaxValue;
        int secondSmallest = Int32.MaxValue;

        foreach (int digit in digits)
        {
            if (digit < smallest)
            {
                secondSmallest = smallest;
                smallest = digit;
            }
            else if (digit < secondSmallest && digit != smallest)
            {
                secondSmallest = digit;
            }
        }

        return new int[] { smallest, secondSmallest };
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int digitCount = NumberChecker.CountDigits(number);
        Console.WriteLine($"Number of digits: {digitCount}");

        int[] digits = NumberChecker.GetDigitsArray(number);
        Console.WriteLine("Digits array: " + string.Join(", ", digits));

        bool isDuck = NumberChecker.IsDuckNumber(digits);
        Console.WriteLine($"Is Duck Number? {isDuck}");

        bool isArmstrong = NumberChecker.IsArmstrong(digits);
        Console.WriteLine($"Is Armstrong Number? {isArmstrong}");

        int[] largest = NumberChecker.FindLargestAndSecondLargest(digits);
        Console.WriteLine($"Largest: {largest[0]}, Second Largest: {largest[1]}");

        int[] smallest = NumberChecker.FindSmallestAndSecondSmallest(digits);
        Console.WriteLine($"Smallest: {smallest[0]}, Second Smallest: {smallest[1]}");
    }
}
