using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    // Interface for Reservation
    interface IReservable
    {
        void ReserveItem(string borrowerName);
        bool CheckAvailability();
    }

    // Abstract Library Item class
    abstract class LibraryItem
    {
        // Encapsulated fields
        private int itemId;
        private string title;
        private string author;

        // Sensitive borrower data (restricted access)
        private string borrowerName;
        protected bool isAvailable = true;

        // Properties
        public int ItemId
        {
            get { return itemId; }
            private set { itemId = value; }
        }

        public string Title
        {
            get { return title; }
            private set { title = value; }
        }

        public string Author
        {
            get { return author; }
            private set { author = value; }
        }

        // Constructor
        public LibraryItem(int id, string title, string author)
        {
            itemId = id;
            this.title = title;
            this.author = author;
        }

        // Abstract method
        public abstract int GetLoanDuration();

        // Concrete method
        public void GetItemDetails()
        {
            Console.WriteLine("Item ID       : " + ItemId);
            Console.WriteLine("Title         : " + Title);
            Console.WriteLine("Author        : " + Author);
            Console.WriteLine("Loan Duration : " + GetLoanDuration() + " days");
            Console.WriteLine("Available     : " + (isAvailable ? "Yes" : "No"));
            Console.WriteLine("------------------------------------");
        }

        // Protected method to set borrower securely
        protected void SetBorrower(string name)
        {
            borrowerName = name;
            isAvailable = false;
        }
    }

    // Book class
    class Book : LibraryItem, IReservable
    {
        public Book(int id, string title, string author)
            : base(id, title, author) { }

        public override int GetLoanDuration()
        {
            return 14; // 2 weeks
        }

        public void ReserveItem(string borrowerName)
        {
            if (isAvailable)
            {
                SetBorrower(borrowerName);
                Console.WriteLine("Book reserved successfully.");
            }
            else
            {
                Console.WriteLine("Book is already reserved.");
            }
        }

        public bool CheckAvailability()
        {
            return isAvailable;
        }
    }

    // Magazine class
    class Magazine : LibraryItem, IReservable
    {
        public Magazine(int id, string title, string author)
            : base(id, title, author) { }

        public override int GetLoanDuration()
        {
            return 7; // 1 week
        }

        public void ReserveItem(string borrowerName)
        {
            if (isAvailable)
            {
                SetBorrower(borrowerName);
                Console.WriteLine("Magazine reserved successfully.");
            }
            else
            {
                Console.WriteLine("Magazine is already reserved.");
            }
        }

        public bool CheckAvailability()
        {
            return isAvailable;
        }
    }

    // DVD class
    class DVD : LibraryItem, IReservable
    {
        public DVD(int id, string title, string author)
            : base(id, title, author) { }

        public override int GetLoanDuration()
        {
            return 3; // 3 days
        }

        public void ReserveItem(string borrowerName)
        {
            if (isAvailable)
            {
                SetBorrower(borrowerName);
                Console.WriteLine("DVD reserved successfully.");
            }
            else
            {
                Console.WriteLine("DVD is already reserved.");
            }
        }

        public bool CheckAvailability()
        {
            return isAvailable;
        }
    }

    // Main Application Class
    class LibraryManagementSystemApp
    {
        static void Main(string[] args)
        {
            List<LibraryItem> items = new List<LibraryItem>
            {
                new Book(1, "Clean Code", "Robert C. Martin"),
                new Magazine(2, "National Geographic", "NG Team"),
                new DVD(3, "Inception", "Christopher Nolan")
            };

            // Reserve one item
            ((IReservable)items[0]).ReserveItem("Aditya");

            // Polymorphism demonstration
            foreach (LibraryItem item in items)
            {
                item.GetItemDetails();
            }

            Console.ReadLine();
        }
    }
}
