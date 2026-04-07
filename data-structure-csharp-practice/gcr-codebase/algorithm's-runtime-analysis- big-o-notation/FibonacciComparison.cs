using System;
using System.Diagnostics;

class FibonacciComparison
{
    // Recursive Fibonacci (O(2^N))
    public static long FibonacciRecursive(int n)
    {
        if (n <= 1) return n;
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    // Iterative Fibonacci (O(N))
    public static long FibonacciIterative(int n)
    {
        if (n <= 1) return n;

        long a = 0, b = 1, sum = 0;
        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }
        return b;
    }

    static void Main()
    {
        Console.Write("Enter N for Fibonacci: ");
        int n = int.Parse(Console.ReadLine());

        Stopwatch sw = new Stopwatch();

        // Recursive (skip for large N to avoid freezing)
        if (n > 40)
        {
            Console.WriteLine("\n Recursive method skipped (too slow for N > 40).");
        }
        else
        {
            sw.Start();
            long recResult = FibonacciRecursive(n);
            sw.Stop();
            Console.WriteLine($"\n Recursive Fibonacci({n}) = {recResult}");
            Console.WriteLine($" Recursive Time = {sw.ElapsedMilliseconds} ms");
            sw.Reset();
        }

        // Iterative
        sw.Start();
        long itResult = FibonacciIterative(n);
        sw.Stop();

        Console.WriteLine($"\n Iterative Fibonacci({n}) = {itResult}");
        Console.WriteLine($" Iterative Time = {sw.ElapsedMilliseconds} ms");

        Console.WriteLine("\n Comparison Completed!");
    }
}
