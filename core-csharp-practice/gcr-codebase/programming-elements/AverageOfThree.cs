using System;

class AverageOfThree
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Enter third number: ");
        double c = double.Parse(Console.ReadLine());

        double avg = (a + b + c) / 3;
        Console.WriteLine("Average = " + avg);
    }
}
