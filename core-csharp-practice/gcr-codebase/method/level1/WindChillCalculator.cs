using System;

class WindChillCalculator
{
    public static double CalculateWindChill(double temperature, double windSpeed)
    {
        double windChill = 35.74
                           + (0.6215 * temperature)
                           + (0.4275 * temperature - 35.75) * Math.Pow(windSpeed, 0.16);

        return windChill;
    }

    static void Main()
    {
        Console.Write("Enter temperature (in Fahrenheit): ");
        double temperature = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter wind speed (in mph): ");
        double windSpeed = Convert.ToDouble(Console.ReadLine());

        double result = CalculateWindChill(temperature, windSpeed);

        Console.WriteLine("The Wind Chill Temperature is: " + result);
    }
}
