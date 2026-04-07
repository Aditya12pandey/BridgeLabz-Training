using System;

class MultiplesBelow100
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Multiples of " + number + " below 100 are:");

        // Loop backward from 100 to 1
        for (int i = 100; i >= 1; i--)
        {
            if (i % number == 0) // Check if i is divisible by number
            {
                Console.WriteLine(i);
            }
        }
    }
}
