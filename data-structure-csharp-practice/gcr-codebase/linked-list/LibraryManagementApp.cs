using System;

class BookRecord
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }

    public void Display()
    {
        string status = IsAvailable ? "Available" : "Not Available";
        Console.WriteLine($"ID: {BookId}, Title: {Title}, Author: {Author}, Genre: {Genre}, Status: {status}");
    }
}

class BookNode
{
    public BookRecord Data;
    public BookNode Prev;
    public BookNode Next;

    public BookNode(BookRecord book)
    {
        Data = book;
        Prev = null;
        Next = null;
    }
}

class LibraryDoublyLinkedList
{
    private BookNode head;
    private BookNode tail;

    // Add at Beginning
    public void AddAtBeginning(BookRecord book)
    {
        BookNode newNode = new BookNode(book);

        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }

        Console.WriteLine("Book added at beginning.");
    }

    // Add at End
    public void AddAtEnd(BookRecord book)
    {
        BookNode newNode = new BookNode(book);

        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }

        Console.WriteLine("Book added at end.");
    }

    // Add at Specific Position
    public void AddAtPosition(BookRecord book, int position)
    {
        if (position <= 1)
        {
            AddAtBeginning(book);
            return;
        }

        BookNode temp = head;
        for (int i = 1; i < position - 1 && temp != null; i++)
            temp = temp.Next;

        if (temp == null || temp.Next == null)
        {
            AddAtEnd(book);
            return;
        }

        BookNode newNode = new BookNode(book);
        newNode.Next = temp.Next;
        newNode.Prev = temp;
        temp.Next.Prev = newNode;
        temp.Next = newNode;

        Console.WriteLine("Book added at position.");
    }

    // Remove by Book ID
    public void RemoveByBookId(int bookId)
    {
        BookNode temp = head;

        while (temp != null && temp.Data.BookId != bookId)
            temp = temp.Next;

        if (temp == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        if (temp == head)
            head = temp.Next;

        if (temp == tail)
            tail = temp.Prev;

        if (temp.Prev != null)
            temp.Prev.Next = temp.Next;

        if (temp.Next != null)
            temp.Next.Prev = temp.Prev;

        Console.WriteLine("Book removed successfully.");
    }

    // Search by Title
    public void SearchByTitle(string title)
    {
        BookNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                temp.Data.Display();
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("Book not found.");
    }

    // Search by Author
    public void SearchByAuthor(string author)
    {
        BookNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Data.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                temp.Data.Display();
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("No books found for this author.");
    }

    // Update Availability Status
    public void UpdateAvailability(int bookId, bool status)
    {
        BookNode temp = head;

        while (temp != null)
        {
            if (temp.Data.BookId == bookId)
            {
                temp.Data.IsAvailable = status;
                Console.WriteLine("Book availability updated.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Book not found.");
    }

    // Display Forward
    public void DisplayForward()
    {
        if (head == null)
        {
            Console.WriteLine("Library is empty.");
            return;
        }

        BookNode temp = head;
        while (temp != null)
        {
            temp.Data.Display();
            temp = temp.Next;
        }
    }

    // Display Reverse
    public void DisplayReverse()
    {
        if (tail == null)
        {
            Console.WriteLine("Library is empty.");
            return;
        }

        BookNode temp = tail;
        while (temp != null)
        {
            temp.Data.Display();
            temp = temp.Prev;
        }
    }

    // Count Total Books
    public void CountBooks()
    {
        int count = 0;
        BookNode temp = head;

        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }

        Console.WriteLine($"Total number of books: {count}");
    }
}

class LibraryManagementApp
{
    static void Main()
    {
        LibraryDoublyLinkedList library = new LibraryDoublyLinkedList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Library Management System ---");
            Console.WriteLine("1. Add Book at Beginning");
            Console.WriteLine("2. Add Book at End");
            Console.WriteLine("3. Add Book at Position");
            Console.WriteLine("4. Remove Book by ID");
            Console.WriteLine("5. Search Book by Title");
            Console.WriteLine("6. Search Book by Author");
            Console.WriteLine("7. Update Availability Status");
            Console.WriteLine("8. Display Books Forward");
            Console.WriteLine("9. Display Books Reverse");
            Console.WriteLine("10. Count Total Books");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                case 2:
                case 3:
                    BookRecord book = new BookRecord();

                    Console.Write("Book ID: ");
                    book.BookId = int.Parse(Console.ReadLine());
                    Console.Write("Title: ");
                    book.Title = Console.ReadLine();
                    Console.Write("Author: ");
                    book.Author = Console.ReadLine();
                    Console.Write("Genre: ");
                    book.Genre = Console.ReadLine();
                    Console.Write("Is Available (true/false): ");
                    book.IsAvailable = bool.Parse(Console.ReadLine());

                    if (choice == 1)
                        library.AddAtBeginning(book);
                    else if (choice == 2)
                        library.AddAtEnd(book);
                    else
                    {
                        Console.Write("Position: ");
                        library.AddAtPosition(book, int.Parse(Console.ReadLine()));
                    }
                    break;

                case 4:
                    Console.Write("Enter Book ID: ");
                    library.RemoveByBookId(int.Parse(Console.ReadLine()));
                    break;

                case 5:
                    Console.Write("Enter Book Title: ");
                    library.SearchByTitle(Console.ReadLine());
                    break;

                case 6:
                    Console.Write("Enter Author Name: ");
                    library.SearchByAuthor(Console.ReadLine());
                    break;

                case 7:
                    Console.Write("Enter Book ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Is Available (true/false): ");
                    bool status = bool.Parse(Console.ReadLine());
                    library.UpdateAvailability(id, status);
                    break;

                case 8:
                    library.DisplayForward();
                    break;

                case 9:
                    library.DisplayReverse();
                    break;

                case 10:
                    library.CountBooks();
                    break;

                case 0:
                    Console.WriteLine("Exiting Library Management System...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 0);
    }
}
