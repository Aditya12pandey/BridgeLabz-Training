using System;
using System.Collections.Generic;

//  ABSTRACT BASE CLASS 
abstract class WarehouseItem
{
    public int ItemId { get; set; }
    public string Name { get; set; }

    public WarehouseItem(int itemId, string name)
    {
        ItemId = itemId;
        Name = name;
    }

    public abstract void ShowDetails();
}

//  ELECTRONICS CLASS 
class Electronics : WarehouseItem
{
    public string Brand { get; set; }

    public Electronics(int itemId, string name, string brand) : base(itemId, name)
    {
        Brand = brand;
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"[Electronics] ID: {ItemId}, Name: {Name}, Brand: {Brand}");
    }
}

//  GROCERIES CLASS 
class Groceries : WarehouseItem
{
    public string ExpiryDate { get; set; }

    public Groceries(int itemId, string name, string expiryDate) : base(itemId, name)
    {
        ExpiryDate = expiryDate;
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"[Groceries] ID: {ItemId}, Name: {Name}, Expiry: {ExpiryDate}");
    }
}

//  FURNITURE CLASS 
class Furniture : WarehouseItem
{
    public string Material { get; set; }

    public Furniture(int itemId, string name, string material) : base(itemId, name)
    {
        Material = material;
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"[Furniture] ID: {ItemId}, Name: {Name}, Material: {Material}");
    }
}

//  GENERIC STORAGE CLASS (CONSTRAINT) 
class Storage<T> where T : WarehouseItem
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
        Console.WriteLine("Item Added Successfully!");
    }

    public List<T> GetAllItems()
    {
        return items;
    }

    public void DisplayAllItems()
    {
        Console.WriteLine("\n Warehouse Items ");
        foreach (T item in items)
        {
            item.ShowDetails();
        }
    }
}

//  VARIANCE (COVARIANCE USING 'out') 
interface IReadOnlyStorage<out T> where T : WarehouseItem
{
    T GetItem(int index);
}

class ReadOnlyStorage<T> : IReadOnlyStorage<T> where T : WarehouseItem
{
    private List<T> items;

    public ReadOnlyStorage(List<T> itemsList)
    {
        items = itemsList;
    }

    public T GetItem(int index)
    {
        return items[index];
    }
}

//  MAIN PROGRAM 
class WarehouseManagementSystem
{
    static void Main()
    {
        Storage<WarehouseItem> warehouse = new Storage<WarehouseItem>();

        while (true)
        {
            Console.WriteLine("\n==== Smart Warehouse Management System ====");
            Console.WriteLine("1. Add Electronics");
            Console.WriteLine("2. Add Groceries");
            Console.WriteLine("3. Add Furniture");
            Console.WriteLine("4. Display All Items");
            Console.WriteLine("5. Variance Example");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 0)
                break;

            switch (choice)
            {
                case 1:
                    Console.Write("Enter ID: ");
                    int eId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    string eName = Console.ReadLine();

                    Console.Write("Enter Brand: ");
                    string brand = Console.ReadLine();

                    warehouse.AddItem(new Electronics(eId, eName, brand));
                    break;

                case 2:
                    Console.Write("Enter ID: ");
                    int gId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    string gName = Console.ReadLine();

                    Console.Write("Enter Expiry Date: ");
                    string expiry = Console.ReadLine();

                    warehouse.AddItem(new Groceries(gId, gName, expiry));
                    break;

                case 3:
                    Console.Write("Enter ID: ");
                    int fId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    string fName = Console.ReadLine();

                    Console.Write("Enter Material: ");
                    string material = Console.ReadLine();

                    warehouse.AddItem(new Furniture(fId, fName, material));
                    break;

                case 4:
                    warehouse.DisplayAllItems();
                    break;

                case 5:
                    // Variance Example
                    List<Electronics> electronicsList = new List<Electronics>()
                    {
                        new Electronics(101, "Laptop", "Dell"),
                        new Electronics(102, "Phone", "Samsung")
                    };

                    IReadOnlyStorage<WarehouseItem> readOnly = new ReadOnlyStorage<Electronics>(electronicsList);
                    Console.WriteLine("\nVariance Example Output:");
                    readOnly.GetItem(0).ShowDetails();
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }

        Console.WriteLine("Program Ended!");
    }
}
