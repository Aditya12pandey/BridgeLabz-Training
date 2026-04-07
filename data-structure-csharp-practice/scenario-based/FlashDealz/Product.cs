using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.Datastructure.FlashDealz
{
    internal class Product
    {
        private string name;
        private double price;
        private double discount;

        public Product(string name, double price, double discount)
        {
            this.name = name;
            this.price = price;
            this.discount = discount;
        }

        public string Name => name;
        public double Price => price;
        public double Discount => discount;

        public override string ToString()
        {
            return $"Product Name: {name}, Price: {price}, Discount: {discount}%";
        }

    }
}
