using System;

class Program
{
    static void GenerateFibonacci(int terms)
    {
        int first = 0, second = 1, next;

        Console.WriteLine("Fibonacci Sequence:");
        for (int i = 0; i < terms; i++)
        {
            if (i <= 1)
            {
                next = i;
            }
            else
            {
                next = first + second;
                first = second;
                second = next;
            }
            Console.Write(next + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("Enter the number of terms: ");
        int n;

        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Please enter a positive integer: ");
        }

        GenerateFibonacci(n);
    }
}
