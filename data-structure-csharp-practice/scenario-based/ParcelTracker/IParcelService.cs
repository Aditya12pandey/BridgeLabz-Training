using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.ParcelTracker
{
    internal interface IParcelService
    {
        void AddParcel(int ParcelID, string ParcelName, string ReceiverName);
        void DisplayParcels();
        void UpdateParcelStatus(int ParcelID, string NewStatus);
        void DisplayParcelStatus(int ParcelID);
    }
}
