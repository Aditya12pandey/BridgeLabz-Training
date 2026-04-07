using System;

class ArmstrongNumber
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int sum = 0;
        int originalNumber = number;

        while (originalNumber != 0)
        {
            int remainder = originalNumber % 10;       // Get last digit
            sum += remainder * remainder * remainder;  // Add cube of digit to sum
            originalNumber = originalNumber / 10;      // Remove last digit
        }

        if (sum == number)
        {
            Console.WriteLine(number + " is an Armstrong number.");
        }
        else
        {
            Console.WriteLine(number + " is not an Armstrong number.");
        }
    }
}
