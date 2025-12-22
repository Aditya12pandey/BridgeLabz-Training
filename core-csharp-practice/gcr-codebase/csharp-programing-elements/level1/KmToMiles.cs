using System;

public class KmToMiles
{
    public static void Main(string[] args)
    {
        double km;
        double miles;

        Console.Write("Enter distance in kilometers: ");
        km = Convert.ToDouble(Console.ReadLine());

        // 1 mile = 1.6 km
        miles = km / 1.6;

        Console.WriteLine("The total miles is " + miles + " mile for the given " + km + " km");
    }
}
