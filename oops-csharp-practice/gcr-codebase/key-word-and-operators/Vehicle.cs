using System;

class Vehicle
{
    // static members
    public static double RegistrationFee = 2000;

    // readonly field
    public readonly string RegistrationNumber;

    // instance variables
    public string OwnerName;
    public string VehicleType;

    // constructor using this
    public Vehicle(string ownerName, string vehicleType, string registrationNumber)
    {
        this.OwnerName = ownerName;
        this.VehicleType = vehicleType;
        this.RegistrationNumber = registrationNumber;
    }

    // static method
    public static void UpdateRegistrationFee(double newFee)
    {
        RegistrationFee = newFee;
        Console.WriteLine("Updated Registration Fee: " + RegistrationFee);
    }

    public void DisplayVehicle()
    {
        Console.WriteLine("\nOwner Name          : " + OwnerName);
        Console.WriteLine("Vehicle Type        : " + VehicleType);
        Console.WriteLine("Registration Number : " + RegistrationNumber);
        Console.WriteLine("Registration Fee    : " + RegistrationFee);
    }
}

class VehicleApp
{
    public static void Main()
    {
        Vehicle.UpdateRegistrationFee(2500);

        Vehicle v1 = new Vehicle("Amit", "Car", "MH12AB1234");

        if (v1 is Vehicle)
            v1.DisplayVehicle();
    }
}
