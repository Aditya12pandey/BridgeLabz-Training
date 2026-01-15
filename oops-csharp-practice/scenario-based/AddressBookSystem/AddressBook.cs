using System;

namespace AddressBookSystem
{
    public class AddressBook
    {
        private Contact[] contacts;
        private int count = 0;

        public AddressBook(int size)
        {
            contacts = new Contact[size];
        }

        public void AddContact()
        {
            if (count >= contacts.Length)
            {
                Console.WriteLine("❌ Address Book is Full! Cannot add more contacts.");
                return;
            }

            Console.WriteLine("\n✅ Enter Contact Details:");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("State: ");
            string state = Console.ReadLine();

            Console.Write("Zip: ");
            string zip = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phone, email);

            contacts[count] = newContact;
            count++;

            Console.WriteLine("\n✅ Contact Added Successfully!");
        }

        public void DisplayAllContacts()
        {
            if (count == 0)
            {
                Console.WriteLine("\n❌ No contacts available.");
                return;
            }

            Console.WriteLine("\n📌 All Contacts:");

            for (int i = 0; i < count; i++)
            {
                contacts[i].Display();
            }
        }
    }
}
