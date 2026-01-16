using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased.TraficManager
{
    internal class QueueNode
    {
        public string VehicleNumber;
        public QueueNode Next;

        public QueueNode(string vehicleNumber)
        {
            VehicleNumber = vehicleNumber;
            Next = null;
        }
    }
}
