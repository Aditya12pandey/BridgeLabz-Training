using System;

class QuickSortProductPrices
{
    static void Main()
    {
        int[] prices = { 999, 299, 799, 199, 499 };

        Console.WriteLine("Product Prices Before Sorting:");
        DisplayArray(prices);

        QuickSort(prices, 0, prices.Length - 1);

        Console.WriteLine("\nProduct Prices After Sorting (Ascending Order):");
        DisplayArray(prices);
    }

    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);

            // Sort elements before and after partition
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; // Pivot element (last element)
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                // Swap arr[i] and arr[j]
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        // Place pivot at correct position
        int tempPivot = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = tempPivot;

        return i + 1;
    }

    static void DisplayArray(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
