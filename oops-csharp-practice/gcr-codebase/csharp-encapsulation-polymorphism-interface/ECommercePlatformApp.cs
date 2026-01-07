using System;
using System.Collections.Generic;

namespace ECommercePlatform
{
    // Interface for Tax
    interface ITaxable
    {
        double CalculateTax();
        string GetTaxDetails();
    }

    // Abstract Product class
    abstract class Product
    {
        private int productId;
        private string name;
        protected double price;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
            }
        }

        public Product(int id, string name, double price)
        {
            productId = id;
            this.name = name;
            this.price = price;
        }

        public abstract double CalculateDiscount();

        public virtual void PrintFinalPrice()
        {
            double tax = 0;

            if (this is ITaxable taxableProduct)
                tax = taxableProduct.CalculateTax();

            double discount = CalculateDiscount();
            double finalPrice = price + tax - discount;

            Console.WriteLine("Product ID   : " + ProductId);
            Console.WriteLine("Name         : " + Name);
            Console.WriteLine("Base Price  : " + price);
            Console.WriteLine("Tax         : " + tax);
            Console.WriteLine("Discount    : " + discount);
            Console.WriteLine("Final Price : " + finalPrice);
            Console.WriteLine("--------------------------------");
        }
    }

    class Electronics : Product, ITaxable
    {
        public Electronics(int id, string name, double price)
            : base(id, name, price) { }

        public override double CalculateDiscount()
        {
            return price * 0.10;
        }

        public double CalculateTax()
        {
            return price * 0.18;
        }

        public string GetTaxDetails()
        {
            return "18% GST on Electronics";
        }
    }

    class Clothing : Product, ITaxable
    {
        public Clothing(int id, string name, double price)
            : base(id, name, price) { }

        public override double CalculateDiscount()
        {
            return price * 0.20;
        }

        public double CalculateTax()
        {
            return price * 0.05;
        }

        public string GetTaxDetails()
        {
            return "5% GST on Clothing";
        }
    }

    class Groceries : Product
    {
        public Groceries(int id, string name, double price)
            : base(id, name, price) { }

        public override double CalculateDiscount()
        {
            return price * 0.05;
        }
    }

    
    class ECommercePlatformApp
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Electronics(1, "Laptop", 60000),
                new Clothing(2, "Jacket", 4000),
                new Groceries(3, "Rice Bag", 1200)
            };

            foreach (Product product in products)
            {
                product.PrintFinalPrice();
            }

            Console.ReadLine();
        }
    }
}
