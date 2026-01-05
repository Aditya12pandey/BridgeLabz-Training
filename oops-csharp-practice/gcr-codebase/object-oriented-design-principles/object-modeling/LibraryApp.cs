using System;
using System.Collections.Generic;

// Book class (Independent class)
class Book
{
    public string Title;
    public string Author;

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public void DisplayBook()
    {
        Console.WriteLine("Title  : " + Title);
        Console.WriteLine("Author : " + Author);
    }
}

// Library class (Aggregates Book objects)
class Library
{
    public string LibraryName;
    public List<Book> Books;

    public Library(string libraryName)
    {
        LibraryName = libraryName;
        Books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void DisplayLibraryBooks()
    {
        Console.WriteLine("\nLibrary: " + LibraryName);

        foreach (Book book in Books)
        {
            book.DisplayBook();
            Console.WriteLine("--------------------");
        }
    }
}

// Main class
class LibraryApp
{
    static void Main()
    {
        // Create books independently
        Book b1 = new Book("C# Basics", "John");
        Book b2 = new Book("OOP Concepts", "Smith");
        Book b3 = new Book("Data Structures", "Alice");

        // Create libraries
        Library lib1 = new Library("Central Library");
        Library lib2 = new Library("College Library");

        // Add books to libraries (Aggregation)
        lib1.AddBook(b1);
        lib1.AddBook(b2);

        lib2.AddBook(b2); // Same book in another library
        lib2.AddBook(b3);

        // Display library contents
        lib1.DisplayLibraryBooks();
        lib2.DisplayLibraryBooks();

        // Book exists independently
        Console.WriteLine("\nIndependent Book Details:");
        b1.DisplayBook();
    }
}
