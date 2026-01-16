using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased.TraficManager
{
    internal class VehicleNode
    {
        public string VehicleNumber;
        public VehicleNode Next;

        public VehicleNode(string vehicleNumber)
        {
            VehicleNumber = vehicleNumber;
            Next = null;
        }
    }
}
