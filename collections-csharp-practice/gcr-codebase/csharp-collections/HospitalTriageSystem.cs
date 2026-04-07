using System;
using System.Collections.Generic;

class HospitalTriageSystem
{
    static void Main()
    {
        Console.Write("Enter number of patients: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // PriorityQueue works as MIN heap, so we use negative severity for MAX priority
        PriorityQueue<string, int> pq = new PriorityQueue<string, int>();

        for (int i = 0; i < n; i++)
        {
            Console.Write("\nEnter patient name: ");
            string name = Console.ReadLine();

            Console.Write("Enter severity (higher = more serious): ");
            int severity = Convert.ToInt32(Console.ReadLine());

            pq.Enqueue(name, -severity); // negative => higher severity comes first
        }

        Console.WriteLine("\nTreatment Order:");
        while (pq.Count > 0)
        {
            string patient = pq.Dequeue();
            Console.WriteLine(patient);
        }
    }
}
