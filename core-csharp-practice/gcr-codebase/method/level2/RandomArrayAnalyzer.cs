using System;

public class RandomArrayAnalyzer
{
    public static int[] Generate4DigitRandomArray(int size)
    {
        int[] numbers = new int[size];
        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            // Generate 4-digit random number (1000 to 9999)
            numbers[i] = rand.Next(1000, 10000);
        }

        return numbers;
    }

    public static double[] FindAverageMinMax(int[] numbers)
    {
        int min = numbers[0];
        int max = numbers[0];
        double sum = 0;

        foreach (int num in numbers)
        {
            min = Math.Min(min, num);
            max = Math.Max(max, num);
            sum += num;
        }

        double average = sum / numbers.Length;
        return new double[] { average, min, max };
    }

    public static void Main(string[] args)
    {
        int size = 5;

        int[] randomNumbers = Generate4DigitRandomArray(size);

        Console.WriteLine("Generated 4-digit random numbers:");
        foreach (int num in randomNumbers)
        {
            Console.WriteLine(num);
        }

        double[] results = FindAverageMinMax(randomNumbers);
        Console.WriteLine($"\nAverage: {results[0]:F2}");
        Console.WriteLine($"Minimum: {results[1]}");
        Console.WriteLine($"Maximum: {results[2]}");
    }
}
