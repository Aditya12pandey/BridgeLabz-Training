using System;

class TemperatureConverter
{
    public static double GetTemperature(string scale)
    {
        double temp;
        Console.Write($"Enter temperature in {scale}: ");
        while (!double.TryParse(Console.ReadLine(), out temp))
        {
            Console.Write($"Invalid input! Enter temperature in {scale}: ");
        }
        return temp;
    }

    public static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    public static void DisplayResult(double originalTemp, string originalScale, double convertedTemp, string convertedScale)
    {
        Console.WriteLine($"{originalTemp}°{originalScale} is equal to {convertedTemp:F2}°{convertedScale}");
    }

    static void Main()
    {
        Console.WriteLine("Temperature Converter");
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        Console.Write("Choose conversion (1 or 2): ");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
        {
            Console.Write("Invalid choice! Enter 1 or 2: ");
        }

        if (choice == 1)
        {
            double celsius = GetTemperature("Celsius");
            double fahrenheit = CelsiusToFahrenheit(celsius);
            DisplayResult(celsius, "C", fahrenheit, "F");
        }
        else
        {
            double fahrenheit = GetTemperature("Fahrenheit");
            double celsius = FahrenheitToCelsius(fahrenheit);
            DisplayResult(fahrenheit, "F", celsius, "C");
        }
    }
}
