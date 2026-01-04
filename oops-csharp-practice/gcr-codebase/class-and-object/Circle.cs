using System;

class Circle
{
    public double radius;

    public double CalculateArea()
    {
        return 3.14 * radius * radius;
    }

    public double CalculateCircumference()
    {
        return 2 * 3.14 * radius;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Radius: " + radius);
        Console.WriteLine("Area of Circle: " + CalculateArea());
        Console.WriteLine("Circumference of Circle: " + CalculateCircumference());
    }
}

class Program
{
    public static void Main()
    {
        Circle c = new Circle();

        Console.Write("Enter radius of the circle: ");
        c.radius = double.Parse(Console.ReadLine());

        c.DisplayDetails();
    }
}
