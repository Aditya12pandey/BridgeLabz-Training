using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased.TraficManager
{
    internal class TrafficManagerMain
    {
        static string ReadVehicleNumber()
        {
            Console.Write("Enter Vehicle Number: ");
            string vehicleNumber = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(vehicleNumber))
            {
                Console.Write(" Invalid input! Enter Vehicle Number again: ");
                vehicleNumber = Console.ReadLine();
            }

            return vehicleNumber.Trim();
        }

        static int ReadCapacity()
        {
            Console.Write("Enter Waiting Queue Capacity: ");
            int cap;

            while (!int.TryParse(Console.ReadLine(), out cap) || cap <= 0)
            {
                Console.Write(" Invalid capacity Enter again: ");
            }

            return cap;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to TrafficManager (Roundabout System)");

            IRoundabout roundabout = new Roundabout();
            int capacity = ReadCapacity();
            IWaitingQueue waitingQueue = new WaitingQueue(capacity);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("  TrafficManager - Roundabout Flow");
                Console.WriteLine("1. Add Vehicle to Waiting Queue");
                Console.WriteLine("2. Allow Vehicle to Enter Roundabout (From Queue)");
                Console.WriteLine("3. Remove Vehicle from Roundabout (Exit)");
                Console.WriteLine("4. Print Roundabout State");
                Console.WriteLine("5. Print Waiting Queue State");
                Console.WriteLine("6. Print Full System State");
                Console.WriteLine("0. Exit");
                Console.Write("Enter Choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string v = ReadVehicleNumber();
                        waitingQueue.Enqueue(v);
                        break;

                    case "2":
                        string enterVehicle = waitingQueue.Dequeue();
                        if (enterVehicle != null)
                            roundabout.AddVehicle(enterVehicle);
                        break;

                    case "3":
                        string exitVehicle = ReadVehicleNumber();
                        roundabout.RemoveVehicle(exitVehicle);
                        break;

                    case "4":
                        roundabout.PrintRoundabout();
                        break;

                    case "5":
                        waitingQueue.PrintQueue();
                        break;

                    case "6":
                        Console.WriteLine("\n FULL STATE ");
                        Console.WriteLine($"Roundabout Vehicles: {roundabout.GetCount()}");
                        Console.WriteLine($"Waiting Queue Size : {waitingQueue.GetSize()}/{waitingQueue.GetCapacity()}");
                        roundabout.PrintRoundabout();
                        waitingQueue.PrintQueue();
                        break;

                    case "0":
                        exit = true;
                        Console.WriteLine(" System Exit");
                        break;

                    default:
                        Console.WriteLine(" Invalid choice! Try again.");
                        break;
                }
            }
        }
    }
}
