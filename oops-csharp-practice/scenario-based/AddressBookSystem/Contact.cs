using System;

namespace AddressBookSystem
{
    public class Contact
    {
        // Properties required in UC1
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Constructor
        public Contact(string firstName, string lastName, string address, string city,
                       string state, string zip, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        // Display contact details
        public void Display()
        {
            Console.WriteLine("----- Contact Details -----");
            Console.WriteLine($"Name   : {FirstName} {LastName}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"City   : {City}");
            Console.WriteLine($"State  : {State}");
            Console.WriteLine($"Zip    : {Zip}");
            Console.WriteLine($"Phone  : {PhoneNumber}");
            Console.WriteLine($"Email  : {Email}");
            Console.WriteLine("----------------------------");
        }
    }
}
