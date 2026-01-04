using System;

class Book
{
    // Access modifiers
    public string ISBN;        // Public
    protected string title;    // Protected
    private string author;     // Private

    // Constructor
    public Book(string isbn, string title, string author)
    {
        this.ISBN = isbn;
        this.title = title;
        this.author = author;
    }

    // Setter for author (private member)
    public void SetAuthor(string author)
    {
        this.author = author;
    }

    // Getter for author (private member)
    public string GetAuthor()
    {
        return author;
    }

    // Method to display book details
    public void DisplayBook()
    {
        Console.WriteLine("ISBN   : " + ISBN);
        Console.WriteLine("Title  : " + title);
        Console.WriteLine("Author : " + author);
    }
}

// Subclass
class EBook : Book
{
    public double fileSize; // in MB

    public EBook(string isbn, string title, string author, double fileSize)
        : base(isbn, title, author)
    {
        this.fileSize = fileSize;
    }

    // Demonstrating access to public and protected members
    public void DisplayEBookDetails()
    {
        Console.WriteLine("E-Book Details:");
        Console.WriteLine("ISBN      : " + ISBN);   // public
        Console.WriteLine("Title     : " + title);  // protected
        Console.WriteLine("Author    : " + GetAuthor()); // private via getter
        Console.WriteLine("File Size : " + fileSize + " MB");
    }
}

class Program
{
    public static void Main()
    {
        Book b1 = new Book("978-0132350884", "Clean Code", "Robert C. Martin");
        b1.DisplayBook();

        Console.WriteLine();

        // Modify author using setter
        b1.SetAuthor("Uncle Bob");
        Console.WriteLine("Updated Author: " + b1.GetAuthor());

        Console.WriteLine();

        EBook eb = new EBook("978-0201616224", "The Pragmatic Programmer", "Andrew Hunt", 5.2);
        eb.DisplayEBookDetails();
    }
}
