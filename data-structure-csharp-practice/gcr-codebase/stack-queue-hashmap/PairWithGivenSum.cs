using System;
using System.Collections.Generic;

class PairWithGivenSumUsingHashMap
{
    public static bool HasPairWithSum(int[] arr, int target)
    {
        HashSet<int> visited = new HashSet<int>();

        foreach (int num in arr)
        {
            int required = target - num;

            if (visited.Contains(required))
            {
                Console.WriteLine($"Pair found: ({required}, {num})");
                return true;
            }

            visited.Add(num);
        }

        return false;
    }
}

class PairWithGivenSum
{
    static void Main()
    {
        int[] arr = { 8, 7, 2, 5, 3, 1 };
        int target = 10;

        Console.WriteLine("Array:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine("\nTarget Sum: " + target);

        bool exists = PairWithGivenSumUsingHashMap.HasPairWithSum(arr, target);

        if (!exists)
        {
            Console.WriteLine("No pair found with the given sum.");
        }
    }
}
