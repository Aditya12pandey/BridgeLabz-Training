using System;

class Book
{
    public string title;
    public string author;
    public double price;

    public void DisplayDetails()
    {
        Console.WriteLine("Book Details:");
        Console.WriteLine("Title  : " + title);
        Console.WriteLine("Author : " + author);
        Console.WriteLine("Price  : " + price);
    }
}

class Program
{
    public static void Main()
    {
        Book b = new Book();

        Console.Write("Enter book title: ");
        b.title = Console.ReadLine();

        Console.Write("Enter author name: ");
        b.author = Console.ReadLine();

        Console.Write("Enter book price: ");
        b.price = double.Parse(Console.ReadLine());

        b.DisplayDetails();
    }
}
