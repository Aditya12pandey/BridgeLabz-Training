using System;

class StudentMarks2D
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine());

        int[,] marks = new int[n, 3];   // 2D array for marks
        double[] percentage = new double[n];
        char[] grade = new char[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter marks for Student {i + 1}:");

            for (int j = 0; j < 3; j++)
            {
                string subject = j == 0 ? "Physics" :
                                 j == 1 ? "Chemistry" : "Maths";

                Console.Write($"Enter {subject} marks: ");
                int value = int.Parse(Console.ReadLine());

                if (value < 0)
                {
                    Console.WriteLine("Marks cannot be negative. Re-enter.");
                    j--; // repeat same subject
                }
                else
                {
                    marks[i, j] = value;
                }
            }

            int total = marks[i, 0] + marks[i, 1] + marks[i, 2];
            percentage[i] = total / 3.0;

            if (percentage[i] >= 80)
                grade[i] = 'A';
            else if (percentage[i] >= 60)
                grade[i] = 'B';
            else if (percentage[i] >= 40)
                grade[i] = 'C';
            else
                grade[i] = 'D';
        }

        Console.WriteLine("\n--- Student Results ---");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Student {i + 1}: Percentage = {percentage[i]:F2}% , Grade = {grade[i]}");
        }
    }
}
