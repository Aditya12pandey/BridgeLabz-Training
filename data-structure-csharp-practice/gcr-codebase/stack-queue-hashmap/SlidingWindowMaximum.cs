using System;
using System.Collections.Generic;

class SlidingWindowMaximumUsingDeque
{
    public static int[] GetSlidingWindowMaximum(int[] nums, int k)
    {
        if (nums == null || k <= 0)
            return new int[0];

        int n = nums.Length;
        int[] result = new int[n - k + 1];
        LinkedList<int> deque = new LinkedList<int>(); // stores indices

        for (int i = 0; i < n; i++)
        {
            // Remove indices outside the current window
            if (deque.Count > 0 && deque.First.Value <= i - k)
            {
                deque.RemoveFirst();
            }

            // Remove smaller elements from the back
            while (deque.Count > 0 && nums[deque.Last.Value] <= nums[i])
            {
                deque.RemoveLast();
            }

            // Add current index
            deque.AddLast(i);

            // Store result once first window is complete
            if (i >= k - 1)
            {
                result[i - k + 1] = nums[deque.First.Value];
            }
        }

        return result;
    }
}

class SlidingWindowMaximum
{
    static void Main()
    {
        int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;

        int[] maxValues = SlidingWindowMaximumUsingDeque.GetSlidingWindowMaximum(nums, k);

        Console.WriteLine("Array:");
        foreach (int num in nums)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine("\n\nSliding Window Maximums:");
        foreach (int max in maxValues)
        {
            Console.Write(max + " ");
        }
    }
}
