using System;

class Product
{
    // Instance variables
    public string productName;
    public double price;

    // Class (static) variable
    public static int totalProducts = 0;

    // Constructor
    public Product(string productName, double price)
    {
        this.productName = productName;
        this.price = price;
        totalProducts++; // Increase count whenever a product is created
    }

    // Instance method
    public void DisplayProductDetails()
    {
        Console.WriteLine("Product Name : " + productName);
        Console.WriteLine("Price        : " + price);
        Console.WriteLine();
    }

    // Class (static) method
    public static void DisplayTotalProducts()
    {
        Console.WriteLine("Total Products Created: " + totalProducts);
    }
}

class Program
{
    public static void Main()
    {
        Product p1 = new Product("Laptop", 55000);
        Product p2 = new Product("Mouse", 800);
        Product p3 = new Product("Keyboard", 1500);

        p1.DisplayProductDetails();
        p2.DisplayProductDetails();
        p3.DisplayProductDetails();

        // Calling static method
        Product.DisplayTotalProducts();
    }
}
