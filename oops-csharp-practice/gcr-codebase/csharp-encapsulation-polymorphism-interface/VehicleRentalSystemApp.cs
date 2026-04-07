using System;
using System.Collections.Generic;

namespace VehicleRentalSystem
{
    // Interface for Insurance
    interface IInsurable
    {
        double CalculateInsurance();
        string GetInsuranceDetails();
    }

    // Abstract Vehicle class
    abstract class Vehicle
    {
        // Encapsulated fields
        private string vehicleNumber;
        private string type;
        protected double rentalRate;

        // Sensitive information (restricted access)
        private string insurancePolicyNumber;

        // Properties
        public string VehicleNumber
        {
            get { return vehicleNumber; }
            set { vehicleNumber = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        protected string InsurancePolicyNumber
        {
            set { insurancePolicyNumber = value; }
        }

        // Constructor
        public Vehicle(string number, string type, double rate)
        {
            vehicleNumber = number;
            this.type = type;
            rentalRate = rate;
        }

        // Abstract method
        public abstract double CalculateRentalCost(int days);

        // Display method (polymorphism)
        public virtual void DisplayRentalDetails(int days)
        {
            double insurance = 0;

            if (this is IInsurable insurableVehicle)
                insurance = insurableVehicle.CalculateInsurance();

            double rentalCost = CalculateRentalCost(days);

            Console.WriteLine("Vehicle Number : " + VehicleNumber);
            Console.WriteLine("Vehicle Type   : " + Type);
            Console.WriteLine("Rental Cost   : " + rentalCost);
            Console.WriteLine("Insurance     : " + insurance);
            Console.WriteLine("Total Amount  : " + (rentalCost + insurance));
            Console.WriteLine("------------------------------------");
        }
    }

    // Car Class
    class Car : Vehicle, IInsurable
    {
        public Car(string number)
            : base(number, "Car", 1500)
        {
            InsurancePolicyNumber = "CAR-INS-101";
        }

        public override double CalculateRentalCost(int days)
        {
            return rentalRate * days;
        }

        public double CalculateInsurance()
        {
            return 500; // flat insurance
        }

        public string GetInsuranceDetails()
        {
            return "Car Insurance Policy";
        }
    }

    // Bike Class
    class Bike : Vehicle, IInsurable
    {
        public Bike(string number)
            : base(number, "Bike", 500)
        {
            InsurancePolicyNumber = "BIKE-INS-202";
        }

        public override double CalculateRentalCost(int days)
        {
            return rentalRate * days;
        }

        public double CalculateInsurance()
        {
            return 200;
        }

        public string GetInsuranceDetails()
        {
            return "Bike Insurance Policy";
        }
    }

    // Truck Class
    class Truck : Vehicle, IInsurable
    {
        public Truck(string number)
            : base(number, "Truck", 3000)
        {
            InsurancePolicyNumber = "TRUCK-INS-303";
        }

        public override double CalculateRentalCost(int days)
        {
            return (rentalRate * days) + 1000; // extra loading charge
        }

        public double CalculateInsurance()
        {
            return 1000;
        }

        public string GetInsuranceDetails()
        {
            return "Truck Insurance Policy";
        }
    }

    // Main Application Class
    class VehicleRentalSystemApp
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car("MH12AB1234"),
                new Bike("MH14CD5678"),
                new Truck("MH20EF9012")
            };

            int rentalDays = 3;

            // Polymorphism demonstration
            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.DisplayRentalDetails(rentalDays);
            }

            Console.ReadLine();
        }
    }
}
