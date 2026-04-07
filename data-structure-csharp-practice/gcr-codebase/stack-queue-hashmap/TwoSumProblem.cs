using System;
using System.Collections.Generic;

class TwoSumUsingHashMap
{
    public static int[] FindTwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int required = target - nums[i];

            if (map.ContainsKey(required))
            {
                return new int[] { map[required], i };
            }

            // Store current element with its index
            if (!map.ContainsKey(nums[i]))
                map[nums[i]] = i;
        }

        return new int[] { -1, -1 }; // No solution
    }
}

class TwoSumProblem
{
    static void Main()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;

        Console.WriteLine("Array:");
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write(nums[i] + " ");
        }

        int[] result = TwoSumUsingHashMap.FindTwoSum(nums, target);

        if (result[0] != -1)
        {
            Console.WriteLine($"\n\nIndices found: {result[0]} and {result[1]}");
            Console.WriteLine($"Values: {nums[result[0]]} + {nums[result[1]]} = {target}");
        }
        else
        {
            Console.WriteLine("\nNo valid pair found.");
        }
    }
}
