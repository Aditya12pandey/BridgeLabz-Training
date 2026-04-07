using System;
using System.Collections;

class ReverseAList
{
    static void ReverseArrayList(ArrayList list)
    {
        int start = 0;
        int end = list.Count - 1;

        while (start < end)
        {
            object temp = list[start];
            list[start] = list[end];
            list[end] = temp;

            start++;
            end--;
        }
    }

    static void Main()
    {
        ArrayList arrList = new ArrayList() { 1, 2, 3, 4, 5 };

        Console.WriteLine("Original ArrayList:");
        foreach (var item in arrList)
            Console.Write(item + " ");

        ReverseArrayList(arrList);

        Console.WriteLine("\nReversed ArrayList:");
        foreach (var item in arrList)
            Console.Write(item + " ");
    }
}
