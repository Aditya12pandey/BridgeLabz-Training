using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased.TraficManager
{
    internal interface IRoundabout
    {
        void AddVehicle(string vehicleNumber);
        bool RemoveVehicle(string vehicleNumber);
        void PrintRoundabout();
        bool IsEmpty();
        int GetCount();
    }
}
