using System;
using System.Collections.Generic;

class FindNthElementFromEnd
{
    static string FindNthFromEnd(LinkedList<string> list, int n)
    {
        if (n <= 0)
            return "Invalid N";

        LinkedListNode<string> first = list.First;
        LinkedListNode<string> second = list.First;

        // Move first pointer n steps ahead
        for (int i = 0; i < n; i++)
        {
            if (first == null)
                return "N is greater than list length";

            first = first.Next;
        }

        // Move both pointers until first reaches end
        while (first != null)
        {
            first = first.Next;
            second = second.Next;
        }

        return second.Value;
    }

    static void Main()
    {
        LinkedList<string> letters = new LinkedList<string>();
        letters.AddLast("A");
        letters.AddLast("B");
        letters.AddLast("C");
        letters.AddLast("D");
        letters.AddLast("E");

        int n = 2;

        Console.WriteLine("Nth Element from End: " + FindNthFromEnd(letters, n));
    }
}
