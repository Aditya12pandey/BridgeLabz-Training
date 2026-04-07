using System;

class BmiCalculator
{
    static void Main()
    {
        Console.Write("Enter weight in kg: ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Enter height in cm: ");
        double heightCm = double.Parse(Console.ReadLine());

        double heightM = heightCm / 100;

        // Calculate BMI
        double bmi = weight / (heightM * heightM);

        Console.WriteLine("Your BMI is: " + bmi.ToString("F2"));

        if (bmi < 18.5)
        {
            Console.WriteLine("Weight Status: Underweight");
        }
        else if (bmi >= 18.5 && bmi < 24.9)
        {
            Console.WriteLine("Weight Status: Normal weight");
        }
        else if (bmi >= 25 && bmi < 29.9)
        {
            Console.WriteLine("Weight Status: Overweight");
        }
        else
        {
            Console.WriteLine("Weight Status: Obese");
        }
    }
}
