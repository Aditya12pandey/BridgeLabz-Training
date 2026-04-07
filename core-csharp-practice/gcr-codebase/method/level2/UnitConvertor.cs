using System;

class UnitConvertor
{
    // Convert kilometers to miles
    public static double ConvertKmToMiles(double km)
    {
        double km2miles = 0.621371;
        return km * km2miles;
    }

    // Convert miles to kilometers
    public static double ConvertMilesToKm(double miles)
    {
        double miles2km = 1.60934;
        return miles * miles2km;
    }

    // Convert meters to feet
    public static double ConvertMetersToFeet(double meters)
    {
        double meters2feet = 3.28084;
        return meters * meters2feet;
    }

    // Convert feet to meters
    public static double ConvertFeetToMeters(double feet)
    {
        double feet2meters = 0.3048;
        return feet * feet2meters;
    }

    static void Main()
    {
        Console.WriteLine("10 Km to Miles: " + ConvertKmToMiles(10));
        Console.WriteLine("5 Miles to Km: " + ConvertMilesToKm(5));
        Console.WriteLine("3 Meters to Feet: " + ConvertMetersToFeet(3));
        Console.WriteLine("10 Feet to Meters: " + ConvertFeetToMeters(10));
    }
}
