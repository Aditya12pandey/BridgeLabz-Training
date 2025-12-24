using System;

class BMICalculator2D
{
    static void Main()
    {
        Console.Write("Enter number of persons: ");
        int number = Convert.ToInt32(Console.ReadLine());

        double[][] personData = new double[number][];
        string[] weightStatus = new string[number];

        for (int i = 0; i < number; i++)
        {
            personData[i] = new double[3];
        }

        for (int i = 0; i < number; i++)
        {
            Console.WriteLine($"\nPerson {i + 1}:");

            Console.Write("Enter weight (kg): ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter height (meters): ");
            double height = Convert.ToDouble(Console.ReadLine());

            if (weight <= 0 || height <= 0)
            {
                Console.WriteLine("Invalid input! Weight and height must be positive.");
                i--; // re-enter values
                continue;
            }

            personData[i][0] = weight;
            personData[i][1] = height;
        }

        for (int i = 0; i < number; i++)
        {
            double weight = personData[i][0];
            double height = personData[i][1];

            double bmi = weight / (height * height);
            personData[i][2] = bmi;

            if (bmi < 18.5)
                weightStatus[i] = "Underweight";
            else if (bmi < 25)
                weightStatus[i] = "Normal weight";
            else if (bmi < 30)
                weightStatus[i] = "Overweight";
            else
                weightStatus[i] = "Obese";
        }

        Console.WriteLine("\n--- BMI REPORT ---");
        for (int i = 0; i < number; i++)
        {
            Console.WriteLine(
                $"Person {i + 1}: Height = {personData[i][1]} m, " +
                $"Weight = {personData[i][0]} kg, " +
                $"BMI = {personData[i][2]:F2}, " +
                $"Status = {weightStatus[i]}"
            );
        }
    }
}
