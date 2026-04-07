using System;
using System.Collections.Generic;

namespace RideHailingApplication
{
    // Interface for GPS functionality
    interface IGPS
    {
        string GetCurrentLocation();
        void UpdateLocation(string newLocation);
    }

    // Abstract Vehicle class
    abstract class Vehicle
    {
        // Encapsulated fields
        private int vehicleId;
        private string driverName;
        protected double ratePerKm;

        // Properties
        public int VehicleId
        {
            get { return vehicleId; }
            private set { vehicleId = value; }
        }

        public string DriverName
        {
            get { return driverName; }
            private set { driverName = value; }
        }

        // Constructor
        public Vehicle(int id, string driverName, double rate)
        {
            vehicleId = id;
            this.driverName = driverName;
            ratePerKm = rate;
        }

        // Abstract method
        public abstract double CalculateFare(double distance);

        // Concrete method
        public void GetVehicleDetails()
        {
            Console.WriteLine("Vehicle ID    : " + VehicleId);
            Console.WriteLine("Driver Name   : " + DriverName);
            Console.WriteLine("Rate per Km   : " + ratePerKm);
        }
    }

    // Car class
    class Car : Vehicle, IGPS
    {
        private string currentLocation = "Not Set";

        public Car(int id, string driverName)
            : base(id, driverName, 15) { }

        public override double CalculateFare(double distance)
        {
            return (ratePerKm * distance) + 50; // base charge
        }

        public string GetCurrentLocation()
        {
            return currentLocation;
        }

        public void UpdateLocation(string newLocation)
        {
            currentLocation = newLocation;
        }
    }

    // Bike class
    class Bike : Vehicle, IGPS
    {
        private string currentLocation = "Not Set";

        public Bike(int id, string driverName)
            : base(id, driverName, 8) { }

        public override double CalculateFare(double distance)
        {
            return ratePerKm * distance;
        }

        public string GetCurrentLocation()
        {
            return currentLocation;
        }

        public void UpdateLocation(string newLocation)
        {
            currentLocation = newLocation;
        }
    }

    // Auto class
    class Auto : Vehicle, IGPS
    {
        private string currentLocation = "Not Set";

        public Auto(int id, string driverName)
            : base(id, driverName, 10) { }

        public override double CalculateFare(double distance)
        {
            return (ratePerKm * distance) + 20; // auto charge
        }

        public string GetCurrentLocation()
        {
            return currentLocation;
        }

        public void UpdateLocation(string newLocation)
        {
            currentLocation = newLocation;
        }
    }

    // Main Application Class
    class RideHailingApplicationApp
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car(1, "Ramesh"),
                new Bike(2, "Suresh"),
                new Auto(3, "Mahesh")
            };

            double distance = 10; // km

            // Update locations
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle is IGPS gps)
                {
                    gps.UpdateLocation("City Center");
                }
            }

            // Polymorphism demonstration
            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.GetVehicleDetails();
                Console.WriteLine("Fare for " + distance + " km : " + vehicle.CalculateFare(distance));
                Console.WriteLine("-----------------------------------");
            }

            Console.ReadLine();
        }
    }
}
