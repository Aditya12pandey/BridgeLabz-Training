using System;

public class EarthVolume
{
    public static void Main(string[] args)
    {
        double radiusKm = 6378;
        double pi = Math.PI;

        double volumeKm3 = (4.0 / 3.0) * pi * Math.Pow(radiusKm, 3);

        // Convert cubic kilometers to cubic miles
        double volumeMiles3 = volumeKm3 * Math.Pow(0.621371, 3);

        Console.WriteLine("The volume of earth in cubic kilometers is " + volumeKm3 +" and cubic miles is " + volumeMiles3);
    }
}
