using System;

class Circle
{
    // Attribute
    public double radius;

    // Default constructor
    public Circle() : this(1.0)   // Constructor chaining
    {
    }

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double CalculateArea()
    {
        return 3.14 * radius * radius;
    }

    public double CalculateCircumference()
    {
        return 2 * 3.14 * radius;
    }

    public void Display()
    {
        Console.WriteLine("Radius: " + radius);
        Console.WriteLine("Area: " + CalculateArea());
        Console.WriteLine("Circumference: " + CalculateCircumference());
    }
}

class Program
{
    public static void Main()
    {
        // Using default constructor
        Circle c1 = new Circle();
        c1.Display();

        Console.WriteLine();

        // Using parameterized constructor
        Console.Write("Enter radius: ");
        double r = double.Parse(Console.ReadLine());

        Circle c2 = new Circle(r);
        c2.Display();
    }
}
