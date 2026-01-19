using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BridgeLabzTraning.Datastructure.ParcelTracker
{
    internal class ParcelServiceUtility : IParcelService
    {
        private ParcelStore Store;
        public ParcelServiceUtility()
        {
            Store = new ParcelStore(5);
        }
        public void AddParcel(int parcelId, string ParcelName, string receiver)
        {
            Parcel parcel = new Parcel(parcelId, ParcelName, receiver);
            bool added = Store.Add(parcel);

            if (added)
                Console.WriteLine($" Parcel {parcelId} added successfully!");
            else
                Console.WriteLine(" Parcel not added (Duplicate ID OR Storage Full).");
        }
        public void DisplayParcels()
        {
            int total = Store.GetCount();

            if (total == 0)
            {
                Console.WriteLine(" No parcels available!");
                return;
            }

            Console.WriteLine("\n All Parcels:");
            for (int i = 0; i < total; i++)
            {
                Parcel p = Store.GetAt(i);
                Console.WriteLine($"ParcelId: {p.ParcelId} | ParcelName: {p.ParcelName}");
            }

        }
        public void UpdateParcelStatus(int parcelId, string newStatus)
        {
            Parcel parcel = Store.GetById(parcelId);

            if (parcel == null)
            {
                Console.WriteLine($" Parcel {parcelId} not found!");
                return;
            }

            if (string.IsNullOrWhiteSpace(newStatus))
            {
                Console.WriteLine(" Stage name cannot be empty!");
                return;
            }

            parcel.TrackingStages.AddLast(newStatus);
            Console.WriteLine($" Stage '{newStatus}' added to Parcel {parcelId}.");
        }
        public void DisplayParcelStatus(int parcelId)
        {
            Parcel parcel = Store.GetById(parcelId);

            if (parcel == null)
            {
                Console.WriteLine($" Parcel {parcelId} not found!");
                return;
            }

            Console.WriteLine($"\n Tracking for Parcel {parcel.ParcelId}:");
            parcel.TrackingStages.Display();
        }
    }
}
