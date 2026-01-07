using System;
using System.Collections.Generic;

namespace OnlineFoodDeliverySystem
{
    // Interface for Discount
    interface IDiscountable
    {
        double ApplyDiscount();
        string GetDiscountDetails();
    }

    // Abstract Food Item class
    abstract class FoodItem
    {
        // Encapsulated fields
        private string itemName;
        protected double price;
        protected int quantity;

        // Properties
        public string ItemName
        {
            get { return itemName; }
            private set { itemName = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            protected set { quantity = value; }
        }

        // Constructor
        public FoodItem(string name, double price, int quantity)
        {
            itemName = name;
            this.price = price;
            this.quantity = quantity;
        }

        // Abstract method
        public abstract double CalculateTotalPrice();

        // Concrete method
        public void GetItemDetails()
        {
            Console.WriteLine("Item Name     : " + ItemName);
            Console.WriteLine("Price         : " + price);
            Console.WriteLine("Quantity      : " + quantity);
            Console.WriteLine("Total Price   : " + CalculateTotalPrice());
            Console.WriteLine("----------------------------------");
        }
    }

    // Veg Item
    class VegItem : FoodItem, IDiscountable
    {
        public VegItem(string name, double price, int quantity)
            : base(name, price, quantity) { }

        public override double CalculateTotalPrice()
        {
            return price * quantity; // no extra charges
        }

        public double ApplyDiscount()
        {
            return CalculateTotalPrice() * 0.10; // 10% discount
        }

        public string GetDiscountDetails()
        {
            return "10% discount on Veg Items";
        }
    }

    // Non-Veg Item
    class NonVegItem : FoodItem, IDiscountable
    {
        public NonVegItem(string name, double price, int quantity)
            : base(name, price, quantity) { }

        public override double CalculateTotalPrice()
        {
            return (price * quantity) + 50; // extra non-veg charge
        }

        public double ApplyDiscount()
        {
            return CalculateTotalPrice() * 0.05; // 5% discount
        }

        public string GetDiscountDetails()
        {
            return "5% discount on Non-Veg Items";
        }
    }

    // Main Application Class
    class OnlineFoodDeliverySystemApp
    {
        static void Main(string[] args)
        {
            List<FoodItem> order = new List<FoodItem>
            {
                new VegItem("Paneer Butter Masala", 250, 2),
                new NonVegItem("Chicken Biryani", 300, 1)
            };

            // Polymorphism demonstration
            foreach (FoodItem item in order)
            {
                item.GetItemDetails();

                if (item is IDiscountable discountable)
                {
                    Console.WriteLine("Discount      : " + discountable.ApplyDiscount());
                    Console.WriteLine(discountable.GetDiscountDetails());
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
