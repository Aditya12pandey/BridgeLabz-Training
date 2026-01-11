using System;

class BubbleSortStudentMarks
{
    static void Main()
    {
        int[] marks = { 78, 45, 89, 62, 50 };
        int n = marks.Length;
        bool swapped;

        Console.WriteLine("Student Marks Before Sorting:");
        DisplayArray(marks);

        // Bubble Sort Logic
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (marks[j] > marks[j + 1])
                {
                    // Swap
                    int temp = marks[j];
                    marks[j] = marks[j + 1];
                    marks[j + 1] = temp;
                    swapped = true;
                }
            }

            // If no swaps occurred, array is already sorted
            if (!swapped)
                break;
        }

        Console.WriteLine("\nStudent Marks After Sorting (Ascending Order):");
        DisplayArray(marks);
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
