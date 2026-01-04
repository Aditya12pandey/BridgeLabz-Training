using System;

class BankAccount
{
    // static variable (shared by all accounts)
    public static string bankName = "State Bank of India";
    private static int totalAccounts = 0;

    // readonly variable (cannot be changed after constructor)
    public readonly int AccountNumber;

    // instance variable
    public string AccountHolderName;

    // Constructor using 'this' keyword
    public BankAccount(int accountNumber, string accountHolderName)
    {
        this.AccountNumber = accountNumber;          // readonly set once
        this.AccountHolderName = accountHolderName;  // using this to resolve ambiguity
        totalAccounts++;
    }

    // Instance method to display details
    public void DisplayAccountDetails()
    {
        Console.WriteLine("Bank Name          : " + bankName);
        Console.WriteLine("Account Number     : " + AccountNumber);
        Console.WriteLine("Account Holder     : " + AccountHolderName);
        Console.WriteLine();
    }

    // static method
    public static void GetTotalAccounts()
    {
        Console.WriteLine("Total Accounts Created: " + totalAccounts);
    }
}

class Program
{
    public static void Main()
    {
        BankAccount acc1 = new BankAccount(101, "Aditya");
        BankAccount acc2 = new BankAccount(102, "Rahul");

        // Using 'is' operator before displaying details
        if (acc1 is BankAccount)
        {
            acc1.DisplayAccountDetails();
        }

        if (acc2 is BankAccount)
        {
            acc2.DisplayAccountDetails();
        }

        // Calling static method
        BankAccount.GetTotalAccounts();
    }
}
