using System;
using System.Collections.Generic;

//  CATEGORY BASE 
abstract class Category
{
    public string CategoryName { get; set; }

    public Category(string categoryName)
    {
        CategoryName = categoryName;
    }
}

//  BOOK CATEGORY 
class BookCategory : Category
{
    public BookCategory() : base("Books") { }
}

//  CLOTHING CATEGORY 
class ClothingCategory : Category
{
    public ClothingCategory() : base("Clothing") { }
}

//  GENERIC PRODUCT CLASS 
// T is restricted to only Category types
class Product<T> where T : Category
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public T ProductCategory { get; set; }

    public Product(int id, string name, double price, T category)
    {
        ProductId = id;
        ProductName = name;
        Price = price;
        ProductCategory = category;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Price: {Price}, Category: {ProductCategory.CategoryName}");
    }
}

//  GENERIC METHODS CLASS 
class DiscountUtility
{
    // Generic Method with constraint
    // Here T must be any Product of any category
    public static void ApplyDiscount<T>(T product, double percentage) where T : Product<Category>
    {
        double discountAmount = product.Price * (percentage / 100);
        product.Price -= discountAmount;

        Console.WriteLine($" Discount Applied: {percentage}%  New Price: {product.Price}");
    }
}

//  MAIN PROGRAM 
class DynamicOnlineMarketplace
{
    static void Main()
    {
        // Multiple categories but type safe
        Product<BookCategory> book1 = new Product<BookCategory>(1, "C# Basics", 500, new BookCategory());
        Product<ClothingCategory> cloth1 = new Product<ClothingCategory>(2, "T-Shirt", 800, new ClothingCategory());

        // Catalog holding different product categories safely (using base object type)
        List<object> catalog = new List<object>();

        catalog.Add(book1);
        catalog.Add(cloth1);

        Console.WriteLine(" Product Catalog:");
        book1.ShowDetails();
        cloth1.ShowDetails();

        Console.WriteLine("\n Applying Discount:");

        // Works for both types safely
        DiscountUtility.ApplyDiscount<Product<Category>>(
            new Product<Category>(10, "Generic Item", 1000, new BookCategory()), 10);

        // Apply discount directly to book and clothing by converting to Product<Category> safely
        ApplyDiscountToAnyProduct(book1, 20);
        ApplyDiscountToAnyProduct(cloth1, 15);

        Console.WriteLine("\n Updated Products:");
        book1.ShowDetails();
        cloth1.ShowDetails();
    }

    //  Better generic method for any Product<TCategory>
    static void ApplyDiscountToAnyProduct<TCategory>(Product<TCategory> product, double percentage)
        where TCategory : Category
    {
        double discountAmount = product.Price * (percentage / 100);
        product.Price -= discountAmount;

        Console.WriteLine($" Discount Applied on {product.ProductName}: {percentage}% -> New Price = {product.Price}");
    }
}
