using System;
using System.IO;
using System.Text.RegularExpressions;

class ValidateCsvData
{
    static void Main()
    {
        string filePath = "users.csv";

        // Regex patterns
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        string phonePattern = @"^\d{10}$";

        Regex emailRegex = new Regex(emailPattern);
        Regex phoneRegex = new Regex(phonePattern);

        using (StreamReader reader = new StreamReader(filePath))
        {
            // Skip header
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');

                string email = data[2];
                string phone = data[3];

                bool isEmailValid = emailRegex.IsMatch(email);
                bool isPhoneValid = phoneRegex.IsMatch(phone);

                if (!isEmailValid || !isPhoneValid)
                {
                    Console.WriteLine("Invalid Record Found:");
                    Console.WriteLine(line);

                    if (!isEmailValid)
                        Console.WriteLine("Error: Invalid Email Format");

                    if (!isPhoneValid)
                        Console.WriteLine("Error: Phone number must be exactly 10 digits");

                    Console.WriteLine();
                }
            }
        }
    }
}
