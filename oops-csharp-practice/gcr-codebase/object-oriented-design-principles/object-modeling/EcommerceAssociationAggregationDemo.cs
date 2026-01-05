using System;
using System.Collections.Generic;

// Product class (independent entity)
class Product
{
    public string ProductName;
    public double Price;

    public Product(string productName, double price)
    {
        ProductName = productName;
        Price = price;
    }

    public void ShowProduct()
    {
        Console.WriteLine("Product: " + ProductName + " | Price: " + Price);
    }
}

// Order class (aggregates Products)
class Order
{
    public int OrderId;
    private List<Product> products;

    public Order(int orderId)
    {
        OrderId = orderId;
        products = new List<Product>();
    }

    // Aggregation
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void ShowOrderDetails()
    {
        Console.WriteLine("\nOrder ID: " + OrderId);
        double total = 0;

        foreach (Product product in products)
        {
            product.ShowProduct();
            total += product.Price;
        }

        Console.WriteLine("Total Amount: " + total);
    }
}

// Customer class (associated with Order)
class Customer
{
    public string CustomerName;
    private List<Order> orders;

    public Customer(string customerName)
    {
        CustomerName = customerName;
        orders = new List<Order>();
    }

    // Communication method
    public void PlaceOrder(Order order)
    {
        orders.Add(order);
        Console.WriteLine(
            "\nCustomer " + CustomerName +
            " placed Order ID: " + order.OrderId
        );
    }

    public void ShowOrders()
    {
        Console.WriteLine("\nOrders placed by " + CustomerName + ":");
        foreach (Order order in orders)
        {
            order.ShowOrderDetails();
        }
    }
}

// Concept-focused main class
class EcommerceAssociationAggregationDemo
{
    static void Main()
    {
        // Products (independent objects)
        Product p1 = new Product("Laptop", 50000);
        Product p2 = new Product("Mouse", 500);
        Product p3 = new Product("Keyboard", 1500);

        // Order (aggregates products)
        Order order1 = new Order(101);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        Order order2 = new Order(102);
        order2.AddProduct(p3);

        // Customer (associated with orders)
        Customer customer = new Customer("Rahul");

        // Association + Communication
        customer.PlaceOrder(order1);
        customer.PlaceOrder(order2);

        // Display details
        customer.ShowOrders();
    }
}
