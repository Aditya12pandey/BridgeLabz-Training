using System;

class LeapYearProgram
{
    static bool IsLeapYear(int year)
    {
        if (year < 1582)
            return false;

        if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
            return true;

        return false;
    }

    static void Main()
    {
        Console.Write("Enter a year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        if (IsLeapYear(year))
            Console.WriteLine("Year is a Leap Year");
        else
            Console.WriteLine("Year is not a Leap Year");
    }
}
