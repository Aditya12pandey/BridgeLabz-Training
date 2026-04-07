using System;

class InventoryItem
{
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public void Display()
    {
        Console.WriteLine($"ID: {ItemId}, Name: {ItemName}, Qty: {Quantity}, Price: {Price}");
    }
}

class InventoryNode
{
    public InventoryItem Data;
    public InventoryNode Next;

    public InventoryNode(InventoryItem item)
    {
        Data = item;
        Next = null;
    }
}

class InventoryLinkedList
{
    private InventoryNode head;

    // Add at Beginning
    public void AddAtBeginning(InventoryItem item)
    {
        InventoryNode newNode = new InventoryNode(item);
        newNode.Next = head;
        head = newNode;
        Console.WriteLine("Item added at beginning.");
    }

    // Add at End
    public void AddAtEnd(InventoryItem item)
    {
        InventoryNode newNode = new InventoryNode(item);

        if (head == null)
        {
            head = newNode;
            Console.WriteLine("Item added as first record.");
            return;
        }

        InventoryNode temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
        Console.WriteLine("Item added at end.");
    }

    // Add at Position
    public void AddAtPosition(InventoryItem item, int position)
    {
        if (position <= 1)
        {
            AddAtBeginning(item);
            return;
        }

        InventoryNode temp = head;
        for (int i = 1; i < position - 1 && temp != null; i++)
            temp = temp.Next;

        if (temp == null)
        {
            Console.WriteLine("Invalid position.");
            return;
        }

        InventoryNode newNode = new InventoryNode(item);
        newNode.Next = temp.Next;
        temp.Next = newNode;

        Console.WriteLine("Item added at position.");
    }

    // Remove by Item ID
    public void RemoveByItemId(int itemId)
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        if (head.Data.ItemId == itemId)
        {
            head = head.Next;
            Console.WriteLine("Item removed.");
            return;
        }

        InventoryNode temp = head;
        while (temp.Next != null && temp.Next.Data.ItemId != itemId)
            temp = temp.Next;

        if (temp.Next == null)
            Console.WriteLine("Item not found.");
        else
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine("Item removed.");
        }
    }

    // Update Quantity
    public void UpdateQuantity(int itemId, int newQty)
    {
        InventoryNode temp = head;

        while (temp != null)
        {
            if (temp.Data.ItemId == itemId)
            {
                temp.Data.Quantity = newQty;
                Console.WriteLine("Quantity updated.");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item not found.");
    }

    // Search by Item ID
    public void SearchByItemId(int itemId)
    {
        InventoryNode temp = head;

        while (temp != null)
        {
            if (temp.Data.ItemId == itemId)
            {
                temp.Data.Display();
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item not found.");
    }

    // Search by Item Name
    public void SearchByItemName(string name)
    {
        InventoryNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Data.ItemName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                temp.Data.Display();
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("Item not found.");
    }

    // Calculate Total Inventory Value
    public void CalculateTotalValue()
    {
        double total = 0;
        InventoryNode temp = head;

        while (temp != null)
        {
            total += temp.Data.Price * temp.Data.Quantity;
            temp = temp.Next;
        }

        Console.WriteLine($"Total Inventory Value: {total}");
    }

    // Sort Inventory
    public void Sort(string criteria, bool ascending)
    {
        if (head == null || head.Next == null)
            return;

        for (InventoryNode i = head; i.Next != null; i = i.Next)
        {
            for (InventoryNode j = i.Next; j != null; j = j.Next)
            {
                bool condition =
                    criteria == "name"
                        ? (ascending
                            ? string.Compare(i.Data.ItemName, j.Data.ItemName) > 0
                            : string.Compare(i.Data.ItemName, j.Data.ItemName) < 0)
                        : (ascending
                            ? i.Data.Price > j.Data.Price
                            : i.Data.Price < j.Data.Price);

                if (condition)
                {
                    InventoryItem temp = i.Data;
                    i.Data = j.Data;
                    j.Data = temp;
                }
            }
        }

        Console.WriteLine("Inventory sorted successfully.");
    }

    // Display All Items
    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        InventoryNode temp = head;
        while (temp != null)
        {
            temp.Data.Display();
            temp = temp.Next;
        }
    }
}

class InventoryManagementApp
{
    static void Main()
    {
        InventoryLinkedList inventory = new InventoryLinkedList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Inventory Management System ---");
            Console.WriteLine("1. Add Item at Beginning");
            Console.WriteLine("2. Add Item at End");
            Console.WriteLine("3. Add Item at Position");
            Console.WriteLine("4. Remove Item by ID");
            Console.WriteLine("5. Update Item Quantity");
            Console.WriteLine("6. Search Item by ID");
            Console.WriteLine("7. Search Item by Name");
            Console.WriteLine("8. Display All Items");
            Console.WriteLine("9. Calculate Total Inventory Value");
            Console.WriteLine("10. Sort Inventory");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                case 2:
                case 3:
                    InventoryItem item = new InventoryItem();

                    Console.Write("Item ID: ");
                    item.ItemId = int.Parse(Console.ReadLine());
                    Console.Write("Item Name: ");
                    item.ItemName = Console.ReadLine();
                    Console.Write("Quantity: ");
                    item.Quantity = int.Parse(Console.ReadLine());
                    Console.Write("Price: ");
                    item.Price = double.Parse(Console.ReadLine());

                    if (choice == 1)
                        inventory.AddAtBeginning(item);
                    else if (choice == 2)
                        inventory.AddAtEnd(item);
                    else
                    {
                        Console.Write("Position: ");
                        inventory.AddAtPosition(item, int.Parse(Console.ReadLine()));
                    }
                    break;

                case 4:
                    Console.Write("Enter Item ID: ");
                    inventory.RemoveByItemId(int.Parse(Console.ReadLine()));
                    break;

                case 5:
                    Console.Write("Item ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("New Quantity: ");
                    inventory.UpdateQuantity(id, int.Parse(Console.ReadLine()));
                    break;

                case 6:
                    Console.Write("Item ID: ");
                    inventory.SearchByItemId(int.Parse(Console.ReadLine()));
                    break;

                case 7:
                    Console.Write("Item Name: ");
                    inventory.SearchByItemName(Console.ReadLine());
                    break;

                case 8:
                    inventory.DisplayAll();
                    break;

                case 9:
                    inventory.CalculateTotalValue();
                    break;

                case 10:
                    Console.Write("Sort by (name/price): ");
                    string criteria = Console.ReadLine().ToLower();
                    Console.Write("Ascending? (true/false): ");
                    bool asc = bool.Parse(Console.ReadLine());
                    inventory.Sort(criteria, asc);
                    break;

                case 0:
                    Console.WriteLine("Exiting Inventory System...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 0);
    }
}
