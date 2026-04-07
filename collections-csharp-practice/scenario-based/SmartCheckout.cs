using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure
{
    internal class SmartCheckout
    {

        static Queue<string> customerQueue = new Queue<string>();

        static Dictionary<string, List<string>> customerItems = new Dictionary<string, List<string>>();

        static Dictionary<string, int> priceMap = new Dictionary<string, int>();

        static Dictionary<string, int> stockMap = new Dictionary<string, int>();

        static void Main()
        {
            //  Add some default items in supermarket
            priceMap["Milk"] = 60;
            priceMap["Bread"] = 40;
            priceMap["Rice"] = 80;
            priceMap["Sugar"] = 45;
            priceMap["Eggs"] = 10;

            stockMap["Milk"] = 5;
            stockMap["Bread"] = 4;
            stockMap["Rice"] = 6;
            stockMap["Sugar"] = 3;
            stockMap["Eggs"] = 10;

            while (true)
            {
                Console.WriteLine("\n SMART CHECKOUT MENU ");
                Console.WriteLine("1. Add Customer to Queue");
                Console.WriteLine("2. Serve Customer (Billing)");
                Console.WriteLine("3. Show Queue");
                Console.WriteLine("4. Show Stock");
                Console.WriteLine("5. Exit");
                Console.Write("Choose option: ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1) AddCustomer();
                else if (choice == 2) ServeCustomer();
                else if (choice == 3) ShowQueue();
                else if (choice == 4) ShowStock();
                else if (choice == 5) break;
                else Console.WriteLine(" Invalid option!");
            }
        }

        static void AddCustomer()
        {
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("How many items customer wants to buy? ");
            int n = int.Parse(Console.ReadLine());

            List<string> items = new List<string>();

            Console.WriteLine("\nAvailable Items: Milk, Bread, Rice, Sugar, Eggs");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter item {i + 1}: ");
                string item = Console.ReadLine();

                items.Add(item);
            }

            customerQueue.Enqueue(name);
            customerItems[name] = items;

            Console.WriteLine($" {name} added to queue.");
        }

        static void ServeCustomer()
        {
            if (customerQueue.Count == 0)
            {
                Console.WriteLine(" No customers in queue!");
                return;
            }

            string customer = customerQueue.Dequeue();
            List<string> items = customerItems[customer];

            Console.WriteLine($"\n Billing for: {customer}");
            int totalBill = 0;

            foreach (string item in items)
            {
                if (!priceMap.ContainsKey(item))
                {
                    Console.WriteLine($" {item} is not available in store!");
                    continue;
                }

                if (stockMap[item] <= 0)
                {
                    Console.WriteLine($" {item} is OUT OF STOCK!");
                    continue;
                }

                //  Add price
                totalBill += priceMap[item];

                stockMap[item]--;

                Console.WriteLine($" {item} = {priceMap[item]} (Stock left: {stockMap[item]})");
            }

            Console.WriteLine($"Total Bill = {totalBill}");

            // remove customer record
            customerItems.Remove(customer);
        }

        static void ShowQueue()
        {
            if (customerQueue.Count == 0)
            {
                Console.WriteLine("Queue is empty!");
                return;
            }

            Console.WriteLine("\n Current Queue:");
            foreach (string c in customerQueue)
            {
                Console.WriteLine(c);
            }
        }

        static void ShowStock()
        {
            Console.WriteLine("\n Current Stock:");
            foreach (var item in stockMap)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
