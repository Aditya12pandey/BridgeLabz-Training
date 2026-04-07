using System;

class FizzBuzzWhile
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        int n = int.Parse(Console.ReadLine());

        if (n <= 0)
        {
            Console.WriteLine("Please enter a positive integer.");
            return;
        }

        int i = 0;
        while (i <= n)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }

            i++;
        }
    }
}
