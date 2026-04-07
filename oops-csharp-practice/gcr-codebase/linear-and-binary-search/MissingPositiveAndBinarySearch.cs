using System;

class MissingPositiveAndBinarySearch
{
    // ✅ Linear Search based approach (using visited array)
    static int FirstMissingPositive(int[] arr)
    {
        int n = arr.Length;

        bool[] visited = new bool[n + 2]; // +2 for safety

        for (int i = 0; i < n; i++)
        {
            if (arr[i] > 0 && arr[i] <= n + 1)
            {
                visited[arr[i]] = true;
            }
        }

        for (int i = 1; i <= n + 1; i++)
        {
            if (!visited[i])
                return i;
        }

        return n + 1;
    }

    // ✅ Binary Search
    static int BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Linear Search + Binary Search Program");

        Console.Write("Enter size of array: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        Console.WriteLine("Enter elements:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int missing = FirstMissingPositive(arr);
        Console.WriteLine($"\n First Missing Positive Integer = {missing}");

        Console.Write("\nEnter target to search: ");
        int target = int.Parse(Console.ReadLine());

        Array.Sort(arr);

        Console.WriteLine("\nSorted Array:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }

        int index = BinarySearch(arr, target);

        if (index != -1)
            Console.WriteLine($"\n\n Target {target} found at index {index} (in sorted array)");
        else
            Console.WriteLine($"\n\n Target {target} not found. Index = -1");
    }
}
