using System;
using System.Diagnostics;

class SortingComparison
{
    //  Bubble Sort 
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped) break;
        }
    }

    //  Merge Sort 
    static void MergeSort(int[] arr)
    {
        MergeSortHelper(arr, 0, arr.Length - 1);
    }

    static void MergeSortHelper(int[] arr, int left, int right)
    {
        if (left >= right) return;

        int mid = left + (right - left) / 2;
        MergeSortHelper(arr, left, mid);
        MergeSortHelper(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
                arr[k++] = L[i++];
            else
                arr[k++] = R[j++];
        }

        while (i < n1)
            arr[k++] = L[i++];

        while (j < n2)
            arr[k++] = R[j++];
    }

    //  Quick Sort 
    static void QuickSort(int[] arr)
    {
        QuickSortHelper(arr, 0, arr.Length - 1);
    }

    static void QuickSortHelper(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            QuickSortHelper(arr, low, pivotIndex - 1);
            QuickSortHelper(arr, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int swapTemp = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = swapTemp;

        return i + 1;
    }

    //  Generate Random Array 
    static int[] GenerateRandomArray(int n)
    {
        Random rand = new Random();
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
            arr[i] = rand.Next(1, 100000);

        return arr;
    }

    //  Main 
    static void Main()
    {
        Console.Write("Enter dataset size (e.g., 1000, 10000, 100000): ");
        int n = int.Parse(Console.ReadLine());

        int[] original = GenerateRandomArray(n);

        // Make copies
        int[] arrBubble = (int[])original.Clone();
        int[] arrMerge = (int[])original.Clone();
        int[] arrQuick = (int[])original.Clone();

        Stopwatch sw = new Stopwatch();

        // Bubble Sort timing
        if (n > 50000)
        {
            Console.WriteLine("\nBubble Sort is too slow for large datasets, skipped.");
        }
        else
        {
            sw.Start();
            BubbleSort(arrBubble);
            sw.Stop();
            Console.WriteLine($"\nBubble Sort Time: {sw.ElapsedMilliseconds} ms");
            sw.Reset();
        }

        // Merge Sort timing
        sw.Start();
        MergeSort(arrMerge);
        sw.Stop();
        Console.WriteLine($"Merge Sort Time : {sw.ElapsedMilliseconds} ms");
        sw.Reset();

        // Quick Sort timing
        sw.Start();
        QuickSort(arrQuick);
        sw.Stop();
        Console.WriteLine($"Quick Sort Time : {sw.ElapsedMilliseconds} ms");
        sw.Reset();

        Console.WriteLine("\n Sorting comparison completed.");
    }
}
