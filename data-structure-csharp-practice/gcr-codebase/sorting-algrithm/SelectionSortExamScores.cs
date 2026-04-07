using System;

class SelectionSortExamScores
{
    static void Main()
    {
        int[] scores = { 72, 85, 63, 90, 78 };
        int n = scores.Length;

        Console.WriteLine("Exam Scores Before Sorting:");
        DisplayArray(scores);

        // Selection Sort Logic
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            // Find the minimum element in unsorted part
            for (int j = i + 1; j < n; j++)
            {
                if (scores[j] < scores[minIndex])
                {
                    minIndex = j;
                }
            }

            // Swap the found minimum element with the first unsorted element
            int temp = scores[minIndex];
            scores[minIndex] = scores[i];
            scores[i] = temp;
        }

        Console.WriteLine("\nExam Scores After Sorting (Ascending Order):");
        DisplayArray(scores);
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
