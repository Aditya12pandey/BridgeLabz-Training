using System;

class Countdown
{
    static void Main()
    {
        int counter;

        Console.Write("Enter the countdown number: ");
        counter = int.Parse(Console.ReadLine());

        for (int i = counter; i >= 1; i--)
        {
            Console.WriteLine(i);
        }
    }
}
