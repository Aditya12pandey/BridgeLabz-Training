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

            AddressBookMenu menu = new AddressBookMenu(addressBook);
            menu.Start();
        }
    }
}
