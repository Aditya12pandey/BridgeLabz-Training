using System;

namespace AddressBookSystem
{
    public class AddressBookMenu
    {
        private IAddressBookOperations addressBook;

        public AddressBookMenu(IAddressBookOperations addressBook)
        {
            this.addressBook = addressBook;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n MENU ");
                Console.WriteLine("1. Add Contact (UC2 + UC6)");
                Console.WriteLine("2. Display All Contacts");
                Console.WriteLine("3. Edit Contact (UC3)");
                Console.WriteLine("4. Delete Contact (UC4)");
                Console.WriteLine("5. Add Multiple Contacts (UC5)");
                Console.WriteLine("6. Search Person By City/State (UC7)");
                Console.WriteLine("7. Exit");
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
                        addressBook.AddMultipleContacts();
                        break;

                    case 6:
                        addressBook.SearchPersonByCityOrState();
                        break;

                    case 7:
                        Console.WriteLine("\n Exiting Address Book Program...");
                        return;

                    default:
                        Console.WriteLine("\n Invalid Choice! Try again.");
                        break;
                }
            }
        }
    }
}
