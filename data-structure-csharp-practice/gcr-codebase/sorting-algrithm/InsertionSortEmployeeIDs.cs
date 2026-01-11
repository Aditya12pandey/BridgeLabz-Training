using System;

class InsertionSortEmployeeIDs
{
    static void Main()
    {
        int[] employeeIds = { 105, 102, 108, 101, 104 };
        int n = employeeIds.Length;

        Console.WriteLine("Employee IDs Before Sorting:");
        DisplayArray(employeeIds);

        // Insertion Sort Logic
        for (int i = 1; i < n; i++)
        {
            int key = employeeIds[i];
            int j = i - 1;

            // Move elements greater than key one position ahead
            while (j >= 0 && employeeIds[j] > key)
            {
                employeeIds[j + 1] = employeeIds[j];
                j--;
            }

            employeeIds[j + 1] = key;
        }

        Console.WriteLine("\nEmployee IDs After Sorting (Ascending Order):");
        DisplayArray(employeeIds);
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
