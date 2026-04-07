using System;

class FahrenheitToCelsius
{
    static void Main()
    {
        Console.Write("Enter temperature in Fahrenheit: ");
        double f = double.Parse(Console.ReadLine());

        double c = (f - 32) * 5 / 9;
        Console.WriteLine("Temperature in Celsius = " + c);
    }
}
