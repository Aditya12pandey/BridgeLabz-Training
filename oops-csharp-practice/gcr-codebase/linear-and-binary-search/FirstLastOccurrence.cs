using System;

class FirstLastOccurrence
{
    static int FindFirst(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                result = mid;
                right = mid - 1; // search left side
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }

    static int FindLast(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                result = mid;
                left = mid + 1; // search right side
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("---- First and Last Occurrence using Binary Search ----");

        Console.Write("Enter size of array: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        Console.WriteLine("Enter sorted array elements:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter target element: ");
        int target = int.Parse(Console.ReadLine());

        int first = FindFirst(arr, target);
        int last = FindLast(arr, target);

        if (first == -1)
        {
            Console.WriteLine($"\n Target {target} not found in the array.");
        }
        else
        {
            Console.WriteLine($"\n Target {target} found!");
            Console.WriteLine("First Occurrence Index = " + first);
            Console.WriteLine("Last Occurrence Index  = " + last);
        }
    }
}
