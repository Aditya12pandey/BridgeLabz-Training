using System;

class SimpleInterestProgram
{
    static double CalculateSimpleInterest(double principal, double rate, double time)
    {
        return (principal * rate * time) / 100;
    }

    static void Main()
    {
        Console.Write("Enter Principal: ");
        double principal = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Rate of Interest: ");
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Time (in years): ");
        double time = Convert.ToDouble(Console.ReadLine());

        double simpleInterest = CalculateSimpleInterest(principal, rate, time);

        Console.WriteLine(
            "The Simple Interest is {0} for Principal {1}, Rate of Interest {2} and Time {3}",
            simpleInterest, principal, rate, time
        );
    }
}
