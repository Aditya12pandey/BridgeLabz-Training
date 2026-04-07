using System;

class PrimeCheck
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        if (number <= 1)
        {
            Console.WriteLine(number + " is not a prime number.");
            return;
        }

        bool isPrime = true;

        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        if (isPrime)
        {
            Console.WriteLine(number + " is a prime number.");
        }
        else
        {
            Console.WriteLine(number + " is not a prime number.");
        }
    }
}
