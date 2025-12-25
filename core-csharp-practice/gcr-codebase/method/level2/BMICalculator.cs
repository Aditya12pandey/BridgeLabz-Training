using System;

public class BMICalculator
{
    public static void CalculateBMI(double[,] data, int numberOfPersons)
    {
        for (int i = 0; i < numberOfPersons; i++)
        {
            double weight = data[i, 0]; // in kg
            double heightInMeters = data[i, 1] / 100; // convert cm to meters
            double bmi = weight / (heightInMeters * heightInMeters);
            data[i, 2] = Math.Round(bmi, 2); // store BMI in 3rd column
        }
    }

    public static string[] DetermineBMIStatus(double[,] data, int numberOfPersons)
    {
        string[] status = new string[numberOfPersons];

        for (int i = 0; i < numberOfPersons; i++)
        {
            double bmi = data[i, 2];

            if (bmi < 18.5)
            {
                status[i] = "Underweight";
            }
            else if (bmi >= 18.5 && bmi < 24.9)
            {
                status[i] = "Normal weight";
            }
            else if (bmi >= 25 && bmi < 29.9)
            {
                status[i] = "Overweight";
            }
            else
            {
                status[i] = "Obese";
            }
        }

        return status;
    }

    public static void Main(string[] args)
    {
        int numberOfPersons = 10;
        double[,] data = new double[numberOfPersons, 3]; // 0=weight, 1=height, 2=BMI

        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.Write($"Enter weight (kg) for person {i + 1}: ");
            data[i, 0] = double.Parse(Console.ReadLine());

            Console.Write($"Enter height (cm) for person {i + 1}: ");
            data[i, 1] = double.Parse(Console.ReadLine());
        }

        CalculateBMI(data, numberOfPersons);

        string[] status = DetermineBMIStatus(data, numberOfPersons);

        Console.WriteLine("\nPerson\tWeight(kg)\tHeight(cm)\tBMI\t\tStatus");
        for (int i = 0; i < numberOfPersons; i++)
        {
            Console.WriteLine($"{i + 1}\t{data[i, 0]}\t\t{data[i, 1]}\t\t{data[i, 2]}\t\t{status[i]}");
        }
    }
}
