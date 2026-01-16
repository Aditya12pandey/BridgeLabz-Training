using System;

namespace AddressBookSystem
{
    public class AddressBook : IAddressBookOperations
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

            //  UC6: Duplicate Check
            for (int i = 0; i < count; i++)
            {
                if (contacts[i].FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    contacts[i].LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\n Duplicate Contact Found!");
                    Console.WriteLine(" This person already exists in Address Book.");
                    return;
                }
            }

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

        //  UC5
        public void AddMultipleContacts()
        {
            Console.Write("\nHow many contacts you want to add? : ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (count >= contacts.Length)
                {
                    Console.WriteLine("\n Address Book is Full! Cannot add more contacts.");
                    break;
                }

                Console.WriteLine($"\n Enter Details for Contact {i} ");
                AddContact();
            }
        }

        //  UC3
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

        // ✅ UC4
        public void DeleteContact()
        {
            if (count == 0)
            {
                Console.WriteLine("\n No contacts available to delete.");
                return;
            }

            Console.Write("\nEnter First Name of contact to delete: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name of contact to delete: ");
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

            for (int i = index; i < count - 1; i++)
            {
                contacts[i] = contacts[i + 1];
            }

            contacts[count - 1] = null;
            count--;

            Console.WriteLine("\n Contact Deleted Successfully!");
        }

        //  Display
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

        //  UC7
        public void SearchPersonByCityOrState()
        {
            if (count == 0)
            {
                Console.WriteLine("\n No contacts available to search.");
                return;
            }

            Console.WriteLine("\n Search Menu (UC7) ");
            Console.WriteLine("1. Search By City");
            Console.WriteLine("2. Search By State");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            bool found = false;

            if (choice == 1)
            {
                Console.Write("Enter City Name to Search: ");
                string cityName = Console.ReadLine();

                Console.WriteLine($"\n Persons found in City: {cityName}\n");

                for (int i = 0; i < count; i++)
                {
                    if (contacts[i].City.Equals(cityName, StringComparison.OrdinalIgnoreCase))
                    {
                        contacts[i].Display();
                        found = true;
                    }
                }
            }
            else if (choice == 2)
            {
                Console.Write("Enter State Name to Search: ");
                string stateName = Console.ReadLine();

                Console.WriteLine($"\n Persons found in State: {stateName}\n");

                for (int i = 0; i < count; i++)
                {
                    if (contacts[i].State.Equals(stateName, StringComparison.OrdinalIgnoreCase))
                    {
                        contacts[i].Display();
                        found = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("\n Invalid Choice!");
                return;
            }

            if (!found)
            {
                Console.WriteLine("\n No person found in given City/State.");
            }
        }
        //  UC8: View Persons by City or State with Count
        public void ViewPersonsByCityOrState()
        {
            if (count == 0)
            {
                Console.WriteLine("\n No contacts available.");
                return;
            }

            Console.WriteLine("\n View Menu (UC8) ");
            Console.WriteLine("1. View By City");
            Console.WriteLine("2. View By State");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            int personCount = 0;

            if (choice == 1)
            {
                Console.Write("Enter City Name: ");
                string cityName = Console.ReadLine();

                Console.WriteLine($"\n Persons in City: {cityName}\n");

                for (int i = 0; i < count; i++)
                {
                    if (contacts[i].City.Equals(cityName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($" {contacts[i].FirstName} {contacts[i].LastName}");
                        personCount++;
                    }
                }

                Console.WriteLine($"\n Total Persons Found in {cityName}: {personCount}");
            }
            else if (choice == 2)
            {
                Console.Write("Enter State Name: ");
                string stateName = Console.ReadLine();

                Console.WriteLine($"\n Persons in State: {stateName}\n");

                for (int i = 0; i < count; i++)
                {
                    if (contacts[i].State.Equals(stateName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($" {contacts[i].FirstName} {contacts[i].LastName}");
                        personCount++;
                    }
                }

                Console.WriteLine($"\n Total Persons Found in {stateName}: {personCount}");
            }
            else
            {
                Console.WriteLine("\n Invalid choice!");
            }

            if (personCount == 0)
            {
                Console.WriteLine("\n No person found in given City/State.");
            }
        }
        // UC9: Count persons by City and State (Summary)
        public void CountPersonsByCityAndState()
        {
            if (count == 0)
            {
                Console.WriteLine("\n No contacts available.");
                return;
            }

            Console.WriteLine("\n Count Menu (UC9) ");
            Console.WriteLine("1. Count By City");
            Console.WriteLine("2. Count By State");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            // temporary arrays to store unique city/state and counts
            string[] keys = new string[count];
            int[] keyCounts = new int[count];
            int uniqueCount = 0;

            if (choice == 1)
            {
                // Count By City
                for (int i = 0; i < count; i++)
                {
                    string city = contacts[i].City;
                    int index = -1;

                    for (int j = 0; j < uniqueCount; j++)
                    {
                        if (keys[j].Equals(city, StringComparison.OrdinalIgnoreCase))
                        {
                            index = j;
                            break;
                        }
                    }

                    if (index == -1)
                    {
                        keys[uniqueCount] = city;
                        keyCounts[uniqueCount] = 1;
                        uniqueCount++;
                    }
                    else
                    {
                        keyCounts[index]++;
                    }
                }

                Console.WriteLine("\n Persons Count By City:");
                for (int i = 0; i < uniqueCount; i++)
                {
                    Console.WriteLine($"{keys[i]} : {keyCounts[i]}");
                }
            }
            else if (choice == 2)
            {
                // Count By State
                for (int i = 0; i < count; i++)
                {
                    string state = contacts[i].State;
                    int index = -1;

                    for (int j = 0; j < uniqueCount; j++)
                    {
                        if (keys[j].Equals(state, StringComparison.OrdinalIgnoreCase))
                        {
                            index = j;
                            break;
                        }
                    }

                    if (index == -1)
                    {
                        keys[uniqueCount] = state;
                        keyCounts[uniqueCount] = 1;
                        uniqueCount++;
                    }
                    else
                    {
                        keyCounts[index]++;
                    }
                }

                Console.WriteLine("\n Persons Count By State:");
                for (int i = 0; i < uniqueCount; i++)
                {
                    Console.WriteLine($"{keys[i]} : {keyCounts[i]}");
                }
            }
            else
            {
                Console.WriteLine("\n Invalid choice!");
            }
        }


    }
}
