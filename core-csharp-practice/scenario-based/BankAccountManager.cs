using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BridgeLabzTraning.ScenarioBased
{
    internal class Bank
    {
        public int AccountNumber;
        public double Balance;
        public double MinimumBalance = 2000;

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount.");
            }
            else
            {
                Balance = Balance + amount;
                Console.WriteLine("Deposit successful.");
                Console.WriteLine("Updated Balance: " + Balance);
            }
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount.");
            }
            else if ((Balance - amount) < MinimumBalance)
            {
                Console.WriteLine("Withdrawal denied!");
                Console.WriteLine("Minimum balance of 2000 must be maintained.");
                Console.WriteLine("Current Balance: " + Balance);
            }
            else
            {
                Balance = Balance - amount;
                Console.WriteLine("Withdrawal successful.");
                Console.WriteLine("Updated Balance: " + Balance);
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine("Current Balance: " + Balance);
        }
    }

    // -------------------- User Class --------------------
    class User
    {
        public void DepositMoney(Bank bank)
        {
            Console.Write("Enter amount to deposit: ");
            double amount = double.Parse(Console.ReadLine());
            bank.Deposit(amount);
        }

        public void WithdrawMoney(Bank bank)
        {
            Console.Write("Enter amount to withdraw: ");
            double amount = double.Parse(Console.ReadLine());
            bank.Withdraw(amount);
        }

        public void ViewBalance(Bank bank)
        {
            bank.CheckBalance();
        }
    }

    // -------------------- Admin Class --------------------
    class Admin
    {
        public static void Main()
        {
            // Step 1: Create Account
            Bank bank = new Bank();
            bank.AccountNumber = 101;
            bank.Balance = 5000;

            Console.WriteLine("Account Created Successfully");
            Console.WriteLine("Account Number: " + bank.AccountNumber);
            Console.WriteLine("Initial Balance: " + bank.Balance);
            Console.WriteLine("Minimum Balance Required: 2000");
            Console.WriteLine("--------------------------------");

            User user = new User();
            int choice;

            // Step 2: Menu-driven operations
            do
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        user.DepositMoney(bank);
                        break;

                    case 2:
                        user.WithdrawMoney(bank);
                        break;

                    case 3:
                        user.ViewBalance(bank);
                        break;

                    case 4:
                        Console.WriteLine("Thank you for using the banking system.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (choice != 4);

            Console.WriteLine("--------------------------------");
            ShowAccountDetails(bank);
        }

        public static void ShowAccountDetails(Bank bank)
        {
            Console.WriteLine("Admin View:");
            Console.WriteLine("Account Number: " + bank.AccountNumber);
            Console.WriteLine("Final Balance: " + bank.Balance);
        }
    }
}
