using System;

class AreaOfCircle
{
    static void Main()
    {
        Console.Write("Enter radius: ");
        double r = double.Parse(Console.ReadLine());

        double area = Math.PI * r * r;
        Console.WriteLine("Area of Circle = " + area);
    }
}
