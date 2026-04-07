using System;

class KmToMiles
{
    static void Main()
    {
        Console.Write("Enter distance in KM: ");
        double km = double.Parse(Console.ReadLine());

        double miles = km * 0.621371;
        Console.WriteLine("Distance in Miles = " + miles);
    }
}
