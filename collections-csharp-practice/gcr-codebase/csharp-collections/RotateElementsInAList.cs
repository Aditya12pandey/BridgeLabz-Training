using System;
using System.Collections.Generic;

class RotateElementsInAList
{
    static List<int> RotateLeft(List<int> list, int k)
    {
        int n = list.Count;
        k = k % n; // in case k is bigger than list size

        List<int> rotated = new List<int>();

        // Add elements from k to end
        for (int i = k; i < n; i++)
        {
            rotated.Add(list[i]);
        }

        // Add elements from start to k-1
        for (int i = 0; i < k; i++)
        {
            rotated.Add(list[i]);
        }

        return rotated;
    }

    static void Main()
    {
        List<int> numbers = new List<int>() { 10, 20, 30, 40, 50 };
        int rotateBy = 2;

        Console.WriteLine("Original List: " + string.Join(", ", numbers));

        List<int> result = RotateLeft(numbers, rotateBy);

        Console.WriteLine("Rotated List: " + string.Join(", ", result));
    }
}
