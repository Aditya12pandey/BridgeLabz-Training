using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.ParcelTracker
{
    internal class ParcelTrackingMain
    {
        public static void Main(string[] args)
        {
            IParcelService service = new ParcelServiceUtility();
            int choice;

            do
            {
                Console.WriteLine("\n Multi Parcel Tracking Menu ");
                Console.WriteLine("1. Add Parcel");
                Console.WriteLine("2. Display All Parcels");
                Console.WriteLine("3. Display Parcel Tracking");
                Console.WriteLine("4. Add Tracking Stage at End");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine(" Invalid input! Enter number only.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Parcel ID: ");
                        int parcelId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter ParcelName Name: ");
                        string sender = Console.ReadLine();

                        Console.Write("Enter Receiver Name: ");
                        string receiver = Console.ReadLine();

                        service.AddParcel(parcelId, sender, receiver);
                        break;

                    case 2:
                        service.DisplayParcels();
                        break;

                    case 3:
                        Console.Write("Enter Parcel ID: ");
                        int searchId = Convert.ToInt32(Console.ReadLine());
                        service.DisplayParcelStatus(searchId);
                        break;

                    case 4:
                        Console.Write("Enter Parcel ID: ");
                        int pid = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter new stage name: ");
                        string stage = Console.ReadLine();

                        service.UpdateParcelStatus(pid, stage);
                        break;                  
                    case 0:
                        Console.WriteLine(" Exiting... Thank you!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 0);
        }

    }
}
