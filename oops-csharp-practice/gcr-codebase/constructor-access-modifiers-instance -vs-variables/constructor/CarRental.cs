
using System;

class CarRental
{
    // Attributes
    public string customerName;
    public string carModel;
    public int rentalDays;

    // Cost per day (fixed for simplicity)
    public double costPerDay = 1500;

    // Default constructor
    public CarRental()
    {
        customerName = "Customer";
        carModel = "Standard";
        rentalDays = 1;
    }

    // Parameterized constructor
    public CarRental(string customerName, string carModel, int rentalDays)
    {
        this.customerName = customerName;
        this.carModel = carModel;
        this.rentalDays = rentalDays;
    }

    // Method to calculate total cost
    public double CalculateTotalCost()
    {
        return rentalDays * costPerDay;
    }

    // Method to display rental details
    public void DisplayDetails()
    {
        Console.WriteLine("Customer Name : " + customerName);
        Console.WriteLine("Car Model     : " + carModel);
        Console.WriteLine("Rental Days   : " + rentalDays);
        Console.WriteLine("Total Cost    : ₹" + CalculateTotalCost());
        Console.WriteLine();
    }
}

class Program
{
    public static void Main()
    {
        // Using default constructor
        CarRental r1 = new CarRental();
        Console.WriteLine("Default Rental:");
        r1.DisplayDetails();

        // Using parameterized constructor
        CarRental r2 = new CarRental("Aditya", "SUV", 5);
        Console.WriteLine("Parameterized Rental:");
        r2.DisplayDetails();
    }
}
