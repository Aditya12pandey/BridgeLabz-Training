using System;

class SpringSeason
{
    static bool IsSpringSeason(int month, int day)
    {
        if ((month == 3 && day >= 20) ||
            (month == 4) ||
            (month == 5) ||
            (month == 6 && day <= 20))
        {
            return true;
        }
        return false;
    }

    static void Main(string[] args)
    {
        int month = Convert.ToInt32(args[0]);
        int day = Convert.ToInt32(args[1]);

        if (IsSpringSeason(month, day))
            Console.WriteLine("Its a Spring Season");
        else
            Console.WriteLine("Not a Spring Season");
    }
}
