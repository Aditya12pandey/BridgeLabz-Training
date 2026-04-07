using System;

class RotationPointFinder
{
    // Returns index of smallest element (rotation point)
    public int FindRotationPoint(int[] arr)
    {
        int low = 0, high = arr.Length - 1;

        while (low < high)
        {
            int mid = low + (high - low) / 2;

            if (arr[mid] > arr[high])
                low = mid + 1;
            else
                high = mid; // smallest lies in left part including mid
        }

    }
}

class BinarySearchRotationPoint
{
    static void Main()
    {
        Console.Write("Enter size of array: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        Console.WriteLine("Enter elements of rotated sorted array:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Element {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        RotationPointFinder finder = new RotationPointFinder();
        int rotationIndex = finder.FindRotationPoint(arr);

        Console.WriteLine($"\n Rotation Point Index (Smallest Element) = {rotationIndex}");
        Console.WriteLine($" Smallest Element = {arr[rotationIndex]}");
    }
}
