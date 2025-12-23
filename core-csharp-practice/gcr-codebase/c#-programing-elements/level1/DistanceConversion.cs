using System;

class DistanceConversion
{
    public static void Main(string[] args)
    {
        Console.Write("Enter distance in feet: ");
        double distanceInFeet = Convert.ToDouble(Console.ReadLine());

        double yards = distanceInFeet / 3;
        double miles = yards / 1760;

        Console.WriteLine("Distance in yards is " + yards +" and distance in miles is " + miles);
    }
}
