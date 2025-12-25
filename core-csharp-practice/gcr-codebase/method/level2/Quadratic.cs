using System;

public class Quadratic
{
    public static double[] FindRoots(double a, double b, double c)
    {
        if (a == 0)
        {
            Console.WriteLine("Coefficient 'a' cannot be 0 for a quadratic equation.");
            return new double[0]; // empty array
        }

        double delta = Math.Pow(b, 2) - 4 * a * c; // discriminant

        if (delta > 0)
        {
            double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double root2 = (-b - Math.Sqrt(delta)) / (2 * a);
            return new double[] { root1, root2 };
        }
        else if (delta == 0)
        {
            double root = -b / (2 * a);
            return new double[] { root };
        }
        else
        {
            // delta < 0, no real roots
            return new double[0];
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter coefficient a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter coefficient b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Enter coefficient c: ");
        double c = double.Parse(Console.ReadLine());

        double[] roots = FindRoots(a, b, c);

        if (roots.Length == 0)
        {
            Console.WriteLine("The equation has no real roots.");
        }
        else if (roots.Length == 1)
        {
            Console.WriteLine($"The equation has one real root: {roots[0]}");
        }
        else
        {
            Console.WriteLine($"The equation has two real roots: {roots[0]} and {roots[1]}");
        }
    }
}
