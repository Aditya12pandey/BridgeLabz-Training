using System;
using System.Collections.Generic;

class RemoveDuplicatesOrder
{
    static void Main()
    {
        List<int> numbers = new List<int>() { 3, 1, 2, 2, 3, 4 };

        HashSet<int> seen = new HashSet<int>();
        List<int> result = new List<int>();

        foreach (int num in numbers)
        {
            if (!seen.Contains(num))
            {
                seen.Add(num);
                result.Add(num);
            }
        }

        Console.WriteLine("Original List: " + string.Join(", ", numbers));
        Console.WriteLine("After Removing Duplicates: " + string.Join(", ", result));
    }
}
