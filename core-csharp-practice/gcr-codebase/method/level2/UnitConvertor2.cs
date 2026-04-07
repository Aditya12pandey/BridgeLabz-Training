using System;

class UnitConvertor2
{
    public static double ConvertYardsToFeet(double yards)
    {
        double yards2feet = 3;
        return yards * yards2feet;
    }

    public static double ConvertFeetToYards(double feet)
    {
        double feet2yards = 0.333333;
        return feet * feet2yards;
    }

    public static double ConvertMetersToInches(double meters)
    {
        double meters2inches = 39.3701;
        return meters * meters2inches;
    }

    public static double ConvertInchesToMeters(double inches)
    {
        double inches2meters = 0.0254;
        return inches * inches2meters;
    }

    public static double ConvertInchesToCentimeters(double inches)
    {
        double inches2cm = 2.54;
        return inches * inches2cm;
    }


    static void Main()
    {
        Console.WriteLine("Yards to Feet: " + UnitConvertor.ConvertYardsToFeet(5));
        Console.WriteLine("Feet to Yards: " + UnitConvertor.ConvertFeetToYards(9));
        Console.WriteLine("Meters to Inches: " + UnitConvertor.ConvertMetersToInches(2));
        Console.WriteLine("Inches to Meters: " + UnitConvertor.ConvertInchesToMeters(10));
        Console.WriteLine("Inches to Centimeters: " + UnitConvertor.ConvertInchesToCentimeters(12));
    }
}

