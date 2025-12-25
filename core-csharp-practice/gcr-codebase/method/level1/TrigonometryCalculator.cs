using System;

class TrigonometryCalculator
{
    public static double[] CalculateTrigonometricFunctions(double angle)
    {
        double radians = angle * Math.PI / 180;

        double sine = Math.Sin(radians);
        double cosine = Math.Cos(radians);
        double tangent = Math.Tan(radians);

        return new double[] { sine, cosine, tangent };
    }

    static void Main()
    {
        Console.Write("Enter angle in degrees: ");
        double angle = Convert.ToDouble(Console.ReadLine());

        double[] result = CalculateTrigonometricFunctions(angle);

        Console.WriteLine("Sine of angle = " + result[0]);
        Console.WriteLine("Cosine of angle = " + result[1]);
        Console.WriteLine("Tangent of angle = " + result[2]);
    }
}
