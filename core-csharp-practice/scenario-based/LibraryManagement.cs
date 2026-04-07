using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

//This C# program simulates a simple Library Management System using a 2D array to store book details.
//It provides different functionalities based on user roles: user or admin.
//Users can search for books, check availability, or view all books, while admins can add new books or display records.
//The program uses switch-case, loops, and string operations to manage and access library data.


namespace BridgeLabzTraning.ScenarioBased
{
    internal class LibraryManagement
    {
        public static void Main()
        {
            string[,] books2 = {
            { "Harry Potter","JK Rowling","Available" },
            { "The Lord of the Rings","unknown","Not Available" },
            { "Game of Thrones","RR Martin","Available"},
            { "The Hobbit","John Ronald" ,"Available"},
            { "Iron Man","Unknown","NotAvailable"} };
            Console.WriteLine("enter your Code if -Admin and enter name 'user' if -user");
            string code = Console.ReadLine();
            string[,] books = new string[5, 3];
            switch (code)
            {
                case "user":
                    Console.WriteLine("Enter 1,2,3 for the option ");
                    Console.WriteLine(
                        " \n 1. Search books" +
                        " \n 2. check Accessbility" +
                        " \n 3. display all books");
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {

                        case 1:
                            SearchOperation(books2);
                            break;

                        case 2:
                            CheckAccessibiltiy(books2);
                            break;
                        case 3:

                            for (int i = 0; i < 5; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    Console.WriteLine(books2[i, j]);
                                }
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid input");
                            break;


                    }

                    break;

                case "Admin123":
                    Console.WriteLine("Enter 1,2 for the option ");
                    Console.WriteLine(
                        " \n 1. Add books" +
                        " \n 2. display All books");
                    int optionadmin = Convert.ToInt32(Console.ReadLine());

                    switch (optionadmin)
                    {
                        case 1:
                            AddOperation(books);
                            break;

                        case 2:
                            CheckAccessibiltiy(books2);
                            break;
                    }

                    break;

            }



        }
        static void AddOperation(string[,] books)
        {
            Console.WriteLine("Enter the tittle , Writer and Availability of the books");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter the details for book " + (i + 1));
                for (int j = 0; j < 3; j++)
                {
                    books[i, j] = Console.ReadLine();
                }
            }
        }

        static void SearchOperation(string[,] books)
        {
            Console.WriteLine("Enter tittle to search");
            string search = Console.ReadLine().ToLower();
            bool found = false;
            for (int i = 0; i < books.GetLength(0); i++)
            {
                string title = books[i, 0].ToLower();
                if (title.Contains(search))
                {
                    Console.WriteLine("book found: " + books[i, 0] + " by " + books[i, 1]);
                    found = true;
                }

            }
            if (!found)
            {
                Console.WriteLine("Book not found");
            }

        }
        static void CheckAccessibiltiy(string[,] books)
        {
            Console.WriteLine("enter the title");
            string searching = Console.ReadLine().ToLower();

            bool founded = false;

            for (int i = 0; i < books.GetLength(0); i++)
            {
                string title1 = books[i, 0].ToLower();
                if (title1.Contains(searching))
                {
                    Console.WriteLine("book found: " + books[i, 0] + " by " + books[i, 1] + "status " + books[i, 2]);
                    founded = true;
                }

            }
            if (!founded)
            {
                Console.WriteLine("book not found");
            }
        }
    }
}

