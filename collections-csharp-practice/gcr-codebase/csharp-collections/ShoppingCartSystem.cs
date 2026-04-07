using System;
using System.Collections.Generic;

class ShoppingCartSystem
{
    static void Main()
    {
        //  Dictionary -> store product prices
        Dictionary<string, double> cart = new Dictionary<string, double>();

        //  LinkedDictionary equivalent -> maintain insertion order
        List<string> orderList = new List<string>();

        Console.Write("Enter number of products: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("\nEnter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter product price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            // If product already exists, update price only
            if (!cart.ContainsKey(name))
                orderList.Add(name);

            cart[name] = price;
        }

        //  Display cart in insertion order (LinkedDictionary style)
        Console.WriteLine("\n Shopping Cart (Insertion Order):");
        foreach (string name in orderList)
        {
            Console.WriteLine(name + " => " + cart[name]);
        }

        //  Display items sorted by price (SortedDictionary)
        SortedDictionary<double, List<string>> sortedByPrice = new SortedDictionary<double, List<string>>();

        foreach (var item in cart)
        {
            string productName = item.Key;
            double price = item.Value;

            if (!sortedByPrice.ContainsKey(price))
                sortedByPrice[price] = new List<string>();

            sortedByPrice[price].Add(productName);
        }

        Console.WriteLine("\n Shopping Cart (Sorted by Price):");
        foreach (var item in sortedByPrice)
        {
            double price = item.Key;
            List<string> products = item.Value;

            foreach (string product in products)
            {
                Console.WriteLine(product + " => " + price);
            }
        }
    }
}
