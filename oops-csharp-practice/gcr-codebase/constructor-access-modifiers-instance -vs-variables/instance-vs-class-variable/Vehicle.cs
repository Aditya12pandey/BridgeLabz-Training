using System;

class Vehicle
{
    // Instance variables
    public string ownerName;
    public string vehicleType;

    // Class (static) variable
    public static double registrationFee = 5000;

    // Constructor
    public Vehicle(string ownerName, string vehicleType)
    {
        this.ownerName = ownerName;
        this.vehicleType = vehicleType;
    }

    // Instance method
    public void DisplayVehicleDetails()
    {
        Console.WriteLine("Owner Name        : " + ownerName);
        Console.WriteLine("Vehicle Type      : " + vehicleType);
        Console.WriteLine("Registration Fee  : ₹" + registrationFee);
        Console.WriteLine();
    }

    // Class (static) method
    public static void UpdateRegistrationFee(double newFee)
    {
        registrationFee = newFee;
    }
}

class Program
{
    public static void Main()
    {
        Vehicle v1 = new Vehicle("Aditya", "Two-Wheeler");
        Vehicle v2 = new Vehicle("Rahul", "Four-Wheeler");

        // Display vehicle details
        v1.DisplayVehicleDetails();
        v2.DisplayVehicleDetails();

        // Update registration fee
        Vehicle.UpdateRegistrationFee(6000);

        Console.WriteLine("After Updating Registration Fee:\n");

        // Display again to show updated fee for all vehicles
        v1.DisplayVehicleDetails();
        v2.DisplayVehicleDetails();
    }
}
