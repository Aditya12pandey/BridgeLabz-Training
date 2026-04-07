using System;

class BankAccount
{
    public int accountNumber;          // Public
    protected string accountHolder;    // Protected
    private double balance;             // Private

    // Constructor
    public BankAccount(int accountNumber, string accountHolder, double balance)
    {
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this.balance = balance;
    }

    // Getter for balance
    public double GetBalance()
    {
        return balance;
    }

    // Deposit method
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
        else
        {
            Console.WriteLine("Invalid deposit amount");
        }
    }

    // Withdraw method
    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
        }
        else
        {
            Console.WriteLine("Invalid or insufficient balance");
        }
    }
}

// Subclass
class SavingsAccount : BankAccount
{
    public double interestRate;

    public SavingsAccount(int accountNumber, string accountHolder, double balance, double interestRate)
        : base(accountNumber, accountHolder, balance)
    {
        this.interestRate = interestRate;
    }

    // Demonstrating access to public and protected members
    public void DisplaySavingsAccount()
    {
        Console.WriteLine("Savings Account Details:");
        Console.WriteLine("Account Number : " + accountNumber);   // public
        Console.WriteLine("Account Holder : " + accountHolder);   // protected
        Console.WriteLine("Balance        : " + GetBalance());    // private via getter
        Console.WriteLine("Interest Rate  : " + interestRate + "%");
    }
}

class Program
{
    public static void Main()
    {
        BankAccount acc = new BankAccount(1001, "Aditya", 5000);
        acc.Deposit(2000);
        acc.Withdraw(1500);

        Console.WriteLine("Current Balance: " + acc.GetBalance());
        Console.WriteLine();

        SavingsAccount sa = new SavingsAccount(2001, "Rahul", 10000, 4.5);
        sa.DisplaySavingsAccount();
    }
}
