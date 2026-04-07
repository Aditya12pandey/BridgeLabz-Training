using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.FlashDealz
{
    internal class CustomProductList
    {
        private Product[] arr;
        private int size;

        public CustomProductList()
        {
            arr = new Product[5]; // initial capacity
            size = 0;
        }

        public void Add(Product p)
        {
            if (size == arr.Length)
            {
                Grow();
            }

            arr[size] = p;
            size++;
        }

        private void Grow()
        {
            Product[] newArr = new Product[arr.Length * 2];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            arr = newArr;
        }

        public int Size()
        {
            return size;
        }

        public Product Get(int index)
        {
            if (index < 0 || index >= size)
                return null;

            return arr[index];
        }

        public void Set(int index, Product value)
        {
            if (index >= 0 && index < size)
            {
                arr[index] = value;
            }
        }

        public void Display()
        {
            if (size == 0)
            {
                Console.WriteLine("No products available!");
                return;
            }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{i + 1}. {arr[i]}");
            }
        }
    }
}
