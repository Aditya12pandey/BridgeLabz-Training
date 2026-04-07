using System;

class Product
{
    public static double Discount = 0;   // percentage

    public readonly int ProductID;

    public string ProductName;
    public double Price;
    public int Quantity;

    private static int idCounter = 1000;

    public Product(string productName, double price, int quantity)
    {
        this.ProductName = productName;
        this.Price = price;
        this.Quantity = quantity;
        this.ProductID = ++idCounter;
    }

    public static void UpdateDiscount(double newDiscount)
    {
        Discount = newDiscount;
        Console.WriteLine("Discount updated to " + Discount + "%");
    }

    public void DisplayProduct()
    {
        double discountedPrice = Price - (Price * Discount / 100);
        Console.WriteLine("\nProduct ID   : " + ProductID);
        Console.WriteLine("Name         : " + ProductName);
        Console.WriteLine("Price        : " + Price);
        Console.WriteLine("Quantity     : " + Quantity);
        Console.WriteLine("Final Price  : " + discountedPrice);
    }
}

class ShoppingCart
{
    public static void Main()
    {
        // update discount using static method
        Product.UpdateDiscount(10);

        // create product objects
        Product p1 = new Product("Laptop", 50000, 1);
        Product p2 = new Product("Mouse", 500, 2);

        // object validation using is operator
        if (p1 is Product)
        {
            p1.DisplayProduct();
        }

        if (p2 is Product)
        {
            p2.DisplayProduct();
        }

        // invalid object example
        object obj = "Not a product";

        if (obj is Product)
        {
            Console.WriteLine("Valid Product");
        }
        else
        {
            Console.WriteLine("\nInvalid object: Not a Product");
        }
    }
}
