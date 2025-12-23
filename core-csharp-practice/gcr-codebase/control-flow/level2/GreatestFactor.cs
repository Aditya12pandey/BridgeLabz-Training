using System;

class GreatestFactor
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int greatestFactor = 1; // Initialize greatest factor

        for (int i = number - 1; i >= 1; i--)
        {
            if (number % i == 0) 
            {
                greatestFactor = i;
                break; // Found the greatest factor, exit loop
            }
        }

        Console.WriteLine("The greatest factor of " + number + " besides itself is: " + greatestFactor);
    }
}
