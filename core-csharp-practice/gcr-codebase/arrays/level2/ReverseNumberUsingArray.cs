using System;

class ReverseNumberUsingArray
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int tempNumber = number;
        int digitCount = 0;

        while (tempNumber != 0)
        {
            digitCount++;
            tempNumber /= 10;
        }

        int[] digits = new int[digitCount];
        tempNumber = number;

        for (int i = 0; i < digitCount; i++)
        {
            digits[i] = tempNumber % 10;
            tempNumber /= 10;
        }

        int[] reverseDigits = new int[digitCount];
        for (int i = 0; i < digitCount; i++)
        {
            reverseDigits[i] = digits[digitCount - 1 - i];
        }

        Console.WriteLine("\nReversed number:");
        for (int i = 0; i < digitCount; i++)
        {
            Console.Write(reverseDigits[i]);
        }
    }
}
