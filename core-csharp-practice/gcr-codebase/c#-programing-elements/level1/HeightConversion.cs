using System;

public class HeightConversion
{
    public static void Main(string[] args)
    {
        double heightCm;

        // Take user input
        Console.Write("Enter your height in centimeters: ");
        heightCm = Convert.ToDouble(Console.ReadLine());

        // Convert cm to inches
        double totalInches = heightCm / 2.54;

        // Convert inches to feet and remaining inches
        int feet = (int)(totalInches / 12);
        double inches = totalInches % 12;

        Console.WriteLine("Your Height in cm is " + heightCm +" while in feet is " + feet +" and inches is " + inches);
    }
}
