using System;

class PeakElementFinder
{
    public int FindPeakElement(int[] arr)
    {
        int low = 0, high = arr.Length - 1;

        while (low < high)
        {
            int mid = low + (high - low) / 2;

            if (arr[mid] < arr[mid + 1])
                low = mid + 1;
            else
                high = mid; 
        }

        return low;
    }
}

class BinarySearchFindPeakElement
{
    static void Main()
    {
        Console.Write("Enter size of array: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Element {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        PeakElementFinder finder = new PeakElementFinder();
        int peakIndex = finder.FindPeakElement(arr);

        Console.WriteLine($"\n Peak Element Index = {peakIndex}");
        Console.WriteLine($" Peak Element Value = {arr[peakIndex]}");
    }
}
