using System;

class RocketLaunch
{
    static void Main()
    {
        int counter;

        Console.Write("Enter the countdown number: ");
        counter = int.Parse(Console.ReadLine());

        while (counter >= 1)
        {
            Console.WriteLine(counter);
            counter--;
        }
    }
}
