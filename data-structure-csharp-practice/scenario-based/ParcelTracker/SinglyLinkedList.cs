using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.ParcelTracker
{
    internal class SinglyLinkedList
    {
        private Node head;
        public SinglyLinkedList()
        {
            head = null;
        }
        public void AddLast(string data)
        {
            Node newnode = new Node(data);
            if (head == null)
            {
                head = newnode;
                return;
            }
            Node temp;
            temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newnode;
        }
        public void Display() 
        {
            if(head == null) 
            {
                Console.WriteLine("Item is not Packed");
                return;
            }
            Node temp;
            temp = head;
            while(temp.Next != null)
            {
                Console.WriteLine(temp);
                if(temp.Next != null)
                {
                    Console.WriteLine("->");
                }
                else
                {
                    Console.WriteLine(".");
                }
                temp = temp.Next;
            }
        }
    }
}
