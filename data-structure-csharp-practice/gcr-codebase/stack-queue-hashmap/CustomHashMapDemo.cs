using System;

class HashNode
{
    public int Key;
    public int Value;
    public HashNode Next;

    public HashNode(int key, int value)
    {
        Key = key;
        Value = value;
        Next = null;
    }
}

class CustomHashMap
{
    private const int SIZE = 10;   // Hash table size
    private HashNode[] table;

    public CustomHashMap()
    {
        table = new HashNode[SIZE];
    }

    // Simple hash function
    private int HashFunction(int key)
    {
        return key % SIZE;
    }

    // Insert or Update
    public void Put(int key, int value)
    {
        int index = HashFunction(key);
        HashNode head = table[index];

        // Update if key exists
        while (head != null)
        {
            if (head.Key == key)
            {
                head.Value = value;
                return;
            }
            head = head.Next;
        }

        // Insert at beginning
        HashNode newNode = new HashNode(key, value);
        newNode.Next = table[index];
        table[index] = newNode;
    }

    // Retrieve value
    public int Get(int key)
    {
        int index = HashFunction(key);
        HashNode head = table[index];

        while (head != null)
        {
            if (head.Key == key)
                return head.Value;
            head = head.Next;
        }

        return -1; // Key not found
    }

    // Remove key
    public void Remove(int key)
    {
        int index = HashFunction(key);
        HashNode head = table[index];
        HashNode prev = null;

        while (head != null)
        {
            if (head.Key == key)
            {
                if (prev == null)
                    table[index] = head.Next;
                else
                    prev.Next = head.Next;
                return;
            }
            prev = head;
            head = head.Next;
        }
    }

    // Display hash map
    public void Display()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Console.Write($"Index {i}: ");
            HashNode head = table[i];
            while (head != null)
            {
                Console.Write($"[{head.Key}:{head.Value}] -> ");
                head = head.Next;
            }
            Console.WriteLine("null");
        }
    }
}

class CustomHashMapDemo
{
    static void Main()
    {
        CustomHashMap map = new CustomHashMap();

        map.Put(1, 10);
        map.Put(2, 20);
        map.Put(12, 120); // Collision with key 2
        map.Put(3, 30);

        Console.WriteLine("Hash Map Contents:");
        map.Display();

        Console.WriteLine("\nGet key 2: " + map.Get(2));
        Console.WriteLine("Get key 12: " + map.Get(12));

        map.Remove(2);
        Console.WriteLine("\nAfter removing key 2:");
        map.Display();
    }
}
