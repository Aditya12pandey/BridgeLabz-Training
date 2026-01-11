using System;

class CountingSortStudentAges
{
    static void Main()
    {
        int[] ages = { 12, 15, 10, 18, 14, 12, 16 };

        Console.WriteLine("Student Ages Before Sorting:");
        DisplayArray(ages);

        CountingSort(ages, 10, 18);

        Console.WriteLine("\nStudent Ages After Sorting (Ascending Order):");
        DisplayArray(ages);
    }

    static void CountingSort(int[] arr, int minAge, int maxAge)
    {
        int range = maxAge - minAge + 1;
        int[] count = new int[range];
        int[] output = new int[arr.Length];

        // Step 1: Count frequencies
        for (int i = 0; i < arr.Length; i++)
        {
            count[arr[i] - minAge]++;
        }

        // Step 2: Cumulative count
        for (int i = 1; i < range; i++)
        {
            count[i] += count[i - 1];
        }

        // Step 3: Place elements in output array (stable sort)
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            int age = arr[i];
            int position = count[age - minAge] - 1;
            output[position] = age;
            count[age - minAge]--;
        }

        // Step 4: Copy output to original array
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = output[i];
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
