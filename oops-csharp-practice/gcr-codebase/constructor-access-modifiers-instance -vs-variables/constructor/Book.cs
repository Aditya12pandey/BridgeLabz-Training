using System;

class Book
{
    public string title;
    public string author;
    public double price;

    // Default constructor
    public Book()
    {
        title = "Not Available";
        author = "Not Available";
        price = 0.0;
    }

    public Book(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }
}

class Program
{
    public static void Main()
    {
        // Object using default constructor
        Book book1 = new Book();
        Console.WriteLine(book1.title + ", " + book1.author + ", " + book1.price);

        // Object using parameterized constructor
        Book book2 = new Book("Clean Code", "Robert C. Martin", 550);
        Console.WriteLine(book2.title + ", " + book2.author + ", " + book2.price);
    }
}
