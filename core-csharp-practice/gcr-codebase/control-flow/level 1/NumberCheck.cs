using System;

class NumberCheck
{
    static void Main()
    {
        int number;

        Console.Write("Enter a number: ");
        number = int.Parse(Console.ReadLine());

        if (number > 0)
        {
            Console.WriteLine("positive");
        }
        else if (number < 0)
        {
            Console.WriteLine("negative");
        }
        else
        {
            Console.WriteLine("zero");
        }
    }
}
