//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraning.ScenarioBased
//{
//    internal class CafeteriaMenuApp
//    {
//        static string[] menuItems = new string[]
//    {
//        "Idli",
//        "Dosa",
//        "Vada",
//        "Pav Bhaji",
//        "Veg Sandwich",
//        "Poha",
//        "Upma",
//        "Fried Rice",
//        "Noodles",
//        "Tea"
//    };

//        // Method to display menu
//        public static void DisplayMenu()
//        {
//            Console.WriteLine("\n--- Cafeteria Menu ---");
//            for (int i = 0; i < menuItems.Length; i++)
//            {
//                Console.WriteLine(i + " : " + menuItems[i]);
//            }
//        }

//        // Method to get item by index
//        public static string GetItemByIndex(int index)
//        {
//            if (index >= 0 && index < menuItems.Length)
//                return menuItems[index];
//            else
//                return null;
//        }

//        // Main Method
//        public static void Main()
//        {
//            int choice;

//            do
//            {
//                Console.WriteLine("\n=== Cafeteria Menu App ===");
//                Console.WriteLine("1. Display Menu");
//                Console.WriteLine("2. Select Item by Index");
//                Console.WriteLine("3. Exit");
//                Console.Write("Enter your choice: ");

//                choice = int.Parse(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        DisplayMenu();
//                        break;

//                    case 2:
//                        Console.Write("Enter item index: ");
//                        int index = int.Parse(Console.ReadLine());

//                        string selectedItem = GetItemByIndex(index);
//                        if (selectedItem != null)
//                            Console.WriteLine("You selected: " + selectedItem);
//                        else
//                            Console.WriteLine("Invalid index! Please try again.");
//                        break;

//                    case 3:
//                        Console.WriteLine("Thank you for using Cafeteria Menu App!");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid choice! Please select 1–3.");
//                        break;
//                }

//            } while (choice != 3);
//        }
//    }
//}
