using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased
{
    internal class RouteDistanceTracker
    {
        public static void Main()
        {
            double totalDistance = 0;
            double farePerKm = 5;
            char getOff = 'N';
            int stopCount = 0;

            Random random = new Random();

            Console.WriteLine("🚌 Bus Route Distance Tracker Started");

            while (getOff != 'Y' && getOff != 'y')
            {
                stopCount++;

                // Generate distance between 3 and 4 km
                double stopDistance = 3 + random.NextDouble(); // 3.0 to 4.0

                totalDistance += stopDistance;

                Console.WriteLine("\nStop Number: " + stopCount);
                Console.WriteLine("Distance from this stop: " + stopDistance.ToString("0.00") + " km");
                Console.WriteLine("Total distance so far: " + totalDistance.ToString("0.00") + " km");

                Console.Write("Do you want to get off at this stop? (Y/N): ");
                getOff = char.Parse(Console.ReadLine());
            }

            double totalFare = totalDistance * farePerKm;

            Console.WriteLine("\n--- Journey Summary ---");
            Console.WriteLine("Total Stops Travelled: " + stopCount);
            Console.WriteLine("Total Distance: " + totalDistance.ToString("0.00") + " km");
            Console.WriteLine("Fare per km: ₹" + farePerKm);
            Console.WriteLine("Total Fare: ₹" + totalFare.ToString("0.00"));

            Console.WriteLine("\nThank you for travelling with us ");
        }
    }
}
