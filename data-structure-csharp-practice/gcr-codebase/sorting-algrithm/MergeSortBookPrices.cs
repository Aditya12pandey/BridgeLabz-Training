using System;

class MergeSortBookPrices
{
    static void Main()
    {
        int[] prices = { 450, 299, 799, 199, 599 };

        Console.WriteLine("Book Prices Before Sorting:");
        DisplayArray(prices);

        MergeSort(prices, 0, prices.Length - 1);

        Console.WriteLine("\nBook Prices After Sorting (Ascending Order):");
        DisplayArray(prices);
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            // Sort left half
            MergeSort(arr, left, mid);

            // Sort right half
            MergeSort(arr, mid + 1, right);

            // Merge sorted halves
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        // Copy data to temp arrays
        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];

        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + 1 + j];

        int iIndex = 0, jIndex = 0, k = left;

        // Merge temp arrays back into original
        while (iIndex < n1 && jIndex < n2)
        {
            if (L[iIndex] <= R[jIndex])
            {
                arr[k] = L[iIndex];
                iIndex++;
            }
            else
            {
                arr[k] = R[jIndex];
                jIndex++;
            }
            k++;
        }

        // Copy remaining elements
        while (iIndex < n1)
        {
            arr[k] = L[iIndex];
            iIndex++;
            k++;
        }

        while (jIndex < n2)
        {
            arr[k] = R[jIndex];
            jIndex++;
            k++;
        }
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
