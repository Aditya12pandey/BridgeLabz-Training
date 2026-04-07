using System;
using System.Collections.Generic;

class ConvertSetToSortedList
{
    static HashSet<int> ReadSetFromUser()
    {
        Console.Write("Enter number of elements in the set: ");
        int n = Convert.ToInt32(Console.ReadLine());

        HashSet<int> set = new HashSet<int>();

        Console.WriteLine("Enter elements:");
        for (int i = 0; i < n; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            set.Add(value); // duplicates are automatically ignored
        }

        return set;
    }

    static void Main()
    {
        HashSet<int> set = ReadSetFromUser();

        // Convert to List
        List<int> sortedList = new List<int>(set);

        // Sort in ascending order
        sortedList.Sort();

        Console.WriteLine("\nSorted List: " + string.Join(", ", sortedList));
    }
}
