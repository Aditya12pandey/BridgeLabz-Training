using System;

public class StudentVoteChecker
{
    public bool CanStudentVote(int age)
    {
        if (age < 0)
        {
            // Negative age is invalid
            return false;
        }
        else if (age >= 18)
        {
            return true; // Can vote
        }
        else
        {
            return false; // Cannot vote
        }
    }

    public static void Main(string[] args)
    {
        StudentVoteChecker checker = new StudentVoteChecker();
        int[] ages = new int[10]; // Array to store ages of 10 students

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Enter age of student {i + 1}: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int age);

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                i--; // repeat this iteration
                continue;
            }

            ages[i] = age;

            if (checker.CanStudentVote(age))
            {
                Console.WriteLine("This student CAN vote.");
            }
            else
            {
                Console.WriteLine("This student CANNOT vote.");
            }
        }

        Console.WriteLine("\nSummary of voting eligibility:");
        for (int i = 0; i < 10; i++)
        {
            string result = checker.CanStudentVote(ages[i]) ? "CAN vote" : "CANNOT vote";
            Console.WriteLine($"Student {i + 1}: Age = {ages[i]}, {result}");
        }
    }
}
