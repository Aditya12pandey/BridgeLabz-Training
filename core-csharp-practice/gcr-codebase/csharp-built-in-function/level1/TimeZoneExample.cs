using System;

class TimeZoneExample
{
    static void Main()
    {
        DateTimeOffset utcNow = DateTimeOffset.UtcNow;

        TimeZoneInfo gmtZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        DateTimeOffset gmtTime = TimeZoneInfo.ConvertTime(utcNow, gmtZone);
        DateTimeOffset istTime = TimeZoneInfo.ConvertTime(utcNow, istZone);
        DateTimeOffset pstTime = TimeZoneInfo.ConvertTime(utcNow, pstZone);

        Console.WriteLine("Current Time in Different Time Zones:");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("GMT : " + gmtTime);
        Console.WriteLine("IST : " + istTime);
        Console.WriteLine("PST : " + pstTime);
    }
}
