using System;

class HotelBooking
{
    // Attributes
    public string guestName;
    public string roomType;
    public int nights;

    // Default constructor
    public HotelBooking()
    {
        guestName = "Guest";
        roomType = "Standard";
        nights = 1;
    }

    // Parameterized constructor
    public HotelBooking(string guestName, string roomType, int nights)
    {
        this.guestName = guestName;
        this.roomType = roomType;
        this.nights = nights;
    }

    // Copy constructor
    public HotelBooking(HotelBooking other)
    {
        this.guestName = other.guestName;
        this.roomType = other.roomType;
        this.nights = other.nights;
    }

    // Method to display booking details
    public void DisplayBooking()
    {
        Console.WriteLine("Guest Name : " + guestName);
        Console.WriteLine("Room Type  : " + roomType);
        Console.WriteLine("Nights     : " + nights);
        Console.WriteLine();
    }
}

class Program
{
    public static void Main()
    {
        // Default booking
        HotelBooking b1 = new HotelBooking();
        Console.WriteLine("Default Booking:");
        b1.DisplayBooking();

        // Parameterized booking
        HotelBooking b2 = new HotelBooking("Aditya", "Deluxe", 3);
        Console.WriteLine("Parameterized Booking:");
        b2.DisplayBooking();

        // Copy booking
        HotelBooking b3 = new HotelBooking(b2);
        Console.WriteLine("Copied Booking:");
        b3.DisplayBooking();
    }
}
