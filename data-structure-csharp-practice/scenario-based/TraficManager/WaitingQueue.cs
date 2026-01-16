using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased.TraficManager
{
    internal class WaitingQueue : IWaitingQueue
    {
        private QueueNode front;
        private QueueNode rear;
        private int size;
        private int capacity;

        public WaitingQueue(int capacity)
        {
            this.capacity = capacity;
            front = null;
            rear = null;
            size = 0;
        }

        public bool Enqueue(string vehicleNumber)
        {
            if (IsFull())
            {
                Console.WriteLine(" Queue Overflow Waiting queue is FULL.");
                return false;
            }

            QueueNode newNode = new QueueNode(vehicleNumber);

            if (rear == null)
            {
                front = rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }

            size++;
            Console.WriteLine($" Vehicle {vehicleNumber} added to WAITING QUEUE.");
            return true;
        }

        public string Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine(" Queue Underflow Waiting queue is EMPTY.");
                return null;
            }

            string data = front.VehicleNumber;
            front = front.Next;

            if (front == null)
                rear = null;

            size--;
            return data;
        }

        public void PrintQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine(" Waiting Queue: EMPTY");
                return;
            }

            Console.WriteLine("\n Waiting Queue (Front -> Rear):");

            QueueNode temp = front;
            while (temp != null)
            {
                Console.Write(temp.VehicleNumber );
                temp = temp.Next;
            }

            Console.WriteLine("REAR");
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == capacity;
        }

        public int GetSize()
        {
            return size;
        }

        public int GetCapacity()
        {
            return capacity;
        }
    }
}
