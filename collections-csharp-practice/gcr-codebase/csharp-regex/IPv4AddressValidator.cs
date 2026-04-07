using System;
using System.Text.RegularExpressions;

class IPv4AddressValidator
{
    static void Main()
    {
        string[] ipAddresses =
        {
            "192.168.1.1",
            "255.255.255.0",
            "256.1.1.1",
            "192.168.01.1",
            "10.0.0.5"
        };

        string pattern =
            @"^(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)){3}$";

        foreach (string ip in ipAddresses)
        {
            if (Regex.IsMatch(ip, pattern))
                Console.WriteLine($"{ip} → Valid");
            else
                Console.WriteLine($"{ip} → Invalid");
        }
    }
}
