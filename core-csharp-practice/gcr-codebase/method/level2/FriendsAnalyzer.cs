using System;

public class FriendsAnalyzer
{
    public static string FindYoungest(string[] names, int[] ages)
    {
        int minAge = ages[0];
        int index = 0;

        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < minAge)
            {
                minAge = ages[i];
                index = i;
            }
        }

        return names[index];
    }

    public static string FindTallest(string[] names, double[] heights)
    {
        double maxHeight = heights[0];
        int index = 0;

        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > maxHeight)
            {
                maxHeight = heights[i];
                index = i;
            }
        }

        return names[index];
    }

    public static void Main(string[] args)
    {
        string[] friends = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        double[] heights = new double[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Enter age of {friends[i]}: ");
            ages[i] = int.Parse(Console.ReadLine());

            Console.Write($"Enter height (in cm) of {friends[i]}: ");
            heights[i] = double.Parse(Console.ReadLine());
        }

        string youngest = FindYoungest(friends, ages);
        string tallest = FindTallest(friends, heights);

        Console.WriteLine($"\nThe youngest friend is: {youngest}");
        Console.WriteLine($"The tallest friend is: {tallest}");
    }
}
