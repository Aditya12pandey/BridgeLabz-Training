using System;

class LeapYear
{
    static void Main()
    {
        int year;

        Console.Write("Enter a year: ");
        year = int.Parse(Console.ReadLine());

        if (year < 1582)
        {
            Console.WriteLine("Leap Year calculation is valid only for year >= 1582");
            return;
        }

        Console.WriteLine("\nUsing multiple if-else statements:");

        if (year % 400 == 0)
        {
            Console.WriteLine("The year " + year + " is a Leap Year");
        }
        else if (year % 100 == 0)
        {
            Console.WriteLine("The year " + year + " is not a Leap Year");
        }
        else if (year % 4 == 0)
        {
            Console.WriteLine("The year " + year + " is a Leap Year");
        }
        else
        {
            Console.WriteLine("The year " + year + " is not a Leap Year");
        }

        Console.WriteLine("\nUsing single if statement with logical operators:");

        if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
        {
            Console.WriteLine("The year " + year + " is a Leap Year");
        }
        else
        {
            Console.WriteLine("The year " + year + " is not a Leap Year");
        }
    }
}
