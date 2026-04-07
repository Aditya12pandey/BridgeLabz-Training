using System;

class DayOfWeek
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Usage: DayOfWeek <month> <day> <year>");
            return;
        }

        int m = int.Parse(args[0]);
        int d = int.Parse(args[1]);
        int y = int.Parse(args[2]);

        int y0 = y - (14 - m) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = m + 12 * ((14 - m) / 12) - 2;
        int d0 = (d + x + (31 * m0) / 12) % 7;

        Console.WriteLine("Day of the week (0 = Sunday, 1 = Monday, ... 6 = Saturday): " + d0);
    }
}
