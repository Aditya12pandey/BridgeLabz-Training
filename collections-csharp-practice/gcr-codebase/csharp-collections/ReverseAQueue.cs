using System;
using System.Collections.Generic;

class ReverseAQueue
{
    static void Main()
    {
        Queue<int> queue = new Queue<int>();

        Console.Write("Enter number of elements in queue: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter elements:");
        for (int i = 0; i < n; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            queue.Enqueue(value);
        }

        Console.WriteLine("\nOriginal Queue: " + string.Join(", ", queue));

        // Reversing using Stack
        Stack<int> stack = new Stack<int>();

        while (queue.Count > 0)
        {
            stack.Push(queue.Dequeue());
        }

        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }

        Console.WriteLine("Reversed Queue: " + string.Join(", ", queue));
    }
}
