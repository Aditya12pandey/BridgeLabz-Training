using System;

class MeanHeight
{
    static void Main()
    {
        double[] heights = new double[11];
        double sum = 0.0;

        Console.WriteLine("Enter the heights of 11 football players:");

        for (int i = 0; i < heights.Length; i++)
        {
            Console.Write($"Enter height of player {i + 1}: ");
            heights[i] = Convert.ToDouble(Console.ReadLine());
        }

        for (int i = 0; i < heights.Length; i++)
        {
            sum += heights[i];
        }

        double mean = sum / heights.Length;

        Console.WriteLine($"\nMean height of the football team = {mean}");
    }
}
