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
                Console.WriteLine(" Address Book is Full! Cannot add more contacts.");
                return;
            }

            Console.WriteLine("\n Enter Contact Details:");

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

            Console.WriteLine("\n Contact Added Successfully!");
        }

        //  UC3: Edit contact using name
        public void EditContact()
        {
            if (count == 0)
            {
                Console.WriteLine("\n No contacts available to edit.");
                return;
            }

            Console.Write("\nEnter First Name of contact to edit: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name of contact to edit: ");
            string lastName = Console.ReadLine();

            int index = -1;

            for (int i = 0; i < count; i++)
            {
                if (contacts[i].FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    contacts[i].LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("\n Contact not found!");
                return;
            }

            Console.WriteLine("\n Contact Found! Current Details:");
            contacts[index].Display();

            Console.WriteLine("\nWhat do you want to edit?");
            Console.WriteLine("1. Address");
            Console.WriteLine("2. City");
            Console.WriteLine("3. State");
            Console.WriteLine("4. Zip");
            Console.WriteLine("5. Phone Number");
            Console.WriteLine("6. Email");
            Console.Write("Enter choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter New Address: ");
                    contacts[index].Address = Console.ReadLine();
                    break;

                case 2:
                    Console.Write("Enter New City: ");
                    contacts[index].City = Console.ReadLine();
                    break;

                case 3:
                    Console.Write("Enter New State: ");
                    contacts[index].State = Console.ReadLine();
                    break;

                case 4:
                    Console.Write("Enter New Zip: ");
                    contacts[index].Zip = Console.ReadLine();
                    break;

                case 5:
                    Console.Write("Enter New Phone Number: ");
                    contacts[index].PhoneNumber = Console.ReadLine();
                    break;

                case 6:
                    Console.Write("Enter New Email: ");
                    contacts[index].Email = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine(" Invalid choice! No changes made.");
                    return;
            }

            Console.WriteLine("\n Contact Updated Successfully! Updated Details:");
            contacts[index].Display();
        }

        public void DisplayAllContacts()
        {
            if (count == 0)
            {
                Console.WriteLine("\n No contacts available.");
                return;
            }

            Console.WriteLine("\n All Contacts:");

            for (int i = 0; i < count; i++)
            {
                contacts[i].Display();
            }
        }
    }
}
