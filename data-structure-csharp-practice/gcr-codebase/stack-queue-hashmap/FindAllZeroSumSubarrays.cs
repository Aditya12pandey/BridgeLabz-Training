using System;
using System.Collections.Generic;

class ZeroSumSubarraysUsingHashMap
{
    public static void FindZeroSumSubarrays(int[] arr)
    {
        // Map: cumulative sum -> list of indices
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

        int sum = 0;

        // To handle subarrays starting from index 0
        map[0] = new List<int> { -1 };

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];

            if (map.ContainsKey(sum))
            {
                foreach (int startIndex in map[sum])
                {
                    Console.WriteLine($"Zero-sum subarray found from index {startIndex + 1} to {i}");
                }
                map[sum].Add(i);
            }
            else
            {
                map[sum] = new List<int> { i };
            }
        }
    }
}

class FindAllZeroSumSubarrays
{
    static void Main()
    {
        int[] arr = { 3, 4, -7, 3, 1, 3, 1, -4, -2, -2 };

        Console.WriteLine("Array:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine("\n\nZero Sum Subarrays:");
        ZeroSumSubarraysUsingHashMap.FindZeroSumSubarrays(arr);
    }
}
