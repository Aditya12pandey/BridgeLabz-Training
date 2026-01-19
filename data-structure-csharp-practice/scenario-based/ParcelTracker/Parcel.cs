using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.ParcelTracker
{
    internal class Parcel
    {

        public int ParcelId;
        public string ParcelName;
        public string ReceiverName;

        public SinglyLinkedList TrackingStages;

        public Parcel(int parcelId, string parcelName, string receiverName)
        {
            TrackingStages = new SinglyLinkedList();
            ParcelId = parcelId;
            ParcelName = parcelName;
            ReceiverName = receiverName;

            TrackingStages.AddLast("Packed");

        }
    }
}
