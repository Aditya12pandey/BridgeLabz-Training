using System;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("   Welcome to Address Book Program  ");

            Console.Write("Enter maximum contacts you want to store: ");
            int size = Convert.ToInt32(Console.ReadLine());

            AddressBook addressBook = new AddressBook(size);

            while (true)
            {
                Console.WriteLine("\n MENU ");
                Console.WriteLine("1. Add Contact (UC2)");
                Console.WriteLine("2. Display All Contacts");
                Console.WriteLine("3. Edit Contact (UC3)");
                Console.WriteLine("4. Delete Contact (UC4)");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addressBook.AddContact();
                        break;

                    case 2:
                        addressBook.DisplayAllContacts();
                        break;

                    case 3:
                        addressBook.EditContact();
                        break;

                    case 4:
                        addressBook.DeleteContact();
                        break;

                    case 5:
                        Console.WriteLine("\n Exiting Address Book Program...");
                        return;

                    default:
                        Console.WriteLine("\n Invalid Choice! Please try again.");
                        break;
                }
            }
        }
    }
}
