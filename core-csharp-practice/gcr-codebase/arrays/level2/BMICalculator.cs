using System;

class BMICalculator
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of persons: ");
        int count = Convert.ToInt32(Console.ReadLine());

        double[] weight = new double[count];
        double[] height = new double[count];
        double[] bmi = new double[count];
        string[] status = new string[count];

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nPerson {i + 1}:");

            Console.Write("Enter weight (in kg): ");
            weight[i] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter height (in meters): ");
            height[i] = Convert.ToDouble(Console.ReadLine());
        }

        for (int i = 0; i < count; i++)
        {
            bmi[i] = weight[i] / (height[i] * height[i]);

            if (bmi[i] < 18.5)
                status[i] = "Underweight";
            else if (bmi[i] < 25)
                status[i] = "Normal weight";
            else if (bmi[i] < 30)
                status[i] = "Overweight";
            else
                status[i] = "Obese";
        }

        Console.WriteLine("\n--- BMI Report ---");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(
                $"Person {i + 1}: Height = {height[i]} m, Weight = {weight[i]} kg, BMI = {bmi[i]:F2}, Status = {status[i]}"
            );
        }
    }
}
