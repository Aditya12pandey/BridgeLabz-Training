using System;
using System.Collections.Generic;

class UnionAndIntersectionOfTwoSets
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
            set.Add(value); // HashSet automatically avoids duplicates
        }

        return set;
    }

    static void Main()
    {
        HashSet<int> set1 = ReadSetFromUser("Set1");
        HashSet<int> set2 = ReadSetFromUser("Set2");

        // UNION
        HashSet<int> unionSet = new HashSet<int>(set1);
        unionSet.UnionWith(set2);

        // INTERSECTION
        HashSet<int> intersectionSet = new HashSet<int>(set1);
        intersectionSet.IntersectWith(set2);

        Console.WriteLine("\nUnion: " + string.Join(", ", unionSet));
        Console.WriteLine("Intersection: " + string.Join(", ", intersectionSet));
    }
}
