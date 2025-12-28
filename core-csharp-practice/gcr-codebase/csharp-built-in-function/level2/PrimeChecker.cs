using System;

class PrimeChecker
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num;
        while (!int.TryParse(Console.ReadLine(), out num) || num < 1)
        {
            Console.Write("Invalid input! Enter a positive integer: ");
        }

        if (IsPrime(num))
            Console.WriteLine(num + " is a prime number.");
        else
            Console.WriteLine(num + " is NOT a prime number.");
    }

    static bool IsPrime(int number)
    {
        if (number == 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}
