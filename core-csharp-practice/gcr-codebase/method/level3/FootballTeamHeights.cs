using System;

public class FootballTeamHeights
{
    public static int FindSum(int[] heights)
    {
        int sum = 0;
        foreach (int height in heights)
        {
            sum += height;
        }
        return sum;
    }

    public static double FindMean(int[] heights)
    {
        int sum = FindSum(heights);
        return (double)sum / heights.Length;
    }

    public static int FindShortest(int[] heights)
    {
        int shortest = heights[0];
        foreach (int height in heights)
        {
            if (height < shortest)
            {
                shortest = height;
            }
        }
        return shortest;
    }

    public static int FindTallest(int[] heights)
    {
        int tallest = heights[0];
        foreach (int height in heights)
        {
            if (height > tallest)
            {
                tallest = height;
            }
        }
        return tallest;
    }

    public static void Main(string[] args)
    {
        int[] heights = new int[11];
        Random rand = new Random();

        for (int i = 0; i < heights.Length; i++)
        {
            heights[i] = rand.Next(150, 251); // 150 to 250 inclusive
        }
        Console.WriteLine("Heights of football team players (in cm):");
        foreach (int height in heights)
        {
            Console.WriteLine(height);
        }

        int shortest = FindShortest(heights);
        int tallest = FindTallest(heights);
        double mean = FindMean(heights);

        Console.WriteLine($"\nShortest height: {shortest} cm");
        Console.WriteLine($"Tallest height: {tallest} cm");
        Console.WriteLine($"Mean height: {mean:F2} cm");
    }
}
