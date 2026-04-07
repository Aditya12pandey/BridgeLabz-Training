using System;
using System.Collections.Generic;

class QueueUsingTwoStacks
{
    private Stack<int> stackEnqueue = new Stack<int>();
    private Stack<int> stackDequeue = new Stack<int>();

    // Enqueue operation
    public void Enqueue(int data)
    {
        stackEnqueue.Push(data);
        Console.WriteLine($"{data} enqueued");
    }

    // Dequeue operation
    public int Dequeue()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty");
            return -1;
        }

        if (stackDequeue.Count == 0)
        {
            while (stackEnqueue.Count > 0)
            {
                stackDequeue.Push(stackEnqueue.Pop());
            }
        }

        return stackDequeue.Pop();
    }

    // Check if queue is empty
    public bool IsEmpty()
    {
        return stackEnqueue.Count == 0 && stackDequeue.Count == 0;
    }
}


class QueueUsingTwoStacksDemo
{
    static void Main()
    {
        QueueUsingTwoStacks queue = new QueueUsingTwoStacks();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Console.WriteLine("Dequeued: " + queue.Dequeue());
        Console.WriteLine("Dequeued: " + queue.Dequeue());

        queue.Enqueue(40);

        Console.WriteLine("Dequeued: " + queue.Dequeue());
        Console.WriteLine("Dequeued: " + queue.Dequeue());
    }
}
