using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.ScenarioBased
{
    class BookBuddy
    {
        private string[] books;
        private int count;

        public BookBuddy(int capacity)
        {
            books = new string[capacity];
            count = 0;
        }

        public void AddBook(string title, string author)
        {
            if (count >= books.Length)
            {
                Console.WriteLine(" Bookshelf is full! Cannot add more books.");
                return;
            }

            books[count] = title + " - " + author;
            count++;

            Console.WriteLine(" Book Added Successfully!");
        }

        public void SortBooksAlphabetically()
        {
            if (count == 0)
            {
                Console.WriteLine(" No books to sort.");
                return;
            }

            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    string title1 = books[j].Split(" - ")[0];
                    string title2 = books[j + 1].Split(" - ")[0];

                    if (string.Compare(title1, title2, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        string temp = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine(" Books Sorted Alphabetically by Title!");
        }

        public void SearchByAuthor(string author)
        {
            bool found = false;
            Console.WriteLine("\n Books by Author: " + author);

            for (int i = 0; i < count; i++)
            {
                string[] parts = books[i].Split(" - ");
                string title = parts[0];
                string bookAuthor = parts[1];

                if (bookAuthor.ToLower().Contains(author.ToLower()))
                {
                    found = true;
                    Console.WriteLine($" {title} (Author: {bookAuthor})");
                }
            }

            if (!found)
            {
                Console.WriteLine(" No books found for this author.");
            }
        }

        public void DisplayAllBooks()
        {
            if (count == 0)
            {
                Console.WriteLine(" No books in your bookshelf.");
                return;
            }

            Console.WriteLine("\n Your Bookshelf:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i]}");
            }
        }
    }
    internal class BookShelf
    {
        static void Main()
        {
            Console.Write("Enter bookshelf capacity: ");
            int capacity = int.Parse(Console.ReadLine());

            BookBuddy buddy = new BookBuddy(capacity);

            while (true)
            {
                Console.WriteLine(" BookBuddy - Digital Bookshelf");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Display All Books");
                Console.WriteLine("3. Sort Books Alphabetically");
                Console.WriteLine("4. Search By Author");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Book Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter Author Name: ");
                        string author = Console.ReadLine();

                        buddy.AddBook(title, author);
                        break;

                    case 2:
                        buddy.DisplayAllBooks();
                        break;

                    case 3:
                        buddy.SortBooksAlphabetically();
                        break;

                    case 4:
                        Console.Write("Enter Author name to search: ");
                        string searchAuthor = Console.ReadLine();

                        buddy.SearchByAuthor(searchAuthor);
                        break;

                    case 5:
                        Console.WriteLine("Thank you for using BookBuddy!");
                        return;

                    default:
                        Console.WriteLine("Please select between 1-5.");
                        break;
                }
            }
        }
    }
}
