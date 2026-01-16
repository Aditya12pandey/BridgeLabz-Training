using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased.TraficManager
{
    internal class Roundabout : IRoundabout
    {
        private VehicleNode tail;   // tail.Next = head
        private int count;

        public Roundabout()
        {
            tail = null;
            count = 0;
        }

        public void AddVehicle(string vehicleNumber)
        {
            VehicleNode newNode = new VehicleNode(vehicleNumber);

            if (tail == null)
            {
                tail = newNode;
                tail.Next = tail; // circular
            }
            else
            {
                newNode.Next = tail.Next; // new -> head
                tail.Next = newNode;      // tail -> new
                tail = newNode;           // new tail
            }

            count++;
            Console.WriteLine($" Vehicle {vehicleNumber} ENTERED roundabout.");
        }

        public bool RemoveVehicle(string vehicleNumber)
        {
            if (tail == null)
            {
                Console.WriteLine(" Roundabout is empty.");
                return false;
            }

            VehicleNode head = tail.Next;
            VehicleNode current = head;
            VehicleNode prev = tail;

            do
            {
                if (current.VehicleNumber.Equals(vehicleNumber, StringComparison.OrdinalIgnoreCase))
                {
                    // Single node case
                    if (current == tail && current == head)
                    {
                        tail = null;
                    }
                    else
                    {
                        prev.Next = current.Next;

                        // if removing tail, update tail
                        if (current == tail)
                            tail = prev;
                    }

                    count--;
                    Console.WriteLine($" Vehicle {vehicleNumber} EXITED roundabout.");
                    return true;
                }

                prev = current;
                current = current.Next;

            } while (current != head);

            Console.WriteLine($" Vehicle {vehicleNumber} NOT FOUND in roundabout.");
            return false;
        }

        public void PrintRoundabout()
        {
            if (tail == null)
            {
                Console.WriteLine(" Roundabout State: EMPTY");
                return;
            }

            VehicleNode head = tail.Next;
            VehicleNode temp = head;

            Console.WriteLine("\n Roundabout Vehicles (Circular):");

            do
            {
                Console.Write(temp.VehicleNumber );
                temp = temp.Next;
            } while (temp != head);

            Console.WriteLine("back to " + head.VehicleNumber);
        }

        public bool IsEmpty()
        {
            return tail == null;
        }

        public int GetCount()
        {
            return count;
        }
    }
}
