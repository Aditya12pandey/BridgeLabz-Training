using System;

class TriangleArea
{
    public static void Main(string[] args)
    {
        // Input
        Console.Write("Enter base (in inches): ");
        double baseValue = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter height (in inches): ");
        double height = Convert.ToDouble(Console.ReadLine());

        // Area calculation
        double areaSqInches = 0.5 * baseValue * height;
        double areaSqCm = areaSqInches * 6.4516;

        // Height conversion
        double heightCm = height * 2.54;
        double heightFeet = height / 12;

        // Output
        Console.WriteLine("Area of Triangle:\n" +
            "Square Inches = " + areaSqInches +
            "\nSquare Centimeters = " + areaSqCm +
            "\n\nYour Height in cm is " + heightCm +
            " while in feet is " + heightFeet +
            " and inches is " + height);
    }
}
