using System;

public class StudentScoreCard
{
    static Random random = new Random();

    public static int[,] GeneratePCMScores(int students)
    {
        int[,] scores = new int[students, 3];

        for (int i = 0; i < students; i++)
        {
            scores[i, 0] = random.Next(10, 100); // Physics
            scores[i, 1] = random.Next(10, 100); // Chemistry
            scores[i, 2] = random.Next(10, 100); // Maths
        }
        return scores;
    }

    public static double[,] CalculateResults(int[,] scores)
    {
        int students = scores.GetLength(0);
        double[,] results = new double[students, 3];

        for (int i = 0; i < students; i++)
        {
            int total = scores[i, 0] + scores[i, 1] + scores[i, 2];
            double average = total / 3.0;
            double percentage = (total / 300.0) * 100;

            results[i, 0] = total;
            results[i, 1] = Math.Round(average, 2);
            results[i, 2] = Math.Round(percentage, 2);
        }
        return results;
    }

    public static void DisplayScoreCard(int[,] scores, double[,] results)
    {
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine("Student\tPhysics\tChemistry\tMaths\tTotal\tAverage\tPercentage");
        Console.WriteLine("---------------------------------------------------------------");

        for (int i = 0; i < scores.GetLength(0); i++)
        {
            Console.WriteLine(
                $"{i + 1}\t{scores[i, 0]}\t{scores[i, 1]}\t\t{scores[i, 2]}\t{results[i, 0]}\t{results[i, 1]}\t{results[i, 2]}"
            );
        }

        Console.WriteLine("---------------------------------------------------------------");
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter number of students: ");
        int students = Convert.ToInt32(Console.ReadLine());

        int[,] pcmScores = GeneratePCMScores(students);
        double[,] results = CalculateResults(pcmScores);

        DisplayScoreCard(pcmScores, results);
    }
}
