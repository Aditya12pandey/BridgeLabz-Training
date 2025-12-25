using System;

public class GeometryUtility
{
    public static double FindDistance(double x1, double y1, double x2, double y2)
    {
        double dx = Math.Pow(x2 - x1, 2);
        double dy = Math.Pow(y2 - y1, 2);
        return Math.Sqrt(dx + dy);
    }

    public static double[] FindLineEquation(double x1, double y1, double x2, double y2)
    {
        double[] result = new double[2];

        if (x2 == x1)
        {
            throw new Exception("Slope is undefined (vertical line).");
        }

        double m = (y2 - y1) / (x2 - x1);
        double b = y1 - (m * x1);

        result[0] = m;
        result[1] = b;

        return result;
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

        double distance = FindDistance(x1, y1, x2, y2);
        Console.WriteLine($"\nEuclidean Distance = {distance:F2}");

        try
        {
            double[] line = FindLineEquation(x1, y1, x2, y2);
            Console.WriteLine($"Slope (m) = {line[0]:F2}");
            Console.WriteLine($"Y-Intercept (b) = {line[1]:F2}");
            Console.WriteLine($"Equation of line: y = {line[0]:F2}x + {line[1]:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
