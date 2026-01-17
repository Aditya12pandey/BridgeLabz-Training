using System;

public class LibraryService : ILibraryService
{
    private CustomHashMap catalog;

    public LibraryService()
    {
        catalog = new CustomHashMap(10);
    }

    private int ReadInt(string msg)
    {
        int value;
        while (true)
        {
            Console.Write(msg);
            string input = Console.ReadLine();

            if (int.TryParse(input, out value))
                return value;

            Console.WriteLine(" Invalid number, try again!");
        }
    }

    private string ReadString(string msg)
    {
        while (true)
        {
            Console.Write(msg);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            Console.WriteLine(" Input cannot be empty!");
        }
    }

    private void AddBook()
    {
        int id = ReadInt("Enter Book ID: ");
        string title = ReadString("Enter Title: ");
        string author = ReadString("Enter Author: ");
        string genre = ReadString("Enter Genre: ");

        Book book = new Book(id, title, author, genre);

        BookLinkedList list = catalog.GetOrCreateGenreList(genre);

        if (list.AddBook(book))
            Console.WriteLine(" Book Added Successfully!");
        else
            Console.WriteLine(" Duplicate Book ID in this Genre!");
    }

    private void BorrowBook()
    {
        string genre = ReadString("Enter Genre: ");
        int id = ReadInt("Enter Book ID to Borrow: ");

        BookLinkedList list = catalog.GetGenreList(genre);

        if (list == null)
        {
            Console.WriteLine(" Genre not found!");
            return;
        }

        Book book = list.SearchById(id);

        if (book == null)
            Console.WriteLine(" Book not found!");
        else if (book.IsBorrowed)
            Console.WriteLine(" Book already borrowed!");
        else
        {
            book.IsBorrowed = true;
            Console.WriteLine(" Book Borrowed Successfully!");
        }
    }

    private void ReturnBook()
    {
        string genre = ReadString("Enter Genre: ");
        int id = ReadInt("Enter Book ID to Return: ");

        BookLinkedList list = catalog.GetGenreList(genre);

        if (list == null)
        {
            Console.WriteLine(" Genre not found!");
            return;
        }

        Book book = list.SearchById(id);

        if (book == null)
            Console.WriteLine(" Book not found!");
        else if (!book.IsBorrowed)
            Console.WriteLine(" Book is already Available!");
        else
        {
            book.IsBorrowed = false;
            Console.WriteLine(" Book Returned Successfully!");
        }
    }

    private void RemoveBook()
    {
        string genre = ReadString("Enter Genre: ");
        int id = ReadInt("Enter Book ID to Remove: ");

        BookLinkedList list = catalog.GetGenreList(genre);

        if (list == null)
        {
            Console.WriteLine(" Genre not found!");
            return;
        }

        if (list.DeleteBook(id))
            Console.WriteLine(" Book Removed Successfully!");
        else
            Console.WriteLine(" Book not found!");
    }

    private void DisplayGenreWise()
    {
        string genre = ReadString("Enter Genre: ");

        BookLinkedList list = catalog.GetGenreList(genre);

        if (list == null)
        {
            Console.WriteLine(" Genre not found!");
            return;
        }

        Console.WriteLine("\n Books in Genre: " + genre);
        list.DisplayAll();
    }

    private void DisplayAll()
    {
        Console.WriteLine("\nComplete Library Catalog:");
        catalog.DisplayAllGenres();
    }

    public void StartMenu()
    {
        while (true)
        {
            Console.WriteLine("\n BookShelf – Library Organizer ");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Borrow Book");
            Console.WriteLine("3. Return Book");
            Console.WriteLine("4. Remove Book");
            Console.WriteLine("5. Display Books by Genre");
            Console.WriteLine("6. Display All Books");
            Console.WriteLine("0. Exit");

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    BorrowBook();
                    break;
                case "3":
                    ReturnBook();
                    break;
                case "4":
                    RemoveBook();
                    break;
                case "5":
                    DisplayGenreWise();
                    break;
                case "6":
                    DisplayAll();
                    break;
                case "0":
                    Console.WriteLine(" Exiting... Thank You!");
                    return;
                default:
                    Console.WriteLine(" Invalid choice, try again!");
                    break;
            }
        }
    }
}
