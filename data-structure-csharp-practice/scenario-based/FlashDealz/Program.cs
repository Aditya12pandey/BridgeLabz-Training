using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.FlashDealz
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IFlashDealz flashDealz = new FlashDealzUtility();

            while (true)
            {
                Console.WriteLine("\n FLASHDEALZ MENU ");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display All Products");
                Console.WriteLine("3. Sort Products by Discount (Quick Sort)");
                Console.WriteLine("4. Display Top N Discounted Products");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                bool isValid = int.TryParse(Console.ReadLine(), out choice);

                if (!isValid)
                {
                    Console.WriteLine(" Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Product Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Product Price: ");
                        double price = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Discount (%): ");
                        double discount = Convert.ToDouble(Console.ReadLine());

                        flashDealz.AddProduct(name, price, discount);
                        break;

                    case 2:
                        flashDealz.DisplayAllProducts();
                        break;

                    case 3:
                        flashDealz.SortByDiscountDesc();
                        break;

                    case 4:
                        Console.Write("Enter value of N: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        flashDealz.DisplayTopN(n);
                        break;

                    case 0:
                        Console.WriteLine(" Exiting... Thank You!");
                        return;

                    default:
                        Console.WriteLine(" Invalid choice! Try again.");
                        break;
                }
            }
        }
    }
}
