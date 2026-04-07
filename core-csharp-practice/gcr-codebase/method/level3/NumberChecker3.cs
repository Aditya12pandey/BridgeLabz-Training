using System;

public static class NumberChecker3
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

    public static int[] ReverseDigits(int[] digits)
    {
        int[] reversed = new int[digits.Length];
        for (int i = 0; i < digits.Length; i++)
        {
            reversed[i] = digits[digits.Length - 1 - i];
        }
        return reversed;
    }

    public static bool CompareArrays(int[] arr1, int[] arr2)
    {
        if (arr1.Length != arr2.Length)
            return false;

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i])
                return false;
        }
        return true;
    }

    public static bool IsPalindrome(int[] digits)
    {
        int[] reversed = ReverseDigits(digits);
        return CompareArrays(digits, reversed);
    }

    public static bool IsDuckNumber(int[] digits)
    {
        foreach (int d in digits)
        {
            if (d != 0)
                return true;
        }
        return false;
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

        int[] reversed = NumberChecker.ReverseDigits(digits);
        Console.WriteLine("Reversed Digits: " + string.Join(", ", reversed));

        bool isPalindrome = NumberChecker.IsPalindrome(digits);
        Console.WriteLine("Is Palindrome: " + isPalindrome);

        bool isDuck = NumberChecker.IsDuckNumber(digits);
        Console.WriteLine("Is Duck Number: " + isDuck);
    }
}
