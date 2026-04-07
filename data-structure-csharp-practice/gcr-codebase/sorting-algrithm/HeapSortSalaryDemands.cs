using System;

class HeapSortSalaryDemands
{
    static void Main()
    {
        int[] salaries = { 45000, 60000, 35000, 80000, 50000 };
        int n = salaries.Length;

        Console.WriteLine("Salary Demands Before Sorting:");
        DisplayArray(salaries);

        // Build Max Heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(salaries, n, i);
        }

        // Extract elements from heap one by one
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root to end
            int temp = salaries[0];
            salaries[0] = salaries[i];
            salaries[i] = temp;

            // Heapify the reduced heap
            Heapify(salaries, i, 0);
        }

        Console.WriteLine("\nSalary Demands After Sorting (Ascending Order):");
        DisplayArray(salaries);
    }

    static void Heapify(int[] arr, int heapSize, int rootIndex)
    {
        int largest = rootIndex;
        int left = 2 * rootIndex + 1;
        int right = 2 * rootIndex + 2;

        // Check left child
        if (left < heapSize && arr[left] > arr[largest])
            largest = left;

        // Check right child
        if (right < heapSize && arr[right] > arr[largest])
            largest = right;

        // If largest is not root
        if (largest != rootIndex)
        {
            int swap = arr[rootIndex];
            arr[rootIndex] = arr[largest];
            arr[largest] = swap;

            // Recursively heapify affected sub-tree
            Heapify(arr, heapSize, largest);
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
