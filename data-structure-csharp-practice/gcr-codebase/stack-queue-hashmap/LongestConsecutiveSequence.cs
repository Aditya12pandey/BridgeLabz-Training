using System;
using System.Collections.Generic;

class LongestConsecutiveSequenceUsingHashMap
{
    public static int FindLongestConsecutiveSequence(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        HashSet<int> set = new HashSet<int>(nums);
        int longestStreak = 0;

        foreach (int num in set)
        {
            // Check if num is the start of a sequence
            if (!set.Contains(num - 1))
            {
                int currentNum = num;
                int currentStreak = 1;

                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentStreak++;
                }

                longestStreak = Math.Max(longestStreak, currentStreak);
            }
        }

        return longestStreak;
    }
}

class LongestConsecutiveSequence
{
    static void Main()
    {
        int[] arr = { 100, 4, 200, 1, 3, 2 };

        Console.WriteLine("Array:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }

        int result = LongestConsecutiveSequenceUsingHashMap
                        .FindLongestConsecutiveSequence(arr);

        Console.WriteLine("\n\nLength of Longest Consecutive Sequence: " + result);
    }
}
