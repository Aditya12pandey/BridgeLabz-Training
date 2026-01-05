using System;

class Book
{
    // static variable (shared across all books)
    public static string LibraryName = "Central Library";

    // readonly variable (cannot be modified after constructor)
    public readonly string ISBN;

    // instance variables
    public string Title;
    public string Author;

    // Constructor using 'this' keyword
    public Book(string isbn, string title, string author)
    {
        this.ISBN = isbn;       // readonly assigned once
        this.Title = title;
        this.Author = author;
    }

    // Instance method to display book details
    public void DisplayBookDetails()
    {
        Console.WriteLine("Library Name : " + LibraryName);
        Console.WriteLine("ISBN         : " + ISBN);
        Console.WriteLine("Title        : " + Title);
        Console.WriteLine("Author       : " + Author);
        Console.WriteLine();
    }

    // static method
    public static void DisplayLibraryName()
    {
        Console.WriteLine("Library Name: " + LibraryName);
        Console.WriteLine();
    }
}

class Program
{
    public static void Main()
    {
        Book b1 = new Book("978-0132350884", "Clean Code", "Robert C. Martin");
        Book b2 = new Book("978-0201616224", "The Pragmatic Programmer", "Andrew Hunt");

        // Call static method
        Book.DisplayLibraryName();

        // Using 'is' operator before displaying details
        if (b1 is Book)
        {
            b1.DisplayBookDetails();
        }

        if (b2 is Book)
        {
            b2.DisplayBookDetails();
        }
    }
}
