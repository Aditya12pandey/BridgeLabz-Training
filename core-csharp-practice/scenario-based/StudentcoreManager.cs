using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased
{
    internal class StudentcoreManager
    {
        static void Main()
        {
            Console.Write("Enter number of students: ");
            int n;

            // Validate number of students
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Invalid input. Enter a positive number: ");
            }

            int[] scores = new int[n];

            // Input scores with validation
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter score for student " + (i + 1) + ": ");
                while (!int.TryParse(Console.ReadLine(), out scores[i]) || scores[i] < 0)
                {
                    Console.Write("Invalid score. Enter a non-negative number: ");
                }
            }

            AnalyzeScores(scores);
        }

        static void AnalyzeScores(int[] scores)
        {
            int sum = 0;
            int highest = scores[0];
            int lowest = scores[0];

            for (int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];

                if (scores[i] > highest)
                    highest = scores[i];

                if (scores[i] < lowest)
                    lowest = scores[i];
            }

            double average = (double)sum / scores.Length;

            Console.WriteLine("\nAverage Score: " + average);
            Console.WriteLine("Highest Score: " + highest);
            Console.WriteLine("Lowest Score: " + lowest);

            Console.WriteLine("\nScores above average:");
            bool found = false;

            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] > average)
                {
                    Console.WriteLine(scores[i]);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No scores above average.");
            }
        }
    }
}
