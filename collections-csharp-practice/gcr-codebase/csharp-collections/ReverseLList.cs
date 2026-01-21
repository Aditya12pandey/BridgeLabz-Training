using System;
using System.Collections.Generic;

class ReverseLList
{
    static LinkedList<int> ReverseLinkedList(LinkedList<int> list)
    {
        LinkedList<int> reversed = new LinkedList<int>();

        foreach (int item in list)
        {
            reversed.AddFirst(item);
        }

        return reversed;
    }

    static void Main()
    {
        LinkedList<int> linkList = new LinkedList<int>();
        linkList.AddLast(1);
        linkList.AddLast(2);
        linkList.AddLast(3);
        linkList.AddLast(4);
        linkList.AddLast(5);

        Console.WriteLine("Original LinkedList:");
        foreach (var item in linkList)
            Console.Write(item + " ");

        LinkedList<int> reversedList = ReverseLinkedList(linkList);

        Console.WriteLine("\nReversed LinkedList:");
        foreach (var item in reversedList)
            Console.Write(item + " ");
    }
}
