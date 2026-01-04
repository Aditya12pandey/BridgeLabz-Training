using System;

class Book1
{
    // Attributes
    public string title;
    public string author;
    public double price;
    public bool availability;

    // Constructor
    public Book(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
        this.availability = true; // Book is available initially
    }

    // Method to borrow a book
    public void BorrowBook()
    {
        if (availability)
        {
            availability = false;
            Console.WriteLine("Book borrowed successfully.");
        }
        else
        {
            Console.WriteLine("Sorry, the book is already borrowed.");
        }
    }

    // Method to display book details
    public void DisplayDetails()
    {
        Console.WriteLine("Title        : " + title);
        Console.WriteLine("Author       : " + author);
        Console.WriteLine("Price        : " + price);
        Console.WriteLine("Availability : " + (availability ? "Available" : "Not Available"));
        Console.WriteLine();
    }
}

class Program
{
    public static void Main()
    {
        Book book = new Book("Clean Code", "Robert C. Martin", 550);

        // Display details before borrowing
        book.DisplayDetails();

        // Borrow the book
        book.BorrowBook();

        // Display details after borrowing
        book.DisplayDetails();

        // Try borrowing again
        book.BorrowBook();
    }
}
