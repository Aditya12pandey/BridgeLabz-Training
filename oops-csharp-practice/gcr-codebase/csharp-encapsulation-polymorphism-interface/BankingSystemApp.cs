using System;
using System.Collections.Generic;

namespace BankingSystem
{
    // Interface for Loan Facility
    interface ILoanable
    {
        void ApplyForLoan(double amount);
        double CalculateLoanEligibility();
    }

    // Abstract Bank Account class
    abstract class BankAccount
    {
        // Encapsulated fields
        private string accountNumber;
        private string holderName;
        protected double balance;

        // Properties (controlled access)
        public string AccountNumber
        {
            get { return accountNumber; }
            private set { accountNumber = value; }
        }

        public string HolderName
        {
            get { return holderName; }
            private set { holderName = value; }
        }

        public double Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        // Constructor
        public BankAccount(string accNo, string name, double initialBalance)
        {
            accountNumber = accNo;
            holderName = name;
            balance = initialBalance;
        }

        // Common methods
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("Amount Deposited: " + amount);
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("Amount Withdrawn: " + amount);
            }
            else
            {
                Console.WriteLine("Insufficient Balance or Invalid Amount");
            }
        }

        // Abstract method
        public abstract double CalculateInterest();

        // Display method (polymorphism)
        public virtual void DisplayAccountDetails()
        {
            Console.WriteLine("Account Number : " + AccountNumber);
            Console.WriteLine("Account Holder : " + HolderName);
            Console.WriteLine("Balance        : " + Balance);
            Console.WriteLine("Interest       : " + CalculateInterest());
            Console.WriteLine("-----------------------------------");
        }
    }

    // Savings Account
    class SavingsAccount : BankAccount, ILoanable
    {
        public SavingsAccount(string accNo, string name, double balance)
            : base(accNo, name, balance) { }

        public override double CalculateInterest()
        {
            return balance * 0.04; // 4% interest
        }

        public void ApplyForLoan(double amount)
        {
            Console.WriteLine("Loan Application Submitted for Savings Account");
        }

        public double CalculateLoanEligibility()
        {
            return balance * 5; // 5 times balance
        }
    }

    // Current Account
    class CurrentAccount : BankAccount, ILoanable
    {
        public CurrentAccount(string accNo, string name, double balance)
            : base(accNo, name, balance) { }

        public override double CalculateInterest()
        {
            return balance * 0.01; // 1% interest
        }

        public void ApplyForLoan(double amount)
        {
            Console.WriteLine("Loan Application Submitted for Current Account");
        }

        public double CalculateLoanEligibility()
        {
            return balance * 10; // higher eligibility
        }
    }

    // Main Application Class
    class BankingSystemApp
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>
            {
                new SavingsAccount("SB1001", "Rahul", 50000),
                new CurrentAccount("CA2001", "Anita", 100000)
            };

            // Common operations
            accounts[0].Deposit(5000);
            accounts[1].Withdraw(20000);

            // Polymorphism demonstration
            foreach (BankAccount account in accounts)
            {
                account.DisplayAccountDetails();
            }

            Console.ReadLine();
        }
    }
}
