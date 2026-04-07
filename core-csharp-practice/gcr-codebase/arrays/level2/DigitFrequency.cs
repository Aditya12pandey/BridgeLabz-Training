using System;

class DigitFrequency
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int temp = number;
        int count = 0;

        while (temp > 0)
        {
            count++;
            temp /= 10;
        }

        int[] digits = new int[count];
        int[] frequency = new int[10]; // 0 to 9 digits

        temp = number;

        for (int i = 0; i < count; i++)
        {
            digits[i] = temp % 10;
            temp /= 10;
        }

        for (int i = 0; i < count; i++)
        {
            frequency[digits[i]]++;
        }

        Console.WriteLine("\nDigit Frequency:");
        for (int i = 0; i < 10; i++)
        {
            if (frequency[i] > 0)
            {
                Console.WriteLine($"Digit {i} occurs {frequency[i]} time(s)");
            }
        }
    }
}
