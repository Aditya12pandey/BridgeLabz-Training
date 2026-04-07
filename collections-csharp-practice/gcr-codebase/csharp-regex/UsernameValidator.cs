using System;
using System.Text.RegularExpressions;

class UsernameValidator
{
    static void Main()
    {
        string[] usernames = { "user_123", "123user", "us" };
        string pattern = @"^[A-Za-z][A-Za-z0-9_]{4,14}$";

        foreach (string username in usernames)
        {
            if (Regex.IsMatch(username, pattern))
                Console.WriteLine($"{username} → Valid");
            else
                Console.WriteLine($"{username} → Invalid");
        }
    }
}
