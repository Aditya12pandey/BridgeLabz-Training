using System;
using System.Collections.Generic;

class PetrolPump
{
    public int Petrol { get; set; }
    public int Distance { get; set; }

    public PetrolPump(int petrol, int distance)
    {
        Petrol = petrol;
        Distance = distance;
    }
}

class CircularTourUsingQueue
{
    public static int FindStartingPoint(PetrolPump[] pumps)
    {
        Queue<int> queue = new Queue<int>();
        int start = 0;
        int surplus = 0;
        int count = 0;
        int n = pumps.Length;

        while (count < n)
        {
            surplus += pumps[start].Petrol - pumps[start].Distance;
            queue.Enqueue(start);

            // If surplus goes negative, reset
            while (surplus < 0 && queue.Count > 0)
            {
                int removed = queue.Dequeue();
                surplus -= pumps[removed].Petrol - pumps[removed].Distance;
                count++;
            }

            start = (start + 1) % n;
        }

        return (surplus >= 0 && queue.Count > 0) ? queue.Peek() : -1;
    }
}

class CircularTourProblem
{
    static void Main()
    {
        PetrolPump[] pumps =
        {
            new PetrolPump(6, 4),
            new PetrolPump(3, 6),
            new PetrolPump(7, 3)
        };

        int startIndex = CircularTourUsingQueue.FindStartingPoint(pumps);

        if (startIndex == -1)
            Console.WriteLine("No possible circular tour.");
        else
            Console.WriteLine("Start at petrol pump index: " + startIndex);
    }
}
