using System;

class TriangularParkRun
{
    static double CalculateRounds(double side1, double side2, double side3)
    {
        double perimeter = side1 + side2 + side3;
        double totalDistance = 5000; // 5 km in meters
        return totalDistance / perimeter;
    }

    static void Main()
    {
        Console.Write("Enter side 1 (in meters): ");
        double side1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side 2 (in meters): ");
        double side2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side 3 (in meters): ");
        double side3 = Convert.ToDouble(Console.ReadLine());

        double rounds = CalculateRounds(side1, side2, side3);

        Console.WriteLine(
            "The athlete must complete {0} rounds to finish a 5 km run.",
            rounds
        );
    }
}
