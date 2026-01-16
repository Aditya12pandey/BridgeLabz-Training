using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased.TraficManager
{
    internal interface IWaitingQueue
    {
        bool Enqueue(string vehicleNumber);
        string Dequeue();
        void PrintQueue();
        bool IsEmpty();
        bool IsFull();
        int GetSize();
        int GetCapacity();
    }
}
