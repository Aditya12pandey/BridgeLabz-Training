using System;

class FirstNegativeNumberSearcher
{
    public int FindFirstNegative(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < 0)
                return i; // returning index of first negative number
        }
        return -1; // no negative number found
    }
}

class LinearSearchFirstNegativeNumber
{
    static void Main()
    {
        Console.Write("Enter size of array: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        FirstNegativeNumberSearcher searcher = new FirstNegativeNumberSearcher();
        int index = searcher.FindFirstNegative(arr);

        if (index == -1)
            Console.WriteLine("\nNo negative number found in the array.");
        else
            Console.WriteLine($"\nFirst negative number is {arr[index]} at index {index}.");
    }
}
