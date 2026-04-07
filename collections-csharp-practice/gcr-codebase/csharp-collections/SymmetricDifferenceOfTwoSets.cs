using System;
using System.Collections.Generic;

class SymmetricDifferenceOfTwoSets
{
    static HashSet<int> ReadSetFromUser(string setName)
    {
        Console.Write($"Enter number of elements in {setName}: ");
        int n = Convert.ToInt32(Console.ReadLine());

        HashSet<int> set = new HashSet<int>();

        Console.WriteLine($"Enter {n} elements for {setName}:");
        for (int i = 0; i < n; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            set.Add(value);
        }

        return set;
    }

    static void Main()
    {
        HashSet<int> set1 = ReadSetFromUser("Set1");
        HashSet<int> set2 = ReadSetFromUser("Set2");

        // Symmetric Difference
        HashSet<int> symDiff = new HashSet<int>(set1);
        symDiff.SymmetricExceptWith(set2);

        Console.WriteLine("\nSymmetric Difference: " + string.Join(", ", symDiff));
    }
}
