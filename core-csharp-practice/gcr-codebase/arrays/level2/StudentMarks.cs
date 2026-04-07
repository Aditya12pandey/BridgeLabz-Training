using System;

class StudentMarks
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] physics = new int[n];
        int[] chemistry = new int[n];
        int[] maths = new int[n];
        double[] percentage = new double[n];
        char[] grade = new char[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter marks for Student {i + 1}");

            Console.Write("Physics: ");
            physics[i] = Convert.ToInt32(Console.ReadLine());
            if (physics[i] < 0)
            {
                Console.WriteLine("Marks must be positive. Re-enter.");
                i--;
                continue;
            }

            Console.Write("Chemistry: ");
            chemistry[i] = Convert.ToInt32(Console.ReadLine());
            if (chemistry[i] < 0)
            {
                Console.WriteLine("Marks must be positive. Re-enter.");
                i--;
                continue;
            }

            Console.Write("Maths: ");
            maths[i] = Convert.ToInt32(Console.ReadLine());
            if (maths[i] < 0)
            {
                Console.WriteLine("Marks must be positive. Re-enter.");
                i--;
                continue;
            }

            percentage[i] = (physics[i] + chemistry[i] + maths[i]) / 3.0;

            // Updated grade calculation
            if (percentage[i] >= 80)
                grade[i] = 'A';
            else if (percentage[i] >= 70)
                grade[i] = 'B';
            else if (percentage[i] >= 60)
                grade[i] = 'C';
            else if (percentage[i] >= 40)
                grade[i] = 'D';
            else
                grade[i] = 'F';
        }

        // Display result
        Console.WriteLine("\n--- Student Result ---");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(
                $"Student {i + 1}: Physics = {physics[i]}, Chemistry = {chemistry[i]}, Maths = {maths[i]}, " +
                $"Percentage = {percentage[i]:F2}%, Grade = {grade[i]}"
            );
        }
    }
}
