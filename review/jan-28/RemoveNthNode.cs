using review.DoublyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace review.DoublyLinkedList
{
    public class Node
    {
        public int Data;
        public Node next;
        public Node(int data)
        {
            Data = data;
            next = null;

        }
        
    }
    internal class RemoveNthNode
    {
        public Node Head;
        public void Add(int data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node temp = Head;
            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = newNode;
        }
        public void RemoveNthFromEnd(int n)
        {
            Node demo = new Node(0);
            demo.next = Head;

            Node pointer1 = demo;
            Node pointer2 = demo;

            // Move fast pointer n+1 steps
            for (int i = 0; i <= n; i++)
            {
                if (pointer1 == null)
                {
                    return; 
                }
                pointer1 = pointer1.next;
            }

            // Move both pointers
            while (pointer1 != null)
            {
                pointer1 = pointer1.next;
                pointer2 = pointer2.next;
            }

            // Remove node
            pointer2.next = pointer2.next.next;
            Head = demo.next;
        }
        public void Print()
        {
            Node temp = Head;
            while (temp != null)
            {
                Console.Write(temp.Data + " -> ");
                temp = temp.next;
            }
            Console.WriteLine("null");
        }

        static void Main()
        {
            RemoveNthNode list = new RemoveNthNode();

            Console.WriteLine("Enter the number of node to enter ");
            int x = Convert.ToInt32(Console.ReadLine());
            for(int i =0; i<x; i++)
            {
                Console.WriteLine("Enter the value");
                int k= Convert.ToInt32(Console.ReadLine());

                list.Add(k);
            }
            

            Console.WriteLine("Original List:");
            list.Print();

            Console.WriteLine("\nEnter the nth position from where to remove number");
            int n = Convert.ToInt32(Console.ReadLine());

            list.RemoveNthFromEnd(n);

            Console.WriteLine("After removing "+ n +"th node from end:");
            list.Print();
        }

    }
        
}
//remove nth node from end of linked list 
