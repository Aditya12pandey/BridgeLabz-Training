using System;
using System.Collections.Generic;

// Bank class (associated with Customer)
class Bank
{
    public string BankName;

    public Bank(string bankName)
    {
        BankName = bankName;
    }

    // Association method
    public void OpenAccount(Customer customer, double initialBalance)
    {
        customer.Balance = initialBalance;
        customer.AssociatedBank = this;

        Console.WriteLine(
            "Account opened for " + customer.CustomerName +
            " in " + BankName +
            " with balance: " + initialBalance
        );
    }
}

// Customer class (associated with Bank)
class Customer
{
    public string CustomerName;
    public double Balance;
    public Bank AssociatedBank;   // Association reference

    public Customer(string customerName)
    {
        CustomerName = customerName;
    }

    // Communication method
    public void ViewBalance()
    {
        if (AssociatedBank != null)
        {
            Console.WriteLine(
                CustomerName + "'s balance in " +
                AssociatedBank.BankName + " is: " + Balance
            );
        }
        else
        {
            Console.WriteLine(CustomerName + " has no bank account.");
        }
    }
}

// Concept-focused main class
class AssociationDemo
{
    static void Main()
    {
        // Independent objects
        Bank bank = new Bank("National Bank");
        Customer customer1 = new Customer("Rahul");
        Customer customer2 = new Customer("Priya");

        // Association created via method calls
        bank.OpenAccount(customer1, 5000);
        bank.OpenAccount(customer2, 10000);

        // Customer interacts with Bank
        customer1.ViewBalance();
        customer2.ViewBalance();
    }
}
