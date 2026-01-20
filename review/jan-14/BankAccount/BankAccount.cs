using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace review
{
    internal class BankAccount: IBankAccount
    {
        
        public string AccountNumber { get; private set; }
        public double Balance { get; private set; }

        public BankAccount(string accountNumber, double initialBalance = 0)
        {
            AccountNumber = accountNumber;

            if (initialBalance < 0)
            {
                Console.WriteLine("Initial balance cannot be negative. Setting balance to 0.");
                Balance = 0;
            }
            else
            {
                Balance = initialBalance;
            }
        }

        

       
        public void deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be greater than 0.");
                return;
            }

            Balance += amount;
            Console.WriteLine($"Deposited ₹{amount}. New Balance: ₹{Balance}");
        }

        public void withdraw (double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withraw amount greate than 0.");
                return;
            }
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient Balnace ");
                return;
            }
            Balance = Balance - amount;
            Console.WriteLine("Amount Withdraw Successfully ");
            Console.WriteLine($"Remaining Balance{Balance} ");

        }
        public double checkBalance()
        {
            return Balance;
        }

    }
}
