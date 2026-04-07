using System;

class PowerCalculate
{
    static void Main()
    {
        Console.Write("Enter base: ");
        double baseNum = double.Parse(Console.ReadLine());

        Console.Write("Enter exponent: ");
        double exp = double.Parse(Console.ReadLine());

        double result = Math.Pow(baseNum, exp);
        Console.WriteLine("Result = " + result);
    }
}
