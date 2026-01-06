//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Runtime.ConstrainedExecution;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraning.ScenarioBased
//{
//    interface IRentable
//    {
//        double CalculateRent(int days);
//    }

//    // ---------------- BASE CLASS ----------------
//    abstract class Vehicle : IRentable
//    {
//        protected int vehicleId;
//        protected string brand;
//        protected double ratePerDay;

//        public Vehicle(int id, string brand, double rate)
//        {
//            this.vehicleId = id;
//            this.brand = brand;
//            this.ratePerDay = rate;
//        }

//        public abstract double CalculateRent(int days);

//        public virtual void DisplayInfo()
//        {
//            Console.WriteLine($"Vehicle ID: {vehicleId}");
//            Console.WriteLine($"Brand: {brand}");
//            Console.WriteLine($"Rate per Day: ₹{ratePerDay}");
//        }
//    }

//    // ---------------- BIKE CLASS ----------------
//    class Bike : Vehicle
//    {
//        public Bike(int id, string brand, double rate)
//            : base(id, brand, rate) { }

//        public override double CalculateRent(int days)
//        {
//            return days * ratePerDay;
//        }

//        public override void DisplayInfo()
//        {
//            Console.WriteLine("\n--- Bike Details ---");
//            base.DisplayInfo();
//        }
//    }

//    // ---------------- CAR CLASS ----------------
//    class Car : Vehicle
//    {
//        public Car(int id, string brand, double rate)
//            : base(id, brand, rate) { }

//        public override double CalculateRent(int days)
//        {
//            return days * ratePerDay + 500; // extra service charge
//        }

//        public override void DisplayInfo()
//        {
//            Console.WriteLine("\n--- Car Details ---");
//            base.DisplayInfo();
//        }
//    }

//    // ---------------- TRUCK CLASS ----------------
//    class Truck : Vehicle
//    {
//        public Truck(int id, string brand, double rate)
//            : base(id, brand, rate) { }

//        public override double CalculateRent(int days)
//        {
//            return days * ratePerDay + 1000; // heavy vehicle charge
//        }

//        public override void DisplayInfo()
//        {
//            Console.WriteLine("\n--- Truck Details ---");
//            base.DisplayInfo();
//        }
//    }

//    // ---------------- CUSTOMER CLASS ----------------
//    class Customer
//    {
//        public int CustomerId { get; set; }
//        public string Name { get; set; }

//        public Customer(int id, string name)
//        {
//            CustomerId = id;
//            Name = name;
//        }

//        public void DisplayCustomer()
//        {
//            Console.WriteLine($"\nCustomer ID: {CustomerId}");
//            Console.WriteLine($"Customer Name: {Name}");
//        }
//    }
//    internal class VehiclerRentalSystem
//    {
//        static void Main()
//        {
//            Vehicle vehicle = null;

//            Console.Write("Enter Customer ID: ");
//            int cid = Convert.ToInt32(Console.ReadLine());

//            Console.Write("Enter Customer Name: ");
//            string cname = Console.ReadLine();

//            Customer customer = new Customer(cid, cname);

//            while (true)
//            {
//                Console.WriteLine("\n===== Vehicle Rental System =====");
//                Console.WriteLine("1. Rent Bike");
//                Console.WriteLine("2. Rent Car");
//                Console.WriteLine("3. Rent Truck");
//                Console.WriteLine("4. Display Bill");
//                Console.WriteLine("5. Exit");
//                Console.Write("Choose option: ");

//                int choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        vehicle = new Bike(101, "Honda", 300);
//                        Console.WriteLine("Bike selected successfully!");
//                        break;

//                    case 2:
//                        vehicle = new Car(201, "Toyota", 800);
//                        Console.WriteLine("Car selected successfully!");
//                        break;

//                    case 3:
//                        vehicle = new Truck(301, "Tata", 1500);
//                        Console.WriteLine("Truck selected successfully!");
//                        break;

//                    case 4:
//                        if (vehicle == null)
//                        {
//                            Console.WriteLine("Please select a vehicle first!");
//                            break;
//                        }

//                        Console.Write("Enter number of rental days: ");
//                        int days = Convert.ToInt32(Console.ReadLine());

//                        customer.DisplayCustomer();
//                        vehicle.DisplayInfo();
//                        Console.WriteLine($"Total Rent: ₹{vehicle.CalculateRent(days)}");
//                        break;

//                    case 5:
//                        Console.WriteLine("Thank you for using Vehicle Rental System!");
//                        return;

//                    default:
//                        Console.WriteLine("Invalid option!");
//                        break;
//                }
//            }
//        }
//    }
//}
