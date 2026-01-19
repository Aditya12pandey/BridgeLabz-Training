using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.ParcelTracker
{
    internal class ParcelStore
    {
        private Parcel[] parcels;
        int count;
       
        public ParcelStore(int size)
        {
            parcels = new Parcel[size];
            count = 0;
        }
        public bool Add(Parcel parcel)
        {
            if (count >= parcels.Length)
                return false;

            // Avoid duplicate ParcelId
            for (int i = 0; i < count; i++)
            {
                if (parcels[i].ParcelId == parcel.ParcelId)
                    return false;
            }

            parcels[count] = parcel;
            count++;
            return true;
        }
        public Parcel GetById(int parcelId)
        {
            for (int i = 0; i < count; i++)
            {
                if (parcels[i].ParcelId == parcelId)
                    return parcels[i];
            }
            return null;
        }
        public int GetCount()
        {
            return count;
        }
        public Parcel GetAt(int index)
        {
            if (index < 0 || index >= count)
                return null;

            return parcels[index];
        }
    }
}
