using System;

class VolumeOfCylinder
{
    static void Main()
    {
        Console.Write("Enter radius: ");
        double r = double.Parse(Console.ReadLine());

        Console.Write("Enter height: ");
        double h = double.Parse(Console.ReadLine());

        double volume = Math.PI * r * r * h;
        Console.WriteLine("Volume of Cylinder = " + volume);
    }
}
