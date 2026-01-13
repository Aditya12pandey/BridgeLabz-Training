using System;

class MatrixBinarySearch
{
    static bool BinarySearchRow(int[] row, int target)
    {
        int left = 0, right = row.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (row[mid] == target)
                return true;
            else if (row[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return false;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(" Binary Search in 2D Sorted Matrix ");

        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];

        Console.WriteLine("\nEnter matrix elements (Row-wise):");

        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine($"Enter elements for Row {i + 1}: ");
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.Write("\nEnter target value to search: ");
        int target = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = 0; i < rows; i++)
        {
            int[] rowArray = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                rowArray[j] = matrix[i, j];
            }

            if (BinarySearchRow(rowArray, target))
            {
                Console.WriteLine($"\n Target {target} FOUND in Row {i + 1}");
                found = true;
                break;
            }
        }

        if (!found)
            Console.WriteLine($"\n Target {target} NOT FOUND in the matrix.");
    }
}
