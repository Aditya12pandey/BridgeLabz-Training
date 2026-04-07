using System;
using System.Collections.Generic;

class GenerateBinaryNumbersUsingQueue
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Queue<string> queue = new Queue<string>();
        queue.Enqueue("1");

        Console.WriteLine("\nFirst " + n + " Binary Numbers:");

        for (int i = 0; i < n; i++)
        {
            string current = queue.Dequeue();
            Console.Write(current + " ");

            queue.Enqueue(current + "0");
            queue.Enqueue(current + "1");
        }
    }
}
