using System;

public class CollinearPoints
{
    public static bool AreCollinearUsingSlope(
        double x1, double y1,
        double x2, double y2,
        double x3, double y3)
    {
        if ((x2 - x1) == 0 && (x3 - x2) == 0)
            return true;

        if ((x2 - x1) == 0 || (x3 - x2) == 0 || (x3 - x1) == 0)
            return false;

        double slopeAB = (y2 - y1) / (x2 - x1);
        double slopeBC = (y3 - y2) / (x3 - x2);
        double slopeAC = (y3 - y1) / (x3 - x1);

        return slopeAB == slopeBC && slopeBC == slopeAC;
    }

    public static bool AreCollinearUsingArea(
        double x1, double y1,
        double x2, double y2,
        double x3, double y3)
    {
        double area = 0.5 * (
            x1 * (y2 - y3) +
            x2 * (y3 - y1) +
            x3 * (y1 - y2)
        );

        return area == 0;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter x1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y1: ");
        double y1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter x2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y2: ");
        double y2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter x3: ");
        double x3 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y3: ");
        double y3 = Convert.ToDouble(Console.ReadLine());

        bool slopeResult = AreCollinearUsingSlope(x1, y1, x2, y2, x3, y3);
        bool areaResult = AreCollinearUsingArea(x1, y1, x2, y2, x3, y3);

        Console.WriteLine("\n--- Result ---");
        Console.WriteLine($"Using Slope Method: {(slopeResult ? "Collinear" : "Not Collinear")}");
        Console.WriteLine($"Using Area Method : {(areaResult ? "Collinear" : "Not Collinear")}");
    }
}
