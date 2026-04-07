using System;

public class CalendarDisplay
{
    public static string GetMonthName(int month)
    {
        string[] months = {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };
        return months[month - 1];
    }

    public static bool IsLeapYear(int year)
    {
        return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
    }

    public static int GetDaysInMonth(int month, int year)
    {
        int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        if (month == 2 && IsLeapYear(year))
        {
            return 29;
        }
        return days[month - 1];
    }

    public static int GetFirstDay(int month, int year)
    {
        int d = 1;
        int m = month;
        int y = year;

        int y0 = y - (14 - m) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = m + 12 * ((14 - m) / 12) - 2;
        int d0 = (d + x + (31 * m0) / 12) % 7;

        return d0;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter month (1-12): ");
        int month = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        string monthName = GetMonthName(month);
        int daysInMonth = GetDaysInMonth(month, year);
        int firstDay = GetFirstDay(month, year);

        Console.WriteLine($"\n     {monthName} {year}");
        Console.WriteLine(" Sun Mon Tue Wed Thu Fri Sat");

        for (int i = 0; i < firstDay; i++)
        {
            Console.Write("    ");
        }

        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write($"{day,4}");

            if ((day + firstDay) % 7 == 0)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine();
    }
}
