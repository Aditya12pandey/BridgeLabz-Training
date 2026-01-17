using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.FlashDealz
{
    internal class FlashDealzUtility : IFlashDealz
    {
        private CustomProductList products;

        public FlashDealzUtility()
        {
            products = new CustomProductList();
        }

        public void AddProduct(string name, double price, double discount)
        {
            if (discount < 0 || discount > 100)
            {
                Console.WriteLine("Invalid Discount! Must be between 0 to 100.");
                return;
            }

            Product p = new Product(name, price, discount);
            products.Add(p);
            Console.WriteLine(" Product Added Successfully!");
        }

        public void DisplayAllProducts()
        {
            Console.WriteLine("\n All Products:");
            products.Display();
        }

        public void SortByDiscountDesc()
        {
            if (products.Size() <= 1)
            {
                Console.WriteLine("Not enough products to sort!");
                return;
            }

            QuickSort(0, products.Size() - 1);
            Console.WriteLine(" Products sorted by Discount (High → Low) Successfully!");
        }

        // Quick Sort Logic
        private void QuickSort(int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(low, high);
                QuickSort(low, pivotIndex - 1);
                QuickSort(pivotIndex + 1, high);
            }
        }

        private int Partition(int low, int high)
        {
            double pivot = products.Get(high).Discount;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                // Descending order
                if (products.Get(j).Discount > pivot)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, high);
            return i + 1;
        }

        private void Swap(int i, int j)
        {
            Product temp = products.Get(i);
            products.Set(i, products.Get(j));
            products.Set(j, temp);
        }

        public void DisplayTopN(int n)
        {
            if (products.Size() == 0)
            {
                Console.WriteLine("No products available!");
                return;
            }

            if (n > products.Size())
                n = products.Size();

            Console.WriteLine($"\n Top {n} Discounted Products:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1}. {products.Get(i)}");
            }
        }
    }

}
